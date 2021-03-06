using Dotmim.Sync;
using Dotmim.Sync.SqlServer;
using Dotmim.Sync.Web.Client;
using ISynergy.Framework.Core.Abstractions;
using ISynergy.Framework.Core.Abstractions.Services;
using ISynergy.Framework.Core.Utilities;
using ISynergy.Framework.Core.Validation;
using Microsoft.AspNetCore.SignalR.Client;
using SyncDemoCommon.Abstractions;
using SyncDemoCommon.Messages;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Timer = System.Timers.Timer;

namespace SyncDemoClient.Services
{
    internal class SynchronizationService : ISynchronizationService
    {
        private readonly IContext _context;
        private readonly IMessageService _messageService;
        private readonly Timer _timer;
        private readonly IClientSynchronizationOptions _options;
        private readonly HubConnection _connection;

        private const string DefaultScope = "DefaultScope";

        public SynchronizationService(
            IContext context,
            IMessageService messageService,
            IClientSynchronizationOptions options)
        {
            Argument.IsNotNull(nameof(options), options);

            _context = context;
            _messageService = messageService;
            _options = options;

            _connection = new HubConnectionBuilder()
                .WithUrl($"{_options.Host}/synchronization")
                .WithAutomaticReconnect()
                .Build();

            _timer = new Timer
            {
                Interval = _options.CheckHostInterval.TotalMilliseconds,
                AutoReset = true
            };

            _timer.Elapsed += async (sender, e) =>
            {
                _timer.Stop();

                // Async task that the background worker has to perform.
                // Check if network connection is available or host available.
                // Check if serial number is set correctly.
                if (NetworkInterface.GetIsNetworkAvailable() && NetworkUtility.IsUrlReachable(_options.Host))
                {
                    // create connection to signalR service.
                    // check if signalR service is connected (do nothing, else reconnect)
                    if (!IsConnected)
                        await ConnectAsync();

                    if (IsConnected)
                    {
                        // Tester is online and able to connect.
                        MarkClientOnline();

                        await SynchronizeAsync();
                    }
                    else
                    {
                        MarkClientOffline();
                    }
                }
                else
                {
                    MarkClientOffline();
                }

                _timer.Start();
            };

            _timer.Start();
        }

        private bool IsConnected =>
            _connection.State == HubConnectionState.Connected;

        private Task ConnectAsync()
        {
            Debug.WriteLine("Connecting to synchronization host.");
            return _connection.StartAsync();
        }

        public async Task DisconnectAsync()
        {
            Debug.WriteLine("Disconnecting from synchronization host.");

            if (_connection is not null)
                await _connection.DisposeAsync();
        }

        public async Task SynchronizeAsync()
        {
            if (!_context.IsOffline)
            {
                try
                {
                    Trace.WriteLine($"Synchronization started at {DateTime.Now}");

                    var serverOrchestrator = new WebClientOrchestrator($"{_options.Host}/api/sync");
                    var clientProvider = new SqlSyncChangeTrackingProvider(_options.ConnectionString);

                    var options = new SyncOptions
                    {
                        BatchSize = 1000,
                        DisableConstraintsOnApplyChanges = true
                    };

                    // Creating an agent that will handle all the process
                    var agent = new SyncAgent(clientProvider, serverOrchestrator, options);

                    await agent.LocalOrchestrator.DeprovisionAsync();

                    var schema = await serverOrchestrator.GetSchemaAsync();

                    await agent.LocalOrchestrator.ProvisionAsync(schema, true);

                    // Launch the sync process
                    // This first sync will create all the sync architecture
                    // and will get the server rows
                    await agent.SynchronizeAsync();

                    if (_options.IsMaster)
                    {
                        // Now we can "mark" original clients rows as "to be uploaded"
                        await agent.LocalOrchestrator.UpdateUntrackedRowsAsync();

                        // Then we can make a new synchronize to upload these rows to server
                        // Launch the sync process
                        await agent.SynchronizeAsync();
                    }

                    Trace.WriteLine($"Synchronization completed at {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Synchronization failed at {DateTime.Now}.{Environment.NewLine}{ex.Message}");
                }

            }
            else
            {
                Debug.WriteLine("Tester is unavailable and disconnected.");
            }
        }

        /// <summary>
        /// Marks host as available (online)
        /// - which enables:
        ///   1. CRUD methods
        ///   2. CRUD result code groups.
        ///   3. CRUD result codes.
        /// </summary>
        private void MarkClientOnline()
        {
            // Mark client as online.
            _messageService.Send(new IsOnlineMessage(true));
            Trace.WriteLine("Synchronization service is online.");
        }

        /// <summary>
        /// Marks host as unavailable (offline)
        /// - which disables:
        ///   1. CRUD methods
        ///   2. CRUD result code groups.
        ///   3. CRUD result codes.
        /// </summary>
        private void MarkClientOffline()
        {
            // Mark client as offline.
            _messageService.Send(new IsOnlineMessage(false));
            Trace.WriteLine("Synchronization service is offline.");
        }
    }
}

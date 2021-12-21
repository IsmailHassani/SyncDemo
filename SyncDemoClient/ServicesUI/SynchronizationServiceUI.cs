using Autofac;
using ISynergy.Framework.Core.Abstractions;
using SyncDemoClient.Bootstrapper;
using SyncDemoClient.Services;
using SyncDemoCommon.Abstractions;

namespace SyncDemoClient.ServicesUI
{
    /// <summary>
    /// Synchronization Service UI
    /// </summary>
    public class SynchronizationServiceUI : ISynchronizationServiceUI
    {
        private ISynchronizationService _synchronizationService;
        private readonly IContext _context;
        private readonly IClientSynchronizationOptions _synchronizationOptions;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        public SynchronizationServiceUI(IContext context, IClientSynchronizationOptions options)
        {
            _context = context;
            _synchronizationOptions = options;
        }

        /// <summary>
        /// Initialize method for the synchronization service ui.
        /// </summary>
        /// <param name="context"></param>
        public void InitializeSynchronizationServiceUI()
        {
            using var serviceContainer = new ContainerBootstrapper().Bootstrap(_context, _synchronizationOptions).BeginLifetimeScope();
            _synchronizationService = serviceContainer.Resolve<ISynchronizationService>();
        }

        public Task SynchronizeAsync() => _synchronizationService.SynchronizeAsync();
        public Task DisconnectAsync() => _synchronizationService.DisconnectAsync();
    }
}

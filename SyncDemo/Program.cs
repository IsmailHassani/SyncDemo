using ISynergy.Framework.Core.Abstractions;
using ISynergy.Framework.Core.Services;
using Newtonsoft.Json;
using SyncDemoClient.ServicesUI;
using SyncDemoCommon.Messages;
using SyncDemoCommon.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = Context.GetInstance();
            var syncSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings", $"{nameof(ClientSynchronizationOptions)}.json");

            if (File.Exists(syncSettingsPath) && JsonConvert.DeserializeObject<ClientSynchronizationOptions>(File.ReadAllText(syncSettingsPath)) is ClientSynchronizationOptions options &&
                !string.IsNullOrEmpty(options.Host))
            {
                MessageService.Default.Register<IsOnlineMessage>(null, m => {
                    context.IsOffline = !m.Content;
                    Console.WriteLine("Online state received and set in the application context.");
                });

                var _synchronizationService = new SynchronizationServiceUI(context, options);
                _synchronizationService.InitializeSynchronizationServiceUI();
            }

            Console.Read();
        }
    }
}

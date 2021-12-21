using Autofac;
using ISynergy.Framework.Core.Abstractions;
using ISynergy.Framework.Core.Abstractions.Services;
using ISynergy.Framework.Core.Services;
using SyncDemoClient.Services;
using SyncDemoCommon.Abstractions;
using System.Reflection;

namespace SyncDemoClient.Bootstrapper
{
    public class ContainerBootstrapper
    {
        protected bool IsSynchronizationEnabled = true;

        public IContainer Bootstrap(IContext context, IClientSynchronizationOptions synchronizationOptions)
        {
            var containerBuilder = new ContainerBuilder();

            // Register UI services.
            containerBuilder.Register(c => synchronizationOptions).As<IClientSynchronizationOptions>().SingleInstance();
            containerBuilder.Register(c => context).As<IContext>().SingleInstance();
            containerBuilder.RegisterType<SynchronizationService>().As<ISynchronizationService>().SingleInstance();

            // Register messaging service.
            var messageService = MessageService.Default;
            containerBuilder.Register(c => messageService).As<IMessageService>().SingleInstance();

            var versionService = new VersionService(Assembly.GetAssembly(typeof(ContainerBootstrapper)));
            containerBuilder.Register(c => versionService).As<IVersionService>().SingleInstance();

            return containerBuilder.Build();
        }
    }
}

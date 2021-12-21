using SyncDemoClient.Services;

namespace SyncDemoClient.ServicesUI
{
    public interface ISynchronizationServiceUI : ISynchronizationService
    {
        void InitializeSynchronizationServiceUI();
    }
}
using System.Threading.Tasks;

namespace SyncDemoClient.Services
{
    public interface ISynchronizationService
    {
        Task SynchronizeAsync();
        Task DisconnectAsync();
    }
}

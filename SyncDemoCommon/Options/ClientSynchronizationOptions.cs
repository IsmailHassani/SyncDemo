using SyncDemoCommon.Abstractions;

namespace SyncDemoCommon.Options
{
    /// <summary>
    /// Class that defines synchronization settings.
    /// </summary>
    public class ClientSynchronizationOptions : IClientSynchronizationOptions
    {
        /// <summary>
        /// SignalR channel.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Host name or ip address of the service endpoint.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Interval in which the client checks if host is available.
        /// </summary>
        public TimeSpan CheckHostInterval { get; set; }

        /// <summary>
        /// Gets or sets machine as master.
        /// </summary>
        public bool IsMaster { get; set; }

        /// <summary>
        /// Gets or sets connectionstring for the client sync.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}

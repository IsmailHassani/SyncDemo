namespace SyncDemoCommon.Abstractions
{
    public interface IClientSynchronizationOptions
    {
        /// <summary>
        /// SignalR channel.
        /// </summary>
        string Channel { get; set; }

        /// <summary>
        /// Interval in which the client checks if host is available.
        /// </summary>
        TimeSpan CheckHostInterval { get; set; }

        /// <summary>
        /// Host name or ip address of the service endpoint.
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets machine as master.
        /// </summary>
        bool IsMaster { get; set; }

        /// <summary>
        /// Gets or sets connectionstring for the client sync.
        /// </summary>
        string ConnectionString { get; set; }
    }
}

namespace SyncDemoCommon.Abstractions
{
    /// <summary>
    /// Interface IHubMessage
    /// </summary>
    /// <typeparam name="T">The type of the t entity.</typeparam>
    public interface IHubMessage<T>
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; }
    }
}

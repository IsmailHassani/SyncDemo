using SyncDemoCommon.Abstractions;

namespace SyncDemoCommon.Models
{
    /// <summary>
    /// Class HubMessage.
    /// </summary>
    /// <typeparam name="T">The type of the t entity.</typeparam>
    public class HubMessage<T> : IHubMessage<T> {
        /// <summary>
        /// Initializes a new instance of the <see cref="HubMessage{T}" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public HubMessage(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; }
    }
}

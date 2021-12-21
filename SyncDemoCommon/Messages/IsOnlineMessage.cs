using ISynergy.Framework.Core.Messaging;

namespace SyncDemoCommon.Messages
{
    public class IsOnlineMessage : Message<bool>
    {
        public IsOnlineMessage(bool value)
            : base(value)
        {
        }
    }
}

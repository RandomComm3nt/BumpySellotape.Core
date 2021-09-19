using Sirenix.Utilities;
using System.Collections.Generic;

namespace BumpySellotape.Core.Messaging
{
    public interface IMessageReceiver
    {
        void SendMessage(Message message);
    }

    public static class IMessageReceiverListExtensions
    {
        public static void SendMessage(this IEnumerable<IMessageReceiver> list, Message message)
        {
            list.ForEach(mr => mr.SendMessage(message));
        }
    }
}

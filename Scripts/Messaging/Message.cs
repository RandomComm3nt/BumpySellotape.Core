namespace BumpySellotape.Core.Messaging
{
    public class Message
    {
        public Message(MessageType messageType)
        {
            MessageFilter = new MessageFilter(messageType);
        }

        public MessageFilter MessageFilter { get; private set; }
    }
}

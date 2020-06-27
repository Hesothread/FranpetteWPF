using System;
using System.Collections.Generic;
using System.Linq;

namespace FranpetteLib.MessageProvider
{
    public class MessageProvider : IMessageProvider
    {
        private readonly List<Message> _messages;

        public MessageProvider()
        {
            _messages = new List<Message>();
        }

        public ICollection<Message> Messages => _messages;

        public bool HasError => Messages.Any(x => x.Type == MessageType.Error);

        public void AddException(Exception exception)
        {
            _messages.Add(new Message(MessageType.Error, exception.Message));
        }

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }

        public void Clear()
        {
            _messages.Clear();
        }
    }
}

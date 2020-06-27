using System;
using System.Collections.Generic;

namespace FranpetteLib.MessageProvider
{
    public interface IMessageProvider
    {
        ICollection<Message> Messages { get; }
        bool HasError { get; }
        void AddMessage(Message message);
        void AddException(Exception exception);
        void Clear();
    }

    public class Message
    {
        public Message(MessageType type, string text)
        {
            this.Type = type;
            this.Text = text;
        }
        public MessageType Type { get; }
        public string Text { get; }
        public string TypeDescription
        {
            get
            {
                return this.Type.ToString();
            }
        }
    }

    public enum MessageType
    {
        Error,
        Warning,
        Info,
        Success
    }
}

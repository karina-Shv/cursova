using System;

namespace SocialNetworkApp
{
    public class Message
    {
        public User Sender { get; }
        public User Receiver { get; }
        public string Text { get; }
        public DateTime Timestamp { get; }

        public Message(User sender, User receiver, string text, DateTime timestamp)
        {
            Sender = sender;
            Receiver = receiver;
            Text = text;
            Timestamp = timestamp;
        }
    }
}

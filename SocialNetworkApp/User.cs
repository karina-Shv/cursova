using System;
using System.Collections.Generic;

namespace SocialNetworkApp
{
    public class User
    {
        public string Name { get; }
        public List<User> Friends { get; }
        public List<Message> Inbox { get; }
        public List<Message> Outbox { get; }

        public User(string name)
        {
            Name = name;
            Friends = new List<User>();
            Inbox = new List<Message>();
            Outbox = new List<Message>();
        }

        public void SendFriendRequest(User receiver, SocialNetwork network)
        {
            if (receiver == this || Friends.Contains(receiver))
            {
                Console.WriteLine("Запит не може бути надісланий.");
                return;
            }

            network.Requests.Add(new FriendRequest(this, receiver));
            Console.WriteLine("Запит у друзі надіслано.");
        }

        public void ViewIncomingRequests(SocialNetwork network)
        {
            var requests = network.Requests.FindAll(r => r.Receiver == this && r.Status == RequestStatus.Sent);
            if (requests.Count == 0)
            {
                Console.WriteLine("Немає нових запитів.");
                return;
            }

            foreach (var req in requests)
            {
                Console.WriteLine($"Запит від: {req.Sender.Name}");
                Console.Write("Прийняти (y) / Відхилити (n): ");
                var input = Console.ReadLine();
                if (input == "y")
                {
                    Friends.Add(req.Sender);
                    req.Sender.Friends.Add(this);
                    req.Status = RequestStatus.Accepted;
                    Console.WriteLine("Запит прийнято.");
                }
                else
                {
                    req.Status = RequestStatus.Rejected;
                    Console.WriteLine("Запит відхилено.");
                }
            }
        }

        public void ViewFriends()
        {
            if (Friends.Count == 0)
            {
                Console.WriteLine("У вас немає друзів.");
                return;
            }

            Console.WriteLine("Ваші друзі:");
            foreach (var f in Friends)
                Console.WriteLine($"- {f.Name}");
        }

        public void SendMessage(User receiver, string text)
        {
            if (!Friends.Contains(receiver))
            {
                Console.WriteLine("Повідомлення можна надсилати лише друзям.");
                return;
            }

            var msg = new Message(this, receiver, text, DateTime.Now);
            Outbox.Add(msg);
            receiver.Inbox.Add(msg);
            Console.WriteLine("Повідомлення надіслано.");
        }

        public void ViewMessages()
        {
            if (Inbox.Count == 0)
            {
                Console.WriteLine("Повідомлень немає.");
                return;
            }

            Console.WriteLine("Вхідні повідомлення:");
            foreach (var msg in Inbox)
            {
                Console.WriteLine($"[{msg.Timestamp}] {msg.Sender.Name}: {msg.Text}");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace SocialNetworkApp
{
    public class SocialNetwork
    {
        public List<User> Users { get; }
        public List<FriendRequest> Requests { get; }

        public SocialNetwork()
        {
            Users = new List<User>();
            Requests = new List<FriendRequest>();
        }

        public void CreateUser(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ім’я не може бути порожнім.");
                return;
            }

            if (Users.Exists(u => u.Name == name))
            {
                Console.WriteLine("Користувач з таким ім’ям вже існує.");
                return;
            }

            Users.Add(new User(name));
            Console.WriteLine($"Користувача {name} створено.");
        }


        public void ListUsers()
        {
            if (Users.Count == 0)
            {
                Console.WriteLine("Користувачі відсутні.");
                return;
            }

            Console.WriteLine("Список користувачів:");
            foreach (var u in Users)
                Console.WriteLine($"- {u.Name}");
        }

        public User? FindUserByName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            return Users.Find(u => u.Name == name);
        }
    }
}

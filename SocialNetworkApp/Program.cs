using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();

            while (true)
            {
                Console.WriteLine("\nМЕНЮ");
                Console.WriteLine("1. Зареєструвати користувача");
                Console.WriteLine("2. Переглянути користувачів");
                Console.WriteLine("3. Увійти як користувач");
                Console.WriteLine("0. Вийти");
                Console.Write("Ваш вибір: ");

                string? choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть ім’я користувача: ");
                        string? name = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            network.CreateUser(name);
                        }
                        else
                        {
                            Console.WriteLine("Ім’я не може бути порожнім.");
                        }
                        break;

                    case "2":
                        network.ListUsers();
                        break;

                    case "3":
                        Console.Write("Введіть ім’я користувача: ");
                        string? loginName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(loginName))
                        {
                            Console.WriteLine("Некоректне ім’я користувача.");
                            break;
                        }

                        User? user = network.FindUserByName(loginName);
                        if (user != null)
                        {
                            UserMenu(user, network);
                        }
                        else
                        {
                            Console.WriteLine("Користувача не знайдено.");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        static void UserMenu(User user, SocialNetwork network)
        {
            while (true)
            {
                Console.WriteLine($"\nМеню користувача: {user.Name}");
                Console.WriteLine("1. Надіслати запит у друзі");
                Console.WriteLine("2. Переглянути вхідні запити у друзі");
                Console.WriteLine("3. Переглянути список друзів");
                Console.WriteLine("4. Надіслати повідомлення другу");
                Console.WriteLine("5. Переглянути повідомлення");
                Console.WriteLine("0. Вийти до головного меню");
                Console.Write("Ваш вибір: ");

                string? choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.Write("Кому надіслати запит у друзі? Введіть ім’я: ");
                        string? friendName = Console.ReadLine();
                        User? friend = network.FindUserByName(friendName);
                        if (friend != null)
                        {
                            user.SendFriendRequest(friend, network);
                        }
                        else
                        {
                            Console.WriteLine("Користувача не знайдено.");
                        }
                        break;

                    case "2":
                        user.ViewIncomingRequests(network);
                        break;

                    case "3":
                        user.ViewFriends();
                        break;

                    case "4":
                        Console.Write("Кому написати? Введіть ім’я друга: ");
                        string? target = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(target))
                        {
                            Console.WriteLine("Некоректне ім’я.");
                            break;
                        }
                        User? receiver = network.FindUserByName(target);
                        if (receiver != null)
                        {
                            Console.Write("Введіть повідомлення: ");
                            string? message = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(message))
                            {
                                user.SendMessage(receiver, message);
                            }
                            else
                            {
                                Console.WriteLine("Повідомлення не може бути порожнім.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Користувача не знайдено.");
                        }
                        break;

                    case "5":
                        user.ViewMessages();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }
}

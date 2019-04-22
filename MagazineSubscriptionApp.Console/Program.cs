using MagazineSubscriptionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MagazineSubscriptionApp.Console
{
    class Program
    {
        static void Register()
        {

        }

        static void Subscribe(User client)
        {
            if (client is PublisherWorker)
                return;
            Write("Enter your credit card number: ");
            int creditCard = int.Parse(ReadLine());

            int subscribtionPeriod;
            while (true)
            {

                WriteLine("Choose subscribtion period\n1 - 12 months: 14000 tg\n2 - 24 months: 25000 tg\n3 - 36 months: 35000 tg");
                int answer = int.Parse(ReadLine());


                switch (answer)
                {
                    case 1: subscribtionPeriod = 12; break;
                    case 2: subscribtionPeriod = 24; break;
                    case 3: subscribtionPeriod = 36; break;
                    default:
                        WriteLine("There\'s no such variant");
                        continue;
                }
                break;
            }

            using (var context = new DataContext())
            {
                context.Subscriptions.Add(new Subscription { StartDate = DateTime.Now, Client = client as Client, SubscriptionTerm = subscribtionPeriod });
                context.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            string currentUserStatus;
            while (true)
            {
                WriteLine("Hello there! Who are you? (1 - client, 2 - publisher worker)");
                int answer = int.Parse(ReadLine());
                switch (answer)
                {
                    case 1: currentUserStatus = "client"; break;
                    case 2: currentUserStatus = "publisher worker"; break;
                    default:
                        WriteLine("There\'s no such variant");
                        continue;
                }
                break;
            }

            bool isRegister = true;

            User user = new Client();
            if (currentUserStatus == "publisher worker")
                user = new PublisherWorker();

            if (currentUserStatus == "client")
            {
                while (true)
                {
                    WriteLine("Do you want to register? (1 - yes, 2 - no)");
                    int answer = int.Parse(ReadLine());

                    switch (answer)
                    {
                        case 1: Register(); break;
                        case 2: isRegister = false; break;
                        default:
                            WriteLine("There\'s no such variant");
                            continue;
                    }
                    break;
                }
            }

            if (!isRegister)
            {

            }

            if (currentUserStatus == "client")
            {
                while (true)
                {
                    WriteLine("What do you wanna do?\n1 - Subscribe to a magazine\n2 - Cancel existing subscription\n3 - Exit");
                    int answer = int.Parse(ReadLine());

                    switch (answer)
                    {
                        case 1: Subscribe(user); break;
                        case 2: break;
                        case 3: Environment.Exit(0); break;
                        default:
                            WriteLine("There\'s no such variant");
                            continue;
                    }
                    break;
                }
            }

        }
    }
}

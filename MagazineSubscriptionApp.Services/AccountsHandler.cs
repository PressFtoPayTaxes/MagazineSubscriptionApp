using MagazineSubscriptionApp.Console;
using MagazineSubscriptionApp.Models;

namespace MagazineSubscriptionApp.Services
{
    public class AccountsHandler
    {
        public bool CheckLogin(string userStatus, string login)
        {
            if (userStatus == "client")
                using (var context = new DataContext())
                    foreach (var client in context.Clients)
                        if (client.Account.Login == login)
                            return false;

            if (userStatus == "publisher worker")
                using (var context = new DataContext())
                    foreach (var worker in context.PublisherWorkers)
                        if (worker.Account.Login == login)
                            return false;

            return true;
        }

        public void Registrate(Client client)
        {
            using (var context = new DataContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        public void Registrate(PublisherWorker worker)
        {
            using (var context = new DataContext())
            {
                context.PublisherWorkers.Add(worker);
                context.SaveChanges();
            }
        }

        public User LogIn(string userStatus, string login, string password)
        {
            User user = new Client();
            using (var context = new DataContext())
            {
                if (userStatus == "client")
                {
                    foreach (var client in context.Clients)
                        if (client.Account.Login == login && client.Account.Password == password)
                            user = client;
                }
                else if(userStatus == "publisher worker")
                {
                    foreach (var worker in context.PublisherWorkers)
                        if (worker.Account.Login == login && worker.Account.Password == password)
                            user = worker;
                }
            }
            return user;
        }
    }
}

namespace MagazineSubscriptionApp.Console.Migrations
{
    using MagazineSubscriptionApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MagazineSubscriptionApp.Console.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MagazineSubscriptionApp.Console.DataContext context)
        {
            Account account = new Account()
            {
                Login = "admin",
                Password = "TheHardestPasswordEver"
            };

            PublisherWorker worker = new PublisherWorker
            {
                FullName = "Greg",
                Account = account,
                IsDirector = true
            };

            context.Accounts.AddOrUpdate(account);
            context.PublisherWorkers.AddOrUpdate(worker);
            context.SaveChanges();
        }
    }
}

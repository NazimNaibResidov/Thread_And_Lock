namespace MonyTansfer.Migrations
{
    using MonyTansfer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MonyTansfer.Data.TrasferDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MonyTansfer.Data.TrasferDbContext context)
        {
            if (!context.Accounts.Any())
            {
                Account account = new Account
                {
                    AccoundNumber = "123-123-123",
                    Id = 1,
                    Balance = 1000,
                    IsActive = true
                };
                Account account1 = new Account
                {
                    AccoundNumber = "124-124-124",
                    Id = 1,
                    Balance = 1000,
                    IsActive = true
                };

                context.Accounts.AddOrUpdate(account, account1);
            }
        }
    }
}

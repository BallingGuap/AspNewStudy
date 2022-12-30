namespace AspNewStudy.Migrations
{
    using AspNewStudy.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNewStudy.Models.AccountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AspNewStudy.Models.AccountContext";
        }

        protected override void Seed(AspNewStudy.Models.AccountContext context)
        {
            context.Accounts.Add(new AspNewStudy.Models.Account
            {
                ID = 0,
                FirstName = "Metin",
                LastName = "Sidiropulo",
                EmailD = "EMAIL",
                Gender = "Male",
                Password = "*****",
                CreatedDate = DateTime.Now
            });
            base.Seed(context);
        }
    }
}

namespace AspNewStudy.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class AccountConfiguration : DbMigrationsConfiguration<AspNewStudy.Models.AccountContext>
    {
        public AccountConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNewStudy.Models.AccountContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

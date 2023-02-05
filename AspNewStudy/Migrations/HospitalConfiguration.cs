namespace AspNewStudy.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class HospitalConfiguration : DbMigrationsConfiguration<AspNewStudy.Models.HospitalContext>
    {
        public HospitalConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNewStudy.Models.HospitalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

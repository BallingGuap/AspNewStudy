namespace AspNewStudy.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class HospitalContextConfiguration : DbMigrationsConfiguration<AspNewStudy.Models.HospitalContext>
    {
        public HospitalContextConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AspNewStudy.Models.HospitalContext";
        }

        protected override void Seed(AspNewStudy.Models.HospitalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class HospitalContext :
        DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().
                HasMany(d => d.Doctors).
                WithMany(p => p.Patients).
                Map(t=>t.MapLeftKey("PatientId").
                MapRightKey("DoctorId").
                ToTable("PatientStudent"));

            modelBuilder.Entity<Patient>().Property(Id => Id.account.FirstName);
            modelBuilder.Entity<Patient>().Property(Id => Id.account.LastName);
            modelBuilder.Entity<Patient>().Property(Id => Id.account.Gender);
            modelBuilder.Entity<Patient>().Property(Id => Id.account.CreatedDate);
            modelBuilder.Entity<Patient>().Property(Id => Id.account.EmailD);
            modelBuilder.Entity<Patient>().Property(Id => Id.account.Password);
            modelBuilder.Entity<Patient>().Property(Id => Id.account.ID);


            modelBuilder.Entity<Doctor>().Property(Id => Id.account.FirstName);
            modelBuilder.Entity<Doctor>().Property(Id => Id.account.LastName);
            modelBuilder.Entity<Doctor>().Property(Id => Id.account.Gender);
            modelBuilder.Entity<Doctor>().Property(Id => Id.account.CreatedDate);
            modelBuilder.Entity<Doctor>().Property(Id => Id.account.EmailD);
            modelBuilder.Entity<Doctor>().Property(Id => Id.account.Password);
            modelBuilder.Entity<Doctor>().Property(Id => Id.account.ID);


            base.OnModelCreating(modelBuilder);
        }
    }
}
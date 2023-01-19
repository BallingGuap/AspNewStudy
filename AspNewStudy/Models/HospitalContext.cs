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
            base.OnModelCreating(modelBuilder);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class HospitalDbInitializer :
        DropCreateDatabaseAlways<HospitalContext>
    {
        protected override void Seed(HospitalContext context)
        {
         
            Doctor d1 = new Doctor
            {
                Id = 1,
                account = new Account
                {
                    CreatedDate = DateTime.Now,
                    EmailD = "MAIL",
                    FirstName = "doc",
                    Gender = "male",
                    ID = 7,
                    LastName = "last",
                    Password = "****(*"
                },
            };

            Doctor d2 = new Doctor
            {
                Id = 2,
                account = new Account
                {
                    CreatedDate = DateTime.Now,
                    EmailD = "GMAIL",
                    FirstName = "Martin",
                    Gender = "male",
                    ID = 8,
                    LastName = "sECOND",
                    Password = "***"
                },
            };

            context.Doctors.Add(d1);
            context.Doctors.Add(d2);


            Patient p1 = new Patient
            {
                Id = 1,
                account = new Account
                {
                    CreatedDate = DateTime.Now,
                    EmailD = "DocMail",
                    FirstName = "Vika",
                    Gender = "female",
                    ID = 9,
                    LastName = "Gobina",
                    Password = "***"
                },
                Doctors = { d1, d2 }
            };

            Patient p2 = new Patient
            {
                Id = 1,
                account = new Account
                {
                    CreatedDate = DateTime.Now,
                    EmailD = "NewMail",
                    FirstName = "Georgiy",
                    Gender = "male",
                    ID = 10,
                    LastName = "Chort",
                    Password = "***"
                },
                Doctors = { d2 }
            };

            context.Patients.Add(p1);
            context.Patients.Add(p2);

            base.Seed(context);
        }
    }
}
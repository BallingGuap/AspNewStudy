using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace AspNewStudy.Models
{

    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<AspNewStudy.Models.Patient> Patients { get; set; }
    }
}
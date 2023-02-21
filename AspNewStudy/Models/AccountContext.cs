using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace AspNewStudy.Models
{

    public class AccountContext 
        : DbContext
    {
        public DbSet<Account> Accounts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AccountContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }


    public interface IRepository
    {
        void Save(Account m);
        void Remove(int id);
        IEnumerable<Account> List();
        Account Get(int id);
    }

    public class AccountRepository : 
        IDisposable, 
        IRepository
    {
        private AccountContext db;

        public AccountRepository(AccountContext context)
        {
            db = context;
        }

        public AccountContext Context
        {
            get { return db; }
            set { db = value; }
        }
        public void Save(Account m)
        {
            db.Accounts.Add(m);
            db.SaveChanges();
        }
        public void Remove(int id)
        {
            Account movie = db.Accounts.Find(id);
            db.Accounts.Remove(movie);
            db.SaveChanges();
        }
        public IEnumerable<Account> List()
        {
            return db.Accounts;
        }
        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }


}
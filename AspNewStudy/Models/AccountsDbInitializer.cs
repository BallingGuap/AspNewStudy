using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class AccountsDbInitializer : DropCreateDatabaseAlways<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            context.Accounts.Add(new Account
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

        public void AddSeed(AccountContext context)
        {
            base.Seed(context);
        }

    }
}
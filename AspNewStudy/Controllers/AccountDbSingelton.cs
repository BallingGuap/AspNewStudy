using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNewStudy.Models;

namespace AspNewStudy.Controllers
{
    public class AccountDbSingelton
    { 
        //Недосингелтон, потом исправлю 
        static private AccountContext db = new AccountContext();
        static public AccountContext dbSingl { get => db; }

    }
}
 using AspNewStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNewStudy.Controllers
{
    public class CurrentAccountSingelton
    {
        static private Account login = null;
        static public Account loginSingl 
        { 
            get 
            {
                if (login == null) 
                    throw new NullReferenceException();

                return login; 
            } 
        }
        static public void setCurrLogin(Account lg) =>
            login = lg;
        
    }
}

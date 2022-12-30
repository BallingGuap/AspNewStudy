using AspNewStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        AccountContext context = new AccountContext();
        public ActionResult Index()
        {
            IEnumerable<Account> accounts = context.Accounts;
            ViewBag.Accounts = accounts;
            return View();
        }
    }
}
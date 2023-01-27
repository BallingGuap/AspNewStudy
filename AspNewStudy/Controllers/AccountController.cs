using AspNewStudy.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace AspNewStudy.Controllers
{
  

    public class AccountController : Controller
    {
        // GET: Account


       


        AccountContext context = new AccountContext();
        IEnumerable<Account> accounts = null;

        public AccountController() :
            base() =>
             accounts = context.Accounts;

      
        public ActionResult Index()
        {
            ViewBag.Accounts = accounts;    
            return View();
        }

       
        public ActionResult AccountPagination(int page = 1)
        {
            int pageSize = 2;

            IQueryable<Account> source = context.Accounts;
         
            var count =  source.Count();
            var items = source.OrderBy(acc => acc.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel<Account> viewModel = new IndexViewModel<Account>
            {
                PageViewModel = pageViewModel,
                Objects = items
            };
            return View(viewModel);
        }



        public ActionResult AccountLogin() =>
            View();

        [HttpPost]
        public  ActionResult AccountLogin(Account login)
        {
            Response.Cookies["UserLogin"].Value = "UserLogin";
            Response.Cookies["UserLogin"].Expires = DateTime.Now.AddDays(1);

            if (String.IsNullOrEmpty(login.EmailD) || String.IsNullOrEmpty(login.Password))
            {
                return HttpNotFound("Login email or Password is empty");
            }

            var currLogin = accounts.FirstOrDefault(acc => acc.EmailD == login.EmailD && acc.Password == login.Password);
            


            if (currLogin == default(Account))
            {
                return HttpNotFound("Login email or Password is uncorrect");
            }

            CurrentAccountSingelton.setCurrLogin(currLogin);
            Response.Cookies["UserLogin"]["FirstName"] = currLogin.FirstName;
            Response.Cookies["UserLogin"]["LastName"] = currLogin.LastName;
            Response.Cookies["UserLogin"]["Gender"] = currLogin.Gender;
            Response.Cookies["UserLogin"]["ID"] = currLogin.ID.ToString();
            Response.Cookies["UserLogin"]["Password"] = currLogin.Password;
            Response.Cookies["UserLogin"]["EmailD"] = currLogin.EmailD;
            Response.Cookies["UserLogin"]["CreatedDate"] = currLogin.CreatedDate.ToString();

            return RedirectToAction($"ShowCurrentLogin");

        }

        public string  ShowCurrentLogin()
        {
            return Request.Cookies["UserLogin"]["FirstName"];
        }
          

    }
}
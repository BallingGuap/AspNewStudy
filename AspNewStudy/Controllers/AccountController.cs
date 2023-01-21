using AspNewStudy.Models;
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


       


        AccountContext context = AccountDbSingelton.dbSingl;
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
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Users = items
            };
            return View(viewModel);
        }

    }
}
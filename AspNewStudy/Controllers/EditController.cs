using AspNewStudy.Migrations;
using AspNewStudy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Account = AspNewStudy.Models.Account;

namespace AspNewStudy.Controllers
{
    public class EditController : Controller
    {
        AccountContext context = AccountDbSingelton.dbSingl;

        [HttpGet]
        public ActionResult Edit(int? id)
        {
          
                if (id == null)
                {
                    return HttpNotFound();
                }

                Account account = context.Accounts.Find(id);

                if (account != null)
                {
                    return View(account);
                }

                return HttpNotFound();
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Account account)
        {

            context.Set<Account>().AddOrUpdate(account);
            //context.Entry(account).State = EntityState.Modified;
            context.SaveChanges(); 
            return RedirectToAction("../Account/Index");
        }
    }
}
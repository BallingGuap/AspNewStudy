using AspNewStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Account = AspNewStudy.Models.Account;

namespace AspNewStudy.Controllers
{
    public class DeleteController : Controller
    {
        AccountContext context = AccountDbSingelton.dbSingl;
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Account account = context.Accounts.Find(id);

            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = context.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }

            context.Accounts.Remove(account);
            context.SaveChanges();
            return RedirectToAction("../Account/Index");
        }

    }
}
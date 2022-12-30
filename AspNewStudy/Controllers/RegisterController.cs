﻿using AspNewStudy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AspNewStudy.Controllers
{
    public class RegisterController : Controller
    {
        AccountContext context = AccountDbSingelton.dbSingl;

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public string Register(Account acc)
        {
            var accs = context.Accounts;
            try
            {
                acc.CreatedDate = DateTime.Now;
                acc.ID = accs.Max(b => b.ID) + 1;

                if (String.IsNullOrEmpty(acc.Password) ||
                   String.IsNullOrEmpty(acc.FirstName) ||
                   String.IsNullOrEmpty(acc.LastName) ||
                   String.IsNullOrEmpty(acc.Gender) ||
                   String.IsNullOrEmpty(acc.EmailD))
                {
                    throw new ArgumentNullException();
                }

                context.Accounts.Add(acc);
                context.SaveChanges();
                return "Succes";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNewStudy.Models;

namespace AspNewStudy.Controllers
{
    public class QuestController : Controller
    {
        // GET: Quest
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult StylizedQuest()
        {
            return View(new Quest());
        }
    }
}
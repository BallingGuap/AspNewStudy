using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNewStudy.Models;
using Ninject.Infrastructure.Language;

namespace AspNewStudy.Controllers
{
    public class QuestController : Controller
    {
        QuestContext db = new QuestContext();
        public ActionResult Index()
        {
            var quests = db.Quests.ToEnumerable();
            return View(quests);
        }


        public ActionResult StylizedQuest(int id)
        {
            var quest = db.Quests.First(q => q.Id == id);
            return View(quest);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Controllers
{
    public class InfoController : Controller
    {
        private void SetInfo(string browser, string Uagent, string url, string ip, string referrer)
        {
            ViewBag.browser = browser;
            ViewBag.userAgent = Uagent;
            ViewBag.url = url;
            ViewBag.ip = ip;    
            ViewBag.referrer = referrer;
        }
        public ActionResult UserInfo()
        {
            var req = HttpContext.Request;
            SetInfo(req.Browser.Browser, req.UserAgent, req.RawUrl, req.UserHostAddress,
                HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri);
            return View();
        }
    }
}
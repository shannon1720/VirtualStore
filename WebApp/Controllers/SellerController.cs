using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public class SellerController : Controller
    {
        public ActionResult vWelcomeSeller()
        {
            return View();
        }
        public ActionResult vCreateSeller()
        {
            Session.Add("JasonKey", "JSN__001");
            return View();
        }

        public ActionResult vRetrieveSeller()
        {
            return View();
        }

        public ActionResult vRetrieveSellerPlatform()
        {
            return View();
        }

        public ActionResult vUpdateSeller()
        {
            return View();
        }
    }
}

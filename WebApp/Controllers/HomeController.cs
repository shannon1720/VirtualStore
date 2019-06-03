using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]

    public class HomeController : Controller
    {

        public ActionResult DashboardStore()
        {
            return View();
        }
 
        public ActionResult vBussinesManager()
        {

            return View();
        }

        public ActionResult vRetrieveBussinesManager()
        {

            return View();
        }
        public ActionResult vRetrieveStoreAdministrator()
        {

            return View();
        }
       

        public ActionResult vRetrieveStore()
        {

            return View();
        }


        public ActionResult vCreateShipping ()
        {

            return View();
        }

        public ActionResult vRetrieveShipping()
        {

            return View();
        }


        public ActionResult vUpdateShipping()
        {

            return View();
        }

        public ActionResult vUpdateBussinesManager()
        {

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vCards()
        {
            return View();
        }

        public ActionResult vCreateCategory()
        {
            return View();
        }

        public ActionResult vCreateSeller()
        {
            return View();
        }

        public ActionResult vRetrieveSeller()
        {
            return View();
        }

        public ActionResult vRetrieveCategory()
        {
            return View();
        }


        public ActionResult vWelcomeStore()
        {
            return View();
        }

        public ActionResult vPassword()
        {
            return View();
        }

        public ActionResult vUserCode()
        {
            return View();
        }

    }
}
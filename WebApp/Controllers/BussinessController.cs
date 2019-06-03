using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public class BussinessController : Controller
    {
        // GET: Bussines
        public ActionResult Index()
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

        public ActionResult vUpdateBussinesManager()
        {

            return View();
        }
    }
}
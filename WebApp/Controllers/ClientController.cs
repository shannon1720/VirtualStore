using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult vCreateClient()
        {
            return View();
        }
        public ActionResult vRetrieveClient()
        {
            return View();
        }   

        public ActionResult vUpdateClient()
        {
            return View();
        }

        public ActionResult vCards()
        {
            return View();
        }
        public ActionResult vCreateCart()
        {
            return View();
        }

        public ActionResult vCardsStore()
        {
            return View();
        }

    }
}
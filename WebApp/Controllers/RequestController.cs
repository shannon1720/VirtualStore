using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vCreateRequest()
        {
            return View();
        }

        public ActionResult vRetrieveClientRequest()
        {
            return View();
        }
    }
}
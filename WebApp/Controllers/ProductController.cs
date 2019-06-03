using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult vCreateProduct()
        {
            return View();
        }
        public ActionResult vRetrieveProduct()
        {
            return View();
        }

        public ActionResult vCards()
        {
            return View();
        }

        public ActionResult vUpdateProduct()
        {
            return View();
        }


        public ActionResult vViewProduct()
        {
            return View();
        }
    }
}
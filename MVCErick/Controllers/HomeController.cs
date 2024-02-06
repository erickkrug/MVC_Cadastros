using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCErick.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Formulary()
        {
            ViewBag.Message = "Your Formulary page.";
            return View();
        }

        public ActionResult RegisterUsers()
        {
            ViewBag.Message = "Your user registration page ;3";
            return View();
        }
    }
}
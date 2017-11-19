using Lab20CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab20CoffeeShop.Controllers
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

        public ActionResult Register()
        {
            return View();
        }

        
        public ActionResult Registered(RegistrationForm registrationForm)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View("Register");
            }
        }
    }
}
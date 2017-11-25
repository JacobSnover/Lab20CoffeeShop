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

        public ActionResult Duplicant()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Registered(User registrationForm)
        {

            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
                ORM.Users.Add(registrationForm);
                ORM.SaveChanges();
                ViewBag.FirstName = registrationForm.First_Name;
                return View("Registered");
            }
            else
            {
                return View("Register");
            }
        }

        public ActionResult ItemList()
        {

            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult ItemAdded(Item addItemForm)
        {

            if (ModelState.IsValid)
            {
                
                CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
                ORM.Items.Add(addItemForm);
                ORM.SaveChanges();
                ViewBag.ProdName = addItemForm.ProdName;
                return View("ItemAdded");
            }
            else
            {
                return View("AddItem");
            }

        }

        public ActionResult ListItems()
        {
            return View();
        }

        public ActionResult ListOfItems()
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();

            List<Item> temp = ORM.Items.ToList();

            ViewBag.ItemList = temp;

            return View("ListItems");
        }

        public ActionResult DeleteItem(string ProdName)
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();

            Item output = ORM.Items.Find(ProdName);

            if (output != null)
            {
                ORM.Items.Remove(output);
                ORM.SaveChanges();
            }

            return RedirectToAction("ListOfItems");

        }

        public ActionResult UpdateItem(string ProdName)
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();

            Item output = ORM.Items.Find(ProdName);

            if (output != null)
            {
                ViewBag.output = output;

                return View("UpdateItemForm");

            }
            else
            {
                return RedirectToAction("ListOfItems");
            }
        }

        public ActionResult SaveUpdatedItem(Item UpdatedItem)
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();

            Item output = ORM.Items.Find(UpdatedItem.ProdName);
            output.ProdName = UpdatedItem.ProdName;
            output.ProdDesc = UpdatedItem.ProdDesc;
            output.ProdQuan = UpdatedItem.ProdQuan;
            output.ProdPrice = UpdatedItem.ProdPrice;

            ORM.Entry(output).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();

            return RedirectToAction("ListOfItems");
        }
    }
}
using Lab20CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
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
                User user = ORM.Users.Find(registrationForm.Email);

                if (user != null)
                {
                    return View("Duplicant");
                }
                else
                {
                    ORM.Users.Add(registrationForm);
                    ORM.SaveChanges();
                    ViewBag.FirstName = registrationForm.First_Name;
                    return View("Registered");
                }

            }
            else
            {
                return View("Register");
            }
        }

        public ActionResult ItemList()
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
            List<Item> temp = ORM.Items.ToList();
            ViewBag.ItemList = temp;

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
                Item item = ORM.Items.Find(addItemForm.ProdName);

                if (item != null)
                {
                    return View("Duplicant");
                }
                else
                {

                    ORM.Items.Add(addItemForm);
                    ORM.SaveChanges();
                    ViewBag.ProdName = addItemForm.ProdName;
                    return View("ItemAdded");
                }

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

        public ActionResult Image(string ProdDesc)
        {
           
            if (ProdDesc.ToLower().Contains("Cup".ToLower()))
            {
                ViewBag.MyString = "Cup";
               

                return View();
            }
            else if (ProdDesc.ToLower().Contains("Bean".ToLower()))
            {
                ViewBag.MyString = "Bean";

                return View();
            }

            ViewBag.MyString = "neither";
            return View();
        }

        public ActionResult ListByCategory(string ProdDesc)
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
            List<Item> output = new List<Item>();

            foreach (Item item in ORM.Items.ToList())
            {
                if (item.ProdDesc.ToLower().Contains(ProdDesc.ToLower()))
                {
                    output.Add(item);
                }
            }
            ViewBag.ItemList = output;

            return View("ItemList");
        }

        public ActionResult ListByName(string ProdName)
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
            List<Item> output = new List<Item>();

            foreach (Item item in ORM.Items.ToList())
            {
                if (item.ProdName.ToLower().Contains(ProdName.ToLower()))
                {
                    output.Add(item);
                }
            }
            ViewBag.ItemList = output;

            return View("ItemList");
        }

        public ActionResult AdminListByCategory(string ProdDesc)
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
            List<Item> output = new List<Item>();

            foreach (Item item in ORM.Items.ToList())
            {
                if (item.ProdDesc.ToLower().Contains(ProdDesc.ToLower()))
                {
                    output.Add(item);
                }
            }
            ViewBag.ItemList = output;

            return View("ListItems");
        }

        public ActionResult AdminListByName(string ProdName)
        {
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
            List<Item> output = new List<Item>();

            foreach (Item item in ORM.Items.ToList())
            {
                if (item.ProdName.ToLower().Contains(ProdName.ToLower()))
                {
                    output.Add(item);
                }
            }
            ViewBag.ItemList = output;

            return View("ListItems");
        }
    }
}
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
                CoffeeShopDAL DAL = new CoffeeShopDAL();

                if (user != null)
                {
                    return View("Duplicant");
                }
                else
                {
                    DAL.RegisterUser(registrationForm);
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
            CoffeeShopDAL DAL = new CoffeeShopDAL();
            CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
            ViewBag.ItemList = DAL.ItemList();
        
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
                CoffeeShopDAL DAL = new CoffeeShopDAL();
                CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();
                Item item = ORM.Items.Find(addItemForm.ProdName);

                if (item != null)
                {
                    return View("Duplicant");
                }
                else
                {

                    DAL.ItemAdded(addItemForm);
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
            CoffeeShopDAL DAL = new CoffeeShopDAL();

            ViewBag.ItemList = DAL.ListOfItems();

            return View("ListItems");
        }

        public ActionResult DeleteItem(string ProdName)
        {
            CoffeeShopDAL DAL = new CoffeeShopDAL();

            DAL.DeleteItem(ProdName);
         
            return RedirectToAction("ListOfItems");

        }

        public ActionResult UpdateItem(string ProdName)
        {
            CoffeeShopDAL DAL = new CoffeeShopDAL();

            Item output = DAL.UpdateItem(ProdName);

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
            CoffeeShopDAL DAL = new CoffeeShopDAL();

            Item output = DAL.SaveUpdatedItem(UpdatedItem);

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
            CoffeeShopDAL DAL = new CoffeeShopDAL();
           
            ViewBag.ItemList = DAL.ListByCategory(ProdDesc);

            return View("ItemList");
        }

        public ActionResult ListByName(string ProdName)
        {
            CoffeeShopDAL DAL = new CoffeeShopDAL();

            ViewBag.ItemList = DAL.ListByName(ProdName); ;

            return View("ItemList");
        }

        public ActionResult AdminListByCategory(string ProdDesc)
        {
            CoffeeShopDAL DAL = new CoffeeShopDAL();
           
            ViewBag.ItemList = DAL.AdminListByCategory(ProdDesc);

            return View("ListItems");
        }

        public ActionResult AdminListByName(string ProdName)
        {
            CoffeeShopDAL DAL = new CoffeeShopDAL();
           
            ViewBag.ItemList = DAL.AdminListByName(ProdName);

            return View("ListItems");
        }
    }
}
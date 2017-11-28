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
    public class CoffeeShopDAL
    {
        CoffeeShopDBEntities2 ORM = new CoffeeShopDBEntities2();

        public User RegisterUser(User registrationForm)
        {

            ORM.Users.Add(registrationForm);
            ORM.SaveChanges();

            return registrationForm;

        }

        public List<Item> ItemList()
        {
            List<Item> temp = ORM.Items.ToList();
            return temp;
        }

        public Item ItemAdded(Item addItemForm)
        {
            ORM.Items.Add(addItemForm);
            ORM.SaveChanges();
            return addItemForm;
        }

        public List<Item> ListOfItems()
        {
            List<Item> temp = ORM.Items.ToList();

            return temp;
        }

        public void DeleteItem(string ProdName)
        {
            CoffeeShopDAL DAL = new CoffeeShopDAL();
            Item output = ORM.Items.Find(ProdName);

            if (output != null)
            {
                ORM.Items.Remove(output);
                ORM.SaveChanges();
            }

        }

        public Item UpdateItem(string ProdName)
        {

            Item output = ORM.Items.Find(ProdName);

            return output;
        }

        public Item SaveUpdatedItem(Item UpdatedItem)
        {

            Item output = ORM.Items.Find(UpdatedItem.ProdName);
            output.ProdName = UpdatedItem.ProdName;
            output.ProdDesc = UpdatedItem.ProdDesc;
            output.ProdQuan = UpdatedItem.ProdQuan;
            output.ProdPrice = UpdatedItem.ProdPrice;

            ORM.Entry(output).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return output;
        }

        public List<Item> ListByCategory(string ProdDesc)
        {
            List<Item> output = new List<Item>();

            foreach (Item item in ORM.Items.ToList())
            {
                if (item.ProdDesc.ToLower().Contains(ProdDesc.ToLower()))
                {
                    output.Add(item);
                }
            }
            return output;
        }

        public List<Item> ListByName(string ProdName)
        {
            List<Item> output = new List<Item>();

            foreach (Item item in ORM.Items.ToList())
            {
                if (item.ProdName.ToLower().Contains(ProdName.ToLower()))
                {
                    output.Add(item);
                }
            }
            return output;
        }

        public List<Item> AdminListByCategory(string ProdDesc)
        {

            List<Item> output = new List<Item>();

            foreach (Item item in ORM.Items.ToList())
            {
                if (item.ProdDesc.ToLower().Contains(ProdDesc.ToLower()))
                {
                    output.Add(item);
                }
            }
            return output;
        }

        public List<Item> AdminListByName(string ProdName)
        {
            List<Item> output = new List<Item>();

            foreach (Item item in ORM.Items.ToList())
            {
                if (item.ProdName.ToLower().Contains(ProdName.ToLower()))
                {
                    output.Add(item);
                }
            }
            return output;
        }




    }
}
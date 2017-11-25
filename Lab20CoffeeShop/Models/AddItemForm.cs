using System;
using Lab20CoffeeShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab20CoffeeShop.Models
{
    public class AddItemForm
    {

        public AddItemForm() : this("", "", "", "")
        {
        }

        public AddItemForm(string prodName, string prodDesc, string prodQuan, string prodPrice)
        {
            this.name = prodName;
            this.desc = prodDesc;
            this.quan = prodQuan;
            this.price = prodPrice;
           
        }

        private string name;
        private string desc;
        private string quan;
        private string price;
       

        [Required(ErrorMessage = "Please enter Product Name")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Please between 1 and 60")]
        [RegularExpression("^[A-Za-z0-9 ]$")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "Please between 4 and 60")]
        [RegularExpression("^[A-Za-z.]$", ErrorMessage = "Must be letters")]
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Must be a valid quantity. ")]
        public string Quan
        {
            get { return quan; }
            set { quan = value; }
        }

        [Required]
        [RegularExpression("^[0-9]{10}.[0-9]{10}$", ErrorMessage = "Not a valid price")]
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

      
     
        public Item ToItem(AddItemForm addItemForm)
        {
            AddItemForm item = addItemForm;
            return ToItem(item);

        }
    }
}
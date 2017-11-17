using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab20CoffeeShop.Models
{
    public class RegistrationForm
    {
        public RegistrationForm() : this("", "", "", "", "")
        {
        }

        public RegistrationForm(string firstname, string lastname, string email, string phone, string password)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.phone = phone;
            this.password = password;
        }

        private string firstname;
        private string lastname;
        private string email;
        private string phone;
        private string password;

        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        [Required]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
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

        [Required(ErrorMessage ="Please enter  First Name")]
        [StringLength(60, MinimumLength = 4, ErrorMessage ="Please between 4 and 60")]
        [RegularExpression("^[A-Za-z]$", ErrorMessage ="Must be letters")]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "Please between 4 and 60")]
        [RegularExpression("^[A-Za-z]$", ErrorMessage ="Must be letters")]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage ="Must be a valid email. ")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$",ErrorMessage ="Not a valid phone number")]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        [Required(ErrorMessage ="Please enter a valid password")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
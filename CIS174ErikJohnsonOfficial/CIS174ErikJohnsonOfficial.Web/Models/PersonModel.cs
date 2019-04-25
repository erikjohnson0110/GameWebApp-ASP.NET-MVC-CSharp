using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS174ErikJohnsonOfficial.Web.Models
{
    public class PersonModel
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
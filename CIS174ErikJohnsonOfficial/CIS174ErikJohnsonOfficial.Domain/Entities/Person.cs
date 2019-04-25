using System;
using System.ComponentModel.DataAnnotations;

namespace CIS174ErikJohnsonOfficial.Domain.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(13)]
        public string PhoneNumber { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string Password { get; set; }
    }
}

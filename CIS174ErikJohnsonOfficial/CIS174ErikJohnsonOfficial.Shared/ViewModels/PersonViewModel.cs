using CIS174ErikJohnsonOfficial.Domain.Entities;
using System;

namespace CIS174ErikJohnsonOfficial.Shared.ViewModels
{
    public class PersonViewModel
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

        public PersonViewModel()
        {
        }

        public PersonViewModel(Person person)
        {
            this.DateCreated = person.DateCreated;
            this.Email = person.Email;
            this.FirstName = person.FirstName;
            this.Gender = person.Gender;
            this.LastName = person.LastName;
            this.Password = person.Password;
            this.PersonId = person.PersonId;
            this.PhoneNumber = person.PhoneNumber;
            this.UserName = person.UserName;
        }
    }
}

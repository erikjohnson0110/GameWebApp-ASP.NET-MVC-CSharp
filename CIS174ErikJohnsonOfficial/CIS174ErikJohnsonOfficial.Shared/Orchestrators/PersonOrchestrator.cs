using CIS174ErikJohnsonOfficial.Domain;
using CIS174ErikJohnsonOfficial.Domain.Entities;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System;
using System.Threading.Tasks;

namespace CIS174ErikJohnsonOfficial.Shared.Orchestrators
{
    public class PersonOrchestrator : IPersonOrchestrator
    {
        private readonly DataContext _personContext;

        public PersonOrchestrator(DataContext dc)
        {
            _personContext = dc;
        }

        public PersonViewModel populatePerson(Guid id, string email, string password)
        {
            Person person = _personContext.People.Find(id);

            if (person == null)
            {
                Person addPerson = new Person{
                    PersonId = id,
                    UserName = "",
                    Password = "",
                    FirstName = "",
                    LastName = "",
                    Gender = "",
                    Email = email,
                    PhoneNumber = "",
                    DateCreated = DateTime.Now,
                };
                _personContext.People.Add(addPerson);
                _personContext.SaveChanges();
                PersonViewModel returnNewPerson = new PersonViewModel(addPerson);
                return returnNewPerson;
            }
            else
            {
                PersonViewModel returnCurrentPerson = new PersonViewModel(person);
                return returnCurrentPerson;
            }
        }

        public void addPerson(PersonViewModel person)
        {
            var newPerson = new Person();
            newPerson.FirstName = person.FirstName;
            newPerson.LastName = person.LastName;
            newPerson.Gender = person.Gender;
            newPerson.PhoneNumber = person.PhoneNumber;
            newPerson.Email = person.Email;
            newPerson.PersonId = Guid.NewGuid();
            newPerson.UserName = person.UserName;
            newPerson.Password = person.Password;

            _personContext.People.Add(newPerson);
            _personContext.SaveChangesAsync();
        }

        public async Task<bool> updatePerson(PersonViewModel pvm)
        {
            var updateEntity = await _personContext.People.FindAsync(pvm.PersonId);

            if (updateEntity == null)
            {
                return false;
            }

            updateEntity.UserName = pvm.UserName;
            updateEntity.Password = pvm.Password;
            updateEntity.FirstName = pvm.FirstName;
            updateEntity.LastName = pvm.LastName;
            updateEntity.Gender = pvm.Gender;
            updateEntity.Email = pvm.Email;
            updateEntity.PhoneNumber = pvm.PhoneNumber;

            await _personContext.SaveChangesAsync();

            return true;
        }
    }
}

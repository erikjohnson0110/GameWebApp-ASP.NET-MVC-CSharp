using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces
{
    public interface IPersonOrchestrator
    {
        PersonViewModel populatePerson(Guid id, string email, string password);
        void addPerson(PersonViewModel person);
        Task<bool> updatePerson(PersonViewModel pvm);

    }
}

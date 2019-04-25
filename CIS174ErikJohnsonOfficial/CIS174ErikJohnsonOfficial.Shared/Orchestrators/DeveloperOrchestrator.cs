using CIS174ErikJohnsonOfficial.Domain;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CIS174ErikJohnsonOfficial.Shared.Orchestrators
{
    public class DeveloperOrchestrator : IDeveloperOrchestrator
    {
        private readonly DataContext _developerContext;

        public DeveloperOrchestrator(DataContext dc)
        {
            _developerContext = dc;
        }

        public List<DeveloperViewModel> GetAllDevelopers()
        {
            var developers = _developerContext.Developers.Select(x => new DeveloperViewModel
            {
                Name = x.Name,
                Email = x.Email,
                Role = x.Role
            }).ToList();

            return developers;
        }
    }
}

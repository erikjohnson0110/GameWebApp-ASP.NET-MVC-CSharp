using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces
{
    public interface IDeveloperOrchestrator
    {
        List<DeveloperViewModel> GetAllDevelopers();
    }
}

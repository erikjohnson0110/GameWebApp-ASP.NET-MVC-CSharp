using CIS174ErikJohnsonOfficial.Shared.Orchestrators;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Web.Models;
using System.Web.Mvc;

namespace CIS174ErikJohnsonOfficial.Web.Controllers
{
    public class AboutController : Controller
    {
        private IDeveloperOrchestrator _developerOrchestrator;

        public AboutController(IDeveloperOrchestrator ido)
        {
            _developerOrchestrator = ido;
        }

        // GET: About
        public ActionResult Index()
        {
            DeveloperModel newModel = new DeveloperModel();
            newModel.Developers = _developerOrchestrator.GetAllDevelopers();

            return View(newModel);
        }
    }
}
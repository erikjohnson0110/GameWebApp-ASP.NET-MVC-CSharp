using CIS174ErikJohnsonOfficial.Shared.Orchestrators;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using CIS174ErikJohnsonOfficial.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CIS174ErikJohnsonOfficial.Web.Controllers
{
    public class PersonController : Controller
    {
        private IPersonOrchestrator _personOrchestrator;
        private readonly ApplicationDbContext _userContext = new ApplicationDbContext();

        public PersonController(IPersonOrchestrator ipo)
        {
            _personOrchestrator = ipo;
        }

        // GET: Person
        public ActionResult Index()
        {
            PersonViewModel pvm = new PersonViewModel();

            if (User.Identity.IsAuthenticated)
            {
                var user = _userContext.Users.Find(IdentityExtensions.GetUserId<String>(User.Identity));
                pvm = _personOrchestrator.populatePerson(Guid.Parse(user.Id), user.Email, user.PasswordHash);
            }

            return View(pvm);
        }

        [HttpGet]
        public async Task<JsonResult> UpdateUser(PersonViewModel user)
        {
            if (user.PersonId == Guid.Empty)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var result = await _personOrchestrator.updatePerson(user);

            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}
using CIS174ErikJohnsonOfficial.Shared.Orchestrators;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS174ErikJohnsonOfficial.Web.Controllers
{
    public class ErrorController : Controller
    {
        private IErrorOrchestrator _errorOrchestrator;

        public ErrorController(IErrorOrchestrator ieo)
        {
            _errorOrchestrator = ieo;
        }

        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error(ErrorViewModel evm)
        {

            return View(evm);
        }

        public ActionResult GenerateError()
        {
            try
            {
                throw new OutOfMemoryException();
            }
            catch (OutOfMemoryException ex)
            {
                _errorOrchestrator.newError(ex);
                ErrorViewModel evm = new ErrorViewModel(ex);

                return View("Error", evm);
            }
        }
    }
}
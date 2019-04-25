using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CIS174ErikJohnsonOfficial.Web.Api
{
    public class GameSignInApiController : ApiController
    {
        private IGameSignInOrchestrator _signInOrchestrator;
        private IErrorOrchestrator _errorOrchestrator;

        public GameSignInApiController(IGameSignInOrchestrator so, IErrorOrchestrator eo)
        {
            _signInOrchestrator = so;
            _errorOrchestrator = eo;
        }

        [HttpGet]
        public PersonViewModel signIn(string email, string password)
        {
            try
            {
                var person = _signInOrchestrator.signIn(email, password);
                return person;
            }
            catch (Exception ex)
            {
                _errorOrchestrator.newError(ex);
                return null;
            }
        }
    }
}

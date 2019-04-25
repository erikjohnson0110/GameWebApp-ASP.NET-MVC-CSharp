using CIS174ErikJohnsonOfficial.Shared.Orchestrators;
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
    [Route("api/v1/developers")]
    public class DeveloperApiController : ApiController
    {
        private readonly IDeveloperOrchestrator _developerOrchestrator;

        public DeveloperApiController(IDeveloperOrchestrator idc)
        {
            _developerOrchestrator = idc;
        }

        [HttpGet]
        public List<DeveloperViewModel> GetProjectMembers()
        {
            var developers = _developerOrchestrator.GetAllDevelopers();

            return developers;
        }
    }
}
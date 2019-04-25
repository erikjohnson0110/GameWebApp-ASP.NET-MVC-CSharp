using CIS174ErikJohnsonOfficial.Domain;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174ErikJohnsonOfficial.Shared.Orchestrators
{
    public class GameSignInOrchestrator : IGameSignInOrchestrator
    {
        private readonly DataContext _dataContext;
        private IErrorOrchestrator _errorOrchestrator;

        public GameSignInOrchestrator(DataContext dc, IErrorOrchestrator eo)
        {
            _dataContext = dc;
            _errorOrchestrator = eo;
        }

        public PersonViewModel signIn(string email, string password)
        {
            try
            {
                var player = (from users in _dataContext.People
                              where users.Email == email && users.Password.Equals(password)
                              select new PersonViewModel
                              {
                                  UserName = users.UserName,
                                  Password = users.Password,
                                  Email = users.Email,
                                  FirstName = users.FirstName,
                                  LastName = users.LastName,
                                  DateCreated = users.DateCreated,
                                  Gender = users.Gender,
                                  PersonId = users.PersonId,
                                  PhoneNumber = users.PhoneNumber
                              }).Single();

                return player;
            }
            catch (Exception ex)
            {
                _errorOrchestrator.newError(ex);
                return null;
            }
        }
    }
}

using CIS174ErikJohnsonOfficial.Domain;
using CIS174ErikJohnsonOfficial.Domain.Entities;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using System;

namespace CIS174ErikJohnsonOfficial.Shared.Orchestrators
{

    public class ErrorOrchestrator : IErrorOrchestrator
    {
        private DataContext _errorContext; 
        public ErrorOrchestrator(DataContext dc)
        {
            _errorContext = dc;
        }

        public void newError(Exception ex)
        {
            Error newError = new Error();
            newError.ErrorMessage = ex.Message;
            newError.StackTrace = ex.StackTrace;

            if (ex.InnerException != null)
            {
                newError.InnerExceptions += ex.InnerException.ToString();
                newError.InnerExceptions += ", ";
            }
            _errorContext.Errors.Add(newError);
            _errorContext.SaveChanges();
        }
    }
}

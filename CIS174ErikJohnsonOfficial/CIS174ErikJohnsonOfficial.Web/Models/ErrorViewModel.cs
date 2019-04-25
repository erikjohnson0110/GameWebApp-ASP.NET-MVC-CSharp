using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS174ErikJohnsonOfficial.Web.Models
{
    public class ErrorViewModel
    {
        public string ErrorType { get; set; }

        public ErrorViewModel(Exception ex)
        {
            ErrorType = ex.Message;
        }
    }
}
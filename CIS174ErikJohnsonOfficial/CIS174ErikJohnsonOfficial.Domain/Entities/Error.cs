using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174ErikJohnsonOfficial.Domain.Entities
{
    public class Error
    {
        public Guid ErrorID { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string InnerExceptions { get; set; }

        public Error()
        {
            ErrorID = Guid.NewGuid();
            ErrorDateTime = DateTime.Now;
            ErrorMessage = "";
            StackTrace = "";
            InnerExceptions = "";
        }
    }
}

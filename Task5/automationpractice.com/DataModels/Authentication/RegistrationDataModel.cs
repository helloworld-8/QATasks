using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationpractice.com.DataModels.Authentication
{
    public class RegistrationDataModel
    {
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipPostalCode { get; set; }
        public string State { get; set; }
    }
}

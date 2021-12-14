using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class EmployeeModel
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }    
        public DateTime Birthdate { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Street { get; set; }
        public string Region { get; set; }
        public string HouseNumber { get; set; }
    }
}

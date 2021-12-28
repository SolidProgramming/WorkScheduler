using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Street { get; set; }
        public string Region { get; set; }
        public int HouseNumber { get; set; }
        public bool Active { get; set; }
    }
}

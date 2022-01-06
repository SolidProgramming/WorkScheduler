using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ShiftModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}

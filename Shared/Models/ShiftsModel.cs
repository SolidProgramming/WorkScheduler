using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ShiftsModel
    {
        public List<ShiftModel> Shifts { get; set; }
        public EmployeeModel Employee { get; set; }        
    }
}

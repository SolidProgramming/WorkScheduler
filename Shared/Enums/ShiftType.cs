using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    
    public enum ShiftType
    {
        //These numbers represent the values in the database and need to be
        //adjusted after changes where made in the database
        None = 0,
        Early = 1,
        Late = 2,
        Night = 3,
        Special = 4,
        Vacation = 5
    }
}

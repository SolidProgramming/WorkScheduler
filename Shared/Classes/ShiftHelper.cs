using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Classes
{
    public static class ShiftHelper
    {
        private static Shift Shift { get; set; }

        public static void SetShift(Shift shift)
        {
            Shift = shift;
        }

        public static Shift GetShift()
        {
            return Shift;
        }
    }
}

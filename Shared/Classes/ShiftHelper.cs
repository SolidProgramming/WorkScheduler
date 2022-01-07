using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;
using Shared.Models;

namespace Shared.Classes
{
    public static class ShiftHelper
    {
        private static ShiftModel Shift { get; set; } = new ShiftModel() { Type = ShiftType.None};

        public static void SetShift(ShiftModel shift)
        {
            Shift = shift;
        }

        public static ShiftModel GetShift()
        {
            return Shift;
        }
    }
}

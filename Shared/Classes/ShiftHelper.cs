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
        private static ShiftModel Shift { get; set; }

        public static void SetShift(ShiftModel shift)
        {
            Shift = shift;
        }

        public static ShiftModel GetShift()
        {
            return Shift;
        }

        public static string GetShifName(ShiftType shiftType)
        {
            switch (shiftType)
            {
                case ShiftType.None:
                    return Globals.NoShiftName;
                case ShiftType.Early:
                    return Globals.EarlyShiftName;
                case ShiftType.Late:
                    return Globals.LateShiftName;
                case ShiftType.Night:
                   return Globals.NightShiftName;
                case ShiftType.Special:
                   return Globals.SpecialShiftName;
                case ShiftType.Vacation:
                    return Globals.VacationShiftName;
                default:
                    return Globals.NoShiftName;
            }
        }
    }
}

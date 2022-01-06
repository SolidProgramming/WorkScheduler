using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.Classes
{
    public static class Extensions
    {
        public static Shift ToShift(this ShiftModel shift)
        {
            Shift retShift = new Shift();

            switch (shift.Name)
            {
                case "Frühschicht":
                    retShift.Type = ShiftType.Early;
                    retShift.Color = Globals.EarlyShiftColor;
                    break;
                case "Spätschicht":
                    retShift.Type = ShiftType.Late;
                    retShift.Color = Globals.LateShiftColor;
                    break;
                case "Nachtschicht":
                    retShift.Type = ShiftType.Night;
                    retShift.Color = Globals.NightShiftColor;
                    break;
                case "Sonderschicht":
                    retShift.Type = ShiftType.Special;
                    retShift.Color = Globals.SpecialShiftColor;
                    break;
                case "Urlaub":
                    retShift.Type = ShiftType.Vacation;
                    retShift.Color = Globals.VacationShiftColor;
                    break;
                default:
                    retShift.Type = ShiftType.None;
                    retShift.Color = Globals.NoShiftColor;
                    break;
            }

            return retShift;
        }
    }
}

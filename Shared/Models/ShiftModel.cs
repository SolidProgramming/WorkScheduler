using Shared.Classes;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ShiftModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ShiftType Type { get; set; }
        public string Name { get; set; }
        public Color Color
        {
            get
            {
                return DetermineColor(Type);
            }
            set
            {
                Color = value;
            }
        }
        private Color DetermineColor(ShiftType shiftType)
        {
            switch (shiftType)
            {
                case ShiftType.None:
                    return Globals.NoShiftColor;
                case ShiftType.Early:
                    return Globals.EarlyShiftColor;
                case ShiftType.Late:
                    return Globals.LateShiftColor;
                case ShiftType.Night:
                    return Globals.NightShiftColor;
                case ShiftType.Special:
                    return Globals.SpecialShiftColor;
                case ShiftType.Vacation:
                    return Globals.VacationShiftColor;
                default:
                    return Globals.NoShiftColor;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Classes;
using Shared.Enums;
using System.Reflection;
using Shared.Models;

namespace CustomShiftControl
{
    public partial class CustomShiftControl : UserControl
    {
        public CustomShiftControl(List<ShiftModel> shifts, int column)
        {
            InitializeComponent();

            ShiftLabel.UseCustomBackColor = true;

            if (shifts.Count <= column)
            {
                return;
            }

            SetShift(shifts[column], column);
        }


        private Shift Shift { get; set; }

        public void SetShift(Shift shift)
        {
            Shift = shift;

            SetShiftText();
            SetControlColor();
        }

        public void SetShift(ShiftModel shift, int column)
        {
            Shift = shift.ToShift();

            SetShiftText();
            SetControlColor();
        }


        private void SetShiftText()
        {
            switch (Shift.Type)
            {
                case ShiftType.None:
                    ShiftLabel.Text = "-";
                    break;
                case ShiftType.Early:
                    ShiftLabel.Text = "F";
                    break;
                case ShiftType.Late:
                    ShiftLabel.Text = "S";
                    break;
                case ShiftType.Night:
                    ShiftLabel.Text = "N";
                    break;
                case ShiftType.Special:
                    ShiftLabel.Text = "SO";
                    break;
                case ShiftType.Vacation:
                    ShiftLabel.Text = "U";
                    break;
                default:
                    break;
            }
        }

        private void SetControlColor()
        {
            ShiftLabel.BackColor = Shift.Color;
        }

        private void ShiftLabel_DoubleClick(object sender, EventArgs e)
        {
            SetShift(ShiftHelper.GetShift());
        }

        
    }
}

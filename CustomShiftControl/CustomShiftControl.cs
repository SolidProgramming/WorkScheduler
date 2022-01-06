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

namespace CustomShiftControl
{
    public partial class CustomShiftControl : UserControl
    {
        public CustomShiftControl()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this, new object[] { true });

            ShiftLabel.UseCustomBackColor = true;
        }


        private Shift Shift { get; set; }

        public void SetShift(Shift shift)
        {
            Shift = shift;

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

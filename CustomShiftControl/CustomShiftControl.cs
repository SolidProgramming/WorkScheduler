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
    public partial class ShiftControl : UserControl
    {
        public delegate void OnShiftInsertEvent(int employeeId, ShiftModel shift);
        public event OnShiftInsertEvent OnShiftInsert;

        private int TargetDay = -1;
        private int EmployeeId = -1;
        private int ShiftId = -1;

        public ShiftControl(int employeeId, List<ShiftModel> shifts, int day)
        {
            InitializeComponent();

            ShiftLabel.UseCustomBackColor = true;
            TargetDay = day;
            EmployeeId = employeeId;           

            ShiftModel targetShift = shifts.SingleOrDefault(_ => _.Date.Day == TargetDay);

            if (targetShift is null) return;

            ShiftId = targetShift.Id;
            SetShiftControl(targetShift);
                
        }

        private void SetShiftControl(ShiftModel shift)
        {           
            ShiftLabel.BackColor = shift.Color;            

            switch (shift.Type)
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

        private void ShiftLabel_DoubleClick(object sender, EventArgs e)
        {
            ShiftModel oldshift = ShiftHelper.GetShift();

            if (oldshift == null) return;

            ShiftModel newShift = oldshift;
            newShift.Id = ShiftId;

            newShift.Date = new DateTime(oldshift.Date.Year, oldshift.Date.Month, TargetDay);

            SetShiftControl(newShift);

            OnShiftInsert(EmployeeId, newShift);
        }
    }
}

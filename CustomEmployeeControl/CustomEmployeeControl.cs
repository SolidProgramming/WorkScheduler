using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomShiftControl;
using Shared.Models;
using System.Reflection;
using Shared.Classes;
using Shared.Enums;

namespace CustomEmployeeControl
{
    public partial class EmployeeControl : UserControl
    {
        public delegate void OnEmployeeDoubleClickEvent(EmployeeModel employee);
        public event OnEmployeeDoubleClickEvent OnEmployeeDoubleClick;

        public delegate void OnShiftInsertEvent(ShiftModel shift);
        public event OnShiftInsertEvent OnShiftInsert;

        private EmployeeModel _employee;

        public EmployeeControl(ShiftsModel shift)
        {
            InitializeComponent();

            _employee = shift.Employee;

            lblEmployeeName.Text = $"{shift.Employee.Surname}, {shift.Employee.FirstName.Substring(0, 1)}";

            for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
            {
                ShiftControl shiftControl = new ShiftControl(shift.Shifts, day: i);

                shiftControl.OnShiftInsert += shiftControl_OnShiftInsert;

                tableLayoutPanel1.Controls.Add(shiftControl, i, 0);
            }
        }

        private void shiftControl_OnShiftInsert(ShiftModel shift)
        {
            OnShiftInsert(shift);
        }

        private void lblEmployeeName_DoubleClick(object sender, EventArgs e)
        {
            OnEmployeeDoubleClick(_employee);
        }
    }
}

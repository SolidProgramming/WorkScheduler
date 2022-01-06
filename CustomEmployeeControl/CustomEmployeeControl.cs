﻿using System;
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

namespace CustomEmployeeControl
{
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl(ShiftsModel shift)
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this, new object[] { true });

            lblEmployeeName.Text = $"{shift.Employee.Surname}, {shift.Employee.FirstName.Substring(0, 1)}";

            for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
            {
                Control control = new CustomShiftControl.CustomShiftControl(shift.Shifts, i - 1);

                tableLayoutPanel1.Controls.Add(control, i, 0);
            }
        }

    }
}

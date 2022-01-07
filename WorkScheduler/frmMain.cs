using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Shared.Enums;
using Shared.Classes;
using WorkScheduler.Classes;
using Shared.Models;
using CustomEmployeeControl;
using System.Reflection;

namespace WorkScheduler
{
    public partial class frmMain : MetroForm
    {
        public frmMain()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlShifts, new object[] { true });
            pnlShifts.AutoScroll = false;
            pnlShifts.HorizontalScroll.Enabled = false;
            pnlShifts.HorizontalScroll.Visible = false;
            pnlShifts.HorizontalScroll.Maximum = 0;
            pnlShifts.AutoScroll = true;
        }

        private ShiftModel Shift = new ShiftModel();

        private void frmMain_Shown(object sender, EventArgs e)
        {
            LoadShifts(customMonthCalender1.SelectedMonth);
        }

        private void btnFrühschicht_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Early;            
            ShiftHelper.SetShift(Shift);
        }

        private void btnSpätschicht_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Late;
           
            ShiftHelper.SetShift(Shift);
        }

        private void btnNachschicht_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Night;
            
            ShiftHelper.SetShift(Shift);
        }

        private void btnSonderschicht_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Special;
           
            ShiftHelper.SetShift(Shift);
        }

        private void btnVacation_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Vacation;           
            ShiftHelper.SetShift(Shift);
        }

        private void btnNoShift_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.None;           
            ShiftHelper.SetShift(Shift);
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.ShowDialog();

            LoadShifts(customMonthCalender1.SelectedMonth);
        }

        private void LoadShifts(int month)
        {
            pnlShifts.Controls.Clear();

            List<ShiftsModel> shifts = SQLiteController.LoadEmployeesWithSchedules(month);

            int locationY = 0;

            pnlShifts.SuspendLayout();

            foreach (ShiftsModel shift in shifts)
            {
                EmployeeControl employeeControl = new EmployeeControl(shift)
                {
                    Location = new Point(0, locationY)
                };

                employeeControl.OnEmployeeDoubleClick += EmployeeControl_OnEmployeeDoubleClick;
                employeeControl.OnShiftInsert += EmployeeControl_OnShiftInsert;

                pnlShifts.Controls.Add(employeeControl);

                locationY += 28;
            }

            pnlShifts.ResumeLayout();
        }

        private void EmployeeControl_OnShiftInsert(ShiftModel shift)
        {
            Console.WriteLine(shift.Type.ToString());
        }

        private void EmployeeControl_OnEmployeeDoubleClick(EmployeeModel employee)
        {
            frmEmployee frmEmployee = new frmEmployee(employee);
            frmEmployee.ShowDialog();

            LoadShifts(customMonthCalender1.SelectedMonth);
        }

        private void customMonthCalender1_OnMonthChanged(int month)
        {
            LoadShifts(customMonthCalender1.SelectedMonth);
        }
    }
}

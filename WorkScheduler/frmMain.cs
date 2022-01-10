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

        private void frmMain_Shown(object sender, EventArgs e)
        {
            LoadShifts(monthCalendar.SelectedMonth);
        }

        private void btnFrühschicht_Click(object sender, EventArgs e)
        {            
            ShiftHelper.SetShift(BuildShift(ShiftType.Early));
        }

        private void btnSpätschicht_Click(object sender, EventArgs e)
        {
            ShiftHelper.SetShift(BuildShift(ShiftType.Late));
        }

        private void btnNachschicht_Click(object sender, EventArgs e)
        {
            ShiftHelper.SetShift(BuildShift(ShiftType.Night));
        }

        private void btnSonderschicht_Click(object sender, EventArgs e)
        {
            ShiftHelper.SetShift(BuildShift(ShiftType.Special));
        }

        private void btnVacation_Click(object sender, EventArgs e)
        {
            ShiftHelper.SetShift(BuildShift(ShiftType.Vacation));
        }

        private void btnNoShift_Click(object sender, EventArgs e)
        {
            ShiftHelper.SetShift(BuildShift(ShiftType.None));
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.ShowDialog();

            LoadShifts(monthCalendar.SelectedMonth);
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

        private void EmployeeControl_OnShiftInsert(int employeeId, ShiftModel shift)
        {
            if (shift.Type == ShiftType.None)
            {
                SQLiteController.TryDeleteShift(shift.Id);

                return;
            }

            SQLiteController.TryAddEmployeeShift(employeeId, shift);
        }

        private void EmployeeControl_OnEmployeeDoubleClick(EmployeeModel employee)
        {
            frmEmployee frmEmployee = new frmEmployee(employee);
            frmEmployee.ShowDialog();

            LoadShifts(monthCalendar.SelectedMonth);
        }

        private void customMonthCalender1_OnMonthChanged(int month)
        {
            LoadShifts(monthCalendar.SelectedMonth);

            ShiftModel oldshift = ShiftHelper.GetShift();

            if (oldshift == null) return;

            ShiftModel newShift = oldshift;

            newShift.Date = new DateTime(oldshift.Date.Year, monthCalendar.SelectedMonth, oldshift.Date.Day);

            ShiftHelper.SetShift(newShift);            
        }

        private ShiftModel BuildShift(ShiftType shiftType)
        {
            ShiftModel shift = new ShiftModel
            {
                Type = shiftType,
                Date = monthCalendar.SelectedDate,
                Name = ShiftHelper.GetShifName(shiftType)                
            };

            return shift;
        }
    }
}

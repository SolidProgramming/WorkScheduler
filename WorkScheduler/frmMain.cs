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

namespace WorkScheduler
{
    public partial class frmMain : MetroForm
    {
        public frmMain()
        {
            InitializeComponent();

            pnlShifts.AutoScroll = false;
            pnlShifts.HorizontalScroll.Enabled = false;
            pnlShifts.HorizontalScroll.Visible = false;
            pnlShifts.HorizontalScroll.Maximum = 0;
            pnlShifts.AutoScroll = true;
        }

        private Shift Shift = new Shift();

        private void frmMain_Shown(object sender, EventArgs e)
        {
            List<ShiftModel> shifts = SQLiteController.LoadEmployeesWithSchedules();

            int locationY = 0;

            foreach (ShiftModel shift in shifts)
            {
                EmployeeControl employeeControl = new EmployeeControl(shift);

                employeeControl.Location = new Point(0, locationY);
                pnlShifts.Controls.Add(employeeControl);

                locationY += 28;
            }

        }

        private void btnFrühschicht_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Early;
            Shift.Color = btnFrühschicht.BackColor;
            ShiftHelper.SetShift(Shift);
        }

        private void btnSpätschicht_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Late;
            Shift.Color = btnSpätschicht.BackColor;
            ShiftHelper.SetShift(Shift);
        }

        private void btnNachschicht_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Night;
            Shift.Color = btnNachschicht.BackColor;
            ShiftHelper.SetShift(Shift);
        }

        private void btnSonderschicht_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Special;
            Shift.Color = btnSonderschicht.BackColor;
            ShiftHelper.SetShift(Shift);
        }

        private void btnVacation_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.Vacation;
            Shift.Color = btnVacation.BackColor;
            ShiftHelper.SetShift(Shift);
        }

        private void btnNoShift_Click(object sender, EventArgs e)
        {
            Shift.Type = ShiftType.None;
            Shift.Color = btnNoShift.BackColor;
            ShiftHelper.SetShift(Shift);
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.ShowDialog();
        }
    }
}

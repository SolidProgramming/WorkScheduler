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
using MetroFramework.Controls;
using System.Globalization;
using AutoUpdaterDotNET;

namespace WorkScheduler
{

    //TODO: database backup
    //TODO: Database cleanup
    public partial class frmMain : MetroForm
    {
        private CultureInfo culture = new CultureInfo("de-DE");


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
            LoadShifts();
            LoadDaysPanel();
            AutoUpdater.Start("http://ddns.lucaweidmann.de:8085/workschedulerupdates/latest/update.xml");
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

            LoadShifts();
        }

        private void LoadShifts()
        {
            int year = monthCalendar.SelectedYear;
            int month = monthCalendar.SelectedMonth;

            pnlShifts.Controls.Clear();

            List<ShiftsModel> shifts = SQLiteController.LoadEmployeesWithSchedules(month);

            int locationY = 0;

            pnlShifts.SuspendLayout();

            foreach (ShiftsModel shift in shifts)
            {
                EmployeeControl employeeControl = new EmployeeControl(shift, year, month)
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

        private void LoadDaysPanel()
        {
            int month = monthCalendar.SelectedMonth;
            int year = monthCalendar.SelectedYear;

            int daysInMonth = DateTime.DaysInMonth(year, month);

            List<MetroLabel> daysLabels = new List<MetroLabel>();
            List<MetroLabel> dayNamesLabels = new List<MetroLabel>();

            tlpDays.Controls.Clear();
            tlpDayNames.Controls.Clear();

            for (int i = 1; i <= daysInMonth; i++)
            {
                MetroLabel dayLabel = new MetroLabel()
                {
                    Text = (i).ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    FontWeight = MetroFramework.MetroLabelWeight.Bold,
                    UseCustomBackColor = true,
                    UseCustomForeColor = true,
                    Margin = new Padding(0, 0, 0, 0)
                };
                MetroLabel dayNameLabel = new MetroLabel()
                {                   
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    UseCustomBackColor = true,
                    UseCustomForeColor = true,
                    Margin = new Padding(0, 0, 0, 0)
                };

                DayOfWeek dayOfWeek = new DateTime(year, month, day: i).DayOfWeek;

                if (dayOfWeek is DayOfWeek.Saturday || dayOfWeek is DayOfWeek.Sunday)
                {
                    dayNameLabel.BackColor = Color.LightGray;
                    dayLabel.BackColor = Color.LightGray;
                }

                string dayName = culture.DateTimeFormat.GetShortestDayName(dayOfWeek);

                dayNameLabel.Text = dayName;

                daysLabels.Add(dayLabel);
                dayNamesLabels.Add(dayNameLabel);
            }

            tlpDays.Controls.AddRange(daysLabels.ToArray());
            tlpDayNames.Controls.AddRange(dayNamesLabels.ToArray());

            daysLabels.Clear();
            dayNamesLabels.Clear();
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

            LoadShifts();
        }

        private void customMonthCalender1_OnMonthChanged(int month)
        {
            LoadDaysPanel();
            LoadShifts();

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
            doc.Print();
        }

        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Panel grd = pnlShifts;
            Bitmap bmp = new Bitmap(grd.Width, grd.Height, grd.CreateGraphics());
            grd.DrawToBitmap(bmp, new Rectangle(0, 0, grd.Width, grd.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        }
    }
}

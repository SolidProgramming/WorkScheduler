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


namespace WorkScheduler
{
    public partial class frmMain : MetroForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Shift Shift = new Shift();

        private void frmMain_Shown(object sender, EventArgs e)
        {
            
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
    }
}

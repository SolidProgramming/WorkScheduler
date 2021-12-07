using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMonthCalendar
{
    public partial class CustomMonthCalender : UserControl
    {
        public CustomMonthCalender()
        {
            InitializeComponent();
        }

        public int SelectedMonth = -1;
        public int SelectedYear = -1;
        public DateTime SelectedDate
        {
            get
            {
                return new DateTime(SelectedYear, SelectedMonth, 1);
            }
        }

        [Description("Autoselect current Month")]
        public bool AutoselectMonth { get; set; }

        private void FocusAutoselectedMonth()
        {
            switch (SelectedMonth)
            {
                case 1:
                    btnJanuary.Focus();
                    break;
                case 2:
                    btnFebruary.Focus();
                    break;
                case 3:
                    btnMarch.Focus();
                    break;
                case 4:
                    btnApril.Focus();
                    break;
                case 5:
                    btnMai.Focus();
                    break;
                case 6:
                    btnJune.Focus();
                    break;
                case 7:
                    btnJuly.Focus();
                    break;
                case 8:
                    btnAugust.Focus();
                    break;
                case 9:
                    btnSeptember.Focus();
                    break;
                case 10:
                    btnOctober.Focus();
                    break;
                case 11:
                    btnNovember.Focus();
                    break;
                case 12:
                    btnDecember.Focus();
                    break;
                default:
                    break;
            }
        }

        #region Events
        private void CustomMonthCalender_Load(object sender, EventArgs e)
        {
            SelectedYear = DateTime.Now.Year;

            if (AutoselectMonth)
            {
                SelectedMonth = DateTime.Now.Month;

                FocusAutoselectedMonth();
            }
        }
        private void btnJanuary_Click(object sender, EventArgs e)
        {
            SelectedMonth = 1;
        }
        private void btnFebruary_Click(object sender, EventArgs e)
        {
            SelectedMonth = 2;
        }
        private void btnMarch_Click(object sender, EventArgs e)
        {
            SelectedMonth = 3;
        }
        private void btnApril_Click(object sender, EventArgs e)
        {
            SelectedMonth = 4;
        }
        private void btnMai_Click(object sender, EventArgs e)
        {
            SelectedMonth = 5;
        }
        private void btnJune_Click(object sender, EventArgs e)
        {
            SelectedMonth = 6;
        }
        private void btnJuly_Click(object sender, EventArgs e)
        {
            SelectedMonth = 7;
        }
        private void btnAugust_Click(object sender, EventArgs e)
        {
            SelectedMonth = 8;
        }
        private void btnSeptember_Click(object sender, EventArgs e)
        {
            SelectedMonth = 9;
        }
        private void btnOctober_Click(object sender, EventArgs e)
        {
            SelectedMonth = 10;
        }
        private void btnNovember_Click(object sender, EventArgs e)
        {
            SelectedMonth = 11;
        }
        private void btnDecember_Click(object sender, EventArgs e)
        {
            SelectedMonth = 12;
        }
        private void btnYearIncrease_Click(object sender, EventArgs e)
        {
            SelectedYear++;
            lblYearSelected.Text = SelectedYear.ToString();
        }
        private void btnYearDecrease_Click(object sender, EventArgs e)
        {
            SelectedYear--;
            lblYearSelected.Text = SelectedYear.ToString();
        }
        #endregion
    }
}

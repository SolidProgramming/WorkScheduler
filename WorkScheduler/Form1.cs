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

namespace WorkScheduler
{
    public partial class frmMain : MetroForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(customMonthCalender1.SelectedMonth);
            Console.WriteLine(customMonthCalender1.SelectedYear);
            Console.WriteLine(customMonthCalender1.SelectedDate);
        }
    }
}

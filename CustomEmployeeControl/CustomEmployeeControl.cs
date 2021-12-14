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

namespace CustomEmployeeControl
{
    public partial class CustomEmployeeControl : UserControl
    {
        public CustomEmployeeControl()
        {
            InitializeComponent();

            for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
            {
                Control control = new CustomShiftControl.CustomShiftControl();
               
                tableLayoutPanel1.Controls.Add(control, i, 0);

            }
        }

    }
}

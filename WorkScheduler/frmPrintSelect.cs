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
    public partial class frmPrintSelect : MetroForm
    {
        private Dictionary<string, int> _printers = new Dictionary<string, int>();

        public frmPrintSelect()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Printer = cmbPrinters.SelectedItem.ToString();
        }

        private void frmPrintSelect_Load(object sender, EventArgs e)
        {
            LoadPrinters();
            SetSavedPrinter();
        }

        private void LoadPrinters()
        {
            System.Drawing.Printing.PrinterSettings.StringCollection printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;

            int i = 0;

            foreach (string printerName in printers)
            {
                cmbPrinters.Items.Add(printerName);
                _printers.Add(printerName, i);

                i++;
            }
        }

        private void SetSavedPrinter()
        {
            if (Properties.Settings.Default.Printer != string.Empty)
            {
                if (_printers.ContainsKey(Properties.Settings.Default.Printer))
                {
                    cmbPrinters.SelectedIndex = _printers[Properties.Settings.Default.Printer];
                }
            }
        }
    }
}

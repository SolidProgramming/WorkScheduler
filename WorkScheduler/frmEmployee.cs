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
using Shared.Models;
using WorkScheduler.Classes;

namespace WorkScheduler
{
    public partial class frmEmployee : MetroForm
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeModel employee = new EmployeeModel()
            {
                FirstName = txtbFirstname.Text,
                Surname = txtbSurname.Text,
                Region = txtbArea.Text,
                Street = txtbStreet.Text,
                TelephoneNumber = txtbTelephone.Text,
                MobileNumber = txtbMobile.Text,
                Active = chbActive.Checked
            };

            bool success = SQLiteController.TryAddEmployee(employee);

            if (!success) MessageBox.Show("Konnte nicht gespeichert werden.");

            Close();
        }
    }
}

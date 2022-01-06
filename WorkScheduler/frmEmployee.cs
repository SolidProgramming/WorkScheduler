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
using Shared.Enums;

namespace WorkScheduler
{
    public partial class frmEmployee : MetroForm
    {
        private ControlMode Mode = ControlMode.None;

        private int _EmployeeId = 0;

        public frmEmployee()
        {
            InitializeComponent();
            Mode = ControlMode.Add;
        }

        public frmEmployee(EmployeeModel employee)
        {
            InitializeComponent();
            LoadEmployeeData(employee);
            Mode = ControlMode.Update;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeModel employee = new EmployeeModel()
            {
                Id = _EmployeeId,
                FirstName = txtbFirstname.Text,
                Surname = txtbSurname.Text,
                Region = txtbArea.Text,
                Street = txtbStreet.Text,
                TelephoneNumber = txtbTelephone.Text,
                MobileNumber = txtbMobile.Text,
                Active = chbActive.Checked
            };

            bool success;

            if (Mode == ControlMode.Add)
            {
                success = SQLiteController.TryAddEmployee(employee);
            }else if (Mode == ControlMode.Update)
            {
                success = SQLiteController.TryUpdateEmployee(employee);
            }
            else
            {
                return;
            }

            if (!success) MessageBox.Show("Konnte nicht gespeichert werden.");

            Close();
        }

        private void LoadEmployeeData(EmployeeModel employee)
        {
            _EmployeeId = employee.Id;

            txtbFirstname.Text = employee.FirstName;
            txtbSurname.Text = employee.Surname;
            txtbArea.Text = employee.Region;
            txtbStreet.Text = employee.Street;
            txtbTelephone.Text = employee.TelephoneNumber;
            txtbMobile.Text = employee.MobileNumber;
        }
    }
}

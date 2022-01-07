﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Classes;
using Shared.Enums;
using System.Reflection;
using Shared.Models;

namespace CustomShiftControl
{
    public partial class ShiftControl : UserControl
    {
        public delegate void OnShiftInsertEvent(ShiftModel shift);
        public event OnShiftInsertEvent OnShiftInsert;

        private int TargetDay = -1;

        public ShiftControl(List<ShiftModel> shifts, int day)
        {
            InitializeComponent();

            ShiftLabel.UseCustomBackColor = true;

            if (shifts.Count < day)
            {
                return;
            }

            TargetDay = day;
            SetShiftControl(shifts[TargetDay - 1]);
                
        }

        private void SetShiftControl(ShiftModel shift)
        {           
            ShiftLabel.BackColor = shift.Color;            

            shift.Date.AddDays(TargetDay);            

            switch (shift.Type)
            {
                case ShiftType.None:
                    ShiftLabel.Text = "-";
                    break;
                case ShiftType.Early:
                    ShiftLabel.Text = "F";
                    break;
                case ShiftType.Late:
                    ShiftLabel.Text = "S";
                    break;
                case ShiftType.Night:
                    ShiftLabel.Text = "N";
                    break;
                case ShiftType.Special:
                    ShiftLabel.Text = "SO";
                    break;
                case ShiftType.Vacation:
                    ShiftLabel.Text = "U";
                    break;
                default:
                    break;
            }
        }

        private void ShiftLabel_DoubleClick(object sender, EventArgs e)
        {
            ShiftModel shift = ShiftHelper.GetShift();
            
            SetShiftControl(shift);

            OnShiftInsert(shift);
        }


    }
}

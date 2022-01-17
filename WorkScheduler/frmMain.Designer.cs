namespace WorkScheduler
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnNewEmployee = new MetroFramework.Controls.MetroButton();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton3 = new MetroFramework.Controls.MetroRadioButton();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new MetroFramework.Controls.MetroButton();
            this.btnFrühschicht = new MetroFramework.Controls.MetroButton();
            this.btnSpätschicht = new MetroFramework.Controls.MetroButton();
            this.btnSonderschicht = new MetroFramework.Controls.MetroButton();
            this.btnNachschicht = new MetroFramework.Controls.MetroButton();
            this.btnNoShift = new MetroFramework.Controls.MetroButton();
            this.btnVacation = new MetroFramework.Controls.MetroButton();
            this.pnlShifts = new System.Windows.Forms.Panel();
            this.tlpDays = new System.Windows.Forms.TableLayoutPanel();
            this.monthCalendar = new CustomMonthCalendar.CustomMonthCalender();
            this.tlpDayNames = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnNewEmployee.Location = new System.Drawing.Point(215, 584);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(138, 41);
            this.btnNewEmployee.TabIndex = 8;
            this.btnNewEmployee.Text = "+ Mitarbeiter";
            this.btnNewEmployee.UseSelectable = true;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(19, 48);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(66, 15);
            this.metroRadioButton1.TabIndex = 9;
            this.metroRadioButton1.Text = "Option2";
            this.metroRadioButton1.UseSelectable = true;
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Location = new System.Drawing.Point(19, 27);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(66, 15);
            this.metroRadioButton2.TabIndex = 9;
            this.metroRadioButton2.Text = "Option1";
            this.metroRadioButton2.UseSelectable = true;
            // 
            // metroRadioButton3
            // 
            this.metroRadioButton3.AutoSize = true;
            this.metroRadioButton3.Location = new System.Drawing.Point(19, 69);
            this.metroRadioButton3.Name = "metroRadioButton3";
            this.metroRadioButton3.Size = new System.Drawing.Size(66, 15);
            this.metroRadioButton3.TabIndex = 10;
            this.metroRadioButton3.Text = "Option3";
            this.metroRadioButton3.UseSelectable = true;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Enabled = false;
            this.metroCheckBox1.Location = new System.Drawing.Point(517, 37);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(90, 15);
            this.metroCheckBox1.TabIndex = 11;
            this.metroCheckBox1.Text = "Eigenschaft1";
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Enabled = false;
            this.metroCheckBox2.Location = new System.Drawing.Point(517, 58);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(90, 15);
            this.metroCheckBox2.TabIndex = 12;
            this.metroCheckBox2.Text = "Eigenschaft2";
            this.metroCheckBox2.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroRadioButton3);
            this.groupBox1.Controls.Add(this.metroRadioButton1);
            this.groupBox1.Controls.Add(this.metroRadioButton2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(402, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 102);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optionen";
            // 
            // btnPrint
            // 
            this.btnPrint.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnPrint.Location = new System.Drawing.Point(21, 584);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(138, 41);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "&Drucken";
            this.btnPrint.UseSelectable = true;
            // 
            // btnFrühschicht
            // 
            this.btnFrühschicht.BackColor = System.Drawing.Color.Gold;
            this.btnFrühschicht.Location = new System.Drawing.Point(250, 31);
            this.btnFrühschicht.Name = "btnFrühschicht";
            this.btnFrühschicht.Size = new System.Drawing.Size(70, 28);
            this.btnFrühschicht.TabIndex = 21;
            this.btnFrühschicht.Text = "Früh | F";
            this.btnFrühschicht.UseCustomBackColor = true;
            this.btnFrühschicht.UseCustomForeColor = true;
            this.btnFrühschicht.UseSelectable = true;
            this.btnFrühschicht.Click += new System.EventHandler(this.btnFrühschicht_Click);
            // 
            // btnSpätschicht
            // 
            this.btnSpätschicht.BackColor = System.Drawing.Color.SlateGray;
            this.btnSpätschicht.Location = new System.Drawing.Point(250, 63);
            this.btnSpätschicht.Name = "btnSpätschicht";
            this.btnSpätschicht.Size = new System.Drawing.Size(70, 28);
            this.btnSpätschicht.TabIndex = 22;
            this.btnSpätschicht.Text = "Spät | S";
            this.btnSpätschicht.UseCustomBackColor = true;
            this.btnSpätschicht.UseCustomForeColor = true;
            this.btnSpätschicht.UseSelectable = true;
            this.btnSpätschicht.Click += new System.EventHandler(this.btnSpätschicht_Click);
            // 
            // btnSonderschicht
            // 
            this.btnSonderschicht.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSonderschicht.Location = new System.Drawing.Point(326, 31);
            this.btnSonderschicht.Name = "btnSonderschicht";
            this.btnSonderschicht.Size = new System.Drawing.Size(70, 28);
            this.btnSonderschicht.TabIndex = 23;
            this.btnSonderschicht.Text = "Sonder | SO";
            this.btnSonderschicht.UseCustomBackColor = true;
            this.btnSonderschicht.UseCustomForeColor = true;
            this.btnSonderschicht.UseSelectable = true;
            this.btnSonderschicht.Click += new System.EventHandler(this.btnSonderschicht_Click);
            // 
            // btnNachschicht
            // 
            this.btnNachschicht.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNachschicht.Location = new System.Drawing.Point(250, 97);
            this.btnNachschicht.Name = "btnNachschicht";
            this.btnNachschicht.Size = new System.Drawing.Size(70, 28);
            this.btnNachschicht.TabIndex = 24;
            this.btnNachschicht.Text = "Nacht | N";
            this.btnNachschicht.UseCustomBackColor = true;
            this.btnNachschicht.UseCustomForeColor = true;
            this.btnNachschicht.UseSelectable = true;
            this.btnNachschicht.Click += new System.EventHandler(this.btnNachschicht_Click);
            // 
            // btnNoShift
            // 
            this.btnNoShift.BackColor = System.Drawing.Color.White;
            this.btnNoShift.Location = new System.Drawing.Point(326, 97);
            this.btnNoShift.Name = "btnNoShift";
            this.btnNoShift.Size = new System.Drawing.Size(70, 28);
            this.btnNoShift.TabIndex = 25;
            this.btnNoShift.Text = "Frei | -";
            this.btnNoShift.UseCustomBackColor = true;
            this.btnNoShift.UseCustomForeColor = true;
            this.btnNoShift.UseSelectable = true;
            this.btnNoShift.Click += new System.EventHandler(this.btnNoShift_Click);
            // 
            // btnVacation
            // 
            this.btnVacation.BackColor = System.Drawing.Color.GreenYellow;
            this.btnVacation.Location = new System.Drawing.Point(326, 63);
            this.btnVacation.Name = "btnVacation";
            this.btnVacation.Size = new System.Drawing.Size(70, 28);
            this.btnVacation.TabIndex = 26;
            this.btnVacation.Text = "Urlaub | U";
            this.btnVacation.UseCustomBackColor = true;
            this.btnVacation.UseCustomForeColor = true;
            this.btnVacation.UseSelectable = true;
            this.btnVacation.Click += new System.EventHandler(this.btnVacation_Click);
            // 
            // pnlShifts
            // 
            this.pnlShifts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShifts.Location = new System.Drawing.Point(3, 237);
            this.pnlShifts.Name = "pnlShifts";
            this.pnlShifts.Size = new System.Drawing.Size(1685, 323);
            this.pnlShifts.TabIndex = 27;
            // 
            // tlpDays
            // 
            this.tlpDays.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDays.ColumnCount = 32;
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpDays.Location = new System.Drawing.Point(105, 195);
            this.tlpDays.Name = "tlpDays";
            this.tlpDays.RowCount = 1;
            this.tlpDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDays.Size = new System.Drawing.Size(1583, 22);
            this.tlpDays.TabIndex = 21;
            // 
            // monthCalendar
            // 
            this.monthCalendar.AutoselectMonth = true;
            this.monthCalendar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.monthCalendar.Location = new System.Drawing.Point(-1, 2);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.Size = new System.Drawing.Size(245, 183);
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.OnMonthChanged += new CustomMonthCalendar.CustomMonthCalender.OnMonthChangedEvent(this.customMonthCalender1_OnMonthChanged);
            // 
            // tlpDayNames
            // 
            this.tlpDayNames.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDayNames.ColumnCount = 32;
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDayNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpDayNames.Location = new System.Drawing.Point(105, 216);
            this.tlpDayNames.Name = "tlpDayNames";
            this.tlpDayNames.RowCount = 1;
            this.tlpDayNames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDayNames.Size = new System.Drawing.Size(1583, 22);
            this.tlpDayNames.TabIndex = 28;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1698, 635);
            this.Controls.Add(this.tlpDayNames);
            this.Controls.Add(this.tlpDays);
            this.Controls.Add(this.pnlShifts);
            this.Controls.Add(this.btnVacation);
            this.Controls.Add(this.btnNoShift);
            this.Controls.Add(this.btnNachschicht);
            this.Controls.Add(this.btnSonderschicht);
            this.Controls.Add(this.btnSpätschicht);
            this.Controls.Add(this.btnFrühschicht);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroCheckBox2);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.monthCalendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnNewEmployee;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton3;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton btnPrint;
        private MetroFramework.Controls.MetroButton btnFrühschicht;
        private MetroFramework.Controls.MetroButton btnSpätschicht;
        private MetroFramework.Controls.MetroButton btnSonderschicht;
        private MetroFramework.Controls.MetroButton btnNachschicht;
        private MetroFramework.Controls.MetroButton btnNoShift;
        private MetroFramework.Controls.MetroButton btnVacation;
        private System.Windows.Forms.Panel pnlShifts;
        private System.Windows.Forms.TableLayoutPanel tlpDays;
        private CustomMonthCalendar.CustomMonthCalender monthCalendar;
        private System.Windows.Forms.TableLayoutPanel tlpDayNames;
    }
}


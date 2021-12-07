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
            this.customMonthCalender1 = new CustomMonthCalendar.CustomMonthCalender();
            this.SuspendLayout();
            // 
            // customMonthCalender1
            // 
            this.customMonthCalender1.AutoselectMonth = true;
            this.customMonthCalender1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.customMonthCalender1.Location = new System.Drawing.Point(-1, 1);
            this.customMonthCalender1.Name = "customMonthCalender1";
            this.customMonthCalender1.Size = new System.Drawing.Size(245, 185);
            this.customMonthCalender1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.customMonthCalender1);
            this.Movable = false;
            this.Name = "frmMain";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CustomMonthCalendar.CustomMonthCalender customMonthCalender1;
    }
}


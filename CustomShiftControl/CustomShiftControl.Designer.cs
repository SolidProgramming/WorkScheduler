namespace CustomShiftControl
{
    partial class ShiftControl
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ShiftLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // ShiftLabel
            // 
            this.ShiftLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShiftLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShiftLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.ShiftLabel.Location = new System.Drawing.Point(0, 0);
            this.ShiftLabel.Name = "ShiftLabel";
            this.ShiftLabel.Size = new System.Drawing.Size(54, 27);
            this.ShiftLabel.TabIndex = 0;
            this.ShiftLabel.Text = "-";
            this.ShiftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ShiftLabel.DoubleClick += new System.EventHandler(this.ShiftLabel_DoubleClick);
            // 
            // CustomShiftControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShiftLabel);
            this.Name = "CustomShiftControl";
            this.Size = new System.Drawing.Size(54, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel ShiftLabel;
    }
}

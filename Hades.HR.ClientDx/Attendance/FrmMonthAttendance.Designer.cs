namespace Hades.HR.UI
{
    partial class FrmMonthAttendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonthAttendance));
            this.wgvAttendance = new Hades.Pager.WinControl.WinGridViewPager();
            this.SuspendLayout();
            // 
            // wgvAttendance
            // 
            this.wgvAttendance.AppendedMenu = null;
            this.wgvAttendance.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvAttendance.ColumnNameAlias")));
            this.wgvAttendance.DataSource = null;
            this.wgvAttendance.DisplayColumns = "";
            this.wgvAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvAttendance.FixedColumns = null;
            this.wgvAttendance.Location = new System.Drawing.Point(0, 0);
            this.wgvAttendance.MinimumSize = new System.Drawing.Size(540, 0);
            this.wgvAttendance.Name = "wgvAttendance";
            this.wgvAttendance.PrintTitle = "";
            this.wgvAttendance.ShowAddMenu = true;
            this.wgvAttendance.ShowCheckBox = false;
            this.wgvAttendance.ShowDeleteMenu = false;
            this.wgvAttendance.ShowEditMenu = true;
            this.wgvAttendance.ShowExportButton = false;
            this.wgvAttendance.Size = new System.Drawing.Size(793, 480);
            this.wgvAttendance.TabIndex = 0;
            // 
            // FrmMonthAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 480);
            this.Controls.Add(this.wgvAttendance);
            this.Name = "FrmMonthAttendance";
            this.Text = "考勤管理";
            this.ResumeLayout(false);

        }

        #endregion

        private Pager.WinControl.WinGridViewPager wgvAttendance;
    }
}
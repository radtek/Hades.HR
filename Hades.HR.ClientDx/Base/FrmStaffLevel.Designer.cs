namespace Hades.HR.UI
{
    partial class FrmStaffLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStaffLevel));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wgvLevel = new Hades.Pager.WinControl.WinGridView();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // wgvLevel
            // 
            this.wgvLevel.AppendedMenu = null;
            this.wgvLevel.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvLevel.ColumnNameAlias")));
            this.wgvLevel.DataSource = null;
            this.wgvLevel.DisplayColumns = "";
            this.wgvLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvLevel.FixedColumns = null;
            this.wgvLevel.Location = new System.Drawing.Point(0, 0);
            this.wgvLevel.Name = "wgvLevel";
            this.wgvLevel.PrintTitle = "";
            this.wgvLevel.ShowAddMenu = true;
            this.wgvLevel.ShowCheckBox = false;
            this.wgvLevel.ShowDeleteMenu = false;
            this.wgvLevel.ShowEditMenu = true;
            this.wgvLevel.ShowExportButton = true;
            this.wgvLevel.Size = new System.Drawing.Size(1004, 680);
            this.wgvLevel.TabIndex = 12;
            // 
            // FrmStaffLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.wgvLevel);
            this.Name = "FrmStaffLevel";
            this.Text = "职员等级";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Pager.WinControl.WinGridView wgvLevel;
    }
}
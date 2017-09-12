namespace Hades.HR.UI
{
    partial class FrmStaffAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStaffAttendance));
            this.wgvRecord = new Hades.Pager.WinControl.WinGridViewPager();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tvAttendance = new System.Windows.Forms.TreeView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnEditAttendance = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditRecord = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddAttendance = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtDays = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.luDepartment = new Hades.HR.UI.DepartmentLookup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMonth = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wgvRecord
            // 
            this.wgvRecord.AppendedMenu = null;
            this.wgvRecord.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvRecord.ColumnNameAlias")));
            this.wgvRecord.DataSource = null;
            this.wgvRecord.DisplayColumns = "";
            this.wgvRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvRecord.FixedColumns = null;
            this.wgvRecord.Location = new System.Drawing.Point(2, 21);
            this.wgvRecord.MinimumSize = new System.Drawing.Size(540, 0);
            this.wgvRecord.Name = "wgvRecord";
            this.wgvRecord.PrintTitle = "";
            this.wgvRecord.ShowAddMenu = false;
            this.wgvRecord.ShowCheckBox = false;
            this.wgvRecord.ShowDeleteMenu = false;
            this.wgvRecord.ShowEditMenu = false;
            this.wgvRecord.ShowExportButton = false;
            this.wgvRecord.Size = new System.Drawing.Size(817, 531);
            this.wgvRecord.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1027, 680);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tvAttendance);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.tableLayoutPanel1.SetRowSpan(this.groupControl1, 2);
            this.groupControl1.Size = new System.Drawing.Size(194, 674);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "考勤列表";
            // 
            // tvAttendance
            // 
            this.tvAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAttendance.Location = new System.Drawing.Point(2, 21);
            this.tvAttendance.Name = "tvAttendance";
            this.tvAttendance.Size = new System.Drawing.Size(190, 651);
            this.tvAttendance.TabIndex = 0;
            this.tvAttendance.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAttendance_AfterSelect);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtMonth);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.txtDays);
            this.groupControl2.Controls.Add(this.btnEditAttendance);
            this.groupControl2.Controls.Add(this.btnEditRecord);
            this.groupControl2.Controls.Add(this.luDepartment);
            this.groupControl2.Controls.Add(this.btnAddAttendance);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(203, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(821, 114);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "操作";
            // 
            // btnEditAttendance
            // 
            this.btnEditAttendance.Location = new System.Drawing.Point(129, 33);
            this.btnEditAttendance.Name = "btnEditAttendance";
            this.btnEditAttendance.Size = new System.Drawing.Size(75, 23);
            this.btnEditAttendance.TabIndex = 3;
            this.btnEditAttendance.Text = "编辑月考勤";
            this.btnEditAttendance.Click += new System.EventHandler(this.btnEditAttendance_Click);
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Location = new System.Drawing.Point(472, 33);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(102, 23);
            this.btnEditRecord.TabIndex = 2;
            this.btnEditRecord.Text = "编辑考勤记录";
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // btnAddAttendance
            // 
            this.btnAddAttendance.Location = new System.Drawing.Point(18, 33);
            this.btnAddAttendance.Name = "btnAddAttendance";
            this.btnAddAttendance.Size = new System.Drawing.Size(75, 23);
            this.btnAddAttendance.TabIndex = 0;
            this.btnAddAttendance.Text = "新增月考勤";
            this.btnAddAttendance.Click += new System.EventHandler(this.btnAddAttendance_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.wgvRecord);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(203, 123);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(821, 554);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "考勤记录";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(296, 72);
            this.txtDays.Name = "txtDays";
            this.txtDays.Properties.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(65, 20);
            this.txtDays.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(242, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "本月天数";
            // 
            // luDepartment
            // 
            this.luDepartment.Location = new System.Drawing.Point(242, 33);
            this.luDepartment.Name = "luDepartment";
            this.luDepartment.OnlyShowCompany = false;
            this.luDepartment.Size = new System.Drawing.Size(215, 20);
            this.luDepartment.TabIndex = 1;
            this.luDepartment.DepartmentSelect += new System.EventHandler(this.luDepartment_DepartmentSelect);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "考勤月度";
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(83, 72);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Properties.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(121, 20);
            this.txtMonth.TabIndex = 7;
            // 
            // FrmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmAttendance";
            this.Text = "考勤管理";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Hades.Pager.WinControl.WinGridViewPager wgvRecord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TreeView tvAttendance;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnAddAttendance;
        private DevExpress.XtraEditors.SimpleButton btnEditRecord;
        private DepartmentLookup luDepartment;
        private DevExpress.XtraEditors.SimpleButton btnEditAttendance;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDays;
        private DevExpress.XtraEditors.TextEdit txtMonth;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
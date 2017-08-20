namespace Hades.HR.UI
{
    partial class FrmLaborAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLaborAttendance));
            this.wgvRecord = new Hades.Pager.WinControl.WinGridViewPager();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.tvLine = new System.Windows.Forms.TreeView();
            this.tabAttendance = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageSummary = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.tabPageRecord = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnEditRecord = new DevExpress.XtraEditors.SimpleButton();
            this.dpAttendance = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabAttendance)).BeginInit();
            this.tabAttendance.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.tabPageRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpAttendance.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpAttendance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.wgvRecord.Location = new System.Drawing.Point(2, 25);
            this.wgvRecord.MinimumSize = new System.Drawing.Size(540, 0);
            this.wgvRecord.Name = "wgvRecord";
            this.wgvRecord.PrintTitle = "";
            this.wgvRecord.ShowAddMenu = true;
            this.wgvRecord.ShowCheckBox = false;
            this.wgvRecord.ShowDeleteMenu = true;
            this.wgvRecord.ShowEditMenu = true;
            this.wgvRecord.ShowExportButton = true;
            this.wgvRecord.Size = new System.Drawing.Size(787, 517);
            this.wgvRecord.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabAttendance, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 680);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.tvLine);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(3, 3);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(194, 674);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "班组列表";
            // 
            // tvLine
            // 
            this.tvLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLine.Location = new System.Drawing.Point(2, 25);
            this.tvLine.Name = "tvLine";
            this.tvLine.Size = new System.Drawing.Size(190, 647);
            this.tvLine.TabIndex = 0;
            // 
            // tabAttendance
            // 
            this.tabAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAttendance.Location = new System.Drawing.Point(203, 3);
            this.tabAttendance.Name = "tabAttendance";
            this.tabAttendance.SelectedTabPage = this.tabPageSummary;
            this.tabAttendance.Size = new System.Drawing.Size(798, 674);
            this.tabAttendance.TabIndex = 3;
            this.tabAttendance.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageSummary,
            this.tabPageRecord});
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Controls.Add(this.groupControl5);
            this.tabPageSummary.Controls.Add(this.groupControl4);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Size = new System.Drawing.Size(791, 639);
            this.tabPageSummary.Text = "考勤汇总";
            // 
            // groupControl5
            // 
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(0, 100);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(791, 539);
            this.groupControl5.TabIndex = 1;
            this.groupControl5.Text = "汇总记录";
            // 
            // groupControl4
            // 
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(791, 100);
            this.groupControl4.TabIndex = 0;
            this.groupControl4.Text = "操作";
            // 
            // tabPageRecord
            // 
            this.tabPageRecord.Controls.Add(this.groupControl2);
            this.tabPageRecord.Controls.Add(this.groupControl1);
            this.tabPageRecord.Name = "tabPageRecord";
            this.tabPageRecord.Size = new System.Drawing.Size(791, 639);
            this.tabPageRecord.Text = "考勤记录";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.wgvRecord);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 95);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(791, 544);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "考勤记录";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(791, 95);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "操作";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnEditRecord);
            this.layoutControl1.Controls.Add(this.dpAttendance);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 25);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(787, 68);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Location = new System.Drawing.Point(396, 14);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(377, 27);
            this.btnEditRecord.StyleController = this.layoutControl1;
            this.btnEditRecord.TabIndex = 3;
            this.btnEditRecord.Text = "编辑考勤记录";
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // dpAttendance
            // 
            this.dpAttendance.EditValue = null;
            this.dpAttendance.Location = new System.Drawing.Point(77, 14);
            this.dpAttendance.Name = "dpAttendance";
            this.dpAttendance.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpAttendance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpAttendance.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpAttendance.Size = new System.Drawing.Size(315, 24);
            this.dpAttendance.StyleController = this.layoutControl1;
            this.dpAttendance.TabIndex = 4;
            this.dpAttendance.EditValueChanged += new System.EventHandler(this.dpAttendance_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(787, 68);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dpAttendance;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(382, 44);
            this.layoutControlItem1.Text = "日期选择";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnEditRecord;
            this.layoutControlItem2.Location = new System.Drawing.Point(382, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(381, 44);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // FrmLaborAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmLaborAttendance";
            this.Text = "计件工人考勤";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabAttendance)).EndInit();
            this.tabAttendance.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.tabPageRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dpAttendance.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpAttendance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Hades.Pager.WinControl.WinGridViewPager wgvRecord;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.TreeView tvLine;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnEditRecord;
        private DevExpress.XtraEditors.DateEdit dpAttendance;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraTab.XtraTabControl tabAttendance;
        private DevExpress.XtraTab.XtraTabPage tabPageSummary;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraTab.XtraTabPage tabPageRecord;
    }
}
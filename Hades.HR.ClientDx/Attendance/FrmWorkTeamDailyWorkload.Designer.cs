namespace Hades.HR.UI
{
    partial class FrmWorkTeamDailyWorkload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkTeamDailyWorkload));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnInit = new DevExpress.XtraEditors.SimpleButton();
            this.dpAttendance = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuProduction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChange = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuElectric = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.wgvWorkload = new Hades.Pager.WinControl.WinGridView();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.wgvLabor = new Hades.Pager.WinControl.WinGridView();
            this.btnDailyAttendance = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.wgvAttendance = new Hades.Pager.WinControl.WinGridView();
            this.wtTree = new Hades.HR.UI.WorkTeamTree();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpAttendance.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpAttendance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnDailyAttendance);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.btnInit);
            this.layoutControl1.Controls.Add(this.dpAttendance);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 25);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(694, 67);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(449, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(210, 27);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInit.Location = new System.Drawing.Point(14, 42);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(213, 27);
            this.btnInit.StyleController = this.layoutControl1;
            this.btnInit.TabIndex = 18;
            this.btnInit.Text = "设置员工";
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
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
            this.dpAttendance.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dpAttendance.Size = new System.Drawing.Size(582, 24);
            this.dpAttendance.StyleController = this.layoutControl1;
            this.dpAttendance.TabIndex = 16;
            this.dpAttendance.EditValueChanged += new System.EventHandler(this.dpAttendance_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(673, 83);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dpAttendance;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(649, 28);
            this.layoutControlItem2.Text = "日期选择";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnInit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(217, 31);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSearch;
            this.layoutControlItem4.Location = new System.Drawing.Point(435, 28);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(214, 31);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProduction,
            this.menuChange,
            this.menuRepair,
            this.menuElectric});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 100);
            // 
            // menuProduction
            // 
            this.menuProduction.Name = "menuProduction";
            this.menuProduction.Size = new System.Drawing.Size(168, 24);
            this.menuProduction.Text = "编辑产量工时";
            this.menuProduction.Click += new System.EventHandler(this.menuProduction_Click);
            // 
            // menuChange
            // 
            this.menuChange.Name = "menuChange";
            this.menuChange.Size = new System.Drawing.Size(168, 24);
            this.menuChange.Text = "编辑换机工时";
            this.menuChange.Click += new System.EventHandler(this.menuChange_Click);
            // 
            // menuRepair
            // 
            this.menuRepair.Name = "menuRepair";
            this.menuRepair.Size = new System.Drawing.Size(168, 24);
            this.menuRepair.Text = "编辑机修工时";
            this.menuRepair.Click += new System.EventHandler(this.menuRepair_Click);
            // 
            // menuElectric
            // 
            this.menuElectric.Name = "menuElectric";
            this.menuElectric.Size = new System.Drawing.Size(168, 24);
            this.menuElectric.Text = "编辑电修工时";
            this.menuElectric.Click += new System.EventHandler(this.menuElectric_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupControl5, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 680);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.wtTree);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.tableLayoutPanel1.SetRowSpan(this.groupControl1, 4);
            this.groupControl1.Size = new System.Drawing.Size(294, 674);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "班组列表";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(303, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(698, 94);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "操作";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.wgvWorkload);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(303, 103);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(698, 194);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "工作量记录";
            // 
            // wgvWorkload
            // 
            this.wgvWorkload.AppendedMenu = null;
            this.wgvWorkload.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvWorkload.ColumnNameAlias")));
            this.wgvWorkload.DataSource = null;
            this.wgvWorkload.DisplayColumns = "";
            this.wgvWorkload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvWorkload.FixedColumns = null;
            this.wgvWorkload.Location = new System.Drawing.Point(2, 25);
            this.wgvWorkload.Name = "wgvWorkload";
            this.wgvWorkload.PrintTitle = "";
            this.wgvWorkload.ShowAddMenu = false;
            this.wgvWorkload.ShowCheckBox = false;
            this.wgvWorkload.ShowDeleteMenu = false;
            this.wgvWorkload.ShowEditMenu = false;
            this.wgvWorkload.ShowExportButton = true;
            this.wgvWorkload.Size = new System.Drawing.Size(694, 167);
            this.wgvWorkload.TabIndex = 1;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.wgvLabor);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(303, 303);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(698, 184);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "职员工作量";
            // 
            // wgvLabor
            // 
            this.wgvLabor.AppendedMenu = null;
            this.wgvLabor.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvLabor.ColumnNameAlias")));
            this.wgvLabor.DataSource = null;
            this.wgvLabor.DisplayColumns = "";
            this.wgvLabor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvLabor.FixedColumns = null;
            this.wgvLabor.Location = new System.Drawing.Point(2, 25);
            this.wgvLabor.Name = "wgvLabor";
            this.wgvLabor.PrintTitle = "";
            this.wgvLabor.ShowAddMenu = true;
            this.wgvLabor.ShowCheckBox = false;
            this.wgvLabor.ShowDeleteMenu = true;
            this.wgvLabor.ShowEditMenu = true;
            this.wgvLabor.ShowExportButton = true;
            this.wgvLabor.Size = new System.Drawing.Size(694, 157);
            this.wgvLabor.TabIndex = 0;
            // 
            // btnDailyAttendance
            // 
            this.btnDailyAttendance.Location = new System.Drawing.Point(231, 42);
            this.btnDailyAttendance.Name = "btnDailyAttendance";
            this.btnDailyAttendance.Size = new System.Drawing.Size(214, 27);
            this.btnDailyAttendance.StyleController = this.layoutControl1;
            this.btnDailyAttendance.TabIndex = 19;
            this.btnDailyAttendance.Text = "考勤登记";
            this.btnDailyAttendance.Click += new System.EventHandler(this.btnDailyAttendance_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnDailyAttendance;
            this.layoutControlItem3.Location = new System.Drawing.Point(217, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(218, 31);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.wgvAttendance);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(303, 493);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(698, 184);
            this.groupControl5.TabIndex = 4;
            this.groupControl5.Text = "职员考勤";
            // 
            // wgvAttendance
            // 
            this.wgvAttendance.AppendedMenu = null;
            this.wgvAttendance.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvAttendance.ColumnNameAlias")));
            this.wgvAttendance.DataSource = null;
            this.wgvAttendance.DisplayColumns = "";
            this.wgvAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvAttendance.FixedColumns = null;
            this.wgvAttendance.Location = new System.Drawing.Point(2, 25);
            this.wgvAttendance.Name = "wgvAttendance";
            this.wgvAttendance.PrintTitle = "";
            this.wgvAttendance.ShowAddMenu = true;
            this.wgvAttendance.ShowCheckBox = false;
            this.wgvAttendance.ShowDeleteMenu = true;
            this.wgvAttendance.ShowEditMenu = true;
            this.wgvAttendance.ShowExportButton = true;
            this.wgvAttendance.Size = new System.Drawing.Size(694, 157);
            this.wgvAttendance.TabIndex = 1;
            // 
            // wtTree
            // 
            this.wtTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wtTree.Location = new System.Drawing.Point(2, 25);
            this.wtTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wtTree.Name = "wtTree";
            this.wtTree.Size = new System.Drawing.Size(290, 647);
            this.wtTree.TabIndex = 0;
            this.wtTree.TeamSeleted += new System.EventHandler(this.wtTree_TeamSeleted);
            // 
            // FrmWorkTeamDailyWorkload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmWorkTeamDailyWorkload";
            this.Text = "班组日工作量";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dpAttendance.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpAttendance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuProduction;
        private System.Windows.Forms.ToolStripMenuItem menuChange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.DateEdit dpAttendance;
        private DevExpress.XtraEditors.SimpleButton btnInit;
        private WorkTeamTree wtTree;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private Pager.WinControl.WinGridView wgvLabor;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private Pager.WinControl.WinGridView wgvWorkload;
        private System.Windows.Forms.ToolStripMenuItem menuRepair;
        private System.Windows.Forms.ToolStripMenuItem menuElectric;
        private DevExpress.XtraEditors.SimpleButton btnDailyAttendance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private Pager.WinControl.WinGridView wgvAttendance;
    }
}
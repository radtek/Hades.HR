namespace Hades.HR.UI
{
    partial class FrmPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPosition));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDepartmentNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtDepartmentName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuViewPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeletePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.depTree = new Hades.HR.UI.DepartmentTreeGrid();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.wgvPosition = new Hades.Pager.WinControl.WinGridView();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.wgvProductionLine = new Hades.Pager.WinControl.WinGridView();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.wgvWorkTeam = new Hades.Pager.WinControl.WinGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuViewLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteLine = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuViewTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteTeam = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDepartmentNumber);
            this.layoutControl1.Controls.Add(this.txtDepartmentName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 25);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(694, 67);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDepartmentNumber
            // 
            this.txtDepartmentNumber.Location = new System.Drawing.Point(412, 14);
            this.txtDepartmentNumber.Name = "txtDepartmentNumber";
            this.txtDepartmentNumber.Properties.ReadOnly = true;
            this.txtDepartmentNumber.Size = new System.Drawing.Size(268, 24);
            this.txtDepartmentNumber.StyleController = this.layoutControl1;
            this.txtDepartmentNumber.TabIndex = 5;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(77, 14);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Properties.ReadOnly = true;
            this.txtDepartmentName.Size = new System.Drawing.Size(268, 24);
            this.txtDepartmentName.StyleController = this.layoutControl1;
            this.txtDepartmentName.TabIndex = 4;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(694, 67);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDepartmentName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(335, 43);
            this.layoutControlItem1.Text = "部门名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDepartmentNumber;
            this.layoutControlItem2.Location = new System.Drawing.Point(335, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(335, 43);
            this.layoutControlItem2.Text = "部门代码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewPosition,
            this.menuAddPosition,
            this.menuEditPosition,
            this.menuDeletePosition});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 100);
            // 
            // menuViewPosition
            // 
            this.menuViewPosition.Name = "menuViewPosition";
            this.menuViewPosition.Size = new System.Drawing.Size(138, 24);
            this.menuViewPosition.Text = "查看岗位";
            this.menuViewPosition.Click += new System.EventHandler(this.menuViewPosition_Click);
            // 
            // menuAddPosition
            // 
            this.menuAddPosition.Name = "menuAddPosition";
            this.menuAddPosition.Size = new System.Drawing.Size(138, 24);
            this.menuAddPosition.Text = "新增岗位";
            this.menuAddPosition.Click += new System.EventHandler(this.menuAddPosition_Click);
            // 
            // menuEditPosition
            // 
            this.menuEditPosition.Name = "menuEditPosition";
            this.menuEditPosition.Size = new System.Drawing.Size(138, 24);
            this.menuEditPosition.Text = "编辑岗位";
            this.menuEditPosition.Click += new System.EventHandler(this.menuEditPosition_Click);
            // 
            // menuDeletePosition
            // 
            this.menuDeletePosition.Name = "menuDeletePosition";
            this.menuDeletePosition.Size = new System.Drawing.Size(138, 24);
            this.menuDeletePosition.Text = "删除岗位";
            this.menuDeletePosition.Click += new System.EventHandler(this.menuDeletePosition_Click);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 680);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.depTree);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.tableLayoutPanel1.SetRowSpan(this.groupControl1, 4);
            this.groupControl1.Size = new System.Drawing.Size(294, 674);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "部门列表";
            // 
            // depTree
            // 
            this.depTree.DataSource = null;
            this.depTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.depTree.EnableFocusCellStyle = true;
            this.depTree.Location = new System.Drawing.Point(2, 25);
            this.depTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.depTree.Name = "depTree";
            this.depTree.ShowContextMenu = false;
            this.depTree.ShowMenuCreate = false;
            this.depTree.ShowMenuDelete = false;
            this.depTree.ShowMenuEdit = false;
            this.depTree.ShowMenuView = false;
            this.depTree.ShowNameOnly = true;
            this.depTree.Size = new System.Drawing.Size(290, 647);
            this.depTree.TabIndex = 0;
            this.depTree.DepartmentSelect += new System.EventHandler(this.depTree_DepartmentSelect);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(303, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(698, 94);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "选择部门";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.wgvPosition);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(303, 103);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(698, 191);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "岗位列表";
            // 
            // wgvPosition
            // 
            this.wgvPosition.AppendedMenu = null;
            this.wgvPosition.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvPosition.ColumnNameAlias")));
            this.wgvPosition.DataSource = null;
            this.wgvPosition.DisplayColumns = "";
            this.wgvPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvPosition.FixedColumns = null;
            this.wgvPosition.Location = new System.Drawing.Point(2, 25);
            this.wgvPosition.Name = "wgvPosition";
            this.wgvPosition.PrintTitle = "";
            this.wgvPosition.ShowAddMenu = true;
            this.wgvPosition.ShowCheckBox = false;
            this.wgvPosition.ShowDeleteMenu = true;
            this.wgvPosition.ShowEditMenu = true;
            this.wgvPosition.ShowExportButton = true;
            this.wgvPosition.Size = new System.Drawing.Size(694, 164);
            this.wgvPosition.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.wgvProductionLine);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(303, 300);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(698, 185);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "产线列表";
            // 
            // wgvProductionLine
            // 
            this.wgvProductionLine.AppendedMenu = null;
            this.wgvProductionLine.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvProductionLine.ColumnNameAlias")));
            this.wgvProductionLine.DataSource = null;
            this.wgvProductionLine.DisplayColumns = "";
            this.wgvProductionLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvProductionLine.FixedColumns = null;
            this.wgvProductionLine.Location = new System.Drawing.Point(2, 25);
            this.wgvProductionLine.Name = "wgvProductionLine";
            this.wgvProductionLine.PrintTitle = "";
            this.wgvProductionLine.ShowAddMenu = true;
            this.wgvProductionLine.ShowCheckBox = false;
            this.wgvProductionLine.ShowDeleteMenu = true;
            this.wgvProductionLine.ShowEditMenu = true;
            this.wgvProductionLine.ShowExportButton = true;
            this.wgvProductionLine.Size = new System.Drawing.Size(694, 158);
            this.wgvProductionLine.TabIndex = 0;
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.wgvWorkTeam);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(303, 491);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(698, 186);
            this.groupControl5.TabIndex = 4;
            this.groupControl5.Text = "班组列表";
            // 
            // wgvWorkTeam
            // 
            this.wgvWorkTeam.AppendedMenu = null;
            this.wgvWorkTeam.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvWorkTeam.ColumnNameAlias")));
            this.wgvWorkTeam.DataSource = null;
            this.wgvWorkTeam.DisplayColumns = "";
            this.wgvWorkTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvWorkTeam.FixedColumns = null;
            this.wgvWorkTeam.Location = new System.Drawing.Point(2, 25);
            this.wgvWorkTeam.Name = "wgvWorkTeam";
            this.wgvWorkTeam.PrintTitle = "";
            this.wgvWorkTeam.ShowAddMenu = true;
            this.wgvWorkTeam.ShowCheckBox = false;
            this.wgvWorkTeam.ShowDeleteMenu = true;
            this.wgvWorkTeam.ShowEditMenu = true;
            this.wgvWorkTeam.ShowExportButton = true;
            this.wgvWorkTeam.Size = new System.Drawing.Size(694, 159);
            this.wgvWorkTeam.TabIndex = 0;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewLine,
            this.menuAddLine,
            this.menuEditLine,
            this.menuDeleteLine});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(139, 100);
            // 
            // menuViewLine
            // 
            this.menuViewLine.Name = "menuViewLine";
            this.menuViewLine.Size = new System.Drawing.Size(138, 24);
            this.menuViewLine.Text = "查看产线";
            // 
            // menuAddLine
            // 
            this.menuAddLine.Name = "menuAddLine";
            this.menuAddLine.Size = new System.Drawing.Size(138, 24);
            this.menuAddLine.Text = "新增产线";
            this.menuAddLine.Click += new System.EventHandler(this.menuAddLine_Click);
            // 
            // menuEditLine
            // 
            this.menuEditLine.Name = "menuEditLine";
            this.menuEditLine.Size = new System.Drawing.Size(138, 24);
            this.menuEditLine.Text = "编辑产线";
            // 
            // menuDeleteLine
            // 
            this.menuDeleteLine.Name = "menuDeleteLine";
            this.menuDeleteLine.Size = new System.Drawing.Size(138, 24);
            this.menuDeleteLine.Text = "删除产线";
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewTeam,
            this.menuAddTeam,
            this.menuEditTeam,
            this.menuDeleteTeam});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(139, 100);
            // 
            // menuViewTeam
            // 
            this.menuViewTeam.Name = "menuViewTeam";
            this.menuViewTeam.Size = new System.Drawing.Size(138, 24);
            this.menuViewTeam.Text = "查看班组";
            // 
            // menuAddTeam
            // 
            this.menuAddTeam.Name = "menuAddTeam";
            this.menuAddTeam.Size = new System.Drawing.Size(138, 24);
            this.menuAddTeam.Text = "新增班组";
            this.menuAddTeam.Click += new System.EventHandler(this.menuAddTeam_Click);
            // 
            // menuEditTeam
            // 
            this.menuEditTeam.Name = "menuEditTeam";
            this.menuEditTeam.Size = new System.Drawing.Size(138, 24);
            this.menuEditTeam.Text = "编辑班组";
            // 
            // menuDeleteTeam
            // 
            this.menuDeleteTeam.Name = "menuDeleteTeam";
            this.menuDeleteTeam.Size = new System.Drawing.Size(138, 24);
            this.menuDeleteTeam.Text = "删除班组";
            // 
            // FrmPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmPosition";
            this.Text = "岗位产线管理";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DepartmentTreeGrid depTree;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Pager.WinControl.WinGridView wgvPosition;
        private System.Windows.Forms.ToolStripMenuItem menuViewPosition;
        private System.Windows.Forms.ToolStripMenuItem menuEditPosition;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtDepartmentNumber;
        private DevExpress.XtraEditors.TextEdit txtDepartmentName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.ToolStripMenuItem menuDeletePosition;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private Pager.WinControl.WinGridView wgvProductionLine;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private Pager.WinControl.WinGridView wgvWorkTeam;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuViewLine;
        private System.Windows.Forms.ToolStripMenuItem menuAddLine;
        private System.Windows.Forms.ToolStripMenuItem menuEditLine;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteLine;
        private System.Windows.Forms.ToolStripMenuItem menuAddPosition;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem menuViewTeam;
        private System.Windows.Forms.ToolStripMenuItem menuAddTeam;
        private System.Windows.Forms.ToolStripMenuItem menuEditTeam;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteTeam;
    }
}
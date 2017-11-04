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
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.wgvWarehouse = new Hades.Pager.WinControl.WinGridView();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuViewWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteWarehouse = new System.Windows.Forms.ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDepartmentNumber);
            this.layoutControl1.Controls.Add(this.txtDepartmentName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(694, 51);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDepartmentNumber
            // 
            this.txtDepartmentNumber.Location = new System.Drawing.Point(400, 12);
            this.txtDepartmentNumber.Name = "txtDepartmentNumber";
            this.txtDepartmentNumber.Properties.ReadOnly = true;
            this.txtDepartmentNumber.Size = new System.Drawing.Size(282, 20);
            this.txtDepartmentNumber.StyleController = this.layoutControl1;
            this.txtDepartmentNumber.TabIndex = 5;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(63, 12);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Properties.ReadOnly = true;
            this.txtDepartmentName.Size = new System.Drawing.Size(282, 20);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(694, 51);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDepartmentName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(337, 31);
            this.layoutControlItem1.Text = "部门名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDepartmentNumber;
            this.layoutControlItem2.Location = new System.Drawing.Point(337, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(337, 31);
            this.layoutControlItem2.Text = "部门代码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // menuViewPosition
            // 
            this.menuViewPosition.Name = "menuViewPosition";
            this.menuViewPosition.Size = new System.Drawing.Size(124, 22);
            this.menuViewPosition.Text = "查看岗位";
            this.menuViewPosition.Click += new System.EventHandler(this.menuViewPosition_Click);
            // 
            // menuAddPosition
            // 
            this.menuAddPosition.Name = "menuAddPosition";
            this.menuAddPosition.Size = new System.Drawing.Size(124, 22);
            this.menuAddPosition.Text = "新增岗位";
            this.menuAddPosition.Click += new System.EventHandler(this.menuAddPosition_Click);
            // 
            // menuEditPosition
            // 
            this.menuEditPosition.Name = "menuEditPosition";
            this.menuEditPosition.Size = new System.Drawing.Size(124, 22);
            this.menuEditPosition.Text = "编辑岗位";
            this.menuEditPosition.Click += new System.EventHandler(this.menuEditPosition_Click);
            // 
            // menuDeletePosition
            // 
            this.menuDeletePosition.Name = "menuDeletePosition";
            this.menuDeletePosition.Size = new System.Drawing.Size(124, 22);
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
            this.tableLayoutPanel1.Controls.Add(this.groupControl6, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 680);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.depTree);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.tableLayoutPanel1.SetRowSpan(this.groupControl1, 3);
            this.groupControl1.Size = new System.Drawing.Size(294, 674);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "部门列表";
            // 
            // depTree
            // 
            this.depTree.DataSource = null;
            this.depTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.depTree.EnableFocusCellStyle = true;
            this.depTree.Location = new System.Drawing.Point(2, 21);
            this.depTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.depTree.Name = "depTree";
            this.depTree.ShowContextMenu = false;
            this.depTree.ShowMenuCreate = false;
            this.depTree.ShowMenuDelete = false;
            this.depTree.ShowMenuEdit = false;
            this.depTree.ShowMenuView = false;
            this.depTree.ShowNameOnly = true;
            this.depTree.Size = new System.Drawing.Size(290, 651);
            this.depTree.TabIndex = 0;
            this.depTree.DepartmentSelect += new System.EventHandler(this.depTree_DepartmentSelect);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(303, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(698, 74);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "选择部门";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.wgvPosition);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(303, 83);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(698, 294);
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
            this.wgvPosition.Location = new System.Drawing.Point(2, 21);
            this.wgvPosition.Name = "wgvPosition";
            this.wgvPosition.PrintTitle = "";
            this.wgvPosition.ShowAddMenu = true;
            this.wgvPosition.ShowCheckBox = false;
            this.wgvPosition.ShowDeleteMenu = true;
            this.wgvPosition.ShowEditMenu = true;
            this.wgvPosition.ShowExportButton = true;
            this.wgvPosition.Size = new System.Drawing.Size(694, 271);
            this.wgvPosition.TabIndex = 0;
            this.wgvPosition.OnGridViewMouseDoubleClick += new System.EventHandler(this.wgvPosition_OnGridViewMouseDoubleClick);
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.wgvWarehouse);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl6.Location = new System.Drawing.Point(303, 383);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(698, 294);
            this.groupControl6.TabIndex = 5;
            this.groupControl6.Text = "仓库列表";
            // 
            // wgvWarehouse
            // 
            this.wgvWarehouse.AppendedMenu = null;
            this.wgvWarehouse.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvWarehouse.ColumnNameAlias")));
            this.wgvWarehouse.DataSource = null;
            this.wgvWarehouse.DisplayColumns = "";
            this.wgvWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvWarehouse.FixedColumns = null;
            this.wgvWarehouse.Location = new System.Drawing.Point(2, 21);
            this.wgvWarehouse.Name = "wgvWarehouse";
            this.wgvWarehouse.PrintTitle = "";
            this.wgvWarehouse.ShowAddMenu = true;
            this.wgvWarehouse.ShowCheckBox = false;
            this.wgvWarehouse.ShowDeleteMenu = true;
            this.wgvWarehouse.ShowEditMenu = true;
            this.wgvWarehouse.ShowExportButton = true;
            this.wgvWarehouse.Size = new System.Drawing.Size(694, 271);
            this.wgvWarehouse.TabIndex = 0;
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewWarehouse,
            this.menuAddWarehouse,
            this.menuEditWarehouse,
            this.menuDeleteWarehouse});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(125, 92);
            // 
            // menuViewWarehouse
            // 
            this.menuViewWarehouse.Name = "menuViewWarehouse";
            this.menuViewWarehouse.Size = new System.Drawing.Size(124, 22);
            this.menuViewWarehouse.Text = "查看仓库";
            this.menuViewWarehouse.Click += new System.EventHandler(this.menuViewWarehouse_Click);
            // 
            // menuAddWarehouse
            // 
            this.menuAddWarehouse.Name = "menuAddWarehouse";
            this.menuAddWarehouse.Size = new System.Drawing.Size(124, 22);
            this.menuAddWarehouse.Text = "新增仓库";
            this.menuAddWarehouse.Click += new System.EventHandler(this.menuAddWarehouse_Click);
            // 
            // menuEditWarehouse
            // 
            this.menuEditWarehouse.Name = "menuEditWarehouse";
            this.menuEditWarehouse.Size = new System.Drawing.Size(124, 22);
            this.menuEditWarehouse.Text = "编辑仓库";
            this.menuEditWarehouse.Click += new System.EventHandler(this.menuEditWarehouse_Click);
            // 
            // menuDeleteWarehouse
            // 
            this.menuDeleteWarehouse.Name = "menuDeleteWarehouse";
            this.menuDeleteWarehouse.Size = new System.Drawing.Size(124, 22);
            this.menuDeleteWarehouse.Text = "删除仓库";
            // 
            // FrmPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmPosition";
            this.Text = "岗位仓库管理";
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem menuAddPosition;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private Pager.WinControl.WinGridView wgvWarehouse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem menuViewWarehouse;
        private System.Windows.Forms.ToolStripMenuItem menuAddWarehouse;
        private System.Windows.Forms.ToolStripMenuItem menuEditWarehouse;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteWarehouse;
    }
}
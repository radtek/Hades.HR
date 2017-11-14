namespace Hades.HR.UI
{
    partial class DepartmentTreeGrid
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlView = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSortCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAddress = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPrincipal = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFax = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colInnerPhone = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colOuterPhone = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRemark = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFoundDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCloseDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDeleted = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEnabled = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.bsDepartment = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tlView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartment)).BeginInit();
            this.SuspendLayout();
            // 
            // tlView
            // 
            this.tlView.Appearance.SelectedRow.BackColor = System.Drawing.Color.LightBlue;
            this.tlView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tlView.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colNumber,
            this.colName,
            this.colSortCode,
            this.colType,
            this.colAddress,
            this.colPrincipal,
            this.colFax,
            this.colInnerPhone,
            this.colOuterPhone,
            this.colRemark,
            this.colFoundDate,
            this.colCloseDate,
            this.colDeleted,
            this.colEnabled});
            this.tlView.ContextMenuStrip = this.contextMenuStrip1;
            this.tlView.DataSource = this.bsDepartment;
            this.tlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlView.KeyFieldName = "Id";
            this.tlView.Location = new System.Drawing.Point(0, 0);
            this.tlView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlView.Name = "tlView";
            this.tlView.OptionsBehavior.Editable = false;
            this.tlView.OptionsBehavior.PopulateServiceColumns = true;
            this.tlView.ParentFieldName = "PID";
            this.tlView.Size = new System.Drawing.Size(760, 498);
            this.tlView.TabIndex = 0;
            this.tlView.GetNodeDisplayValue += new DevExpress.XtraTreeList.GetNodeDisplayValueEventHandler(this.tlView_GetNodeDisplayValue);
            this.tlView.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlView_FocusedNodeChanged);
            this.tlView.DoubleClick += new System.EventHandler(this.tlView_DoubleClick);
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colNumber
            // 
            this.colNumber.Caption = "部门代码";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowSort = false;
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            this.colNumber.Width = 43;
            // 
            // colName
            // 
            this.colName.Caption = "部门名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 44;
            // 
            // colSortCode
            // 
            this.colSortCode.Caption = "排序码";
            this.colSortCode.FieldName = "SortCode";
            this.colSortCode.Name = "colSortCode";
            this.colSortCode.Visible = true;
            this.colSortCode.VisibleIndex = 2;
            this.colSortCode.Width = 44;
            // 
            // colType
            // 
            this.colType.AppearanceCell.Options.UseTextOptions = true;
            this.colType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colType.Caption = "部门类型";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowSort = false;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 3;
            this.colType.Width = 44;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "地址";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowSort = false;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            this.colAddress.Width = 45;
            // 
            // colPrincipal
            // 
            this.colPrincipal.Caption = "负责人";
            this.colPrincipal.FieldName = "Principal";
            this.colPrincipal.Name = "colPrincipal";
            this.colPrincipal.OptionsColumn.AllowSort = false;
            this.colPrincipal.Visible = true;
            this.colPrincipal.VisibleIndex = 5;
            // 
            // colFax
            // 
            this.colFax.Caption = "传真";
            this.colFax.FieldName = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.OptionsColumn.AllowSort = false;
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 6;
            // 
            // colInnerPhone
            // 
            this.colInnerPhone.Caption = "内线电话";
            this.colInnerPhone.FieldName = "InnerPhone";
            this.colInnerPhone.Name = "colInnerPhone";
            this.colInnerPhone.OptionsColumn.AllowSort = false;
            this.colInnerPhone.Visible = true;
            this.colInnerPhone.VisibleIndex = 7;
            this.colInnerPhone.Width = 45;
            // 
            // colOuterPhone
            // 
            this.colOuterPhone.Caption = "外线电话";
            this.colOuterPhone.FieldName = "OuterPhone";
            this.colOuterPhone.Name = "colOuterPhone";
            this.colOuterPhone.OptionsColumn.AllowSort = false;
            this.colOuterPhone.Visible = true;
            this.colOuterPhone.VisibleIndex = 8;
            this.colOuterPhone.Width = 45;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowSort = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 9;
            this.colRemark.Width = 45;
            // 
            // colFoundDate
            // 
            this.colFoundDate.Caption = "成立日期";
            this.colFoundDate.FieldName = "FoundDate";
            this.colFoundDate.Name = "colFoundDate";
            this.colFoundDate.Width = 45;
            // 
            // colCloseDate
            // 
            this.colCloseDate.Caption = "关闭日期";
            this.colCloseDate.FieldName = "CloseDate";
            this.colCloseDate.Name = "colCloseDate";
            this.colCloseDate.Width = 45;
            // 
            // colDeleted
            // 
            this.colDeleted.Caption = "删除标志";
            this.colDeleted.FieldName = "Deleted";
            this.colDeleted.Name = "colDeleted";
            this.colDeleted.Width = 44;
            // 
            // colEnabled
            // 
            this.colEnabled.AppearanceCell.Options.UseTextOptions = true;
            this.colEnabled.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colEnabled.Caption = "启用标志";
            this.colEnabled.FieldName = "Enabled";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.OptionsColumn.AllowSort = false;
            this.colEnabled.Visible = true;
            this.colEnabled.VisibleIndex = 10;
            this.colEnabled.Width = 44;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuView,
            this.menuCreate,
            this.menuEdit,
            this.menuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 100);
            // 
            // menuView
            // 
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(138, 24);
            this.menuView.Text = "查看部门";
            this.menuView.Click += new System.EventHandler(this.menuView_Click);
            // 
            // menuCreate
            // 
            this.menuCreate.Name = "menuCreate";
            this.menuCreate.Size = new System.Drawing.Size(138, 24);
            this.menuCreate.Text = "新增部门";
            this.menuCreate.Click += new System.EventHandler(this.menuCreate_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(138, 24);
            this.menuEdit.Text = "编辑部门";
            this.menuEdit.Click += new System.EventHandler(this.menuEdit_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(138, 24);
            this.menuDelete.Text = "删除部门";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // bsDepartment
            // 
            this.bsDepartment.DataSource = typeof(Hades.HR.Entity.DepartmentInfo);
            // 
            // DepartmentTreeGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DepartmentTreeGrid";
            this.Size = new System.Drawing.Size(760, 498);
            this.Load += new System.EventHandler(this.DepartmentTreeGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tlView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlView;
        private System.Windows.Forms.BindingSource bsDepartment;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNumber;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSortCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAddress;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colInnerPhone;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOuterPhone;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRemark;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFoundDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCloseDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDeleted;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEnabled;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private System.Windows.Forms.ToolStripMenuItem menuCreate;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPrincipal;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFax;
    }
}

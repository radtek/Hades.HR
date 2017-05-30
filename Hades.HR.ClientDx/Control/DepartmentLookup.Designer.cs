namespace Hades.HR.UI
{
    partial class DepartmentLookup
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
            this.luDepartment = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.bsDepartment = new System.Windows.Forms.BindingSource(this.components);
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.colNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.luDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // luDepartment
            // 
            this.luDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luDepartment.Location = new System.Drawing.Point(0, 0);
            this.luDepartment.Name = "luDepartment";
            this.luDepartment.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.luDepartment.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.luDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luDepartment.Properties.DataSource = this.bsDepartment;
            this.luDepartment.Properties.DisplayMember = "Name";
            this.luDepartment.Properties.NullText = "请选择部门";
            this.luDepartment.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.luDepartment.Properties.ValueMember = "Id";
            this.luDepartment.Size = new System.Drawing.Size(417, 20);
            this.luDepartment.TabIndex = 0;
            this.luDepartment.EditValueChanged += new System.EventHandler(this.luDepartment_EditValueChanged);
            // 
            // bsDepartment
            // 
            this.bsDepartment.DataSource = typeof(Hades.HR.Entity.DepartmentInfo);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colNumber,
            this.colName,
            this.colType});
            this.treeListLookUpEdit1TreeList.DataSource = this.bsDepartment;
            this.treeListLookUpEdit1TreeList.KeyFieldName = "Id";
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsBehavior.Editable = false;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.ParentFieldName = "PID";
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            this.treeListLookUpEdit1TreeList.GetNodeDisplayValue += new DevExpress.XtraTreeList.GetNodeDisplayValueEventHandler(this.treeListLookUpEdit1TreeList_GetNodeDisplayValue);
            // 
            // colNumber
            // 
            this.colNumber.Caption = "部门编码";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            this.colNumber.Width = 20;
            // 
            // colName
            // 
            this.colName.Caption = "部门名称";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 30;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 30;
            // 
            // colType
            // 
            this.colType.AppearanceCell.Options.UseTextOptions = true;
            this.colType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colType.Caption = "部门类型";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 2;
            this.colType.Width = 20;
            // 
            // DepartmentLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.luDepartment);
            this.Name = "DepartmentLookup";
            this.Size = new System.Drawing.Size(417, 20);
            ((System.ComponentModel.ISupportInitialize)(this.luDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TreeListLookUpEdit luDepartment;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private System.Windows.Forms.BindingSource bsDepartment;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNumber;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
    }
}

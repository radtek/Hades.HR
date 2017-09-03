namespace Hades.HR.UI
{
    partial class ProductionLineTree
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
            this.trList = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.trList)).BeginInit();
            this.SuspendLayout();
            // 
            // trList
            // 
            this.trList.Appearance.FocusedCell.BackColor = System.Drawing.Color.CornflowerBlue;
            this.trList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trList.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lavender;
            this.trList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.trList.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lavender;
            this.trList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.trList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colName,
            this.colType});
            this.trList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trList.Location = new System.Drawing.Point(0, 0);
            this.trList.Name = "trList";
            this.trList.OptionsBehavior.Editable = false;
            this.trList.OptionsCustomization.AllowQuickHideColumns = false;
            this.trList.OptionsFilter.AllowFilterEditor = false;
            this.trList.Size = new System.Drawing.Size(281, 406);
            this.trList.TabIndex = 0;
            this.trList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trList_FocusedNodeChanged);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "colId";
            this.colId.Name = "colId";
            // 
            // colName
            // 
            this.colName.Caption = "名称";
            this.colName.FieldName = "colName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 88;
            // 
            // colType
            // 
            this.colType.Caption = "类型";
            this.colType.FieldName = "colType";
            this.colType.Name = "colType";
            this.colType.Width = 87;
            // 
            // ProductionLineTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trList);
            this.Name = "ProductionLineTree";
            this.Size = new System.Drawing.Size(281, 406);
            ((System.ComponentModel.ISupportInitialize)(this.trList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList trList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
    }
}

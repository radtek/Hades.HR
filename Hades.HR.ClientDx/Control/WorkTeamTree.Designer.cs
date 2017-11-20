namespace Hades.HR.UI
{
    partial class WorkTeamTree
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
            this.tlTeam = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tlTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // tlTeam
            // 
            this.tlTeam.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tlTeam.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tlTeam.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colName,
            this.colType});
            this.tlTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlTeam.Location = new System.Drawing.Point(0, 0);
            this.tlTeam.Name = "tlTeam";
            this.tlTeam.OptionsBehavior.Editable = false;
            this.tlTeam.Size = new System.Drawing.Size(259, 357);
            this.tlTeam.TabIndex = 0;
            this.tlTeam.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlTeam_FocusedNodeChanged);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "colId";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowSort = false;
            this.colId.OptionsFilter.AllowFilter = false;
            // 
            // colName
            // 
            this.colName.Caption = "名称";
            this.colName.FieldName = "colName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.OptionsFilter.AllowFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 120;
            // 
            // colType
            // 
            this.colType.Caption = "类型";
            this.colType.FieldName = "colType";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowSort = false;
            this.colType.OptionsFilter.AllowFilter = false;
            // 
            // WorkTeamTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlTeam);
            this.Name = "WorkTeamTree";
            this.Size = new System.Drawing.Size(259, 357);
            ((System.ComponentModel.ISupportInitialize)(this.tlTeam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlTeam;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
    }
}

namespace Hades.HR.UI
{
    partial class StaffBonusGrid
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
            this.dgcBonus = new DevExpress.XtraGrid.GridControl();
            this.bsBonus = new System.Windows.Forms.BindingSource(this.components);
            this.dgvBonus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonus)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcBonus
            // 
            this.dgcBonus.DataSource = this.bsBonus;
            this.dgcBonus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcBonus.Location = new System.Drawing.Point(0, 0);
            this.dgcBonus.MainView = this.dgvBonus;
            this.dgcBonus.Name = "dgcBonus";
            this.dgcBonus.Size = new System.Drawing.Size(443, 268);
            this.dgcBonus.TabIndex = 0;
            this.dgcBonus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvBonus});
            // 
            // bsBonus
            // 
            this.bsBonus.DataSource = typeof(Hades.HR.Entity.StaffBonusInfo);
            // 
            // dgvBonus
            // 
            this.dgvBonus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStaffId,
            this.colName,
            this.colAmount,
            this.colRemark});
            this.dgvBonus.GridControl = this.dgcBonus;
            this.dgvBonus.Name = "dgvBonus";
            this.dgvBonus.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvBonus.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvBonus.OptionsCustomization.AllowFilter = false;
            this.dgvBonus.OptionsCustomization.AllowGroup = false;
            this.dgvBonus.OptionsCustomization.AllowSort = false;
            this.dgvBonus.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvBonus.OptionsView.EnableAppearanceOddRow = true;
            this.dgvBonus.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.dgvBonus.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colStaffId
            // 
            this.colStaffId.Caption = "员工姓名";
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.OptionsColumn.AllowEdit = false;
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "奖金名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "奖金金额";
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 2;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            // 
            // StaffBonusGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcBonus);
            this.Name = "StaffBonusGrid";
            this.Size = new System.Drawing.Size(443, 268);
            this.Load += new System.EventHandler(this.StaffBonusGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcBonus;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvBonus;
        private System.Windows.Forms.BindingSource bsBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}

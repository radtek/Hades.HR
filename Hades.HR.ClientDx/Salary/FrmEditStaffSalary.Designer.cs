namespace Hades.HR.UI
{
    partial class FrmEditStaffSalary
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDepartment = new DevExpress.XtraEditors.TextEdit();
            this.txtMonth = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgcSalary = new DevExpress.XtraGrid.GridControl();
            this.bsSalary = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSalary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffLevelId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReserveFund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsurance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNormalOvertimeSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendOvertimeSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidayOvertimeSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalOverTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(669, 472);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(768, 472);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(582, 472);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 465);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 469);
            this.picPrint.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(855, 84);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "基本信息";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtDepartment);
            this.layoutControl2.Controls.Add(this.txtMonth);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 25);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(851, 57);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(411, 14);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Properties.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(426, 24);
            this.txtDepartment.StyleController = this.layoutControl2;
            this.txtDepartment.TabIndex = 5;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(47, 14);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Properties.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(327, 24);
            this.txtMonth.StyleController = this.layoutControl2;
            this.txtMonth.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(851, 57);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMonth;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(364, 33);
            this.layoutControlItem1.Text = "月度";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(30, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDepartment;
            this.layoutControlItem2.Location = new System.Drawing.Point(364, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(463, 33);
            this.layoutControlItem2.Text = "部门";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(30, 18);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcSalary);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 84);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(855, 353);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "工资信息";
            // 
            // dgcSalary
            // 
            this.dgcSalary.DataSource = this.bsSalary;
            this.dgcSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcSalary.Location = new System.Drawing.Point(2, 25);
            this.dgcSalary.MainView = this.dgvSalary;
            this.dgcSalary.Name = "dgcSalary";
            this.dgcSalary.Size = new System.Drawing.Size(851, 326);
            this.dgcSalary.TabIndex = 0;
            this.dgcSalary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvSalary});
            // 
            // bsSalary
            // 
            this.bsSalary.DataSource = typeof(Hades.HR.Entity.StaffSalaryInfo);
            // 
            // dgvSalary
            // 
            this.dgvSalary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStaffId,
            this.colDepartmentId,
            this.colStaffLevelId,
            this.colLevelSalary,
            this.colBaseBonus,
            this.colDepartmentBonus,
            this.colReserveFund,
            this.colInsurance,
            this.colNormalOvertimeSalary,
            this.colWeekendOvertimeSalary,
            this.colHolidayOvertimeSalary,
            this.colTotalOverTime,
            this.colTotal,
            this.colRemark});
            this.dgvSalary.GridControl = this.dgcSalary;
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.OptionsView.ShowGroupPanel = false;
            this.dgvSalary.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvSalary_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colStaffId
            // 
            this.colStaffId.Caption = "职员姓名";
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.OptionsColumn.AllowEdit = false;
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 0;
            // 
            // colDepartmentId
            // 
            this.colDepartmentId.FieldName = "DepartmentId";
            this.colDepartmentId.Name = "colDepartmentId";
            this.colDepartmentId.OptionsColumn.AllowEdit = false;
            // 
            // colStaffLevelId
            // 
            this.colStaffLevelId.Caption = "职员级别";
            this.colStaffLevelId.FieldName = "StaffLevelId";
            this.colStaffLevelId.Name = "colStaffLevelId";
            this.colStaffLevelId.OptionsColumn.AllowEdit = false;
            this.colStaffLevelId.Visible = true;
            this.colStaffLevelId.VisibleIndex = 1;
            // 
            // colLevelSalary
            // 
            this.colLevelSalary.Caption = "级别工资";
            this.colLevelSalary.FieldName = "LevelSalary";
            this.colLevelSalary.Name = "colLevelSalary";
            this.colLevelSalary.OptionsColumn.AllowEdit = false;
            this.colLevelSalary.Visible = true;
            this.colLevelSalary.VisibleIndex = 2;
            // 
            // colBaseBonus
            // 
            this.colBaseBonus.Caption = "基本奖金";
            this.colBaseBonus.FieldName = "BaseBonus";
            this.colBaseBonus.Name = "colBaseBonus";
            this.colBaseBonus.OptionsColumn.AllowEdit = false;
            this.colBaseBonus.Visible = true;
            this.colBaseBonus.VisibleIndex = 3;
            // 
            // colDepartmentBonus
            // 
            this.colDepartmentBonus.Caption = "部门奖金";
            this.colDepartmentBonus.FieldName = "DepartmentBonus";
            this.colDepartmentBonus.Name = "colDepartmentBonus";
            this.colDepartmentBonus.OptionsColumn.AllowEdit = false;
            this.colDepartmentBonus.Visible = true;
            this.colDepartmentBonus.VisibleIndex = 4;
            // 
            // colReserveFund
            // 
            this.colReserveFund.Caption = "公积金";
            this.colReserveFund.FieldName = "ReserveFund";
            this.colReserveFund.Name = "colReserveFund";
            this.colReserveFund.OptionsColumn.AllowEdit = false;
            this.colReserveFund.Visible = true;
            this.colReserveFund.VisibleIndex = 5;
            // 
            // colInsurance
            // 
            this.colInsurance.Caption = "保险费";
            this.colInsurance.FieldName = "Insurance";
            this.colInsurance.Name = "colInsurance";
            this.colInsurance.OptionsColumn.AllowEdit = false;
            this.colInsurance.Visible = true;
            this.colInsurance.VisibleIndex = 6;
            // 
            // colNormalOvertimeSalary
            // 
            this.colNormalOvertimeSalary.Caption = "平时加班工资";
            this.colNormalOvertimeSalary.FieldName = "NormalOvertimeSalary";
            this.colNormalOvertimeSalary.Name = "colNormalOvertimeSalary";
            this.colNormalOvertimeSalary.Visible = true;
            this.colNormalOvertimeSalary.VisibleIndex = 7;
            // 
            // colWeekendOvertimeSalary
            // 
            this.colWeekendOvertimeSalary.Caption = "周末加班工资";
            this.colWeekendOvertimeSalary.FieldName = "WeekendOvertimeSalary";
            this.colWeekendOvertimeSalary.Name = "colWeekendOvertimeSalary";
            this.colWeekendOvertimeSalary.Visible = true;
            this.colWeekendOvertimeSalary.VisibleIndex = 8;
            // 
            // colHolidayOvertimeSalary
            // 
            this.colHolidayOvertimeSalary.Caption = "节假日加班工资";
            this.colHolidayOvertimeSalary.FieldName = "HolidayOvertimeSalary";
            this.colHolidayOvertimeSalary.Name = "colHolidayOvertimeSalary";
            this.colHolidayOvertimeSalary.Visible = true;
            this.colHolidayOvertimeSalary.VisibleIndex = 9;
            // 
            // colTotalOverTime
            // 
            this.colTotalOverTime.Caption = "加班工资合计";
            this.colTotalOverTime.FieldName = "colTotalOverTime";
            this.colTotalOverTime.Name = "colTotalOverTime";
            this.colTotalOverTime.OptionsColumn.AllowEdit = false;
            this.colTotalOverTime.UnboundExpression = "[NormalOvertimeSalary] + [WeekendOvertimeSalary] + [HolidayOvertimeSalary]";
            this.colTotalOverTime.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTotalOverTime.Visible = true;
            this.colTotalOverTime.VisibleIndex = 10;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "工资合计";
            this.colTotal.FieldName = "colTotal";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.UnboundExpression = "[LevelSalary] + [BaseBonus] + [DepartmentBonus] + [ReserveFund] + [Insurance] + [" +
    "colTotalOverTime]";
            this.colTotal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 11;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 12;
            // 
            // FrmEditStaffSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 507);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmEditStaffSalary";
            this.Text = "StaffSalary";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.TextEdit txtDepartment;
        private DevExpress.XtraEditors.TextEdit txtMonth;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dgcSalary;
        private System.Windows.Forms.BindingSource bsSalary;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffLevelId;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colReserveFund;
        private DevExpress.XtraGrid.Columns.GridColumn colInsurance;
        private DevExpress.XtraGrid.Columns.GridColumn colNormalOvertimeSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendOvertimeSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidayOvertimeSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalOverTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
    }
}
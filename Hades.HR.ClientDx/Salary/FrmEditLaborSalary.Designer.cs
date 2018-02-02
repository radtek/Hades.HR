namespace Hades.HR.UI
{
    partial class FrmEditLaborSalary
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
            this.txtWorkTeam = new DevExpress.XtraEditors.TextEdit();
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
            this.colStaffLevelId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOverSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidaySalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstimation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeam.Properties)).BeginInit();
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
            this.btnOK.Location = new System.Drawing.Point(863, 504);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(962, 504);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(776, 504);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 499);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 501);
            this.picPrint.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1049, 69);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "基本信息";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtWorkTeam);
            this.layoutControl2.Controls.Add(this.txtMonth);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 25);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1045, 42);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtWorkTeam
            // 
            this.txtWorkTeam.Location = new System.Drawing.Point(487, 14);
            this.txtWorkTeam.Name = "txtWorkTeam";
            this.txtWorkTeam.Properties.ReadOnly = true;
            this.txtWorkTeam.Size = new System.Drawing.Size(523, 24);
            this.txtWorkTeam.StyleController = this.layoutControl2;
            this.txtWorkTeam.TabIndex = 5;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(47, 14);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Properties.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(403, 24);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(1024, 52);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMonth;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(440, 28);
            this.layoutControlItem1.Text = "月度";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(30, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtWorkTeam;
            this.layoutControlItem2.Location = new System.Drawing.Point(440, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(560, 28);
            this.layoutControlItem2.Text = "班组";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(30, 18);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcSalary);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 69);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1049, 388);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "工资信息";
            // 
            // dgcSalary
            // 
            this.dgcSalary.DataSource = this.bsSalary;
            this.dgcSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcSalary.Location = new System.Drawing.Point(2, 25);
            this.dgcSalary.MainView = this.dgvSalary;
            this.dgcSalary.Name = "dgcSalary";
            this.dgcSalary.Size = new System.Drawing.Size(1045, 361);
            this.dgcSalary.TabIndex = 0;
            this.dgcSalary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvSalary});
            // 
            // bsSalary
            // 
            this.bsSalary.DataSource = typeof(Hades.HR.Entity.LaborSalaryInfo);
            // 
            // dgvSalary
            // 
            this.dgvSalary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStaffId,
            this.colStaffLevelId,
            this.colLevelSalary,
            this.colBaseSalary,
            this.colOverSalary,
            this.colWeekendSalary,
            this.colHolidaySalary,
            this.colEstimation,
            this.colAllowance,
            this.colTotal,
            this.colShiftAmount,
            this.colRemark});
            this.dgvSalary.GridControl = this.dgcSalary;
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvSalary.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvSalary.OptionsCustomization.AllowFilter = false;
            this.dgvSalary.OptionsCustomization.AllowGroup = false;
            this.dgvSalary.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvSalary.OptionsCustomization.AllowSort = false;
            this.dgvSalary.OptionsFilter.AllowFilterEditor = false;
            this.dgvSalary.OptionsView.ShowGroupPanel = false;
            this.dgvSalary.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvSalary_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
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
            this.colLevelSalary.DisplayFormat.FormatString = "0.000";
            this.colLevelSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLevelSalary.FieldName = "LevelSalary";
            this.colLevelSalary.Name = "colLevelSalary";
            this.colLevelSalary.OptionsColumn.AllowEdit = false;
            this.colLevelSalary.Visible = true;
            this.colLevelSalary.VisibleIndex = 2;
            // 
            // colBaseSalary
            // 
            this.colBaseSalary.Caption = "基本工资";
            this.colBaseSalary.DisplayFormat.FormatString = "0.000";
            this.colBaseSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBaseSalary.FieldName = "BaseSalary";
            this.colBaseSalary.Name = "colBaseSalary";
            this.colBaseSalary.OptionsColumn.AllowEdit = false;
            this.colBaseSalary.Visible = true;
            this.colBaseSalary.VisibleIndex = 3;
            // 
            // colOverSalary
            // 
            this.colOverSalary.Caption = "超产工资";
            this.colOverSalary.DisplayFormat.FormatString = "0.000";
            this.colOverSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOverSalary.FieldName = "OverSalary";
            this.colOverSalary.Name = "colOverSalary";
            this.colOverSalary.OptionsColumn.AllowEdit = false;
            this.colOverSalary.Visible = true;
            this.colOverSalary.VisibleIndex = 4;
            // 
            // colWeekendSalary
            // 
            this.colWeekendSalary.Caption = "周末工资";
            this.colWeekendSalary.DisplayFormat.FormatString = "0.000";
            this.colWeekendSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWeekendSalary.FieldName = "WeekendSalary";
            this.colWeekendSalary.Name = "colWeekendSalary";
            this.colWeekendSalary.OptionsColumn.AllowEdit = false;
            this.colWeekendSalary.Visible = true;
            this.colWeekendSalary.VisibleIndex = 5;
            // 
            // colHolidaySalary
            // 
            this.colHolidaySalary.Caption = "法定假日工资";
            this.colHolidaySalary.DisplayFormat.FormatString = "0.000";
            this.colHolidaySalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHolidaySalary.FieldName = "HolidaySalary";
            this.colHolidaySalary.Name = "colHolidaySalary";
            this.colHolidaySalary.OptionsColumn.AllowEdit = false;
            this.colHolidaySalary.Visible = true;
            this.colHolidaySalary.VisibleIndex = 6;
            // 
            // colEstimation
            // 
            this.colEstimation.Caption = "月综合考核奖";
            this.colEstimation.DisplayFormat.FormatString = "0.000";
            this.colEstimation.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEstimation.FieldName = "Estimation";
            this.colEstimation.Name = "colEstimation";
            this.colEstimation.Visible = true;
            this.colEstimation.VisibleIndex = 7;
            // 
            // colAllowance
            // 
            this.colAllowance.Caption = "月度津贴";
            this.colAllowance.DisplayFormat.FormatString = "0.000";
            this.colAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAllowance.FieldName = "Allowance";
            this.colAllowance.Name = "colAllowance";
            this.colAllowance.Visible = true;
            this.colAllowance.VisibleIndex = 8;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "工资合计";
            this.colTotal.DisplayFormat.FormatString = "0.000";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "colTotal";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.UnboundExpression = "[BaseSalary] + [OverSalary] + [WeekendSalary] + [HolidaySalary] + [Allowance] + [" +
    "Estimation]";
            this.colTotal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 9;
            // 
            // colShiftAmount
            // 
            this.colShiftAmount.Caption = "中夜班金额";
            this.colShiftAmount.DisplayFormat.FormatString = "0.000";
            this.colShiftAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colShiftAmount.FieldName = "ShiftAmount";
            this.colShiftAmount.Name = "colShiftAmount";
            this.colShiftAmount.Visible = true;
            this.colShiftAmount.VisibleIndex = 10;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 11;
            // 
            // FrmEditLaborSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 539);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmEditLaborSalary";
            this.Text = "LaborSalary";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeam.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtWorkTeam;
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
        private DevExpress.XtraGrid.Columns.GridColumn colStaffLevelId;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colOverSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidaySalary;
        private DevExpress.XtraGrid.Columns.GridColumn colEstimation;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowance;
        private DevExpress.XtraGrid.Columns.GridColumn colShiftAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
    }
}
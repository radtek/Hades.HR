namespace Hades.HR.UI
{
    partial class FrmEditLaborSalaryRecord
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgcSalary = new DevExpress.XtraGrid.GridControl();
            this.bsSalaryRecords = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSalary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnnualLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSickLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCasualLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInjuryLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarriageLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsentLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffLevelId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonthWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOverWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOverSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidayWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidaySalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstimation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkshopDeduction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkshopBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBonusDeduction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalSalary2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoonShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNightShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherNoon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherNight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQualityBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeduction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNutrition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEquipmentBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSafetyBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiveSBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHotBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLunchAllowance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalaryRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(684, 486);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(783, 486);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(597, 486);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 481);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 483);
            // 
            // groupControl1
            // 
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(870, 100);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "班组信息";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcSalary);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 100);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(870, 354);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "工资记录";
            // 
            // dgcSalary
            // 
            this.dgcSalary.DataSource = this.bsSalaryRecords;
            this.dgcSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcSalary.Location = new System.Drawing.Point(2, 21);
            this.dgcSalary.MainView = this.dgvSalary;
            this.dgcSalary.Name = "dgcSalary";
            this.dgcSalary.Size = new System.Drawing.Size(866, 331);
            this.dgcSalary.TabIndex = 0;
            this.dgcSalary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvSalary});
            // 
            // bsSalaryRecords
            // 
            this.bsSalaryRecords.DataSource = typeof(Hades.HR.Entity.LaborSalaryRecordInfo);
            // 
            // dgvSalary
            // 
            this.dgvSalary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colAttendanceId,
            this.colStaffNumber,
            this.colStaffId,
            this.colAttendanceDays,
            this.colAnnualLeave,
            this.colSickLeave,
            this.colCasualLeave,
            this.colInjuryLeave,
            this.colMarriageLeave,
            this.colAbsentLeave,
            this.colStaffLevelId,
            this.colLevelSalary,
            this.colMonthWorkload,
            this.colBaseWorkload,
            this.colBaseSalary,
            this.colOverWorkload,
            this.colOverSalary,
            this.colWeekendWorkload,
            this.colWeekendSalary,
            this.colHolidayWorkload,
            this.colHolidaySalary,
            this.colEstimation,
            this.colAllowance,
            this.colWorkshopDeduction,
            this.colWorkshopBonus,
            this.colBonusDeduction,
            this.colTotalSalary2,
            this.colNoonShift,
            this.colNightShift,
            this.colOtherNoon,
            this.colOtherNight,
            this.colShiftAmount,
            this.colQualityBonus,
            this.colDeduction,
            this.colNutrition,
            this.colEquipmentBonus,
            this.colSafetyBonus,
            this.colFiveSBonus,
            this.colHotBonus,
            this.colLunchAllowance,
            this.colRemark});
            this.dgvSalary.GridControl = this.dgcSalary;
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.OptionsView.ColumnAutoWidth = false;
            this.dgvSalary.OptionsView.ShowGroupPanel = false;
            this.dgvSalary.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvSalary_CustomUnboundColumnData);
            this.dgvSalary.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvSalary_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colAttendanceId
            // 
            this.colAttendanceId.FieldName = "AttendanceId";
            this.colAttendanceId.Name = "colAttendanceId";
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.Caption = "职员工号";
            this.colStaffNumber.FieldName = "StaffNumber";
            this.colStaffNumber.Name = "colStaffNumber";
            this.colStaffNumber.OptionsColumn.AllowEdit = false;
            this.colStaffNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStaffNumber.Visible = true;
            this.colStaffNumber.VisibleIndex = 0;
            // 
            // colStaffId
            // 
            this.colStaffId.Caption = "职员姓名";
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.OptionsColumn.AllowEdit = false;
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 1;
            // 
            // colAttendanceDays
            // 
            this.colAttendanceDays.Caption = "出勤天数";
            this.colAttendanceDays.FieldName = "AttendanceDays";
            this.colAttendanceDays.Name = "colAttendanceDays";
            this.colAttendanceDays.OptionsColumn.AllowEdit = false;
            this.colAttendanceDays.Visible = true;
            this.colAttendanceDays.VisibleIndex = 2;
            // 
            // colAnnualLeave
            // 
            this.colAnnualLeave.Caption = "年假天数";
            this.colAnnualLeave.FieldName = "AnnualLeave";
            this.colAnnualLeave.Name = "colAnnualLeave";
            this.colAnnualLeave.OptionsColumn.AllowEdit = false;
            this.colAnnualLeave.Visible = true;
            this.colAnnualLeave.VisibleIndex = 3;
            // 
            // colSickLeave
            // 
            this.colSickLeave.Caption = "病假天数";
            this.colSickLeave.FieldName = "SickLeave";
            this.colSickLeave.Name = "colSickLeave";
            this.colSickLeave.OptionsColumn.AllowEdit = false;
            this.colSickLeave.Visible = true;
            this.colSickLeave.VisibleIndex = 4;
            // 
            // colCasualLeave
            // 
            this.colCasualLeave.Caption = "事假天数";
            this.colCasualLeave.FieldName = "CasualLeave";
            this.colCasualLeave.Name = "colCasualLeave";
            this.colCasualLeave.OptionsColumn.AllowEdit = false;
            this.colCasualLeave.Visible = true;
            this.colCasualLeave.VisibleIndex = 5;
            // 
            // colInjuryLeave
            // 
            this.colInjuryLeave.Caption = "工伤天数";
            this.colInjuryLeave.FieldName = "InjuryLeave";
            this.colInjuryLeave.Name = "colInjuryLeave";
            this.colInjuryLeave.OptionsColumn.AllowEdit = false;
            this.colInjuryLeave.Visible = true;
            this.colInjuryLeave.VisibleIndex = 6;
            // 
            // colMarriageLeave
            // 
            this.colMarriageLeave.Caption = "婚产丧假天数";
            this.colMarriageLeave.FieldName = "MarriageLeave";
            this.colMarriageLeave.Name = "colMarriageLeave";
            this.colMarriageLeave.OptionsColumn.AllowEdit = false;
            this.colMarriageLeave.Visible = true;
            this.colMarriageLeave.VisibleIndex = 7;
            // 
            // colAbsentLeave
            // 
            this.colAbsentLeave.Caption = "旷工天数";
            this.colAbsentLeave.FieldName = "AbsentLeave";
            this.colAbsentLeave.Name = "colAbsentLeave";
            this.colAbsentLeave.OptionsColumn.AllowEdit = false;
            this.colAbsentLeave.Visible = true;
            this.colAbsentLeave.VisibleIndex = 8;
            // 
            // colStaffLevelId
            // 
            this.colStaffLevelId.Caption = "职员等级";
            this.colStaffLevelId.FieldName = "StaffLevelId";
            this.colStaffLevelId.Name = "colStaffLevelId";
            this.colStaffLevelId.OptionsColumn.AllowEdit = false;
            this.colStaffLevelId.Visible = true;
            this.colStaffLevelId.VisibleIndex = 9;
            // 
            // colLevelSalary
            // 
            this.colLevelSalary.Caption = "级别工资";
            this.colLevelSalary.FieldName = "LevelSalary";
            this.colLevelSalary.Name = "colLevelSalary";
            this.colLevelSalary.OptionsColumn.AllowEdit = false;
            this.colLevelSalary.Visible = true;
            this.colLevelSalary.VisibleIndex = 10;
            // 
            // colMonthWorkload
            // 
            this.colMonthWorkload.Caption = "月工作总量";
            this.colMonthWorkload.FieldName = "MonthWorkload";
            this.colMonthWorkload.Name = "colMonthWorkload";
            this.colMonthWorkload.OptionsColumn.AllowEdit = false;
            this.colMonthWorkload.Visible = true;
            this.colMonthWorkload.VisibleIndex = 11;
            // 
            // colBaseWorkload
            // 
            this.colBaseWorkload.Caption = "基本工作量";
            this.colBaseWorkload.FieldName = "BaseWorkload";
            this.colBaseWorkload.Name = "colBaseWorkload";
            this.colBaseWorkload.OptionsColumn.AllowEdit = false;
            this.colBaseWorkload.Visible = true;
            this.colBaseWorkload.VisibleIndex = 12;
            // 
            // colBaseSalary
            // 
            this.colBaseSalary.Caption = "基本工资";
            this.colBaseSalary.FieldName = "BaseSalary";
            this.colBaseSalary.Name = "colBaseSalary";
            this.colBaseSalary.OptionsColumn.AllowEdit = false;
            this.colBaseSalary.Visible = true;
            this.colBaseSalary.VisibleIndex = 13;
            // 
            // colOverWorkload
            // 
            this.colOverWorkload.Caption = "超产工作量";
            this.colOverWorkload.FieldName = "OverWorkload";
            this.colOverWorkload.Name = "colOverWorkload";
            this.colOverWorkload.OptionsColumn.AllowEdit = false;
            this.colOverWorkload.Visible = true;
            this.colOverWorkload.VisibleIndex = 14;
            // 
            // colOverSalary
            // 
            this.colOverSalary.Caption = "超产工资";
            this.colOverSalary.FieldName = "OverSalary";
            this.colOverSalary.Name = "colOverSalary";
            this.colOverSalary.OptionsColumn.AllowEdit = false;
            this.colOverSalary.Visible = true;
            this.colOverSalary.VisibleIndex = 15;
            // 
            // colWeekendWorkload
            // 
            this.colWeekendWorkload.Caption = "周末工作量";
            this.colWeekendWorkload.FieldName = "WeekendWorkload";
            this.colWeekendWorkload.Name = "colWeekendWorkload";
            this.colWeekendWorkload.OptionsColumn.AllowEdit = false;
            this.colWeekendWorkload.Visible = true;
            this.colWeekendWorkload.VisibleIndex = 16;
            // 
            // colWeekendSalary
            // 
            this.colWeekendSalary.Caption = "周末工资";
            this.colWeekendSalary.FieldName = "WeekendSalary";
            this.colWeekendSalary.Name = "colWeekendSalary";
            this.colWeekendSalary.OptionsColumn.AllowEdit = false;
            this.colWeekendSalary.Visible = true;
            this.colWeekendSalary.VisibleIndex = 17;
            // 
            // colHolidayWorkload
            // 
            this.colHolidayWorkload.Caption = "法定假日工作量";
            this.colHolidayWorkload.FieldName = "HolidayWorkload";
            this.colHolidayWorkload.Name = "colHolidayWorkload";
            this.colHolidayWorkload.OptionsColumn.AllowEdit = false;
            this.colHolidayWorkload.Visible = true;
            this.colHolidayWorkload.VisibleIndex = 18;
            // 
            // colHolidaySalary
            // 
            this.colHolidaySalary.Caption = "法定假日工资";
            this.colHolidaySalary.FieldName = "HolidaySalary";
            this.colHolidaySalary.Name = "colHolidaySalary";
            this.colHolidaySalary.OptionsColumn.AllowEdit = false;
            this.colHolidaySalary.Visible = true;
            this.colHolidaySalary.VisibleIndex = 19;
            // 
            // colEstimation
            // 
            this.colEstimation.Caption = "月综合考核奖";
            this.colEstimation.FieldName = "Estimation";
            this.colEstimation.Name = "colEstimation";
            this.colEstimation.Visible = true;
            this.colEstimation.VisibleIndex = 20;
            // 
            // colAllowance
            // 
            this.colAllowance.Caption = "月度津贴";
            this.colAllowance.FieldName = "Allowance";
            this.colAllowance.Name = "colAllowance";
            this.colAllowance.Visible = true;
            this.colAllowance.VisibleIndex = 21;
            // 
            // colWorkshopDeduction
            // 
            this.colWorkshopDeduction.Caption = "车间扣款";
            this.colWorkshopDeduction.FieldName = "WorkshopDeduction";
            this.colWorkshopDeduction.Name = "colWorkshopDeduction";
            this.colWorkshopDeduction.Visible = true;
            this.colWorkshopDeduction.VisibleIndex = 22;
            // 
            // colWorkshopBonus
            // 
            this.colWorkshopBonus.Caption = "车间奖励";
            this.colWorkshopBonus.FieldName = "WorkshopBonus";
            this.colWorkshopBonus.Name = "colWorkshopBonus";
            this.colWorkshopBonus.Visible = true;
            this.colWorkshopBonus.VisibleIndex = 23;
            // 
            // colBonusDeduction
            // 
            this.colBonusDeduction.Caption = "奖金扣款";
            this.colBonusDeduction.FieldName = "BonusDeduction";
            this.colBonusDeduction.Name = "colBonusDeduction";
            this.colBonusDeduction.Visible = true;
            this.colBonusDeduction.VisibleIndex = 24;
            // 
            // colTotalSalary2
            // 
            this.colTotalSalary2.Caption = "工资合计";
            this.colTotalSalary2.FieldName = "colTotalSalary2";
            this.colTotalSalary2.Name = "colTotalSalary2";
            this.colTotalSalary2.OptionsColumn.AllowEdit = false;
            this.colTotalSalary2.UnboundExpression = "[BaseSalary] + [OverSalary] + [WeekendSalary] + [HolidaySalary] + [Estimation] + " +
    "[Allowance] - [WorkshopDeduction] + [WorkshopBonus] - [BonusDeduction]";
            this.colTotalSalary2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTotalSalary2.Visible = true;
            this.colTotalSalary2.VisibleIndex = 26;
            // 
            // colNoonShift
            // 
            this.colNoonShift.Caption = "中班天数";
            this.colNoonShift.FieldName = "NoonShift";
            this.colNoonShift.Name = "colNoonShift";
            this.colNoonShift.Visible = true;
            this.colNoonShift.VisibleIndex = 25;
            // 
            // colNightShift
            // 
            this.colNightShift.Caption = "夜班天数";
            this.colNightShift.FieldName = "NightShift";
            this.colNightShift.Name = "colNightShift";
            this.colNightShift.Visible = true;
            this.colNightShift.VisibleIndex = 27;
            // 
            // colOtherNoon
            // 
            this.colOtherNoon.Caption = "其它中班";
            this.colOtherNoon.FieldName = "OtherNoon";
            this.colOtherNoon.Name = "colOtherNoon";
            this.colOtherNoon.Visible = true;
            this.colOtherNoon.VisibleIndex = 28;
            // 
            // colOtherNight
            // 
            this.colOtherNight.Caption = "其它夜班";
            this.colOtherNight.FieldName = "OtherNight";
            this.colOtherNight.Name = "colOtherNight";
            this.colOtherNight.Visible = true;
            this.colOtherNight.VisibleIndex = 29;
            // 
            // colShiftAmount
            // 
            this.colShiftAmount.Caption = "中夜班金额";
            this.colShiftAmount.FieldName = "ShiftAmount";
            this.colShiftAmount.Name = "colShiftAmount";
            this.colShiftAmount.Visible = true;
            this.colShiftAmount.VisibleIndex = 30;
            // 
            // colQualityBonus
            // 
            this.colQualityBonus.Caption = "质量奖";
            this.colQualityBonus.FieldName = "QualityBonus";
            this.colQualityBonus.Name = "colQualityBonus";
            this.colQualityBonus.Visible = true;
            this.colQualityBonus.VisibleIndex = 31;
            // 
            // colDeduction
            // 
            this.colDeduction.Caption = "扣款";
            this.colDeduction.FieldName = "Deduction";
            this.colDeduction.Name = "colDeduction";
            this.colDeduction.Visible = true;
            this.colDeduction.VisibleIndex = 32;
            // 
            // colNutrition
            // 
            this.colNutrition.Caption = "营养奖";
            this.colNutrition.FieldName = "Nutrition";
            this.colNutrition.Name = "colNutrition";
            this.colNutrition.Visible = true;
            this.colNutrition.VisibleIndex = 33;
            // 
            // colEquipmentBonus
            // 
            this.colEquipmentBonus.Caption = "设备维护奖";
            this.colEquipmentBonus.FieldName = "EquipmentBonus";
            this.colEquipmentBonus.Name = "colEquipmentBonus";
            this.colEquipmentBonus.Visible = true;
            this.colEquipmentBonus.VisibleIndex = 34;
            // 
            // colSafetyBonus
            // 
            this.colSafetyBonus.Caption = "安全奖";
            this.colSafetyBonus.FieldName = "SafetyBonus";
            this.colSafetyBonus.Name = "colSafetyBonus";
            this.colSafetyBonus.Visible = true;
            this.colSafetyBonus.VisibleIndex = 35;
            // 
            // colFiveSBonus
            // 
            this.colFiveSBonus.Caption = "5S扣款";
            this.colFiveSBonus.FieldName = "FiveSBonus";
            this.colFiveSBonus.Name = "colFiveSBonus";
            this.colFiveSBonus.Visible = true;
            this.colFiveSBonus.VisibleIndex = 36;
            // 
            // colHotBonus
            // 
            this.colHotBonus.Caption = "高温费";
            this.colHotBonus.FieldName = "HotBonus";
            this.colHotBonus.Name = "colHotBonus";
            this.colHotBonus.Visible = true;
            this.colHotBonus.VisibleIndex = 37;
            // 
            // colLunchAllowance
            // 
            this.colLunchAllowance.Caption = "午餐补贴";
            this.colLunchAllowance.FieldName = "LunchAllowance";
            this.colLunchAllowance.Name = "colLunchAllowance";
            this.colLunchAllowance.Visible = true;
            this.colLunchAllowance.VisibleIndex = 38;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 39;
            // 
            // FrmEditLaborSalaryRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 521);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmEditLaborSalaryRecord";
            this.Text = "LaborSalaryRecord";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalaryRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dgcSalary;
        private System.Windows.Forms.BindingSource bsSalaryRecords;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceDays;
        private DevExpress.XtraGrid.Columns.GridColumn colAnnualLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colSickLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colCasualLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colInjuryLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colMarriageLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsentLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffLevelId;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidayWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colEstimation;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowance;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkshopDeduction;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkshopBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colBonusDeduction;
        private DevExpress.XtraGrid.Columns.GridColumn colNoonShift;
        private DevExpress.XtraGrid.Columns.GridColumn colNightShift;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherNoon;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherNight;
        private DevExpress.XtraGrid.Columns.GridColumn colShiftAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colQualityBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colDeduction;
        private DevExpress.XtraGrid.Columns.GridColumn colNutrition;
        private DevExpress.XtraGrid.Columns.GridColumn colEquipmentBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colSafetyBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colFiveSBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colHotBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colLunchAllowance;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colOverWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colOverSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidaySalary;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalSalary2;
    }
}
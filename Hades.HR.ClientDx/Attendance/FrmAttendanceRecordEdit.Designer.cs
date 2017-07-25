namespace Hades.HR.UI
{
    partial class FrmAttendanceRecordEdit
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
            this.dgcAttendance = new DevExpress.XtraGrid.GridControl();
            this.bsAttendanceRecord = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnnualLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSickLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCasualLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInjuryLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarriageLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBindLeaveDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNormalOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNormalOvertimeSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendOvertimeSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidayOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidayOvertimeSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBindOvertimeSalarySum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertimeSalarySum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoonShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNightShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLunchAllowance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaderAllowance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeduction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNutrition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.txtDays = new DevExpress.XtraEditors.TextEdit();
            this.txtAttendanceDate = new DevExpress.XtraEditors.TextEdit();
            this.txtDepartmentName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttendanceRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(764, 451);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(863, 451);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(677, 451);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(6, 451);
            this.dataNavigator1.Visible = false;
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(196, 451);
            this.picPrint.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgcAttendance);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 49);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(984, 353);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "考勤记录";
            // 
            // dgcAttendance
            // 
            this.dgcAttendance.DataSource = this.bsAttendanceRecord;
            this.dgcAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcAttendance.Location = new System.Drawing.Point(2, 21);
            this.dgcAttendance.MainView = this.dgvAttendance;
            this.dgcAttendance.Name = "dgcAttendance";
            this.dgcAttendance.Size = new System.Drawing.Size(980, 330);
            this.dgcAttendance.TabIndex = 0;
            this.dgcAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvAttendance});
            // 
            // bsAttendanceRecord
            // 
            this.bsAttendanceRecord.DataSource = typeof(Hades.HR.Entity.AttendanceRecordInfo);
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.dgvAttendance.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.dgvAttendance.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.dgvAttendance.ColumnPanelRowHeight = 50;
            this.dgvAttendance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colAttendanceId,
            this.colStaffId,
            this.colAttendanceDays,
            this.colAnnualLeave,
            this.colSickLeave,
            this.colCasualLeave,
            this.colInjuryLeave,
            this.colMarriageLeave,
            this.colBindLeaveDays,
            this.colLeaveDays,
            this.colNormalOvertime,
            this.colNormalOvertimeSalary,
            this.colWeekendOvertime,
            this.colWeekendOvertimeSalary,
            this.colHolidayOvertime,
            this.colHolidayOvertimeSalary,
            this.colBindOvertimeSalarySum,
            this.colOvertimeSalarySum,
            this.colNoonShift,
            this.colNightShift,
            this.colOtherShift,
            this.colLunchAllowance,
            this.colLeaderAllowance,
            this.colDeduction,
            this.colNutrition,
            this.colRemark});
            this.dgvAttendance.GridControl = this.dgcAttendance;
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvAttendance.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvAttendance.OptionsCustomization.AllowFilter = false;
            this.dgvAttendance.OptionsCustomization.AllowGroup = false;
            this.dgvAttendance.OptionsView.ShowGroupPanel = false;
            this.dgvAttendance.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvAttendance_CustomColumnDisplayText);
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
            // colStaffId
            // 
            this.colStaffId.Caption = "职员姓名";
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.OptionsColumn.AllowEdit = false;
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 0;
            // 
            // colAttendanceDays
            // 
            this.colAttendanceDays.Caption = "出勤天数";
            this.colAttendanceDays.FieldName = "AttendanceDays";
            this.colAttendanceDays.Name = "colAttendanceDays";
            this.colAttendanceDays.Visible = true;
            this.colAttendanceDays.VisibleIndex = 1;
            // 
            // colAnnualLeave
            // 
            this.colAnnualLeave.Caption = "年假天数";
            this.colAnnualLeave.FieldName = "AnnualLeave";
            this.colAnnualLeave.Name = "colAnnualLeave";
            this.colAnnualLeave.Visible = true;
            this.colAnnualLeave.VisibleIndex = 2;
            // 
            // colSickLeave
            // 
            this.colSickLeave.Caption = "病假天数";
            this.colSickLeave.FieldName = "SickLeave";
            this.colSickLeave.Name = "colSickLeave";
            this.colSickLeave.Visible = true;
            this.colSickLeave.VisibleIndex = 3;
            // 
            // colCasualLeave
            // 
            this.colCasualLeave.Caption = "事假天数";
            this.colCasualLeave.FieldName = "CasualLeave";
            this.colCasualLeave.Name = "colCasualLeave";
            this.colCasualLeave.Visible = true;
            this.colCasualLeave.VisibleIndex = 4;
            // 
            // colInjuryLeave
            // 
            this.colInjuryLeave.Caption = "工伤天数";
            this.colInjuryLeave.FieldName = "InjuryLeave";
            this.colInjuryLeave.Name = "colInjuryLeave";
            this.colInjuryLeave.Visible = true;
            this.colInjuryLeave.VisibleIndex = 5;
            // 
            // colMarriageLeave
            // 
            this.colMarriageLeave.Caption = "婚产丧假天数";
            this.colMarriageLeave.FieldName = "MarriageLeave";
            this.colMarriageLeave.Name = "colMarriageLeave";
            this.colMarriageLeave.Visible = true;
            this.colMarriageLeave.VisibleIndex = 6;
            // 
            // colBindLeaveDays
            // 
            this.colBindLeaveDays.Caption = "缺勤天数合计";
            this.colBindLeaveDays.FieldName = "colBindLeaveDays";
            this.colBindLeaveDays.Name = "colBindLeaveDays";
            this.colBindLeaveDays.OptionsColumn.AllowEdit = false;
            this.colBindLeaveDays.UnboundExpression = "[AnnualLeave] + [SickLeave] + [CasualLeave] + [InjuryLeave] + [MarriageLeave]";
            this.colBindLeaveDays.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colBindLeaveDays.Visible = true;
            this.colBindLeaveDays.VisibleIndex = 7;
            // 
            // colLeaveDays
            // 
            this.colLeaveDays.Caption = "缺勤天数合计";
            this.colLeaveDays.FieldName = "LeaveDays";
            this.colLeaveDays.Name = "colLeaveDays";
            // 
            // colNormalOvertime
            // 
            this.colNormalOvertime.Caption = "平时加班工时";
            this.colNormalOvertime.FieldName = "NormalOvertime";
            this.colNormalOvertime.Name = "colNormalOvertime";
            this.colNormalOvertime.Visible = true;
            this.colNormalOvertime.VisibleIndex = 8;
            // 
            // colNormalOvertimeSalary
            // 
            this.colNormalOvertimeSalary.Caption = "平时加班工资";
            this.colNormalOvertimeSalary.FieldName = "NormalOvertimeSalary";
            this.colNormalOvertimeSalary.Name = "colNormalOvertimeSalary";
            this.colNormalOvertimeSalary.Visible = true;
            this.colNormalOvertimeSalary.VisibleIndex = 9;
            // 
            // colWeekendOvertime
            // 
            this.colWeekendOvertime.Caption = "周末加班工时";
            this.colWeekendOvertime.FieldName = "WeekendOvertime";
            this.colWeekendOvertime.Name = "colWeekendOvertime";
            this.colWeekendOvertime.Visible = true;
            this.colWeekendOvertime.VisibleIndex = 10;
            // 
            // colWeekendOvertimeSalary
            // 
            this.colWeekendOvertimeSalary.Caption = "周末加班工资";
            this.colWeekendOvertimeSalary.FieldName = "WeekendOvertimeSalary";
            this.colWeekendOvertimeSalary.Name = "colWeekendOvertimeSalary";
            this.colWeekendOvertimeSalary.Visible = true;
            this.colWeekendOvertimeSalary.VisibleIndex = 11;
            // 
            // colHolidayOvertime
            // 
            this.colHolidayOvertime.Caption = "法定假日加班工时";
            this.colHolidayOvertime.FieldName = "HolidayOvertime";
            this.colHolidayOvertime.Name = "colHolidayOvertime";
            this.colHolidayOvertime.Visible = true;
            this.colHolidayOvertime.VisibleIndex = 12;
            // 
            // colHolidayOvertimeSalary
            // 
            this.colHolidayOvertimeSalary.Caption = "法定假日加班工资";
            this.colHolidayOvertimeSalary.FieldName = "HolidayOvertimeSalary";
            this.colHolidayOvertimeSalary.Name = "colHolidayOvertimeSalary";
            this.colHolidayOvertimeSalary.Visible = true;
            this.colHolidayOvertimeSalary.VisibleIndex = 13;
            // 
            // colBindOvertimeSalarySum
            // 
            this.colBindOvertimeSalarySum.Caption = "加班工资合计";
            this.colBindOvertimeSalarySum.FieldName = "colBindOvertimeSalarySum";
            this.colBindOvertimeSalarySum.Name = "colBindOvertimeSalarySum";
            this.colBindOvertimeSalarySum.OptionsColumn.AllowEdit = false;
            this.colBindOvertimeSalarySum.UnboundExpression = "[NormalOvertimeSalary] + [WeekendOvertimeSalary] + [HolidayOvertimeSalary]";
            this.colBindOvertimeSalarySum.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colBindOvertimeSalarySum.Visible = true;
            this.colBindOvertimeSalarySum.VisibleIndex = 14;
            // 
            // colOvertimeSalarySum
            // 
            this.colOvertimeSalarySum.Caption = "加班工资合计";
            this.colOvertimeSalarySum.FieldName = "OvertimeSalarySum";
            this.colOvertimeSalarySum.Name = "colOvertimeSalarySum";
            // 
            // colNoonShift
            // 
            this.colNoonShift.Caption = "中班天数";
            this.colNoonShift.FieldName = "NoonShift";
            this.colNoonShift.Name = "colNoonShift";
            this.colNoonShift.Visible = true;
            this.colNoonShift.VisibleIndex = 15;
            // 
            // colNightShift
            // 
            this.colNightShift.Caption = "夜班天数";
            this.colNightShift.FieldName = "NightShift";
            this.colNightShift.Name = "colNightShift";
            this.colNightShift.Visible = true;
            this.colNightShift.VisibleIndex = 16;
            // 
            // colOtherShift
            // 
            this.colOtherShift.Caption = "其它中夜班天数";
            this.colOtherShift.FieldName = "OtherShift";
            this.colOtherShift.Name = "colOtherShift";
            this.colOtherShift.Visible = true;
            this.colOtherShift.VisibleIndex = 17;
            // 
            // colLunchAllowance
            // 
            this.colLunchAllowance.Caption = "午餐补贴";
            this.colLunchAllowance.FieldName = "LunchAllowance";
            this.colLunchAllowance.Name = "colLunchAllowance";
            this.colLunchAllowance.Visible = true;
            this.colLunchAllowance.VisibleIndex = 18;
            // 
            // colLeaderAllowance
            // 
            this.colLeaderAllowance.Caption = "班组长补贴";
            this.colLeaderAllowance.FieldName = "LeaderAllowance";
            this.colLeaderAllowance.Name = "colLeaderAllowance";
            this.colLeaderAllowance.Visible = true;
            this.colLeaderAllowance.VisibleIndex = 19;
            // 
            // colDeduction
            // 
            this.colDeduction.Caption = "扣款";
            this.colDeduction.FieldName = "Deduction";
            this.colDeduction.Name = "colDeduction";
            this.colDeduction.Visible = true;
            this.colDeduction.VisibleIndex = 20;
            // 
            // colNutrition
            // 
            this.colNutrition.Caption = "营养费";
            this.colNutrition.FieldName = "Nutrition";
            this.colNutrition.Name = "colNutrition";
            this.colNutrition.Visible = true;
            this.colNutrition.VisibleIndex = 21;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 22;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(984, 49);
            this.panelControl1.TabIndex = 7;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtDays);
            this.layoutControl1.Controls.Add(this.txtAttendanceDate);
            this.layoutControl1.Controls.Add(this.txtDepartmentName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(980, 45);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(730, 12);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(238, 20);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 7;
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(576, 12);
            this.txtDays.Name = "txtDays";
            this.txtDays.Properties.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(99, 20);
            this.txtDays.StyleController = this.layoutControl1;
            this.txtDays.TabIndex = 6;
            // 
            // txtAttendanceDate
            // 
            this.txtAttendanceDate.Location = new System.Drawing.Point(330, 12);
            this.txtAttendanceDate.Name = "txtAttendanceDate";
            this.txtAttendanceDate.Properties.ReadOnly = true;
            this.txtAttendanceDate.Size = new System.Drawing.Size(191, 20);
            this.txtAttendanceDate.StyleController = this.layoutControl1;
            this.txtAttendanceDate.TabIndex = 5;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(63, 12);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Properties.ReadOnly = true;
            this.txtDepartmentName.Size = new System.Drawing.Size(212, 20);
            this.txtDepartmentName.StyleController = this.layoutControl1;
            this.txtDepartmentName.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(980, 45);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDepartmentName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(267, 25);
            this.layoutControlItem1.Text = "部门名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtAttendanceDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(267, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(246, 25);
            this.layoutControlItem2.Text = "考勤时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDays;
            this.layoutControlItem3.Location = new System.Drawing.Point(513, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(154, 25);
            this.layoutControlItem3.Text = "本月天数";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtRemark;
            this.layoutControlItem4.Location = new System.Drawing.Point(667, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(293, 25);
            this.layoutControlItem4.Text = "备注";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // FrmAttendanceRecordEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 486);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmAttendanceRecordEdit";
            this.Text = "编辑考勤记录";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttendanceRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtAttendanceDate;
        private DevExpress.XtraEditors.TextEdit txtDepartmentName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl dgcAttendance;
        private System.Windows.Forms.BindingSource bsAttendanceRecord;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvAttendance;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceDays;
        private DevExpress.XtraGrid.Columns.GridColumn colAnnualLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colSickLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colCasualLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colInjuryLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colMarriageLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colLeaveDays;
        private DevExpress.XtraGrid.Columns.GridColumn colNormalOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colNormalOvertimeSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendOvertimeSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidayOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidayOvertimeSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colOvertimeSalarySum;
        private DevExpress.XtraGrid.Columns.GridColumn colNoonShift;
        private DevExpress.XtraGrid.Columns.GridColumn colNightShift;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherShift;
        private DevExpress.XtraGrid.Columns.GridColumn colLunchAllowance;
        private DevExpress.XtraGrid.Columns.GridColumn colLeaderAllowance;
        private DevExpress.XtraGrid.Columns.GridColumn colDeduction;
        private DevExpress.XtraGrid.Columns.GridColumn colNutrition;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colBindLeaveDays;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private DevExpress.XtraEditors.TextEdit txtDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colBindOvertimeSalarySum;
    }
}
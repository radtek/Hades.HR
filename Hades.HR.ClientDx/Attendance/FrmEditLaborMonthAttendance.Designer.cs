namespace Hades.HR.UI
{
    partial class FrmEditLaborMonthAttendance
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
            this.dgcAttendance = new DevExpress.XtraGrid.GridControl();
            this.bsAttendance = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkTeamId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnnualLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSickLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCasualLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInjuryLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarriageLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaternityLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuneralLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsentLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonthWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOverWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidayWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoonShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNightShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherNoon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherNight = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(798, 394);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(897, 394);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(711, 394);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 389);
            this.dataNavigator1.Visible = false;
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 391);
            this.picPrint.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(984, 69);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "基本信息";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtWorkTeam);
            this.layoutControl2.Controls.Add(this.txtMonth);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 21);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(980, 46);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtWorkTeam
            // 
            this.txtWorkTeam.Location = new System.Drawing.Point(462, 12);
            this.txtWorkTeam.Name = "txtWorkTeam";
            this.txtWorkTeam.Properties.ReadOnly = true;
            this.txtWorkTeam.Size = new System.Drawing.Size(506, 20);
            this.txtWorkTeam.StyleController = this.layoutControl2;
            this.txtWorkTeam.TabIndex = 5;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(39, 12);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Properties.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(392, 20);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(980, 46);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMonth;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(423, 26);
            this.layoutControlItem1.Text = "月度";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(24, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtWorkTeam;
            this.layoutControlItem2.Location = new System.Drawing.Point(423, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(537, 26);
            this.layoutControlItem2.Text = "班组";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(24, 14);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcAttendance);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 69);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(984, 305);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "考勤信息";
            // 
            // dgcAttendance
            // 
            this.dgcAttendance.DataSource = this.bsAttendance;
            this.dgcAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcAttendance.Location = new System.Drawing.Point(2, 21);
            this.dgcAttendance.MainView = this.dgvAttendance;
            this.dgcAttendance.Name = "dgcAttendance";
            this.dgcAttendance.Size = new System.Drawing.Size(980, 282);
            this.dgcAttendance.TabIndex = 0;
            this.dgcAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvAttendance});
            // 
            // bsAttendance
            // 
            this.bsAttendance.DataSource = typeof(Hades.HR.Entity.LaborMonthAttendanceInfo);
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStaffId,
            this.colWorkTeamId,
            this.colAttendanceDays,
            this.colAnnualLeave,
            this.colSickLeave,
            this.colCasualLeave,
            this.colInjuryLeave,
            this.colMarriageLeave,
            this.colMaternityLeave,
            this.colFuneralLeave,
            this.colAbsentLeave,
            this.colMonthWorkload,
            this.colBaseWorkload,
            this.colOverWorkload,
            this.colWeekendWorkload,
            this.colHolidayWorkload,
            this.colNoonShift,
            this.colNightShift,
            this.colOtherNoon,
            this.colOtherNight,
            this.colRemark});
            this.dgvAttendance.GridControl = this.dgcAttendance;
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvAttendance.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvAttendance.OptionsCustomization.AllowFilter = false;
            this.dgvAttendance.OptionsCustomization.AllowGroup = false;
            this.dgvAttendance.OptionsCustomization.AllowSort = false;
            this.dgvAttendance.OptionsFilter.AllowFilterEditor = false;
            this.dgvAttendance.OptionsView.ShowGroupPanel = false;
            this.dgvAttendance.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvAttendance_CustomColumnDisplayText);
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
            // colWorkTeamId
            // 
            this.colWorkTeamId.FieldName = "WorkTeamId";
            this.colWorkTeamId.Name = "colWorkTeamId";
            this.colWorkTeamId.OptionsColumn.AllowEdit = false;
            // 
            // colAttendanceDays
            // 
            this.colAttendanceDays.Caption = "出勤天数";
            this.colAttendanceDays.FieldName = "AttendanceDays";
            this.colAttendanceDays.Name = "colAttendanceDays";
            this.colAttendanceDays.OptionsColumn.AllowEdit = false;
            this.colAttendanceDays.Visible = true;
            this.colAttendanceDays.VisibleIndex = 1;
            // 
            // colAnnualLeave
            // 
            this.colAnnualLeave.Caption = "年假天数";
            this.colAnnualLeave.FieldName = "AnnualLeave";
            this.colAnnualLeave.Name = "colAnnualLeave";
            this.colAnnualLeave.OptionsColumn.AllowEdit = false;
            this.colAnnualLeave.Visible = true;
            this.colAnnualLeave.VisibleIndex = 2;
            // 
            // colSickLeave
            // 
            this.colSickLeave.Caption = "病假天数";
            this.colSickLeave.FieldName = "SickLeave";
            this.colSickLeave.Name = "colSickLeave";
            this.colSickLeave.OptionsColumn.AllowEdit = false;
            this.colSickLeave.Visible = true;
            this.colSickLeave.VisibleIndex = 3;
            // 
            // colCasualLeave
            // 
            this.colCasualLeave.Caption = "事假天数";
            this.colCasualLeave.FieldName = "CasualLeave";
            this.colCasualLeave.Name = "colCasualLeave";
            this.colCasualLeave.OptionsColumn.AllowEdit = false;
            this.colCasualLeave.Visible = true;
            this.colCasualLeave.VisibleIndex = 4;
            // 
            // colInjuryLeave
            // 
            this.colInjuryLeave.Caption = "工伤天数";
            this.colInjuryLeave.FieldName = "InjuryLeave";
            this.colInjuryLeave.Name = "colInjuryLeave";
            this.colInjuryLeave.OptionsColumn.AllowEdit = false;
            this.colInjuryLeave.Visible = true;
            this.colInjuryLeave.VisibleIndex = 5;
            // 
            // colMarriageLeave
            // 
            this.colMarriageLeave.Caption = "婚假天数";
            this.colMarriageLeave.FieldName = "MarriageLeave";
            this.colMarriageLeave.Name = "colMarriageLeave";
            this.colMarriageLeave.OptionsColumn.AllowEdit = false;
            this.colMarriageLeave.Visible = true;
            this.colMarriageLeave.VisibleIndex = 6;
            // 
            // colMaternityLeave
            // 
            this.colMaternityLeave.Caption = "产假天数";
            this.colMaternityLeave.FieldName = "MaternityLeave";
            this.colMaternityLeave.Name = "colMaternityLeave";
            this.colMaternityLeave.OptionsColumn.AllowEdit = false;
            this.colMaternityLeave.Visible = true;
            this.colMaternityLeave.VisibleIndex = 7;
            // 
            // colFuneralLeave
            // 
            this.colFuneralLeave.Caption = "丧假天数";
            this.colFuneralLeave.FieldName = "FuneralLeave";
            this.colFuneralLeave.Name = "colFuneralLeave";
            this.colFuneralLeave.OptionsColumn.AllowEdit = false;
            this.colFuneralLeave.Visible = true;
            this.colFuneralLeave.VisibleIndex = 8;
            // 
            // colAbsentLeave
            // 
            this.colAbsentLeave.Caption = "旷工天数";
            this.colAbsentLeave.FieldName = "AbsentLeave";
            this.colAbsentLeave.Name = "colAbsentLeave";
            this.colAbsentLeave.OptionsColumn.AllowEdit = false;
            this.colAbsentLeave.Visible = true;
            this.colAbsentLeave.VisibleIndex = 9;
            // 
            // colMonthWorkload
            // 
            this.colMonthWorkload.Caption = "月工作总量";
            this.colMonthWorkload.FieldName = "MonthWorkload";
            this.colMonthWorkload.Name = "colMonthWorkload";
            this.colMonthWorkload.OptionsColumn.AllowEdit = false;
            this.colMonthWorkload.Visible = true;
            this.colMonthWorkload.VisibleIndex = 10;
            // 
            // colBaseWorkload
            // 
            this.colBaseWorkload.Caption = "基本工作量";
            this.colBaseWorkload.FieldName = "BaseWorkload";
            this.colBaseWorkload.Name = "colBaseWorkload";
            this.colBaseWorkload.OptionsColumn.AllowEdit = false;
            this.colBaseWorkload.Visible = true;
            this.colBaseWorkload.VisibleIndex = 11;
            // 
            // colOverWorkload
            // 
            this.colOverWorkload.Caption = "超产工作量";
            this.colOverWorkload.FieldName = "OverWorkload";
            this.colOverWorkload.Name = "colOverWorkload";
            this.colOverWorkload.OptionsColumn.AllowEdit = false;
            this.colOverWorkload.Visible = true;
            this.colOverWorkload.VisibleIndex = 12;
            // 
            // colWeekendWorkload
            // 
            this.colWeekendWorkload.Caption = "周末工作量";
            this.colWeekendWorkload.FieldName = "WeekendWorkload";
            this.colWeekendWorkload.Name = "colWeekendWorkload";
            this.colWeekendWorkload.OptionsColumn.AllowEdit = false;
            this.colWeekendWorkload.Visible = true;
            this.colWeekendWorkload.VisibleIndex = 13;
            // 
            // colHolidayWorkload
            // 
            this.colHolidayWorkload.Caption = "法定假日工作量";
            this.colHolidayWorkload.FieldName = "HolidayWorkload";
            this.colHolidayWorkload.Name = "colHolidayWorkload";
            this.colHolidayWorkload.OptionsColumn.AllowEdit = false;
            this.colHolidayWorkload.Visible = true;
            this.colHolidayWorkload.VisibleIndex = 14;
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
            // colOtherNoon
            // 
            this.colOtherNoon.Caption = "其它中班天数";
            this.colOtherNoon.FieldName = "OtherNoon";
            this.colOtherNoon.Name = "colOtherNoon";
            this.colOtherNoon.Visible = true;
            this.colOtherNoon.VisibleIndex = 17;
            // 
            // colOtherNight
            // 
            this.colOtherNight.Caption = "其它夜班天数";
            this.colOtherNight.FieldName = "OtherNight";
            this.colOtherNight.Name = "colOtherNight";
            this.colOtherNight.Visible = true;
            this.colOtherNight.VisibleIndex = 18;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 19;
            // 
            // FrmEditLaborMonthAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 429);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmEditLaborMonthAttendance";
            this.Text = "LaborMonthAttendance";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.TextEdit txtWorkTeam;
        private DevExpress.XtraEditors.TextEdit txtMonth;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl dgcAttendance;
        private System.Windows.Forms.BindingSource bsAttendance;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvAttendance;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkTeamId;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceDays;
        private DevExpress.XtraGrid.Columns.GridColumn colAnnualLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colSickLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colCasualLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colInjuryLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colMarriageLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colMaternityLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colFuneralLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsentLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colOverWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidayWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colNoonShift;
        private DevExpress.XtraGrid.Columns.GridColumn colNightShift;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherNoon;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherNight;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}
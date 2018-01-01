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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dgcAttendance = new DevExpress.XtraGrid.GridControl();
            this.dgvAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.laborMonthAttendanceInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laborMonthAttendanceInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(612, 562);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(711, 562);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(525, 562);
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 557);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 559);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(798, 69);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "基本信息";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcAttendance);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 69);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(798, 423);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "考勤信息";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.textEdit2);
            this.layoutControl2.Controls.Add(this.textEdit1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 21);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(794, 46);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(794, 46);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(40, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(309, 20);
            this.textEdit1.StyleController = this.layoutControl2;
            this.textEdit1.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(341, 26);
            this.layoutControlItem1.Text = "月度";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(24, 14);
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(381, 12);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.Size = new System.Drawing.Size(401, 20);
            this.textEdit2.StyleController = this.layoutControl2;
            this.textEdit2.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.Location = new System.Drawing.Point(341, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(433, 26);
            this.layoutControlItem2.Text = "班组";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(24, 14);
            // 
            // dgcAttendance
            // 
            this.dgcAttendance.DataSource = this.laborMonthAttendanceInfoBindingSource;
            this.dgcAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcAttendance.Location = new System.Drawing.Point(2, 21);
            this.dgcAttendance.MainView = this.dgvAttendance;
            this.dgcAttendance.Name = "dgcAttendance";
            this.dgcAttendance.Size = new System.Drawing.Size(794, 400);
            this.dgcAttendance.TabIndex = 0;
            this.dgcAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvAttendance});
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
            this.dgvAttendance.OptionsView.ShowGroupPanel = false;
            // 
            // laborMonthAttendanceInfoBindingSource
            // 
            this.laborMonthAttendanceInfoBindingSource.DataSource = typeof(Hades.HR.Entity.LaborMonthAttendanceInfo);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colStaffId
            // 
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 0;
            // 
            // colWorkTeamId
            // 
            this.colWorkTeamId.FieldName = "WorkTeamId";
            this.colWorkTeamId.Name = "colWorkTeamId";
            this.colWorkTeamId.Visible = true;
            this.colWorkTeamId.VisibleIndex = 1;
            // 
            // colAttendanceDays
            // 
            this.colAttendanceDays.FieldName = "AttendanceDays";
            this.colAttendanceDays.Name = "colAttendanceDays";
            this.colAttendanceDays.Visible = true;
            this.colAttendanceDays.VisibleIndex = 2;
            // 
            // colAnnualLeave
            // 
            this.colAnnualLeave.FieldName = "AnnualLeave";
            this.colAnnualLeave.Name = "colAnnualLeave";
            this.colAnnualLeave.Visible = true;
            this.colAnnualLeave.VisibleIndex = 3;
            // 
            // colSickLeave
            // 
            this.colSickLeave.FieldName = "SickLeave";
            this.colSickLeave.Name = "colSickLeave";
            this.colSickLeave.Visible = true;
            this.colSickLeave.VisibleIndex = 4;
            // 
            // colCasualLeave
            // 
            this.colCasualLeave.FieldName = "CasualLeave";
            this.colCasualLeave.Name = "colCasualLeave";
            this.colCasualLeave.Visible = true;
            this.colCasualLeave.VisibleIndex = 5;
            // 
            // colInjuryLeave
            // 
            this.colInjuryLeave.FieldName = "InjuryLeave";
            this.colInjuryLeave.Name = "colInjuryLeave";
            this.colInjuryLeave.Visible = true;
            this.colInjuryLeave.VisibleIndex = 6;
            // 
            // colMarriageLeave
            // 
            this.colMarriageLeave.FieldName = "MarriageLeave";
            this.colMarriageLeave.Name = "colMarriageLeave";
            this.colMarriageLeave.Visible = true;
            this.colMarriageLeave.VisibleIndex = 7;
            // 
            // colMaternityLeave
            // 
            this.colMaternityLeave.FieldName = "MaternityLeave";
            this.colMaternityLeave.Name = "colMaternityLeave";
            this.colMaternityLeave.Visible = true;
            this.colMaternityLeave.VisibleIndex = 8;
            // 
            // colFuneralLeave
            // 
            this.colFuneralLeave.FieldName = "FuneralLeave";
            this.colFuneralLeave.Name = "colFuneralLeave";
            this.colFuneralLeave.Visible = true;
            this.colFuneralLeave.VisibleIndex = 9;
            // 
            // colAbsentLeave
            // 
            this.colAbsentLeave.FieldName = "AbsentLeave";
            this.colAbsentLeave.Name = "colAbsentLeave";
            this.colAbsentLeave.Visible = true;
            this.colAbsentLeave.VisibleIndex = 10;
            // 
            // colMonthWorkload
            // 
            this.colMonthWorkload.FieldName = "MonthWorkload";
            this.colMonthWorkload.Name = "colMonthWorkload";
            this.colMonthWorkload.Visible = true;
            this.colMonthWorkload.VisibleIndex = 11;
            // 
            // colBaseWorkload
            // 
            this.colBaseWorkload.FieldName = "BaseWorkload";
            this.colBaseWorkload.Name = "colBaseWorkload";
            this.colBaseWorkload.Visible = true;
            this.colBaseWorkload.VisibleIndex = 12;
            // 
            // colOverWorkload
            // 
            this.colOverWorkload.FieldName = "OverWorkload";
            this.colOverWorkload.Name = "colOverWorkload";
            this.colOverWorkload.Visible = true;
            this.colOverWorkload.VisibleIndex = 13;
            // 
            // colWeekendWorkload
            // 
            this.colWeekendWorkload.FieldName = "WeekendWorkload";
            this.colWeekendWorkload.Name = "colWeekendWorkload";
            this.colWeekendWorkload.Visible = true;
            this.colWeekendWorkload.VisibleIndex = 14;
            // 
            // colHolidayWorkload
            // 
            this.colHolidayWorkload.FieldName = "HolidayWorkload";
            this.colHolidayWorkload.Name = "colHolidayWorkload";
            this.colHolidayWorkload.Visible = true;
            this.colHolidayWorkload.VisibleIndex = 15;
            // 
            // colNoonShift
            // 
            this.colNoonShift.FieldName = "NoonShift";
            this.colNoonShift.Name = "colNoonShift";
            this.colNoonShift.Visible = true;
            this.colNoonShift.VisibleIndex = 16;
            // 
            // colNightShift
            // 
            this.colNightShift.FieldName = "NightShift";
            this.colNightShift.Name = "colNightShift";
            this.colNightShift.Visible = true;
            this.colNightShift.VisibleIndex = 17;
            // 
            // colOtherNoon
            // 
            this.colOtherNoon.FieldName = "OtherNoon";
            this.colOtherNoon.Name = "colOtherNoon";
            this.colOtherNoon.Visible = true;
            this.colOtherNoon.VisibleIndex = 18;
            // 
            // colOtherNight
            // 
            this.colOtherNight.FieldName = "OtherNight";
            this.colOtherNight.Name = "colOtherNight";
            this.colOtherNight.Visible = true;
            this.colOtherNight.VisibleIndex = 19;
            // 
            // colRemark
            // 
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 20;
            // 
            // FrmEditLaborMonthAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 597);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laborMonthAttendanceInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl dgcAttendance;
        private System.Windows.Forms.BindingSource laborMonthAttendanceInfoBindingSource;
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
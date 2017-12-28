namespace Hades.HR.UI
{
    partial class FrmEditLaborDailyAttendance
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chkIsHoliday = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsWeekend = new DevExpress.XtraEditors.CheckEdit();
            this.txtAttendanceDate = new DevExpress.XtraEditors.TextEdit();
            this.txtWorkTeamName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgcLabor = new DevExpress.XtraGrid.GridControl();
            this.bsLabor = new System.Windows.Forms.BindingSource(this.components);
            this.dgvLabor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkTeamId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoAbsent = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colWorkHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsentHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsWeekend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsHoliday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsHoliday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsWeekend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcLabor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLabor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoAbsent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(667, 488);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(766, 488);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(580, 488);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 481);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            this.dataNavigator1.Visible = false;
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 485);
            this.picPrint.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(853, 105);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "基本信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chkIsHoliday);
            this.layoutControl1.Controls.Add(this.chkIsWeekend);
            this.layoutControl1.Controls.Add(this.txtAttendanceDate);
            this.layoutControl1.Controls.Add(this.txtWorkTeamName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(849, 82);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkIsHoliday
            // 
            this.chkIsHoliday.Location = new System.Drawing.Point(426, 36);
            this.chkIsHoliday.Name = "chkIsHoliday";
            this.chkIsHoliday.Properties.Caption = "是否节假日";
            this.chkIsHoliday.Size = new System.Drawing.Size(411, 19);
            this.chkIsHoliday.StyleController = this.layoutControl1;
            this.chkIsHoliday.TabIndex = 7;
            this.chkIsHoliday.CheckedChanged += new System.EventHandler(this.chkIsHoliday_CheckedChanged);
            // 
            // chkIsWeekend
            // 
            this.chkIsWeekend.Location = new System.Drawing.Point(12, 36);
            this.chkIsWeekend.Name = "chkIsWeekend";
            this.chkIsWeekend.Properties.Caption = "是否周末";
            this.chkIsWeekend.Size = new System.Drawing.Size(410, 19);
            this.chkIsWeekend.StyleController = this.layoutControl1;
            this.chkIsWeekend.TabIndex = 6;
            this.chkIsWeekend.CheckedChanged += new System.EventHandler(this.chkIsWeekend_CheckedChanged);
            // 
            // txtAttendanceDate
            // 
            this.txtAttendanceDate.Location = new System.Drawing.Point(477, 12);
            this.txtAttendanceDate.Name = "txtAttendanceDate";
            this.txtAttendanceDate.Properties.ReadOnly = true;
            this.txtAttendanceDate.Size = new System.Drawing.Size(360, 20);
            this.txtAttendanceDate.StyleController = this.layoutControl1;
            this.txtAttendanceDate.TabIndex = 5;
            // 
            // txtWorkTeamName
            // 
            this.txtWorkTeamName.Location = new System.Drawing.Point(63, 12);
            this.txtWorkTeamName.Name = "txtWorkTeamName";
            this.txtWorkTeamName.Properties.ReadOnly = true;
            this.txtWorkTeamName.Size = new System.Drawing.Size(359, 20);
            this.txtWorkTeamName.StyleController = this.layoutControl1;
            this.txtWorkTeamName.TabIndex = 4;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(849, 82);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtWorkTeamName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(414, 24);
            this.layoutControlItem1.Text = "班组名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtAttendanceDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(414, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(415, 24);
            this.layoutControlItem2.Text = "考勤日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkIsWeekend;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(414, 38);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkIsHoliday;
            this.layoutControlItem4.Location = new System.Drawing.Point(414, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(415, 38);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcLabor);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 105);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(853, 349);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "考勤登记";
            // 
            // dgcLabor
            // 
            this.dgcLabor.DataSource = this.bsLabor;
            this.dgcLabor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcLabor.Location = new System.Drawing.Point(2, 21);
            this.dgcLabor.MainView = this.dgvLabor;
            this.dgcLabor.Name = "dgcLabor";
            this.dgcLabor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoAbsent});
            this.dgcLabor.Size = new System.Drawing.Size(849, 326);
            this.dgcLabor.TabIndex = 0;
            this.dgcLabor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvLabor});
            // 
            // bsLabor
            // 
            this.bsLabor.DataSource = typeof(Hades.HR.Entity.LaborDailyAttendanceInfo);
            // 
            // dgvLabor
            // 
            this.dgvLabor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colWorkTeamId,
            this.colAttendanceDate,
            this.colStaffNumber,
            this.colStaffId,
            this.colAbsentType,
            this.colWorkHours,
            this.colAbsentHours,
            this.colIsWeekend,
            this.colIsHoliday,
            this.colRemark});
            this.dgvLabor.GridControl = this.dgcLabor;
            this.dgvLabor.Name = "dgvLabor";
            this.dgvLabor.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvLabor.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvLabor.OptionsCustomization.AllowFilter = false;
            this.dgvLabor.OptionsCustomization.AllowGroup = false;
            this.dgvLabor.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvLabor.OptionsCustomization.AllowSort = false;
            this.dgvLabor.OptionsView.ShowGroupPanel = false;
            this.dgvLabor.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvLabor_CustomUnboundColumnData);
            this.dgvLabor.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvLabor_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colWorkTeamId
            // 
            this.colWorkTeamId.Caption = "班组名称";
            this.colWorkTeamId.FieldName = "WorkTeamId";
            this.colWorkTeamId.Name = "colWorkTeamId";
            this.colWorkTeamId.OptionsColumn.AllowEdit = false;
            this.colWorkTeamId.Visible = true;
            this.colWorkTeamId.VisibleIndex = 0;
            // 
            // colAttendanceDate
            // 
            this.colAttendanceDate.Caption = "考勤日期";
            this.colAttendanceDate.FieldName = "AttendanceDate";
            this.colAttendanceDate.Name = "colAttendanceDate";
            this.colAttendanceDate.OptionsColumn.AllowEdit = false;
            this.colAttendanceDate.Visible = true;
            this.colAttendanceDate.VisibleIndex = 1;
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.Caption = "员工工号";
            this.colStaffNumber.FieldName = "StaffNumber";
            this.colStaffNumber.Name = "colStaffNumber";
            this.colStaffNumber.OptionsColumn.AllowEdit = false;
            this.colStaffNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStaffNumber.Visible = true;
            this.colStaffNumber.VisibleIndex = 2;
            // 
            // colStaffId
            // 
            this.colStaffId.Caption = "员工姓名";
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.OptionsColumn.AllowEdit = false;
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 3;
            // 
            // colAbsentType
            // 
            this.colAbsentType.Caption = "缺勤类型";
            this.colAbsentType.ColumnEdit = this.repoAbsent;
            this.colAbsentType.FieldName = "AbsentType";
            this.colAbsentType.Name = "colAbsentType";
            this.colAbsentType.Visible = true;
            this.colAbsentType.VisibleIndex = 4;
            // 
            // repoAbsent
            // 
            this.repoAbsent.AutoHeight = false;
            this.repoAbsent.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoAbsent.Name = "repoAbsent";
            // 
            // colWorkHours
            // 
            this.colWorkHours.Caption = "工作工时";
            this.colWorkHours.FieldName = "WorkHours";
            this.colWorkHours.Name = "colWorkHours";
            this.colWorkHours.OptionsColumn.AllowEdit = false;
            this.colWorkHours.Visible = true;
            this.colWorkHours.VisibleIndex = 5;
            // 
            // colAbsentHours
            // 
            this.colAbsentHours.Caption = "请假工时";
            this.colAbsentHours.FieldName = "AbsentHours";
            this.colAbsentHours.Name = "colAbsentHours";
            this.colAbsentHours.Visible = true;
            this.colAbsentHours.VisibleIndex = 6;
            // 
            // colIsWeekend
            // 
            this.colIsWeekend.Caption = "是否周末";
            this.colIsWeekend.FieldName = "IsWeekend";
            this.colIsWeekend.Name = "colIsWeekend";
            this.colIsWeekend.OptionsColumn.AllowEdit = false;
            this.colIsWeekend.Visible = true;
            this.colIsWeekend.VisibleIndex = 7;
            // 
            // colIsHoliday
            // 
            this.colIsHoliday.Caption = "是否节假日";
            this.colIsHoliday.FieldName = "IsHoliday";
            this.colIsHoliday.Name = "colIsHoliday";
            this.colIsHoliday.OptionsColumn.AllowEdit = false;
            this.colIsHoliday.Visible = true;
            this.colIsHoliday.VisibleIndex = 8;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 9;
            // 
            // FrmEditLaborDailyAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 523);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmEditLaborDailyAttendance";
            this.Text = "员工日考勤";
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsHoliday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsWeekend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcLabor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLabor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoAbsent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtAttendanceDate;
        private DevExpress.XtraEditors.TextEdit txtWorkTeamName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl dgcLabor;
        private System.Windows.Forms.BindingSource bsLabor;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvLabor;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkTeamId;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsentType;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkHours;
        private DevExpress.XtraGrid.Columns.GridColumn colIsWeekend;
        private DevExpress.XtraGrid.Columns.GridColumn colIsHoliday;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.CheckEdit chkIsHoliday;
        private DevExpress.XtraEditors.CheckEdit chkIsWeekend;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsentHours;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repoAbsent;
    }
}
namespace Hades.HR.UI
{
    partial class FrmEditLaborAttendanceRecord
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtAttendanceDate = new DevExpress.XtraEditors.TextEdit();
            this.chkIsHoliday = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsWeekend = new DevExpress.XtraEditors.CheckEdit();
            this.txtWorkTeamName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgcAttendance = new DevExpress.XtraGrid.GridControl();
            this.bsAttendanceRecord = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoCmbAbsentType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsHoliday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsWeekend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttendanceRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCmbAbsentType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(698, 427);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(797, 427);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(611, 427);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 420);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            this.dataNavigator1.Visible = false;
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 424);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(884, 84);
            this.panelControl1.TabIndex = 6;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtAttendanceDate);
            this.layoutControl1.Controls.Add(this.chkIsHoliday);
            this.layoutControl1.Controls.Add(this.chkIsWeekend);
            this.layoutControl1.Controls.Add(this.txtWorkTeamName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(880, 80);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtAttendanceDate
            // 
            this.txtAttendanceDate.Location = new System.Drawing.Point(77, 42);
            this.txtAttendanceDate.Name = "txtAttendanceDate";
            this.txtAttendanceDate.Properties.ReadOnly = true;
            this.txtAttendanceDate.Size = new System.Drawing.Size(256, 24);
            this.txtAttendanceDate.StyleController = this.layoutControl1;
            this.txtAttendanceDate.TabIndex = 7;
            // 
            // chkIsHoliday
            // 
            this.chkIsHoliday.Location = new System.Drawing.Point(568, 42);
            this.chkIsHoliday.Name = "chkIsHoliday";
            this.chkIsHoliday.Properties.Caption = "是否节假日";
            this.chkIsHoliday.Size = new System.Drawing.Size(298, 22);
            this.chkIsHoliday.StyleController = this.layoutControl1;
            this.chkIsHoliday.TabIndex = 6;
            // 
            // chkIsWeekend
            // 
            this.chkIsWeekend.Location = new System.Drawing.Point(337, 42);
            this.chkIsWeekend.Name = "chkIsWeekend";
            this.chkIsWeekend.Properties.Caption = "是否周末";
            this.chkIsWeekend.Size = new System.Drawing.Size(227, 22);
            this.chkIsWeekend.StyleController = this.layoutControl1;
            this.chkIsWeekend.TabIndex = 5;
            // 
            // txtWorkTeamName
            // 
            this.txtWorkTeamName.Location = new System.Drawing.Point(77, 14);
            this.txtWorkTeamName.Name = "txtWorkTeamName";
            this.txtWorkTeamName.Properties.ReadOnly = true;
            this.txtWorkTeamName.Size = new System.Drawing.Size(789, 24);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(880, 80);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtWorkTeamName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(856, 28);
            this.layoutControlItem1.Text = "班组名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkIsWeekend;
            this.layoutControlItem2.Location = new System.Drawing.Point(323, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(231, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkIsHoliday;
            this.layoutControlItem3.Location = new System.Drawing.Point(554, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(302, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtAttendanceDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(323, 28);
            this.layoutControlItem4.Text = "考勤日期";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 18);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgcAttendance);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 84);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(884, 332);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "考勤记录";
            // 
            // dgcAttendance
            // 
            this.dgcAttendance.DataSource = this.bsAttendanceRecord;
            this.dgcAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcAttendance.Location = new System.Drawing.Point(2, 25);
            this.dgcAttendance.MainView = this.dgvAttendance;
            this.dgcAttendance.Name = "dgcAttendance";
            this.dgcAttendance.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoCmbAbsentType});
            this.dgcAttendance.Size = new System.Drawing.Size(880, 305);
            this.dgcAttendance.TabIndex = 0;
            this.dgcAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvAttendance});
            // 
            // bsAttendanceRecord
            // 
            this.bsAttendanceRecord.DataSource = typeof(Hades.HR.Entity.LaborAttendanceRecordInfo);
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStaffNumber,
            this.colStaffId,
            this.colAttendanceDate,
            this.colWorkload,
            this.colAbsentType,
            this.colRemark});
            this.dgvAttendance.GridControl = this.dgcAttendance;
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvAttendance.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvAttendance.OptionsCustomization.AllowFilter = false;
            this.dgvAttendance.OptionsCustomization.AllowGroup = false;
            this.dgvAttendance.OptionsCustomization.AllowSort = false;
            this.dgvAttendance.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvAttendance.OptionsView.ShowGroupPanel = false;
            this.dgvAttendance.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvAttendance_CustomUnboundColumnData);
            this.dgvAttendance.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvAttendance_CustomColumnDisplayText);
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
            this.colStaffId.VisibleIndex = 1;
            // 
            // colAttendanceDate
            // 
            this.colAttendanceDate.Caption = "考勤日期";
            this.colAttendanceDate.FieldName = "AttendanceDate";
            this.colAttendanceDate.Name = "colAttendanceDate";
            this.colAttendanceDate.OptionsColumn.AllowEdit = false;
            this.colAttendanceDate.Visible = true;
            this.colAttendanceDate.VisibleIndex = 2;
            // 
            // colWorkload
            // 
            this.colWorkload.Caption = "工作量";
            this.colWorkload.FieldName = "Workload";
            this.colWorkload.Name = "colWorkload";
            this.colWorkload.Visible = true;
            this.colWorkload.VisibleIndex = 3;
            // 
            // colAbsentType
            // 
            this.colAbsentType.Caption = "缺勤类型";
            this.colAbsentType.ColumnEdit = this.repoCmbAbsentType;
            this.colAbsentType.FieldName = "AbsentType";
            this.colAbsentType.Name = "colAbsentType";
            this.colAbsentType.Visible = true;
            this.colAbsentType.VisibleIndex = 4;
            // 
            // repoCmbAbsentType
            // 
            this.repoCmbAbsentType.AutoHeight = false;
            this.repoCmbAbsentType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoCmbAbsentType.Name = "repoCmbAbsentType";
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 5;
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.Caption = "工号";
            this.colStaffNumber.FieldName = "StaffNumber";
            this.colStaffNumber.Name = "colStaffNumber";
            this.colStaffNumber.OptionsColumn.AllowEdit = false;
            this.colStaffNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStaffNumber.Visible = true;
            this.colStaffNumber.VisibleIndex = 0;
            // 
            // FrmEditLaborAttendanceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmEditLaborAttendanceRecord";
            this.Text = "日考勤登记";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsHoliday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsWeekend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttendanceRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCmbAbsentType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgcAttendance;
        private System.Windows.Forms.BindingSource bsAttendanceRecord;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvAttendance;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsentType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repoCmbAbsentType;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtWorkTeamName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtAttendanceDate;
        private DevExpress.XtraEditors.CheckEdit chkIsHoliday;
        private DevExpress.XtraEditors.CheckEdit chkIsWeekend;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffNumber;
    }
}
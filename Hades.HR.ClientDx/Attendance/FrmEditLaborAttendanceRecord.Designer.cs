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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgcAttendance = new DevExpress.XtraGrid.GridControl();
            this.bsAttendanceRecord = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsWeekend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsHoliday = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttendanceRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(515, 392);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(614, 392);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(428, 392);
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 385);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(701, 61);
            this.panelControl1.TabIndex = 6;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgcAttendance);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 61);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(701, 263);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "¿¼ÇÚ¼ÇÂ¼";
            // 
            // dgcAttendance
            // 
            this.dgcAttendance.DataSource = this.bsAttendanceRecord;
            this.dgcAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcAttendance.Location = new System.Drawing.Point(2, 21);
            this.dgcAttendance.MainView = this.dgvAttendance;
            this.dgcAttendance.Name = "dgcAttendance";
            this.dgcAttendance.Size = new System.Drawing.Size(697, 240);
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
            this.colStaffId,
            this.colAttendanceDate,
            this.colWorkload,
            this.colAbsentType,
            this.colIsWeekend,
            this.colIsHoliday});
            this.dgvAttendance.GridControl = this.dgcAttendance;
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvAttendance.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvAttendance.OptionsCustomization.AllowFilter = false;
            this.dgvAttendance.OptionsCustomization.AllowGroup = false;
            this.dgvAttendance.OptionsCustomization.AllowSort = false;
            this.dgvAttendance.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvAttendance.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colStaffId
            // 
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 1;
            // 
            // colAttendanceDate
            // 
            this.colAttendanceDate.FieldName = "AttendanceDate";
            this.colAttendanceDate.Name = "colAttendanceDate";
            this.colAttendanceDate.Visible = true;
            this.colAttendanceDate.VisibleIndex = 2;
            // 
            // colWorkload
            // 
            this.colWorkload.FieldName = "Workload";
            this.colWorkload.Name = "colWorkload";
            this.colWorkload.Visible = true;
            this.colWorkload.VisibleIndex = 3;
            // 
            // colAbsentType
            // 
            this.colAbsentType.FieldName = "AbsentType";
            this.colAbsentType.Name = "colAbsentType";
            this.colAbsentType.Visible = true;
            this.colAbsentType.VisibleIndex = 4;
            // 
            // colIsWeekend
            // 
            this.colIsWeekend.FieldName = "IsWeekend";
            this.colIsWeekend.Name = "colIsWeekend";
            this.colIsWeekend.Visible = true;
            this.colIsWeekend.VisibleIndex = 5;
            // 
            // colIsHoliday
            // 
            this.colIsHoliday.FieldName = "IsHoliday";
            this.colIsHoliday.Name = "colIsHoliday";
            this.colIsHoliday.Visible = true;
            this.colIsHoliday.VisibleIndex = 6;
            // 
            // FrmEditLaborAttendanceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 427);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmEditLaborAttendanceRecord";
            this.Text = "ÈÕ¿¼ÇÚµÇ¼Ç";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttendanceRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colIsWeekend;
        private DevExpress.XtraGrid.Columns.GridColumn colIsHoliday;
    }
}
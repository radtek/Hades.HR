namespace Hades.HR.UI
{
    partial class FrmEditChangeWorkload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditChangeWorkload));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.spChangeHours = new DevExpress.XtraEditors.SpinEdit();
            this.txtAttendanceDate = new DevExpress.XtraEditors.TextEdit();
            this.txtWorkTeamName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.wgvChange = new Hades.Pager.WinControl.WinGridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dgcStaff = new DevExpress.XtraGrid.GridControl();
            this.bsLaborWorkload = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkTeamId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spChangeHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLaborWorkload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(679, 493);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(778, 493);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(592, 493);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 488);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            this.dataNavigator1.Visible = false;
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 490);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(865, 473);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // groupControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl1, 2);
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(859, 94);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "基本信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.spChangeHours);
            this.layoutControl1.Controls.Add(this.txtAttendanceDate);
            this.layoutControl1.Controls.Add(this.txtWorkTeamName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 25);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(855, 67);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // spChangeHours
            // 
            this.spChangeHours.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spChangeHours.Location = new System.Drawing.Point(666, 14);
            this.spChangeHours.Name = "spChangeHours";
            this.spChangeHours.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spChangeHours.Properties.ReadOnly = true;
            this.spChangeHours.Size = new System.Drawing.Size(175, 24);
            this.spChangeHours.StyleController = this.layoutControl1;
            this.spChangeHours.TabIndex = 6;
            // 
            // txtAttendanceDate
            // 
            this.txtAttendanceDate.Location = new System.Drawing.Point(364, 14);
            this.txtAttendanceDate.Name = "txtAttendanceDate";
            this.txtAttendanceDate.Properties.ReadOnly = true;
            this.txtAttendanceDate.Size = new System.Drawing.Size(220, 24);
            this.txtAttendanceDate.StyleController = this.layoutControl1;
            this.txtAttendanceDate.TabIndex = 5;
            // 
            // txtWorkTeamName
            // 
            this.txtWorkTeamName.Location = new System.Drawing.Point(92, 14);
            this.txtWorkTeamName.Name = "txtWorkTeamName";
            this.txtWorkTeamName.Properties.ReadOnly = true;
            this.txtWorkTeamName.Size = new System.Drawing.Size(190, 24);
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
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(855, 67);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtWorkTeamName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(272, 28);
            this.layoutControlItem1.Text = "班组名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtAttendanceDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(272, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(302, 28);
            this.layoutControlItem2.Text = "考勤日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.spChangeHours;
            this.layoutControlItem3.Location = new System.Drawing.Point(574, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(257, 28);
            this.layoutControlItem3.Text = "换机总工时";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 18);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(831, 15);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.wgvChange);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 103);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(426, 367);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "本日换机明细";
            // 
            // wgvChange
            // 
            this.wgvChange.AppendedMenu = null;
            this.wgvChange.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvChange.ColumnNameAlias")));
            this.wgvChange.DataSource = null;
            this.wgvChange.DisplayColumns = "";
            this.wgvChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvChange.FixedColumns = null;
            this.wgvChange.Location = new System.Drawing.Point(2, 25);
            this.wgvChange.Name = "wgvChange";
            this.wgvChange.PrintTitle = "";
            this.wgvChange.ShowAddMenu = true;
            this.wgvChange.ShowCheckBox = false;
            this.wgvChange.ShowDeleteMenu = true;
            this.wgvChange.ShowEditMenu = true;
            this.wgvChange.ShowExportButton = true;
            this.wgvChange.Size = new System.Drawing.Size(422, 340);
            this.wgvChange.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.dgcStaff);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(435, 103);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(427, 367);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "换机工时分配";
            // 
            // dgcStaff
            // 
            this.dgcStaff.DataSource = this.bsLaborWorkload;
            this.dgcStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStaff.Location = new System.Drawing.Point(2, 25);
            this.dgcStaff.MainView = this.dgvStaff;
            this.dgcStaff.Name = "dgcStaff";
            this.dgcStaff.Size = new System.Drawing.Size(423, 340);
            this.dgcStaff.TabIndex = 0;
            this.dgcStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStaff});
            // 
            // bsLaborWorkload
            // 
            this.bsLaborWorkload.DataSource = typeof(Hades.HR.Entity.LaborChangeWorkloadInfo);
            // 
            // dgvStaff
            // 
            this.dgvStaff.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colChangeId,
            this.colWorkTeamId,
            this.colStaffNumber,
            this.colStaffId,
            this.colChangeHours,
            this.colAssignType,
            this.colRemark});
            this.dgvStaff.GridControl = this.dgcStaff;
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStaff.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStaff.OptionsCustomization.AllowFilter = false;
            this.dgvStaff.OptionsCustomization.AllowGroup = false;
            this.dgvStaff.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvStaff.OptionsCustomization.AllowSort = false;
            this.dgvStaff.OptionsMenu.EnableColumnMenu = false;
            this.dgvStaff.OptionsMenu.EnableFooterMenu = false;
            this.dgvStaff.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvStaff.OptionsView.ShowFooter = true;
            this.dgvStaff.OptionsView.ShowGroupPanel = false;
            this.dgvStaff.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvStaff_CustomUnboundColumnData);
            this.dgvStaff.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvStaff_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colChangeId
            // 
            this.colChangeId.FieldName = "ChangeId";
            this.colChangeId.Name = "colChangeId";
            // 
            // colWorkTeamId
            // 
            this.colWorkTeamId.FieldName = "WorkTeamId";
            this.colWorkTeamId.Name = "colWorkTeamId";
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.Caption = "员工工号";
            this.colStaffNumber.FieldName = "StaffNumber";
            this.colStaffNumber.Name = "colStaffNumber";
            this.colStaffNumber.OptionsColumn.AllowEdit = false;
            this.colStaffNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStaffNumber.Visible = true;
            this.colStaffNumber.VisibleIndex = 0;
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
            // colChangeHours
            // 
            this.colChangeHours.Caption = "换机工时";
            this.colChangeHours.FieldName = "ChangeHours";
            this.colChangeHours.Name = "colChangeHours";
            this.colChangeHours.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ChangeHours", "合计={0:0.##}")});
            this.colChangeHours.Visible = true;
            this.colChangeHours.VisibleIndex = 2;
            // 
            // colAssignType
            // 
            this.colAssignType.FieldName = "AssignType";
            this.colAssignType.Name = "colAssignType";
            this.colAssignType.OptionsColumn.AllowEdit = false;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            // 
            // FrmEditChangeWorkload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 528);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmEditChangeWorkload";
            this.Text = "编辑班组换机工时";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spChangeHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLaborWorkload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtAttendanceDate;
        private DevExpress.XtraEditors.TextEdit txtWorkTeamName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SpinEdit spChangeHours;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Pager.WinControl.WinGridView wgvChange;
        private DevExpress.XtraGrid.GridControl dgcStaff;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStaff;
        private System.Windows.Forms.BindingSource bsLaborWorkload;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeId;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkTeamId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeHours;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffNumber;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
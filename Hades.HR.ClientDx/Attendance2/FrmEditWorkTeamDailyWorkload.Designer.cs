namespace Hades.HR.UI
{
    partial class FrmEditWorkTeamDailyWorkload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditWorkTeamDailyWorkload));
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtAttendanceDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtProductionHours = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtPersonCount = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.wgvComplete = new Hades.Pager.WinControl.WinGridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lvComplete = new DevExpress.XtraEditors.ListBoxControl();
            this.luWorkTeam = new Hades.HR.UI.WorkTeamLookup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(798, 563);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(897, 563);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(711, 563);
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 558);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 560);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.luWorkTeam);
            this.layoutControl2.Controls.Add(this.txtAttendanceDate);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 25);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(974, 67);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtAttendanceDate
            // 
            this.txtAttendanceDate.EditValue = null;
            this.txtAttendanceDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtAttendanceDate.Location = new System.Drawing.Point(552, 14);
            this.txtAttendanceDate.Name = "txtAttendanceDate";
            this.txtAttendanceDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtAttendanceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAttendanceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtAttendanceDate.Size = new System.Drawing.Size(408, 24);
            this.txtAttendanceDate.StyleController = this.layoutControl2;
            this.txtAttendanceDate.TabIndex = 2;
            this.txtAttendanceDate.EditValueChanged += new System.EventHandler(this.txtAttendanceDate_EditValueChanged);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(974, 67);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtAttendanceDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(475, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(475, 28);
            this.layoutControlItem2.Text = "考勤日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(950, 15);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtProductionHours
            // 
            this.txtProductionHours.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtProductionHours.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtProductionHours.Location = new System.Drawing.Point(92, 14);
            this.txtProductionHours.Name = "txtProductionHours";
            this.txtProductionHours.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtProductionHours.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtProductionHours.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtProductionHours.Size = new System.Drawing.Size(393, 24);
            this.txtProductionHours.StyleController = this.layoutControl3;
            this.txtProductionHours.TabIndex = 3;
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.txtRemark);
            this.layoutControl3.Controls.Add(this.txtPersonCount);
            this.layoutControl3.Controls.Add(this.txtProductionHours);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(2, 25);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup3;
            this.layoutControl3.Size = new System.Drawing.Size(974, 142);
            this.layoutControl3.TabIndex = 0;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(92, 42);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(868, 86);
            this.txtRemark.StyleController = this.layoutControl3;
            this.txtRemark.TabIndex = 8;
            // 
            // txtPersonCount
            // 
            this.txtPersonCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPersonCount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPersonCount.Location = new System.Drawing.Point(567, 14);
            this.txtPersonCount.Name = "txtPersonCount";
            this.txtPersonCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPersonCount.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtPersonCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtPersonCount.Size = new System.Drawing.Size(393, 24);
            this.txtPersonCount.StyleController = this.layoutControl3;
            this.txtPersonCount.TabIndex = 7;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem7});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(974, 142);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtProductionHours;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(475, 28);
            this.layoutControlItem3.Text = "产量总工时";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtPersonCount;
            this.layoutControlItem7.Location = new System.Drawing.Point(475, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(475, 28);
            this.layoutControlItem7.Text = "员工人数";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtRemark;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(950, 90);
            this.layoutControlItem8.Text = "备注";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(75, 18);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupControl4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 536);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // groupControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl1, 2);
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(978, 94);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "基本信息";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.wgvComplete);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(303, 103);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(678, 255);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "完工单数据";
            // 
            // wgvComplete
            // 
            this.wgvComplete.AppendedMenu = null;
            this.wgvComplete.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("wgvComplete.ColumnNameAlias")));
            this.wgvComplete.DataSource = null;
            this.wgvComplete.DisplayColumns = "";
            this.wgvComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wgvComplete.FixedColumns = null;
            this.wgvComplete.Location = new System.Drawing.Point(2, 25);
            this.wgvComplete.Name = "wgvComplete";
            this.wgvComplete.PrintTitle = "";
            this.wgvComplete.ShowAddMenu = true;
            this.wgvComplete.ShowCheckBox = false;
            this.wgvComplete.ShowDeleteMenu = true;
            this.wgvComplete.ShowEditMenu = true;
            this.wgvComplete.ShowExportButton = true;
            this.wgvComplete.Size = new System.Drawing.Size(674, 228);
            this.wgvComplete.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl3, 2);
            this.groupControl3.Controls.Add(this.layoutControl3);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(3, 364);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(978, 169);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "工时汇总";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.lvComplete);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(3, 103);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(294, 255);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "本日完工单";
            // 
            // lvComplete
            // 
            this.lvComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvComplete.Location = new System.Drawing.Point(2, 25);
            this.lvComplete.Name = "lvComplete";
            this.lvComplete.Size = new System.Drawing.Size(290, 228);
            this.lvComplete.TabIndex = 0;
            this.lvComplete.SelectedIndexChanged += new System.EventHandler(this.lvComplete_SelectedIndexChanged);
            // 
            // luWorkTeam
            // 
            this.luWorkTeam.Location = new System.Drawing.Point(77, 14);
            this.luWorkTeam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.luWorkTeam.Name = "luWorkTeam";
            this.luWorkTeam.Size = new System.Drawing.Size(408, 24);
            this.luWorkTeam.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.luWorkTeam;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(475, 28);
            this.layoutControlItem1.Text = "班组选择";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // FrmEditWorkTeamDailyWorkload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 598);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmEditWorkTeamDailyWorkload";
            this.Text = "WorkTeamDailyWorkload";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
          private DevExpress.XtraEditors.DateEdit txtAttendanceDate;
          private DevExpress.XtraEditors.SpinEdit txtProductionHours;
          private DevExpress.XtraEditors.SpinEdit txtPersonCount;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Pager.WinControl.WinGridView wgvComplete;
        private WorkTeamLookup luWorkTeam;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.ListBoxControl lvComplete;
    }
}
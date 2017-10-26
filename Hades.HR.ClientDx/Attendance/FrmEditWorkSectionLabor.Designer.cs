namespace Hades.HR.UI
{
    partial class FrmEditWorkSectionLabor
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnUsePrevious = new DevExpress.XtraEditors.SimpleButton();
            this.txtWorkTeamName = new DevExpress.XtraEditors.TextEdit();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgcStaff = new DevExpress.XtraGrid.GridControl();
            this.bsLabors = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkTeamId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkSectionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffLevelId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoActionButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnAddStaff = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLabors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoActionButton)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(588, 392);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(687, 392);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(501, 392);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(265, 387);
            this.dataNavigator1.Visible = false;
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(458, 389);
            this.picPrint.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(774, 92);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "班组信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnUsePrevious);
            this.layoutControl1.Controls.Add(this.txtWorkTeamName);
            this.layoutControl1.Controls.Add(this.txtDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(770, 69);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnUsePrevious
            // 
            this.btnUsePrevious.Location = new System.Drawing.Point(605, 12);
            this.btnUsePrevious.Name = "btnUsePrevious";
            this.btnUsePrevious.Size = new System.Drawing.Size(153, 22);
            this.btnUsePrevious.StyleController = this.layoutControl1;
            this.btnUsePrevious.TabIndex = 6;
            this.btnUsePrevious.Text = "使用上月职员";
            this.btnUsePrevious.Click += new System.EventHandler(this.btnUsePrevious_Click);
            // 
            // txtWorkTeamName
            // 
            this.txtWorkTeamName.Location = new System.Drawing.Point(263, 12);
            this.txtWorkTeamName.Name = "txtWorkTeamName";
            this.txtWorkTeamName.Properties.ReadOnly = true;
            this.txtWorkTeamName.Size = new System.Drawing.Size(338, 20);
            this.txtWorkTeamName.StyleController = this.layoutControl1;
            this.txtWorkTeamName.TabIndex = 5;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(39, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(193, 20);
            this.txtDate.StyleController = this.layoutControl1;
            this.txtDate.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(770, 69);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(224, 49);
            this.layoutControlItem1.Text = "日期";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(24, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtWorkTeamName;
            this.layoutControlItem2.Location = new System.Drawing.Point(224, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(369, 49);
            this.layoutControlItem2.Text = "班组";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(24, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnUsePrevious;
            this.layoutControlItem3.Location = new System.Drawing.Point(593, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(157, 49);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcStaff);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 92);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(774, 277);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "工段职员";
            // 
            // dgcStaff
            // 
            this.dgcStaff.DataSource = this.bsLabors;
            this.dgcStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStaff.Location = new System.Drawing.Point(2, 21);
            this.dgcStaff.MainView = this.dgvStaff;
            this.dgcStaff.Name = "dgcStaff";
            this.dgcStaff.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoActionButton});
            this.dgcStaff.Size = new System.Drawing.Size(770, 254);
            this.dgcStaff.TabIndex = 0;
            this.dgcStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStaff});
            // 
            // bsLabors
            // 
            this.bsLabors.DataSource = typeof(Hades.HR.Entity.WorkSectionLaborInfo);
            // 
            // dgvStaff
            // 
            this.dgvStaff.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colYear,
            this.colMonth,
            this.colWorkTeamId,
            this.colWorkSectionId,
            this.colStaffNumber,
            this.colStaffId,
            this.colStaffLevelId,
            this.colIn,
            this.colInPosition,
            this.colRemark,
            this.colAction});
            this.dgvStaff.GridControl = this.dgcStaff;
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStaff.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStaff.OptionsView.ShowGroupPanel = false;
            this.dgvStaff.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvStaff_CustomUnboundColumnData);
            this.dgvStaff.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvStaff_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            // 
            // colYear
            // 
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            // 
            // colMonth
            // 
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.OptionsColumn.AllowEdit = false;
            // 
            // colWorkTeamId
            // 
            this.colWorkTeamId.FieldName = "WorkTeamId";
            this.colWorkTeamId.Name = "colWorkTeamId";
            this.colWorkTeamId.OptionsColumn.AllowEdit = false;
            // 
            // colWorkSectionId
            // 
            this.colWorkSectionId.Caption = "工段名称";
            this.colWorkSectionId.FieldName = "WorkSectionId";
            this.colWorkSectionId.Name = "colWorkSectionId";
            this.colWorkSectionId.OptionsColumn.AllowEdit = false;
            this.colWorkSectionId.Visible = true;
            this.colWorkSectionId.VisibleIndex = 0;
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.Caption = "职工工号";
            this.colStaffNumber.FieldName = "colStaffNumber";
            this.colStaffNumber.Name = "colStaffNumber";
            this.colStaffNumber.OptionsColumn.AllowEdit = false;
            this.colStaffNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStaffNumber.Visible = true;
            this.colStaffNumber.VisibleIndex = 1;
            // 
            // colStaffId
            // 
            this.colStaffId.Caption = "职员姓名";
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.OptionsColumn.AllowEdit = false;
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 2;
            // 
            // colStaffLevelId
            // 
            this.colStaffLevelId.Caption = "职员等级";
            this.colStaffLevelId.FieldName = "StaffLevelId";
            this.colStaffLevelId.Name = "colStaffLevelId";
            this.colStaffLevelId.OptionsColumn.AllowEdit = false;
            this.colStaffLevelId.Visible = true;
            this.colStaffLevelId.VisibleIndex = 3;
            // 
            // colIn
            // 
            this.colIn.Caption = "是否在岗";
            this.colIn.FieldName = "colIn";
            this.colIn.Name = "colIn";
            this.colIn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colIn.Visible = true;
            this.colIn.VisibleIndex = 4;
            // 
            // colInPosition
            // 
            this.colInPosition.Caption = "是否在岗";
            this.colInPosition.FieldName = "InPosition";
            this.colInPosition.Name = "colInPosition";
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 5;
            // 
            // colAction
            // 
            this.colAction.Caption = "选择职员";
            this.colAction.ColumnEdit = this.repoActionButton;
            this.colAction.Name = "colAction";
            this.colAction.Visible = true;
            this.colAction.VisibleIndex = 6;
            // 
            // repoActionButton
            // 
            this.repoActionButton.AutoHeight = false;
            this.repoActionButton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "选择职员", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "选择职员", null, null, true)});
            this.repoActionButton.Name = "repoActionButton";
            this.repoActionButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repoActionButton.Click += new System.EventHandler(this.repoActionButton_Click);
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Location = new System.Drawing.Point(12, 392);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(75, 23);
            this.btnAddStaff.TabIndex = 10;
            this.btnAddStaff.Text = "增加职员";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(107, 392);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 11;
            this.simpleButton2.Text = "删除职员";
            // 
            // FrmEditWorkSectionLabor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 427);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmEditWorkSectionLabor";
            this.Text = "WorkSectionLabor";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.btnAddStaff, 0);
            this.Controls.SetChildIndex(this.simpleButton2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLabors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoActionButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dgcStaff;
        private System.Windows.Forms.BindingSource bsLabors;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStaff;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkTeamId;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkSectionId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffLevelId;
        private DevExpress.XtraGrid.Columns.GridColumn colInPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoActionButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtWorkTeamName;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colIn;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffNumber;
        private DevExpress.XtraEditors.SimpleButton btnUsePrevious;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnAddStaff;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
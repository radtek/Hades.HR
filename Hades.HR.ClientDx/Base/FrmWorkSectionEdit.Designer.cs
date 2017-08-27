namespace Hades.HR.UI
{
    partial class FrmWorkSectionEdit
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.luProductionLine = new Hades.HR.UI.ProductionLineLookup();
            this.luCompany = new Hades.HR.UI.DepartmentLookup();
            this.cmbEnabled = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.luWorkTeam = new Hades.HR.UI.WorkTeamLookup();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtSortCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(358, 213);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(457, 213);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(271, 213);
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 208);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 210);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.luProductionLine);
            this.layoutControl1.Controls.Add(this.luCompany);
            this.layoutControl1.Controls.Add(this.cmbEnabled);
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.luWorkTeam);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtNumber);
            this.layoutControl1.Controls.Add(this.txtSortCode);
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(525, 184);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // luProductionLine
            // 
            this.luProductionLine.Location = new System.Drawing.Point(315, 36);
            this.luProductionLine.Name = "luProductionLine";
            this.luProductionLine.Size = new System.Drawing.Size(198, 20);
            this.luProductionLine.TabIndex = 11;
            this.luProductionLine.ProductionLineSelect += new System.EventHandler(this.luProductionLine_ProductionLineSelect);
            // 
            // luCompany
            // 
            this.luCompany.Location = new System.Drawing.Point(63, 36);
            this.luCompany.Name = "luCompany";
            this.luCompany.OnlyShowCompany = true;
            this.luCompany.Size = new System.Drawing.Size(197, 20);
            this.luCompany.TabIndex = 10;
            this.luCompany.DepartmentSelect += new System.EventHandler(this.luCompany_DepartmentSelect);
            // 
            // cmbEnabled
            // 
            this.cmbEnabled.EditValue = 0;
            this.cmbEnabled.Location = new System.Drawing.Point(315, 84);
            this.cmbEnabled.Name = "cmbEnabled";
            this.cmbEnabled.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEnabled.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("未启用", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("已启用", 1, -1)});
            this.cmbEnabled.Size = new System.Drawing.Size(198, 20);
            this.cmbEnabled.StyleController = this.layoutControl1;
            this.cmbEnabled.TabIndex = 9;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(63, 108);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(450, 64);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 8;
            // 
            // luWorkTeam
            // 
            this.luWorkTeam.Location = new System.Drawing.Point(63, 60);
            this.luWorkTeam.Name = "luWorkTeam";
            this.luWorkTeam.Size = new System.Drawing.Size(450, 20);
            this.luWorkTeam.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 1;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(315, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(198, 20);
            this.txtNumber.StyleController = this.layoutControl1;
            this.txtNumber.TabIndex = 2;
            // 
            // txtSortCode
            // 
            this.txtSortCode.Location = new System.Drawing.Point(63, 84);
            this.txtSortCode.Name = "txtSortCode";
            this.txtSortCode.Size = new System.Drawing.Size(197, 20);
            this.txtSortCode.StyleController = this.layoutControl1;
            this.txtSortCode.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(525, 184);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(252, 24);
            this.layoutControlItem1.Text = "名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtSortCode;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(252, 24);
            this.layoutControlItem4.Text = "排序码";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.luWorkTeam;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(505, 24);
            this.layoutControlItem7.Text = "所属班组";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtRemark;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(505, 68);
            this.layoutControlItem3.Text = "备注";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cmbEnabled;
            this.layoutControlItem5.Location = new System.Drawing.Point(252, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem5.Text = "是否启用";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtNumber;
            this.layoutControlItem2.Location = new System.Drawing.Point(252, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem2.Text = "编码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.luCompany;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(252, 24);
            this.layoutControlItem6.Text = "所属公司";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.luProductionLine;
            this.layoutControlItem8.Location = new System.Drawing.Point(252, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem8.Text = "所属产线";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            // 
            // FrmEditWorkSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 248);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEditWorkSection";
            this.Text = "WorkSection";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;

        private DevExpress.XtraEditors.TextEdit txtName;
          private DevExpress.XtraEditors.TextEdit txtNumber;
          private DevExpress.XtraEditors.TextEdit txtSortCode;
  
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private WorkTeamLookup luWorkTeam;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbEnabled;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private ProductionLineLookup luProductionLine;
        private DepartmentLookup luCompany;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
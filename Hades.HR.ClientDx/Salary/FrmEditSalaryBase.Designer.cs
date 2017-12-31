namespace Hades.HR.UI
{
    partial class FrmEditSalaryBase
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
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCardNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBaseBonus = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDepartmentBonus = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReserveFund = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtInsurance = new DevExpress.XtraEditors.SpinEdit();
            this.txtStaffNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtStaffName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtHighTemp = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.cmbStaffLevel = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.luDepartment = new Hades.HR.UI.DepartmentLookup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseBonus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentBonus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReserveFund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStaffNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStaffName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHighTemp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStaffLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(375, 322);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(474, 322);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(288, 322);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 317);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 319);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.cmbStaffLevel);
            this.layoutControl1.Controls.Add(this.luDepartment);
            this.layoutControl1.Controls.Add(this.txtHighTemp);
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtStaffName);
            this.layoutControl1.Controls.Add(this.txtStaffNumber);
            this.layoutControl1.Controls.Add(this.txtCardNumber);
            this.layoutControl1.Controls.Add(this.txtBaseBonus);
            this.layoutControl1.Controls.Add(this.txtDepartmentBonus);
            this.layoutControl1.Controls.Add(this.txtReserveFund);
            this.layoutControl1.Controls.Add(this.txtInsurance);
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(542, 293);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem10});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(542, 293);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCardNumber;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(522, 24);
            this.layoutControlItem2.Text = "银行卡号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(75, 60);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(455, 20);
            this.txtCardNumber.StyleController = this.layoutControl1;
            this.txtCardNumber.TabIndex = 2;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtBaseBonus;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem4.Text = "基本奖金";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txtBaseBonus
            // 
            this.txtBaseBonus.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBaseBonus.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBaseBonus.Location = new System.Drawing.Point(75, 108);
            this.txtBaseBonus.Name = "txtBaseBonus";
            this.txtBaseBonus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtBaseBonus.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtBaseBonus.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtBaseBonus.Size = new System.Drawing.Size(194, 20);
            this.txtBaseBonus.StyleController = this.layoutControl1;
            this.txtBaseBonus.TabIndex = 4;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtDepartmentBonus;
            this.layoutControlItem5.Location = new System.Drawing.Point(261, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem5.Text = "部门奖金";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txtDepartmentBonus
            // 
            this.txtDepartmentBonus.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDepartmentBonus.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtDepartmentBonus.Location = new System.Drawing.Point(336, 108);
            this.txtDepartmentBonus.Name = "txtDepartmentBonus";
            this.txtDepartmentBonus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDepartmentBonus.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDepartmentBonus.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDepartmentBonus.Size = new System.Drawing.Size(194, 20);
            this.txtDepartmentBonus.StyleController = this.layoutControl1;
            this.txtDepartmentBonus.TabIndex = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtReserveFund;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem6.Text = "公积金";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txtReserveFund
            // 
            this.txtReserveFund.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtReserveFund.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtReserveFund.Location = new System.Drawing.Point(75, 132);
            this.txtReserveFund.Name = "txtReserveFund";
            this.txtReserveFund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtReserveFund.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtReserveFund.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtReserveFund.Size = new System.Drawing.Size(194, 20);
            this.txtReserveFund.StyleController = this.layoutControl1;
            this.txtReserveFund.TabIndex = 6;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtInsurance;
            this.layoutControlItem7.Location = new System.Drawing.Point(261, 120);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem7.Text = "保险费";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txtInsurance
            // 
            this.txtInsurance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInsurance.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtInsurance.Location = new System.Drawing.Point(336, 132);
            this.txtInsurance.Name = "txtInsurance";
            this.txtInsurance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtInsurance.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtInsurance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtInsurance.Size = new System.Drawing.Size(194, 20);
            this.txtInsurance.StyleController = this.layoutControl1;
            this.txtInsurance.TabIndex = 7;
            // 
            // txtStaffNumber
            // 
            this.txtStaffNumber.Location = new System.Drawing.Point(75, 12);
            this.txtStaffNumber.Name = "txtStaffNumber";
            this.txtStaffNumber.Properties.ReadOnly = true;
            this.txtStaffNumber.Size = new System.Drawing.Size(194, 20);
            this.txtStaffNumber.StyleController = this.layoutControl1;
            this.txtStaffNumber.TabIndex = 12;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtStaffNumber;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem12.Text = "职员工号";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(336, 12);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Properties.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(194, 20);
            this.txtStaffName.StyleController = this.layoutControl1;
            this.txtStaffName.TabIndex = 13;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtStaffName;
            this.layoutControlItem13.Location = new System.Drawing.Point(261, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem13.Text = "职员姓名";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(75, 180);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(455, 101);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 14;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtRemark;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(522, 105);
            this.layoutControlItem8.Text = "备注";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txtHighTemp
            // 
            this.txtHighTemp.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHighTemp.Location = new System.Drawing.Point(75, 156);
            this.txtHighTemp.Name = "txtHighTemp";
            this.txtHighTemp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHighTemp.Size = new System.Drawing.Size(194, 20);
            this.txtHighTemp.StyleController = this.layoutControl1;
            this.txtHighTemp.TabIndex = 15;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtHighTemp;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem9.Text = "基础高温费";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(60, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(261, 144);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(261, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // cmbStaffLevel
            // 
            this.cmbStaffLevel.Location = new System.Drawing.Point(75, 84);
            this.cmbStaffLevel.Name = "cmbStaffLevel";
            this.cmbStaffLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStaffLevel.Size = new System.Drawing.Size(455, 20);
            this.cmbStaffLevel.StyleController = this.layoutControl1;
            this.cmbStaffLevel.TabIndex = 17;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.cmbStaffLevel;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(522, 24);
            this.layoutControlItem10.Text = "职员等级";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(60, 14);
            // 
            // luDepartment
            // 
            this.luDepartment.Location = new System.Drawing.Point(75, 36);
            this.luDepartment.Name = "luDepartment";
            this.luDepartment.OnlyShowCompany = false;
            this.luDepartment.Size = new System.Drawing.Size(455, 20);
            this.luDepartment.TabIndex = 16;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.luDepartment;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(522, 24);
            this.layoutControlItem1.Text = "财务部门";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // FrmEditStaffSalaryBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 357);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEditStaffSalaryBase";
            this.Text = "StaffSalaryDefine";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseBonus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentBonus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReserveFund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStaffNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStaffName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHighTemp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStaffLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
          private DevExpress.XtraEditors.TextEdit txtCardNumber;
          private DevExpress.XtraEditors.SpinEdit txtBaseBonus;
          private DevExpress.XtraEditors.SpinEdit txtDepartmentBonus;
          private DevExpress.XtraEditors.SpinEdit txtReserveFund;
          private DevExpress.XtraEditors.SpinEdit txtInsurance;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbStaffLevel;
        private DepartmentLookup luDepartment;
        private DevExpress.XtraEditors.SpinEdit txtHighTemp;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.TextEdit txtStaffName;
        private DevExpress.XtraEditors.TextEdit txtStaffNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
    }
}
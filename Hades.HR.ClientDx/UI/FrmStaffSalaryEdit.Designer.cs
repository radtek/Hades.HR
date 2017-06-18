namespace Hades.HR.UI
{
    partial class FrmStaffSalaryEdit
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
            this.luDepartment = new Hades.HR.UI.DepartmentLookup();
            this.txtCardNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtBaseSalary = new DevExpress.XtraEditors.SpinEdit();
            this.txtBaseBonus = new DevExpress.XtraEditors.SpinEdit();
            this.txtDepartmentBonus = new DevExpress.XtraEditors.SpinEdit();
            this.txtReserveFund = new DevExpress.XtraEditors.SpinEdit();
            this.txtInsurance = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseBonus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentBonus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReserveFund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(370, 203);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(469, 203);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(283, 203);
            this.btnAdd.Visible = false;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 198);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 200);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.luDepartment);
            this.layoutControl1.Controls.Add(this.txtCardNumber);
            this.layoutControl1.Controls.Add(this.txtBaseSalary);
            this.layoutControl1.Controls.Add(this.txtBaseBonus);
            this.layoutControl1.Controls.Add(this.txtDepartmentBonus);
            this.layoutControl1.Controls.Add(this.txtReserveFund);
            this.layoutControl1.Controls.Add(this.txtInsurance);
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(537, 174);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // luDepartment
            // 
            this.luDepartment.Location = new System.Drawing.Point(77, 14);
            this.luDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.luDepartment.Name = "luDepartment";
            this.luDepartment.OnlyShowCompany = false;
            this.luDepartment.Size = new System.Drawing.Size(446, 24);
            this.luDepartment.TabIndex = 8;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(77, 42);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(446, 24);
            this.txtCardNumber.StyleController = this.layoutControl1;
            this.txtCardNumber.TabIndex = 2;
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBaseSalary.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBaseSalary.Location = new System.Drawing.Point(77, 70);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtBaseSalary.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtBaseSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtBaseSalary.Size = new System.Drawing.Size(189, 24);
            this.txtBaseSalary.StyleController = this.layoutControl1;
            this.txtBaseSalary.TabIndex = 3;
            // 
            // txtBaseBonus
            // 
            this.txtBaseBonus.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBaseBonus.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBaseBonus.Location = new System.Drawing.Point(333, 70);
            this.txtBaseBonus.Name = "txtBaseBonus";
            this.txtBaseBonus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtBaseBonus.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtBaseBonus.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtBaseBonus.Size = new System.Drawing.Size(190, 24);
            this.txtBaseBonus.StyleController = this.layoutControl1;
            this.txtBaseBonus.TabIndex = 4;
            // 
            // txtDepartmentBonus
            // 
            this.txtDepartmentBonus.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDepartmentBonus.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtDepartmentBonus.Location = new System.Drawing.Point(77, 98);
            this.txtDepartmentBonus.Name = "txtDepartmentBonus";
            this.txtDepartmentBonus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDepartmentBonus.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDepartmentBonus.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDepartmentBonus.Size = new System.Drawing.Size(446, 24);
            this.txtDepartmentBonus.StyleController = this.layoutControl1;
            this.txtDepartmentBonus.TabIndex = 5;
            // 
            // txtReserveFund
            // 
            this.txtReserveFund.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtReserveFund.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtReserveFund.Location = new System.Drawing.Point(77, 126);
            this.txtReserveFund.Name = "txtReserveFund";
            this.txtReserveFund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtReserveFund.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtReserveFund.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtReserveFund.Size = new System.Drawing.Size(189, 24);
            this.txtReserveFund.StyleController = this.layoutControl1;
            this.txtReserveFund.TabIndex = 6;
            // 
            // txtInsurance
            // 
            this.txtInsurance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInsurance.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtInsurance.Location = new System.Drawing.Point(333, 126);
            this.txtInsurance.Name = "txtInsurance";
            this.txtInsurance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtInsurance.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtInsurance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtInsurance.Size = new System.Drawing.Size(190, 24);
            this.txtInsurance.StyleController = this.layoutControl1;
            this.txtInsurance.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(537, 174);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCardNumber;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(513, 28);
            this.layoutControlItem2.Text = "银行卡号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtBaseSalary;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(256, 28);
            this.layoutControlItem3.Text = "基本工资";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtDepartmentBonus;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(513, 28);
            this.layoutControlItem5.Text = "部门奖金";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtReserveFund;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 112);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(256, 38);
            this.layoutControlItem6.Text = "公积金";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtBaseBonus;
            this.layoutControlItem4.Location = new System.Drawing.Point(256, 56);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(257, 28);
            this.layoutControlItem4.Text = "基本奖金";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtInsurance;
            this.layoutControlItem7.Location = new System.Drawing.Point(256, 112);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(257, 38);
            this.layoutControlItem7.Text = "保险费";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.luDepartment;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(513, 28);
            this.layoutControlItem8.Text = "财务部门";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(60, 18);
            // 
            // FrmStaffSalaryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 238);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmStaffSalaryEdit";
            this.Text = "StaffSalary";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseBonus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentBonus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReserveFund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
          private DevExpress.XtraEditors.TextEdit txtCardNumber;
          private DevExpress.XtraEditors.SpinEdit txtBaseSalary;
          private DevExpress.XtraEditors.SpinEdit txtBaseBonus;
          private DevExpress.XtraEditors.SpinEdit txtDepartmentBonus;
          private DevExpress.XtraEditors.SpinEdit txtReserveFund;
          private DevExpress.XtraEditors.SpinEdit txtInsurance;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DepartmentLookup luDepartment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
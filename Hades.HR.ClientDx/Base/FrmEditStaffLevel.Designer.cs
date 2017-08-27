namespace Hades.HR.UI
{
    partial class FrmEditStaffLevel
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
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSalary = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSortCode = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(332, 196);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(431, 196);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(245, 196);
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 191);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 193);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtSalary);
            this.layoutControl1.Controls.Add(this.txtSortCode);
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(499, 167);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(499, 167);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(479, 24);
            this.layoutControlItem1.Text = "名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(424, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 1;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtSalary;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(479, 24);
            this.layoutControlItem2.Text = "级别工资";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtSalary
            // 
            this.txtSalary.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSalary.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtSalary.Location = new System.Drawing.Point(63, 36);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSalary.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtSalary.Size = new System.Drawing.Size(424, 20);
            this.txtSalary.StyleController = this.layoutControl1;
            this.txtSalary.TabIndex = 2;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtSortCode;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(479, 24);
            this.layoutControlItem3.Text = "排序码";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtSortCode
            // 
            this.txtSortCode.Location = new System.Drawing.Point(63, 60);
            this.txtSortCode.Name = "txtSortCode";
            this.txtSortCode.Size = new System.Drawing.Size(424, 20);
            this.txtSortCode.StyleController = this.layoutControl1;
            this.txtSortCode.TabIndex = 3;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(63, 84);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(424, 71);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 4;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtRemark;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(479, 75);
            this.layoutControlItem4.Text = "备注";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // FrmEditStaffLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 231);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEditStaffLevel";
            this.Text = "StaffLevel";
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;

        private DevExpress.XtraEditors.TextEdit txtName;
          private DevExpress.XtraEditors.SpinEdit txtSalary;
          private DevExpress.XtraEditors.TextEdit txtSortCode;
  
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
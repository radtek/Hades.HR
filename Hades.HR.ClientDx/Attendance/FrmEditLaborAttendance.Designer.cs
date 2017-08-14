namespace Hades.HR.UI
{
    partial class FrmEditLaborAttendance
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

            this.txtYear = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txtMonth = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txtDays = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
             
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();

            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();            
            ((System.ComponentModel.ISupportInitialize)(this.txtYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txtDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
             
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(438, 392);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(537, 392);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(351, 392);
            // 
            // layoutControl1
            //             
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(605, 363);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";

            this.layoutControl1.Controls.Add(this.txtYear);
             this.layoutControl1.Controls.Add(this.txtMonth);
             this.layoutControl1.Controls.Add(this.txtDays);
             this.layoutControl1.Controls.Add(this.txtRemark);
 
            this.txtYear.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtYear.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtYear.Location = new System.Drawing.Point(112, 12);
            this.txtYear.Name = "txtYear";
            this.txtYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtYear.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtYear.Size = new System.Drawing.Size(120, 20);
            this.txtYear.StyleController = this.layoutControl1;
            this.txtYear.TabIndex = 1;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtYear;
            this.layoutControlItem1.CustomizationFormText = "";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem1.Text = "";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 14);  

             this.txtMonth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonth.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtMonth.Location = new System.Drawing.Point(112, 36);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtMonth.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtMonth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtMonth.Size = new System.Drawing.Size(120, 20);
            this.txtMonth.StyleController = this.layoutControl1;
            this.txtMonth.TabIndex = 2;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMonth;
            this.layoutControlItem2.CustomizationFormText = "";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem2.Text = "";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 14);  

             this.txtDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDays.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtDays.Location = new System.Drawing.Point(112, 60);
            this.txtDays.Name = "txtDays";
            this.txtDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDays.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDays.Size = new System.Drawing.Size(120, 20);
            this.txtDays.StyleController = this.layoutControl1;
            this.txtDays.TabIndex = 3;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDays;
            this.layoutControlItem3.CustomizationFormText = "";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem3.Text = "";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 14);  

             // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(112, 84);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(481, 20);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 4;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtRemark;
            this.layoutControlItem4.CustomizationFormText = "";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem4.Text = "";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 14);  

 
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
	        this.layoutControlItem1
	 	       ,this.layoutControlItem2
	 	       ,this.layoutControlItem3
	 	       ,this.layoutControlItem4
	        });
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(605, 363);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;          

            // 
            // FrmEditLaborAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 427);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEditLaborAttendance";
            this.Text = "LaborAttendance";
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

            ((System.ComponentModel.ISupportInitialize)(this.txtYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();            
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;

        private DevExpress.XtraEditors.SpinEdit txtYear;
          private DevExpress.XtraEditors.SpinEdit txtMonth;
          private DevExpress.XtraEditors.SpinEdit txtDays;
          private DevExpress.XtraEditors.TextEdit txtRemark;
  
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
 
    }
}
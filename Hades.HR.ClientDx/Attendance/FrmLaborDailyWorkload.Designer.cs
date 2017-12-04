namespace Hades.HR.UI
{
    partial class FrmLaborDailyWorkload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLaborDailyWorkload));
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
        	this.winGridViewPager1 = new Hades.Pager.WinControl.WinGridViewPager();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);            
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();    


            this.txtWorkTeamId = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
 
            this.txtAttendanceDate1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAttendanceDate2 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
             
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();

            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();    

            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
 
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
 

 
 

	 	 		 			
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(698, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 22);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(773, 65);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(69, 22);
            this.btnAddNew.TabIndex = 15;
            this.btnAddNew.Text = "新建";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(848, 65);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(69, 22);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "导入";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(923, 65);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 22);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
            // 
            // winGridViewPager1
            // 
            this.winGridViewPager1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.winGridViewPager1.AppendedMenu = null;
            this.winGridViewPager1.DataSource = null;
            this.winGridViewPager1.DisplayColumns = "";
            this.winGridViewPager1.Location = new System.Drawing.Point(12, 95);
            this.winGridViewPager1.MinimumSize = new System.Drawing.Size(540, 0);
            this.winGridViewPager1.Name = "winGridViewPager1";
            this.winGridViewPager1.PrintTitle = "";
            this.winGridViewPager1.ShowCheckBox = false;
            this.winGridViewPager1.Size = new System.Drawing.Size(980, 580);
            this.winGridViewPager1.TabIndex = 11;
            // 
            // layoutControl1
            //             
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(70, 185, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(980, 53);
            this.layoutControl1.TabIndex = 12;
            this.layoutControl1.Text = "layoutControl1";


            this.layoutControl1.Controls.Add(this.txtWorkTeamId);

 
            this.layoutControl1.Controls.Add(this.txtAttendanceDate1);
            this.layoutControl1.Controls.Add(this.txtAttendanceDate2);

 

            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtWorkTeamId;
            this.layoutControlItem1.CustomizationFormText = "";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(150, 25);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(80, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(150, 25);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Default;
            this.layoutControlItem1.Text = "";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14); 
            // 
            // txtWorkTeamId
            // 
            this.txtWorkTeamId.Location = new System.Drawing.Point(64, 12);
            this.txtWorkTeamId.Name = "txtWorkTeamId";
            this.txtWorkTeamId.Size = new System.Drawing.Size(122, 20);
            this.txtWorkTeamId.StyleController = this.layoutControl1;
            this.txtWorkTeamId.TabIndex = 1;


 
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtAttendanceDate1;
            this.layoutControlItem2.CustomizationFormText = "1";
            this.layoutControlItem2.Location = new System.Drawing.Point(178, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(150, 25);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(80, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(150, 25);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Default;
            this.layoutControlItem2.Text = "";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14); 
            // 
            // txtAttendanceDate
            // 
            this.txtAttendanceDate1.Location = new System.Drawing.Point(242, 12);
            this.txtAttendanceDate1.Name = "txtAttendanceDate1";
            this.txtAttendanceDate1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtAttendanceDate1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.txtAttendanceDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAttendanceDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtAttendanceDate1.Properties.VistaTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtAttendanceDate1.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.txtAttendanceDate1.Size = new System.Drawing.Size(122, 20);
            this.txtAttendanceDate1.StyleController = this.layoutControl1;
            this.txtAttendanceDate1.TabIndex = 2;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtAttendanceDate2;
            this.layoutControlItem3.CustomizationFormText = "2";
            this.layoutControlItem3.Location = new System.Drawing.Point(356, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(150, 25);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(80, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(150, 25);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Default;
            this.layoutControlItem3.Text = "";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14); 
            // 
            // txtAttendanceDate
            // 
            this.txtAttendanceDate2.Location = new System.Drawing.Point(420, 12);
            this.txtAttendanceDate2.Name = "txtAttendanceDate2";
            this.txtAttendanceDate2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtAttendanceDate2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.txtAttendanceDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAttendanceDate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtAttendanceDate2.Properties.VistaTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtAttendanceDate2.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtAttendanceDate2.Size = new System.Drawing.Size(122, 20);
            this.txtAttendanceDate2.StyleController = this.layoutControl1;
            this.txtAttendanceDate2.TabIndex = 3;


 
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {

							this.layoutControlItem1
			 
					       ,this.layoutControlItem2
				       ,this.layoutControlItem3
			        });
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(605, 363);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;          

            // 
            // FrmLaborDailyWorkload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.winGridViewPager1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Name = "FrmLaborDailyWorkload";
            this.Text = "LaborDailyWorkload";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTeamId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit(); 
            ((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAttendanceDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit(); 
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Hades.Pager.WinControl.WinGridViewPager winGridViewPager1;

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;


        private DevExpress.XtraEditors.TextEdit txtWorkTeamId; 
 
        private DevExpress.XtraEditors.DateEdit txtAttendanceDate1;  
        private DevExpress.XtraEditors.DateEdit txtAttendanceDate2;  
 
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;    
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;  
 
    }
}
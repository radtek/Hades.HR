namespace Hades.HR.UI
{
    partial class FrmDepartment
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.depTree = new Hades.HR.UI.DepartmentTreeGrid();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 680F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 680);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.depTree);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(998, 674);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "部门列表";
            // 
            // depTree
            // 
            this.depTree.DataSource = null;
            this.depTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.depTree.EnableFocusCellStyle = false;
            this.depTree.Location = new System.Drawing.Point(2, 25);
            this.depTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.depTree.Name = "depTree";
            this.depTree.ShowContextMenu = true;
            this.depTree.ShowMenuCreate = true;
            this.depTree.ShowMenuDelete = true;
            this.depTree.ShowMenuEdit = true;
            this.depTree.ShowMenuView = true;
            this.depTree.ShowNameOnly = false;
            this.depTree.Size = new System.Drawing.Size(994, 647);
            this.depTree.TabIndex = 0;
            this.depTree.DepartmentCreate += new System.EventHandler(this.depTree_DepartmentCreate);
            this.depTree.DepartmentView += new System.EventHandler(this.depTree_DepartmentView);
            this.depTree.DepartmentEdit += new System.EventHandler(this.depTree_DepartmentEdit);
            this.depTree.DepartmentDelete += new System.EventHandler(this.depTree_DepartmentDelete);
            this.depTree.DepartmentDoubleClick += new System.EventHandler(this.depTree_DepartmentDoubleClick);
            // 
            // FrmDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDepartment";
            this.Text = "部门管理";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DepartmentTreeGrid depTree;
    }
}
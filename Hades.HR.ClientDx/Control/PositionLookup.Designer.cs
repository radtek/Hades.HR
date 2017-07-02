namespace Hades.HR.UI
{
    partial class PositionLookup
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.luPosition = new DevExpress.XtraEditors.LookUpEdit();
            this.bsPosition = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.luPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // luPosition
            // 
            this.luPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luPosition.Location = new System.Drawing.Point(0, 0);
            this.luPosition.Margin = new System.Windows.Forms.Padding(4);
            this.luPosition.Name = "luPosition";
            this.luPosition.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.luPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luPosition.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 34, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "岗位编码", 53, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "岗位名称", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.luPosition.Properties.DataSource = this.bsPosition;
            this.luPosition.Properties.DisplayMember = "Name";
            this.luPosition.Properties.NullText = "请选择岗位";
            this.luPosition.Properties.ValueMember = "Id";
            this.luPosition.Size = new System.Drawing.Size(305, 24);
            this.luPosition.TabIndex = 0;
            // 
            // bsPosition
            // 
            this.bsPosition.DataSource = typeof(Hades.HR.Entity.PositionInfo);
            // 
            // PositionLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.luPosition);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PositionLookup";
            this.Size = new System.Drawing.Size(305, 25);
            ((System.ComponentModel.ISupportInitialize)(this.luPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit luPosition;
        private System.Windows.Forms.BindingSource bsPosition;
    }
}

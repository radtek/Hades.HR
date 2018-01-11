namespace Hades.HR.UI
{
    partial class WorkSectionLookup
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
            this.luWorkSection = new DevExpress.XtraEditors.LookUpEdit();
            this.bsWorkSection = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.luWorkSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWorkSection)).BeginInit();
            this.SuspendLayout();
            // 
            // luWorkSection
            // 
            this.luWorkSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luWorkSection.Location = new System.Drawing.Point(0, 0);
            this.luWorkSection.Name = "luWorkSection";
            this.luWorkSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luWorkSection.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称", 49, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "编码", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caption", "工段长", 58, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.luWorkSection.Properties.DataSource = this.bsWorkSection;
            this.luWorkSection.Properties.DisplayMember = "Name";
            this.luWorkSection.Properties.NullText = "请选择工段";
            this.luWorkSection.Properties.ValueMember = "Id";
            this.luWorkSection.Size = new System.Drawing.Size(297, 24);
            this.luWorkSection.TabIndex = 0;
            // 
            // bsWorkSection
            // 
            this.bsWorkSection.DataSource = typeof(Hades.HR.Entity.WorkSectionInfo);
            // 
            // WorkSectionLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.luWorkSection);
            this.Name = "WorkSectionLookup";
            this.Size = new System.Drawing.Size(297, 25);
            ((System.ComponentModel.ISupportInitialize)(this.luWorkSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWorkSection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit luWorkSection;
        private System.Windows.Forms.BindingSource bsWorkSection;
    }
}

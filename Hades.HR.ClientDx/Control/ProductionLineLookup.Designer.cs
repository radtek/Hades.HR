namespace Hades.HR.UI
{
    partial class ProductionLineLookup
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
            this.luProductionLine = new DevExpress.XtraEditors.LookUpEdit();
            this.bsProductionLine = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.luProductionLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProductionLine)).BeginInit();
            this.SuspendLayout();
            // 
            // luProductionLine
            // 
            this.luProductionLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luProductionLine.Location = new System.Drawing.Point(0, 0);
            this.luProductionLine.Name = "luProductionLine";
            this.luProductionLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProductionLine.Properties.DataSource = this.bsProductionLine;
            this.luProductionLine.Properties.NullText = "请选择产线";
            this.luProductionLine.Size = new System.Drawing.Size(217, 20);
            this.luProductionLine.TabIndex = 0;
            // 
            // bsProductionLine
            // 
            this.bsProductionLine.DataSource = typeof(Hades.HR.Entity.ProductionLineInfo);
            // 
            // ProductionLineLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.luProductionLine);
            this.Name = "ProductionLineLookup";
            this.Size = new System.Drawing.Size(217, 20);
            ((System.ComponentModel.ISupportInitialize)(this.luProductionLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProductionLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit luProductionLine;
        private System.Windows.Forms.BindingSource bsProductionLine;
    }
}

namespace Hades.HR.UI
{
    partial class WorkTeamLookup
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
            this.luWorkTeam = new DevExpress.XtraEditors.LookUpEdit();
            this.bsWorkTeam = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.luWorkTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWorkTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // luWorkTeam
            // 
            this.luWorkTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luWorkTeam.Location = new System.Drawing.Point(0, 0);
            this.luWorkTeam.Name = "luWorkTeam";
            this.luWorkTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luWorkTeam.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 34, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "编码", 53, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.luWorkTeam.Properties.DataSource = this.bsWorkTeam;
            this.luWorkTeam.Properties.DisplayMember = "Name";
            this.luWorkTeam.Properties.NullText = "请选择班组";
            this.luWorkTeam.Properties.ValueMember = "Id";
            this.luWorkTeam.Size = new System.Drawing.Size(240, 20);
            this.luWorkTeam.TabIndex = 0;
            // 
            // bsWorkTeam
            // 
            this.bsWorkTeam.DataSource = typeof(Hades.HR.Entity.WorkTeamInfo);
            // 
            // WorkTeamLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.luWorkTeam);
            this.Name = "WorkTeamLookup";
            this.Size = new System.Drawing.Size(240, 20);
            ((System.ComponentModel.ISupportInitialize)(this.luWorkTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWorkTeam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit luWorkTeam;
        private System.Windows.Forms.BindingSource bsWorkTeam;
    }
}

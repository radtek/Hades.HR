namespace Hades.HR.UI
{
    partial class PositionTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionTree));
            this.treePos = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treePos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // treePos
            // 
            this.treePos.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colName,
            this.colType});
            this.treePos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePos.Location = new System.Drawing.Point(0, 0);
            this.treePos.Name = "treePos";
            this.treePos.OptionsBehavior.Editable = false;
            this.treePos.OptionsCustomization.AllowQuickHideColumns = false;
            this.treePos.OptionsFilter.AllowFilterEditor = false;
            this.treePos.Size = new System.Drawing.Size(215, 353);
            this.treePos.StateImageList = this.imgCollection;
            this.treePos.TabIndex = 0;
            this.treePos.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treePos_FocusedNodeChanged);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "colId";
            this.colId.Name = "colId";
            // 
            // colName
            // 
            this.colName.Caption = "名称";
            this.colName.FieldName = "名称";
            this.colName.MinWidth = 33;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 66;
            // 
            // colType
            // 
            this.colType.Caption = "类型";
            this.colType.FieldName = "colType";
            this.colType.Name = "colType";
            this.colType.Width = 66;
            // 
            // imgCollection
            // 
            this.imgCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCollection.ImageStream")));
            this.imgCollection.InsertGalleryImage("documentmap_16x16.png", "images/navigation/documentmap_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/documentmap_16x16.png"), 0);
            this.imgCollection.Images.SetKeyName(0, "documentmap_16x16.png");
            this.imgCollection.InsertGalleryImage("home_16x16.png", "images/navigation/home_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/home_16x16.png"), 1);
            this.imgCollection.Images.SetKeyName(1, "home_16x16.png");
            this.imgCollection.InsertGalleryImage("boposition2_16x16.png", "images/business%20objects/boposition2_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/boposition2_16x16.png"), 2);
            this.imgCollection.Images.SetKeyName(2, "boposition2_16x16.png");
            this.imgCollection.InsertGalleryImage("team_16x16.png", "images/people/team_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/team_16x16.png"), 3);
            this.imgCollection.Images.SetKeyName(3, "team_16x16.png");
            this.imgCollection.InsertGalleryImage("reading_16x16.png", "images/actions/reading_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/reading_16x16.png"), 4);
            this.imgCollection.Images.SetKeyName(4, "reading_16x16.png");
            // 
            // PositionTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treePos);
            this.Name = "PositionTree";
            this.Size = new System.Drawing.Size(215, 353);
            this.Load += new System.EventHandler(this.PositionTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treePos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treePos;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.Utils.ImageCollection imgCollection;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hades.HR.UI
{
    using Hades.HR.Facade;
    using Hades.HR.Entity;
    using Framework.ControlUtil.Facade;    

    /// <summary>
    /// 部门树形表格
    /// </summary>
    public partial class DepartmentTreeGrid : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 显示菜单
        /// </summary>
        private bool showContextMenu = true;

        /// <summary>
        /// 显示菜单 - 新增
        /// </summary>

        private bool showMenuCreate = false;

        /// <summary>
        /// 显示菜单 - 查看
        /// </summary>
        private bool showMenuView = false;

        /// <summary>
        /// 显示菜单 - 编辑
        /// </summary>
        private bool showMenuEdit = false;

        /// <summary>
        /// 显示菜单 - 删除
        /// </summary>
        private bool showMenuDelete = false;

        /// <summary>
        /// 是否只显示名称列
        /// </summary>
        private bool showNameOnly = false;

        /// <summary>
        /// 是否启用激活单元格样式
        /// </summary>
        private bool enableFocusCellStyle = false;
        #endregion //Field

        #region Constructor
        public DepartmentTreeGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化部门树
        /// </summary>
        /// <param name="level">显示到第几级</param>
        public void Init(int level)
        {
            var departments = CallerFactory<IDepartmentService>.Instance.Find2(string.Format("Enabled = 1 AND Deleted=0 AND Type <= {0}", level), "ORDER BY SortCode");
            this.bsDepartment.DataSource = departments;
        }

        /// <summary>
        /// 获取当前选中对象
        /// </summary>
        /// <returns></returns>
        public DepartmentInfo GetSelectedObject()
        {
            var node = this.tlView.Selection[0];
            if (node == null)
                return null;

            return this.tlView.GetDataRecordByNode(node) as DepartmentInfo;
        }

        /// <summary>
        /// 获取当前选中行ID
        /// </summary>
        /// <returns></returns>
        public string GetCurrentSelectId()
        {
            var node = this.tlView.Selection[0];
            if (node == null)
                return null;

            return node["Id"].ToString();
        }

        /// <summary>
        /// 获取ID列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetIDList()
        {
            var data = this.bsDepartment.DataSource as List<DepartmentInfo>;
            return data.Select(r => r.Id).ToList().ConvertAll<string>(s => s.ToString());
        }

        /// <summary>
        /// 展开树
        /// </summary>
        public void Expand()
        {
            this.tlView.ExpandAll();
        }

        /// <summary>
        /// 增加菜单
        /// </summary>
        /// <param name="menu"></param>
        public void AppendMenu(ContextMenuStrip menu)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                this.contextMenuStrip1.Items.Add(menu.Items[i]);
            }
        }
        #endregion //Method

        #region Delegate
        /// <summary>
        /// 菜单新增事件
        /// </summary>
        [Description("菜单新增事件")]
        public event EventHandler DepartmentCreate;

        /// <summary>
        /// 菜单查看事件
        /// </summary>
        [Description("菜单查看事件")]
        public event EventHandler DepartmentView;

        /// <summary>
        /// 菜单编辑事件
        /// </summary>
        [Description("菜单编辑事件")]
        public event EventHandler DepartmentEdit;

        /// <summary>
        /// 菜单删除事件
        /// </summary>
        [Description("菜单删除事件")]
        public event EventHandler DepartmentDelete;

        /// <summary>
        /// 部门选择事件
        /// </summary>
        [Description("部门选择事件")]
        public event EventHandler DepartmentSelect;

        /// <summary>
        /// 部门双击事件
        /// </summary>
        [Description("部门双击事件")]
        public event EventHandler DepartmentDoubleClick;
        #endregion //Delegate

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartmentTreeGrid_Load(object sender, EventArgs e)
        {
            if (this.showContextMenu)
                this.ContextMenuStrip = this.contextMenuStrip1;
            else
            {
                this.contextMenuStrip1.Items.Clear();
                //this.ContextMenuStrip = null;
            }

            this.menuCreate.Visible = this.showMenuCreate;
            this.menuView.Visible = this.showMenuView;
            this.menuEdit.Visible = this.showMenuEdit;
            this.menuDelete.Visible = this.showMenuDelete;

            this.colNumber.Visible = !this.showNameOnly;
            this.colSortCode.Visible = !this.showNameOnly;
            this.colAddress.Visible = !this.showNameOnly;
            this.colType.Visible = !this.showNameOnly;
            this.colPrincipal.Visible = !this.showNameOnly;
            this.colFax.Visible = !this.showNameOnly;
            this.colInnerPhone.Visible = !this.showNameOnly;
            this.colOuterPhone.Visible = !this.showNameOnly;
            this.colRemark.Visible = !this.showNameOnly;
            this.colEnabled.Visible = !this.showNameOnly;

            if (this.enableFocusCellStyle)
                this.tlView.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightBlue;
            else
                this.tlView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
        }

        /// <summary>
        /// 选择节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlView_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DepartmentSelect?.Invoke(sender, e);
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlView_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
            var dep = this.tlView.GetDataRecordByNode(e.Node) as DepartmentInfo;

            if (e.Column.FieldName == "Type")
            {
                e.Value = ((DepartmentType)dep.Type).DisplayName();
            }
            else if (e.Column.FieldName == "Enabled")
            {
                e.Value = Convert.ToInt32(e.Value) == 0 ? "未启用" : "已启用";
            }
        }

        /// <summary>
        /// 菜单 - 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCreate_Click(object sender, EventArgs e)
        {
            DepartmentCreate?.Invoke(sender, e);
        }

        /// <summary>
        /// 菜单 - 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuView_Click(object sender, EventArgs e)
        {
            DepartmentView?.Invoke(sender, e);
        }

        /// <summary>
        /// 菜单 - 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEdit_Click(object sender, EventArgs e)
        {
            DepartmentEdit?.Invoke(sender, e);
        }

        /// <summary>
        /// 菜单 - 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, EventArgs e)
        {
            DepartmentDelete?.Invoke(sender, e);
        }

        /// <summary>
        /// 双击控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlView_DoubleClick(object sender, EventArgs e)
        {
            DepartmentDoubleClick?.Invoke(sender, e);
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源"), Category("数据"), Browsable(true)]
        public List<DepartmentInfo> DataSource
        {
            get
            {
                return this.bsDepartment.DataSource as List<DepartmentInfo>;
            }
            set
            {
                this.tlView.BeginUpdate();
                this.bsDepartment.DataSource = value;
                this.tlView.EndUpdate();
            }
        }

        /// <summary>
        /// 显示菜单
        /// </summary>
        [Description("显示菜单"), Category("界面"), Browsable(true)]
        public bool ShowContextMenu
        {
            get
            {
                return showContextMenu;
            }

            set
            {
                showContextMenu = value;
            }
        }

        /// <summary>
        /// 显示菜单 - 新增
        /// </summary>
        [Description("显示新增菜单"), Category("界面"), Browsable(true)]
        public bool ShowMenuCreate
        {
            get
            {
                return showMenuCreate;
            }

            set
            {
                showMenuCreate = value;
            }
        }

        /// <summary>
        /// 显示菜单 - 查看
        /// </summary>
        [Description("显示查看菜单"), Category("界面"), Browsable(true)]
        public bool ShowMenuView
        {
            get
            {
                return showMenuView;
            }

            set
            {
                showMenuView = value;
            }
        }

        /// <summary>
        /// 显示菜单 - 编辑
        /// </summary>
        [Description("显示编辑菜单"), Category("界面"), Browsable(true)]
        public bool ShowMenuEdit
        {
            get
            {
                return this.showMenuEdit;
            }
            set
            {
                this.showMenuEdit = value;
            }
        }

        /// <summary>
        /// 显示菜单 - 删除
        /// </summary>
        [Description("显示删除菜单"), Category("界面"), Browsable(true)]
        public bool ShowMenuDelete
        {
            get
            {
                return showMenuDelete;
            }

            set
            {
                showMenuDelete = value;
            }
        }

        /// <summary>
        /// 是否只显示名称列
        /// </summary>
        [Description("是否只显示名称列"), Category("界面"), Browsable(true)]
        public bool ShowNameOnly
        {
            get
            {
                return showNameOnly;
            }

            set
            {
                showNameOnly = value;
            }
        }

        /// <summary>
        /// 是否启用激活单元格样式
        /// </summary>
        [Description("是否启用激活单元格样式"), Category("界面"), Browsable(true)]
        public bool EnableFocusCellStyle
        {
            get
            {
                return enableFocusCellStyle;
            }

            set
            {
                enableFocusCellStyle = value;
            }
        }
        #endregion //Property
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hades.HR.UI
{
    using Hades.Framework.BaseUI;
    using Hades.Framework.Commons;
    using Hades.Framework.ControlUtil;
    using Hades.Framework.ControlUtil.Facade;
    using Hades.HR.Facade;
    using Hades.HR.Entity;

    /// <summary>
    /// 部门选择下拉控件
    /// </summary>
    public partial class DepartmentLookup : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 是否只显示公司级
        /// </summary>
        private bool onlyShowCompany = false;
        #endregion //Field

        #region Constructor
        public DepartmentLookup()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化部门数据
        /// </summary>
        public void Init()
        {
            var data = CallerFactory<IDepartmentService>.Instance.Find2("deleted=0 AND enabled=1", "ORDER BY SortCode");
            if (this.onlyShowCompany)
            {
                data = data.Where(r => r.Type == (int)DepartmentType.Group || r.Type == (int)DepartmentType.Company).ToList();
            }
            this.bsDepartment.DataSource = data;
        }

        /// <summary>
        /// 设置选中部门
        /// </summary>
        /// <param name="departmentId"></param>
        public void SetSelected(string departmentId)
        {
            if (string.IsNullOrEmpty(departmentId))
                this.luDepartment.EditValue = null;
            else
                this.luDepartment.EditValue = departmentId;
        }

        /// <summary>
        /// 获取当前选中部门
        /// </summary>
        /// <returns></returns>
        public DepartmentInfo GetSelected()
        {
            if (this.luDepartment.EditValue == null)
                return null;
            else
            {
                var dep = this.luDepartment.GetSelectedDataRow() as DepartmentInfo;
                return dep;
            }
        }

        /// <summary>
        /// 获取当前选中部门ID
        /// </summary>
        /// <returns></returns>
        public string GetSelectedId()
        {
            if (this.luDepartment.EditValue == null)
                return "";
            else
            {
                var dep = this.luDepartment.GetSelectedDataRow() as DepartmentInfo;
                return dep.Id;
            }
        }
        #endregion //Method

        #region Delegate
        /// <summary>
        /// 部门选择事件
        /// </summary>
        [Description("部门选择事件")]
        public event EventHandler DepartmentSelect;
        #endregion //Delegate

        #region Event
        /// <summary>
        /// 部门选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luDepartment_EditValueChanged(object sender, EventArgs e)
        {
            DepartmentSelect?.Invoke(sender, e);
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListLookUpEdit1TreeList_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
            var dep = this.treeListLookUpEdit1TreeList.GetDataRecordByNode(e.Node) as DepartmentInfo;

            if (e.Column.FieldName == "Type")
            {
                e.Value = ((DepartmentType)dep.Type).DisplayName();
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 是否只显示公司级
        /// </summary>
        [Description("是否只显示公司级"), Category("界面"), Browsable(true)]
        public bool OnlyShowCompany
        {
            get
            {
                return onlyShowCompany;
            }

            set
            {
                onlyShowCompany = value;
            }
        }
        #endregion //Property
    }
}

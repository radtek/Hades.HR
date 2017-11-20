using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hades.HR.UI
{
    using Hades.HR.Facade;
    using Hades.HR.Entity;
    using Framework.ControlUtil.Facade;
    using DevExpress.XtraTreeList.Nodes;

    /// <summary>
    /// 班组树控件
    /// </summary>
    public partial class WorkTeamTree : UserControl
    {
        #region Field
        /// <summary>
        /// 关联班组
        /// </summary>
        private List<WorkTeamInfo> workTeams;
        #endregion //Field

        #region Constructor
        public WorkTeamTree()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 增加公司节点
        /// </summary>
        private void AppendCompanyNodes()
        {
            var companys = CallerFactory<IDepartmentService>.Instance.Find2("Type=2", "ORDER BY SortCode");
            foreach (var item in companys)
            {
                var node = this.tlTeam.AppendNode(new object[] { item.Id, item.Name, 1 }, null);
                node.StateImageIndex = 0;
                node.HasChildren = true;

                AppendTeamNodes(item, node);
            }
        }

        /// <summary>
        /// 增加班组节点
        /// </summary>
        /// <param name="department"></param>
        /// <param name="parentNode"></param>
        private void AppendTeamNodes(DepartmentInfo department, TreeListNode parentNode)
        {
            var teams = this.workTeams.Where(r => r.CompanyId == department.Id);

            foreach (var item in teams)
            {
                var node = this.tlTeam.AppendNode(new object[] { item.Id, item.Name, 2 }, parentNode);
                node.StateImageIndex = 1;
                node.HasChildren = false;
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.workTeams = CallerFactory<IWorkTeamService>.Instance.Find2("Enabled=1 AND Deleted=0", "ORDER BY SortCode");

            AppendCompanyNodes();
        }

        /// <summary>
        /// 获取选择班组ID
        /// </summary>
        /// <returns></returns>
        public string GetSelectedTeamId()
        {
            var node = this.tlTeam.FocusedNode;
            if (node == null)
                return "";

            int type = Convert.ToInt32(node["colType"]);
            if (type == 2)
                return node["colId"].ToString();
            else
                return "";
        }

        /// <summary>
        /// 获取选择节点类型
        /// </summary>
        /// <returns>
        /// 1:公司，2:产线，3:班组
        /// </returns>
        public int GetSelectType()
        {
            var node = this.tlTeam.FocusedNode;
            if (node == null)
                return 0;

            int type = Convert.ToInt32(node["colType"]);
            return type;
        }
        #endregion //Method

        #region Delegate
        /// <summary>
        /// 班组选择事件
        /// </summary>
        [Description("班组选择事件")]
        public event EventHandler TeamSeleted;
        #endregion //Delegate

        #region Event
        private void tlTeam_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null)
                return;

            int type = Convert.ToInt32(e.Node["colType"]);
            if (type == 2)
            {
                TeamSeleted?.Invoke(sender, e);
            }
        }
        #endregion //Event
    }
}

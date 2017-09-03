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
    /// 产线树控件
    /// </summary>
    public partial class ProductionLineTree : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        private List<ProductionLineInfo> productionLines;

        private List<WorkTeamInfo> workTeams;
        #endregion //Field

        #region Constructor
        public ProductionLineTree()
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
                var node = this.trList.AppendNode(new object[] { item.Id, item.Name, 1 }, null);
                node.StateImageIndex = 0;
                node.HasChildren = true;

                AppendLineNodes(item, node);
            }
        }

        /// <summary>
        /// 增加产线节点
        /// </summary>
        /// <param name="company"></param>
        /// <param name="parentNode"></param>
        private void AppendLineNodes(DepartmentInfo company, TreeListNode parentNode)
        {
            var lines = this.productionLines.Where(r => r.CompanyId == company.Id);

            foreach (var item in lines)
            {
                var node = this.trList.AppendNode(new object[] { item.Id, item.Name, 2 }, parentNode);
                node.StateImageIndex = 1;
                node.HasChildren = true;

                AppendTeamNodes(item, node);
            }
        }

        /// <summary>
        /// 增加班组节点
        /// </summary>
        /// <param name="line"></param>
        /// <param name="parentNode"></param>
        private void AppendTeamNodes(ProductionLineInfo line, TreeListNode parentNode)
        {
            var teams = this.workTeams.Where(r => r.ProductionLineId == line.Id);

            foreach (var item in teams)
            {
                var node = this.trList.AppendNode(new object[] { item.Id, item.Name, 3 }, parentNode);
                node.StateImageIndex = 2;
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
            this.productionLines = CallerFactory<IProductionLineService>.Instance.Find2("Enabled=1 AND Deleted=0", "ORDER BY SortCode");
            this.workTeams = CallerFactory<IWorkTeamService>.Instance.Find2("Enabled=1 AND Deleted=0", "ORDER BY SortCode");

            AppendCompanyNodes();
        }

        /// <summary>
        /// 获取选择班组ID
        /// </summary>
        /// <returns></returns>
        public string GetSelectedTeamId()
        {
            var node = this.trList.FocusedNode;
            if (node == null)
                return "";

            int type = Convert.ToInt32(node["colType"]);
            if (type == 3)
                return node["colId"].ToString();
            else
                return "";
        }
        #endregion //Method

        #region Delegate
        /// <summary>
        /// 产线选择事件
        /// </summary>
        [Description("产线选择事件")]
        public event EventHandler LineSelected;

        /// <summary>
        /// 班组选择事件
        /// </summary>
        [Description("班组选择事件")]
        public event EventHandler TeamSeleted;
        #endregion //Delegate

        #region Event
        private void trList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null)
                return;

            int type = Convert.ToInt32(e.Node["colType"]);
            if (type == 2)
            {
                LineSelected?.Invoke(sender, e);
            }
            else if (type == 3)
            {
                TeamSeleted?.Invoke(sender, e);
            }
        }
        #endregion //Event
    }
}

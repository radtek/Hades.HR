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
    using DevExpress.XtraTreeList.Nodes;
    using Hades.Pager.Entity;
    using Hades.Dictionary;
    using Hades.Security.Entity;
    using Hades.Framework.BaseUI;
    using Hades.Framework.Commons;
    using Hades.Framework.ControlUtil;
    using Hades.Framework.ControlUtil.Facade;
    using Hades.HR.Facade;
    using Hades.HR.Entity;

    /// <summary>
    /// 岗位树形控件
    /// </summary>
    public partial class PositionTree : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field

        #endregion //Field

        #region Constructor
        public PositionTree()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入根节点
        /// </summary>
        private void LoadOUNode()
        {
            var tops = CallerFactory<Hades.Security.Facade.IOUService>.Instance.GetTopGroup();

            this.treePos.BeginUnboundLoad();
            this.treePos.Nodes.Clear();

            foreach (var item in tops)
            {
                int level = 1;
                switch (item.Category)
                {
                    case "集团":
                        level = 0;
                        break;
                    case "公司":
                        level = 1;
                        break;
                    case "部门":
                        level = 2;
                        break;
                    case "工作组":
                        level = 3;
                        break;
                }

                var node = this.treePos.AppendNode(new object[] { item.ID, item.Name, level }, null);
                node.StateImageIndex = level;
                node.HasChildren = true;
                node.Expanded = true;

                AddPositionNode(node);

                //获取下级机构
                List<OUNodeInfo> list = CallerFactory<Hades.Security.Facade.IOUService>.Instance.GetTreeByID(item.ID);
                AddOUNode(list, node);
            }

            this.treePos.EndUnboundLoad();
        }

        /// <summary>
        /// 添加机构节点到Tree中
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentNode"></param>
        private void AddOUNode(List<OUNodeInfo> list, TreeListNode parentNode)
        {
            foreach (OUNodeInfo ouInfo in list)
            {
                int level = 1;
                switch (ouInfo.Category)
                {
                    case "集团":
                        level = 0;
                        break;
                    case "公司":
                        level = 1;
                        break;
                    case "部门":
                        level = 2;
                        break;
                    case "工作组":
                        level = 3;
                        break;
                }
                var node = this.treePos.AppendNode(new object[] { ouInfo.ID, ouInfo.Name, level }, parentNode);
                node.StateImageIndex = level;

                //if (ouInfo.Deleted)
                //{
                //    ouNode.ForeColor = Color.Red;
                //    continue;//跳过不显示
                //}               

                AddPositionNode(node);
                AddOUNode(ouInfo.Children, node);
            }
        }

        /// <summary>
        /// 添加岗位节点
        /// </summary>
        /// <param name="parentNode"></param>
        private void AddPositionNode(TreeListNode parentNode)
        {
            var id = Convert.ToInt32(parentNode["colId"]);
            //var data = CallerFactory<IPositionService>.Instance.GetByOU(id);

            //foreach (var item in data)
            //{
            //    var node = this.treePos.AppendNode(new object[] { item.ID, item.Name, 5 }, parentNode);
            //    node.StateImageIndex = 4;
            //    node.HasChildren = false;
            //}
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取当前选中账户ID
        /// </summary>
        /// <returns></returns>
        public string GetCurrentSelectAccountId()
        {
            var node = this.treePos.Selection[0];
            if (node == null)
                return null;

            int type = Convert.ToInt32(node["colType"]);
            if (type == 5)
                return node["colId"].ToString();
            else
                return null;
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshTree()
        {
            LoadOUNode();
        }
        #endregion //Method

        #region Event
        private void PositionTree_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                LoadOUNode();
            }
        }
        #endregion //Event

        #region Delegate
        /// <summary>
        /// 岗位选择事件
        /// </summary>
        [Description("岗位选择事件")]
        public event EventHandler PositionSelected;
        #endregion //Delegate

        #region Event
        private void treePos_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null)
                return;

            int type = Convert.ToInt32(e.Node["colType"]);
            if (type == 5)
            {
                PositionSelected?.Invoke(sender, e);
            }
        }
        #endregion //Event
    }
}

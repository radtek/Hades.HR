using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

using Hades.Pager.Entity;
using Hades.Dictionary;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    /// <summary>
    /// 岗位产线班组管理窗体
    /// </summary>	
    public partial class FrmPosition : BaseDock
    {
        #region Field
        private List<DepartmentInfo> departmentList;
        #endregion //Field

        #region Constructor
        public FrmPosition()
        {
            InitializeComponent();

            InitDictItem();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化字典列表内容
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
        }

        /// <summary>
        /// 载入部门数据
        /// </summary>
        private void LoadDepartments()
        {
            //var departments = CallerFactory<IDepartmentService>.Instance.Find2("deleted=0", "ORDER BY SortCode");
            //this.depTree.DataSource = departments;
            this.depTree.Init(3);
        }

        /// <summary>
        /// 载入部门包含岗位
        /// </summary>
        /// <param name="department"></param>
        private void LoadPositions(DepartmentInfo department)
        {
            var positions = CallerFactory<IPositionService>.Instance.Find2(string.Format("departmentId='{0}' AND Deleted=0", department.Id), "ORDER BY SortCode");

            this.wgvPosition.DisplayColumns = "Name,Number,DepartmentId,Quota,SortCode,Remark,Enabled";
            this.wgvPosition.ColumnNameAlias = CallerFactory<IPositionService>.Instance.GetColumnNameAlias();

            this.wgvPosition.DataSource = positions;
            this.wgvPosition.PrintTitle = "岗位报表";
        }


        /// <summary>
        /// 载入公司包含仓库
        /// </summary>
        /// <param name="department"></param>
        private void LoadWarehouse(DepartmentInfo department)
        {
            var warehouse = CallerFactory<IWarehouseService>.Instance.Find2(string.Format("CompanyId='{0}' AND Deleted=0", department.Id), "ORDER BY SortCode");

            this.wgvWarehouse.DisplayColumns = "Name,Number,CompanyId,SortCode,Remark,Enabled";
            this.wgvWarehouse.ColumnNameAlias = CallerFactory<IWarehouseService>.Instance.GetColumnNameAlias();

            this.wgvWarehouse.DataSource = warehouse;
            this.wgvWarehouse.PrintTitle = "仓库报表";
        }

        /// <summary>
        /// 查看岗位
        /// </summary>
        private void ViewPosition()
        {
            string ID = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvPosition.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvPosition.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmPositionView dlg = new FrmPositionView();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);
                dlg.ShowDialog();
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void FormOnLoad()
        {
            this.departmentList = CallerFactory<IDepartmentService>.Instance.Find("");
            LoadDepartments();

            this.depTree.Expand();

            this.wgvPosition.AppendedMenu = this.contextMenuStrip1;
            this.wgvPosition.ShowLineNumber = true;
            this.wgvPosition.BestFitColumnWith = true;
            this.wgvPosition.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvPosition_CustomColumnDisplayText);

            this.wgvWarehouse.AppendedMenu = this.contextMenuStrip4;
            this.wgvWarehouse.ShowLineNumber = true;
            this.wgvWarehouse.BestFitColumnWith = true;
            this.wgvWarehouse.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvWarehouse_CustomColumnDisplayText);
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 对话框数据保存时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dlg_OnDataSaved(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        /// <summary>
        /// 选择部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentSelect(object sender, EventArgs e)
        {
            var department = this.depTree.GetSelectedObject();
            if (department != null)
            {
                this.txtDepartmentName.Text = department.Name;
                this.txtDepartmentNumber.Text = department.Number;

                LoadPositions(department);

                LoadWarehouse(department);
            }
        }

        /// <summary>
        /// 菜单 - 查看岗位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuViewPosition_Click(object sender, EventArgs e)
        {
            ViewPosition();
        }

        /// <summary>
        /// 菜单 - 新增岗位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddPosition_Click(object sender, EventArgs e)
        {
            FrmPositionEdit dlg = new FrmPositionEdit();
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadDepartments();
            }
        }

        /// <summary>
        /// 菜单 - 编辑岗位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditPosition_Click(object sender, EventArgs e)
        {
            string ID = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvPosition.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvPosition.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmPositionEdit dlg = new FrmPositionEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadDepartments();
                }
            }
        }

        /// <summary>
        /// 菜单 - 删除岗位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeletePosition_Click(object sender, EventArgs e)
        {
            string id = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IPositionService>.Instance.MarkDelete(id);
            LoadDepartments();
        }

        /// <summary>
        /// 菜单 - 查看仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuViewWarehouse_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 菜单 - 新增仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddWarehouse_Click(object sender, EventArgs e)
        {
            FrmWarehouseEdit dlg = new FrmWarehouseEdit();
            // dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadDepartments();
            }
        }

        /// <summary>
        /// 菜单 - 编辑仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditWarehouse_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWarehouse.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvWarehouse.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvWarehouse.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmWarehouseEdit dlg = new FrmWarehouseEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadDepartments();
                }
            }
        }

        #region Grid Event
        /// <summary>
        /// 双击岗位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wgvPosition_OnGridViewMouseDoubleClick(object sender, EventArgs e)
        {
            ViewPosition();
        }

        /// <summary>
        /// 格式化岗位列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvPosition_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (e.Column.ColumnType == typeof(DateTime))
            {
                if (e.Value != null)
                {
                    if (e.Value == DBNull.Value || Convert.ToDateTime(e.Value) <= Convert.ToDateTime("1900-1-1"))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm");//yyyy-MM-dd
                    }
                }
            }
            else if (columnName == "DepartmentId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var dep = this.departmentList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (dep != null)
                        e.DisplayText = dep.Name;
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "已启用" : "未启用";
            }
        }

        /// <summary>
        /// 格式化产线列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvProductionLine_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "CompanyId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var dep = this.departmentList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (dep != null)
                        e.DisplayText = dep.Name;
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "已启用" : "未启用";
            }
        }

        /// <summary>
        /// 格式化仓库列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvWarehouse_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "CompanyId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var dep = this.departmentList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (dep != null)
                        e.DisplayText = dep.Name;
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "已启用" : "未启用";
            }
        }
        #endregion //Grid Event

        #endregion //Event

    }
}

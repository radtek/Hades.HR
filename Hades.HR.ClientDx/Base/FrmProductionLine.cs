using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

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
    /// 产线管理窗体
    /// </summary>	
    public partial class FrmProductionLine : BaseDock
    {
        #region Field
        /// <summary>
        /// 缓存部门列表
        /// </summary>
        private List<DepartmentInfo> departments;

        /// <summary>
        /// 缓存工段列表
        /// </summary>
        private List<WorkSectionInfo> workSections;

        /// <summary>
        /// 缓存班组列表
        /// </summary>
        private List<WorkTeamInfo> workTeams;

        /// <summary>
        /// 当前选择公司
        /// </summary>
        private string currentDepartmentId;
        #endregion //Field

        #region Constructor
        public FrmProductionLine()
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
            this.depTree.Init(2);
        }

        /// <summary>
        /// 载入公司包含班组
        /// </summary>
        private void LoadWorkTeams()
        {
            if (string.IsNullOrEmpty(this.currentDepartmentId))
                this.workTeams = new List<WorkTeamInfo>();
            else
                this.workTeams = CallerFactory<IWorkTeamService>.Instance.Find2(string.Format("CompanyId='{0}' AND Deleted=0", currentDepartmentId), "ORDER BY SortCode");

            this.wgvWorkTeam.DisplayColumns = "Name,Number,CompanyId,Quota,Principal,SortCode,Remark,Enabled";
            this.wgvWorkTeam.ColumnNameAlias = CallerFactory<IWorkTeamService>.Instance.GetColumnNameAlias();

            this.wgvWorkTeam.DataSource = workTeams;
            this.wgvWorkTeam.PrintTitle = "班组报表";
        }

        /// <summary>
        /// 载入公司包含工段
        /// </summary>
        private void LoadWorkSection()
        {
            if (string.IsNullOrEmpty(this.currentDepartmentId))
                this.workSections = new List<WorkSectionInfo>();
            else
                this.workSections = CallerFactory<IWorkSectionService>.Instance.Find2(string.Format("CompanyId='{0}' AND Deleted=0", currentDepartmentId), "ORDER BY SortCode");

            this.wgvWorkSection.DisplayColumns = "Name,Number,CompanyId,Caption,SortCode,Remark,Enabled";
            this.wgvWorkSection.ColumnNameAlias = CallerFactory<IWorkSectionService>.Instance.GetColumnNameAlias();

            this.wgvWorkSection.DataSource = workSections;
            this.wgvWorkSection.PrintTitle = "工段报表";
        }

        /// <summary>
        /// 查看班组
        /// </summary>
        private void ViewWorkTeam()
        {
            string ID = this.wgvWorkTeam.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvWorkTeam.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvWorkTeam.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmWorkTeamView dlg = new FrmWorkTeamView();
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
            this.departments = CallerFactory<IDepartmentService>.Instance.Find2("Enabled=1 AND Deleted=0", "");

            LoadDepartments();

            this.depTree.Expand();

            this.wgvWorkTeam.AppendedMenu = this.contextMenuStrip2;
            this.wgvWorkTeam.ShowLineNumber = true;
            this.wgvWorkTeam.BestFitColumnWith = true;
            this.wgvWorkTeam.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvWorkTeam_CustomColumnDisplayText);
            this.wgvWorkTeam.OnGridViewMouseDoubleClick += WgvWorkTeam_OnGridViewMouseDoubleClick;

            this.wgvWorkSection.AppendedMenu = this.contextMenuStrip3;
            this.wgvWorkSection.ShowLineNumber = true;
            this.wgvWorkSection.BestFitColumnWith = true;
            this.wgvWorkSection.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvWorkSection_CustomColumnDisplayText);
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 部门选择
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

                this.currentDepartmentId = department.Id;

                LoadWorkTeams();
                LoadWorkSection();
            }
        }


        void workTeam_OnDataSaved(object sender, EventArgs e)
        {
            LoadWorkTeams();
        }

        void workSection_OnDataSaved(object sender, EventArgs e)
        {
            LoadWorkSection();
        }

        #region Menu Event
        /// <summary>
        /// 查看班组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuViewTeam_Click(object sender, EventArgs e)
        {
            ViewWorkTeam();
        }

        /// <summary>
        /// 菜单 - 新增班组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddTeam_Click(object sender, EventArgs e)
        {
            FrmWorkTeamEdit dlg = new FrmWorkTeamEdit();
            dlg.OnDataSaved += new EventHandler(workTeam_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadWorkTeams();
            }
        }

        /// <summary>
        /// 菜单 - 编辑班组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditTeam_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkTeam.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvWorkTeam.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvWorkTeam.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmWorkTeamEdit dlg = new FrmWorkTeamEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeams();
                }
            }
        }

        /// <summary>
        /// 菜单 - 删除班组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeleteTeam_Click(object sender, EventArgs e)
        {
            string id = this.wgvWorkTeam.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("您确定删除选定的产线么？") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IWorkTeamService>.Instance.MarkDelete(id);
            LoadWorkTeams();
        }

        /// <summary>
        /// 菜单 - 新增工段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddSection_Click(object sender, EventArgs e)
        {
            FrmWorkSectionEdit dlg = new FrmWorkSectionEdit();
            dlg.OnDataSaved += new EventHandler(workSection_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadWorkSection();
            }
        }

        /// <summary>
        /// 菜单 - 编辑工段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditSection_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 菜单 - 删除工段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeleteSection_Click(object sender, EventArgs e)
        {

        }
        #endregion //Menu Event

        /// <summary>
        /// 双击班组表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WgvWorkTeam_OnGridViewMouseDoubleClick(object sender, EventArgs e)
        {
            ViewWorkTeam();
        }


        /// <summary>
        /// 格式化班组列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvWorkTeam_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "CompanyId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var dep = this.departments.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (dep != null)
                    {
                        e.DisplayText = dep.Name;
                    }
                    else
                    {
                        var dep2 = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = dep.Name;
                    }
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "已启用" : "未启用";
            }
        }

        /// <summary>
        /// 格式化工段列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvWorkSection_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "CompanyId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var dep = this.departments.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (dep != null)
                    {
                        e.DisplayText = dep.Name;
                    }
                    else
                    {
                        var dep2 = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = dep.Name;
                    }
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "已启用" : "未启用";
            }
        }
        #endregion //Event
    }
}

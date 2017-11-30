using System;
using System.Text;
using System.Data;
using System.Drawing;
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
    /// WorkTeamDailyWorkload
    /// </summary>	
    public partial class FrmWorkTeamDailyWorkload : BaseDock
    {
        #region Field
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;

        /// <summary>
        /// 缓存班组信息
        /// </summary>
        private List<WorkTeamInfo> workTeamList;

        /// <summary>
        /// 缓存职员信息
        /// </summary>
        private List<StaffInfo> staffList;
        #endregion //Field

        #region Constructor
        public FrmWorkTeamDailyWorkload()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvWorkload.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvWorkload_CustomColumnDisplayText);
            this.wgvWorkload.AppendedMenu = this.contextMenuStrip1;

            this.wgvLabor.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvLabor_CustomColumnDisplayText);
            //         this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            //         this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            //         this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            //         this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            //         this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            //         this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            //         this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;
            //         this.winGridViewPager1.ShowLineNumber = true;
            //         this.winGridViewPager1.BestFitColumnWith = false;//是否设置为自动调整宽度，false为不设置
            //this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            //         this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            //         this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

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
        /// 根据查询条件构造查询语句
        /// </summary> 
        private string GetConditionSql()
        {
            //如果存在高级查询对象信息，则使用高级查询条件，否则使用主表条件查询
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {
                condition = new SearchCondition();
                // condition.AddCondition("WorkTeamId", this.txtWorkTeamId.Text.Trim(), SqlOperator.Like);
                // condition.AddDateCondition("AttendanceDate", this.txtAttendanceDate1, this.txtAttendanceDate2); //日期类型
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
            //entity
            //this.winGridViewPager1.DisplayColumns = "WorkTeamId,AttendanceDate,ProductionHours,ChangeHours,RepairHours,ElectricHours,PersonCount,Remark";
            //this.winGridViewPager1.ColumnNameAlias = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            //string where = GetConditionSql();
            //PagerInfo pagerInfo = this.winGridViewPager1.PagerInfo;
            //List<WorkTeamDailyWorkloadInfo> list = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindWithPager(where, ref pagerInfo);
            //this.winGridViewPager1.PagerInfo.RecordCount = pagerInfo.RecordCount;
            //this.winGridViewPager1.DataSource = new Hades.Pager.WinControl.SortableBindingList<WorkTeamDailyWorkloadInfo>(list);
            //this.winGridViewPager1.PrintTitle = "WorkTeamDailyWorkload报表";
        }

        /// <summary>
        /// 载入班组工作量数据
        /// </summary>
        private void LoadWorkTeamWorkload()
        {
            if (this.dpAttendance.EditValue == null)
                return;
            DateTime attendanceDate = this.dpAttendance.DateTime;

            string teamId = this.wtTree.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
                return;

            this.wgvWorkload.DisplayColumns = "WorkTeamId,AttendanceDate,ProductionHours,ChangeHours,RepairHours,ElectricHours,PersonCount,Remark";
            this.wgvWorkload.ColumnNameAlias = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            var data = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Find(string.Format("AttendanceDate='{0}' AND WorkTeamId='{1}'", attendanceDate, teamId));
            this.wgvWorkload.DataSource = data;
        }

        /// <summary>
        /// 载入员工工作量
        /// </summary>
        private void LoadLaborWorkload()
        {
            if (this.dpAttendance.EditValue == null)
                return;
            DateTime attendanceDate = this.dpAttendance.DateTime;

            string teamId = this.wtTree.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
                return;

            this.wgvLabor.DisplayColumns = "WorkTeamId,ActualWorkTeamId,StaffId,ProductionHours,ChangeHours,RepairHours,ElectricHours,LeaveHours,AllowanceHours,Remark";
            this.wgvLabor.ColumnNameAlias = CallerFactory<ILaborDailyWorkloadService>.Instance.GetColumnNameAlias();

            var data = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("AttendanceDate='{0}' AND WorkTeamId='{1}'", attendanceDate, teamId));

            this.wgvLabor.DataSource = data;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void FormOnLoad()
        {
            this.workTeamList = CallerFactory<IWorkTeamService>.Instance.Find2("", "");
            this.staffList = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");
            this.wtTree.Init();

            BindData();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 考勤日期选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpAttendance_EditValueChanged(object sender, EventArgs e)
        {
            LoadWorkTeamWorkload();
            LoadLaborWorkload();
        }

        /// <summary>
        /// 班组选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wtTree_TeamSeleted(object sender, EventArgs e)
        {
            LoadWorkTeamWorkload();
            LoadLaborWorkload();
        }

        /// <summary>
        /// 设置员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            if (this.dpAttendance.EditValue == null)
            {
                MessageDxUtil.ShowWarning("请选择考勤日期");
                return;
            }

            string teamId = this.wtTree.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
            {
                MessageDxUtil.ShowWarning("请选择班组");
                return;
            }

            FrmSetDailyLabor frm = new FrmSetDailyLabor(this.dpAttendance.DateTime, teamId);
            frm.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
            frm.ShowDialog();

            LoadWorkTeamWorkload();
            LoadLaborWorkload();
        }

        /// <summary>
        /// 编辑产量工时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuProduction_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkload.gridView1.GetFocusedRowCellDisplayText("Id");
            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditProductionWorkload dlg = new FrmEditProductionWorkload();
                dlg.ID = ID;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeamWorkload();
                    LoadLaborWorkload();
                }
            }
        }

        /// <summary>
        /// 编辑换机工时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuChange_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkload.gridView1.GetFocusedRowCellDisplayText("Id");
            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditChangeWorkload dlg = new FrmEditChangeWorkload();
                dlg.ID = ID;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeamWorkload();
                    LoadLaborWorkload();
                }
            }
        }

        /// <summary>
        /// 编辑机修工时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuRepair_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkload.gridView1.GetFocusedRowCellDisplayText("Id");
            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditRepairWorkload dlg = new FrmEditRepairWorkload();
                dlg.ID = ID;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeamWorkload();
                    LoadLaborWorkload();
                }
            }
        }

        /// <summary>
        /// 编辑电修工时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuElectric_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkload.gridView1.GetFocusedRowCellDisplayText("Id");
            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditElectricWorkload dlg = new FrmEditElectricWorkload();
                dlg.ID = ID;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeamWorkload();
                    LoadLaborWorkload();
                }
            }
        }
        #endregion //Event

        #region Grid
        void wgvWorkload_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");//yyyy-MM-dd
                    }
                }
            }
            else if (columnName == "WorkTeamId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var wt = this.workTeamList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (wt != null)
                    {
                        e.DisplayText = wt.Name;
                    }
                    else
                    {
                        var wt2 = CallerFactory<IWorkTeamService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = wt2.Name;
                    }
                }
            }
            //else if (columnName == "Age")
            //{
            //    e.DisplayText = string.Format("{0}岁", e.Value);
            //}
        }

        void wgvLabor_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");//yyyy-MM-dd
                    }
                }
            }
            else if (columnName == "WorkTeamId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var wt = this.workTeamList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (wt != null)
                    {
                        e.DisplayText = wt.Name;
                    }
                    else
                    {
                        var wt2 = CallerFactory<IWorkTeamService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = wt2.Name;
                    }
                }
            }
            else if (columnName == "ActualWorkTeamId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var wt = this.workTeamList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (wt != null)
                    {
                        e.DisplayText = wt.Name;
                    }
                    else
                    {
                        var wt2 = CallerFactory<IWorkTeamService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = wt2.Name;
                    }
                }
            }
            else if (columnName == "StaffId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var st = this.staffList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (st != null)
                    {
                        e.DisplayText = st.Name;
                    }
                    else
                    {
                        var st2 = CallerFactory<IStaffService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = st2.Name;
                    }
                }
            }
        }
        #endregion //Grid

        #region System
        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName == "OrderStatus")
            //{
            //    string status = this.winGridViewPager1.gridView1.GetRowCellValue(e.RowHandle, "OrderStatus").ToString();
            //    Color color = Color.White;
            //    if (status == "已审核")
            //    {
            //        e.Appearance.BackColor = Color.Red;
            //        e.Appearance.BackColor2 = Color.LightCyan;
            //    }
            //}
        }


        /// <summary>
        /// 绑定数据后，分配各列的宽度
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            //if (this.winGridViewPager1.gridView1.Columns.Count > 0 && this.winGridViewPager1.gridView1.RowCount > 0)
            //{
            //    //统一设置100宽度
            //    foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridViewPager1.gridView1.Columns)
            //    {
            //        column.Width = 100;
            //    }

            //    //可特殊设置特别的宽度
            //    //SetGridColumWidth("Note", 200);
            //}
        }

        /// <summary>
        /// 分页控件刷新操作
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页控件删除操作
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }

            //int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            //foreach (int iRow in rowSelected)
            //{
            //    string ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "ID");
            //    CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Delete(ID);
            //}	 

            //BindData();
        }

        /// <summary>
        /// 分页控件编辑项操作
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            //string ID = this.winGridViewPager1.gridView1.GetFocusedRowCellDisplayText("ID");
            //List<string> IDList = new List<string>();
            //for (int i = 0; i < this.winGridViewPager1.gridView1.RowCount; i++)
            //{
            //    string strTemp = this.winGridViewPager1.GridView1.GetRowCellDisplayText(i, "ID");
            //    IDList.Add(strTemp);
            //}

            //if (!string.IsNullOrEmpty(ID))
            //{
            //    FrmEditWorkTeamDailyWorkload dlg = new FrmEditWorkTeamDailyWorkload();
            //    dlg.ID = ID;
            //    dlg.IDList = IDList;
            //    dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            //    dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            //    if (DialogResult.OK == dlg.ShowDialog())
            //    {
            //        BindData();
            //    }
            //}
        }

        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页控件全部导出操作前的操作
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            //string where = GetConditionSql();
            //this.winGridViewPager1.AllToExport = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindToDataTable(where);
        }

        /// <summary>
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 查询数据操作
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            advanceCondition = null;//必须重置查询条件，否则可能会使用高级查询条件了
            BindData();
        }
        #endregion //System
    }
}

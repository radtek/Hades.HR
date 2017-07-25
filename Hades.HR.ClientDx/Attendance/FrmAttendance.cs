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
    /// Attendance
    /// </summary>	
    public partial class FrmAttendance : BaseDock
    {
        #region Field
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;
        #endregion //Field

        public FrmAttendance()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvRecord.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvRecord.AppendedMenu = this.contextMenuStrip1;
            this.wgvRecord.ShowLineNumber = true;
            this.wgvRecord.BestFitColumnWith = false;//是否设置为自动调整宽度，false为不设置
            this.wgvRecord.gridView1.DataSourceChanged += new EventHandler(gridView1_DataSourceChanged);
        }

        #region Function
        /// <summary>
        /// 初始化字典列表内容
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
        }

        /// <summary>
        /// 载入月度考勤
        /// </summary>
        private void LoadAttendance()
        {
            var data = CallerFactory<IAttendanceService>.Instance.Find("");

            var years = data.GroupBy(r => r.Year).Select(g => g.Key).OrderByDescending(s => s);

            this.tvAttendance.Nodes.Clear();
            foreach (var year in years)
            {
                TreeNode yearNode = new TreeNode { Name = year.ToString(), Text = year.ToString() + "年", Tag = 1 };
                var node = this.tvAttendance.Nodes.Add(yearNode);

                var months = data.Where(r => r.Year == year).OrderByDescending(r => r.Month);
                foreach (var month in months)
                {
                    TreeNode monthNode = new TreeNode { Name = month.Id, Text = month.Month.ToString() + "月", Tag = 2 };
                    yearNode.Nodes.Add(monthNode);
                }
            }
        }

        /// <summary>
        /// 新增月度考勤
        /// </summary>
        private void AddAttendance()
        {
            FrmEditAttendance dlg = new FrmEditAttendance();
            //dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadAttendance();
            }
        }

        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void LoadRecordData()
        {
            //entity
            this.wgvRecord.DisplayColumns = "DepartmentName,Name,AttendanceDays,AnnualLeave,SickLeave,CasualLeave,InjuryLeave,MarriageLeave,LeaveDays,NormalOvertime,NormalOvertimeSalary,WeekendOvertime,WeekendOvertimeSalary,HolidayOvertime,HolidayOvertimeSalary,OvertimeSalarySum,NoonShift,NightShift,OtherShift,LunchAllowance,LeaderAllowance,Deduction,Nutrition,Remark";
            this.wgvRecord.ColumnNameAlias = CallerFactory<IStaffAttendanceViewService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            string where = GetConditionSql();
            PagerInfo pagerInfo = this.wgvRecord.PagerInfo;
            List<StaffAttendanceViewInfo> list = CallerFactory<IStaffAttendanceViewService>.Instance.FindWithPager(where, ref pagerInfo);
            this.wgvRecord.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvRecord.DataSource = new Hades.Pager.WinControl.SortableBindingList<StaffAttendanceViewInfo>(list);
            this.wgvRecord.PrintTitle = "考勤记录报表";
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

                var node = this.tvAttendance.SelectedNode;
                if (node != null && Convert.ToInt32(node.Tag) == 2)
                {
                    condition.AddCondition("AttendanceId", node.Name, SqlOperator.Equal);
                }

                var depId = this.luDepartment.GetSelectedId();
                if (!string.IsNullOrEmpty(depId))
                {
                    var departments = CallerFactory<IDepartmentService>.Instance.FindWithChildren(depId);

                    var idList = departments.Select(r => r.Id).ToList();
                    string ids = string.Join(",", idList);
                    ids = ids.TransSQLInStrFormat();

                    condition.AddCondition("DepartmentId", ids, SqlOperator.In);
                }
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 窗体载入
        /// </summary>
        public override void FormOnLoad()
        {
            LoadAttendance();
            LoadRecordData();

            this.luDepartment.Init();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 月度考勤选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvAttendance_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = this.tvAttendance.SelectedNode;
            if (node == null)
                return;
            if (Convert.ToInt32(node.Tag) == 1)
            {
                this.wgvRecord.DataSource = null;
                this.txtMonth.Text = "";
                this.txtDays.Text = "";
                return;
            }

            var att = CallerFactory<IAttendanceService>.Instance.FindByID(node.Name);
            this.txtMonth.Text = string.Format("{0}年{1}月", att.Year, att.Month);
            this.txtDays.Text = att.Days.ToString();
            LoadRecordData();
        }

        /// <summary>
        /// 新增月度考勤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAttendance_Click(object sender, EventArgs e)
        {
            AddAttendance();
        }

        /// <summary>
        /// 编辑月度考勤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditAttendance_Click(object sender, EventArgs e)
        {
            var node = this.tvAttendance.SelectedNode;
            if (node == null)
                return;
            if (Convert.ToInt32(node.Tag) == 1)
            {
                MessageDxUtil.ShowWarning("请选择考勤月度");
                return;
            }

            string attId = node.Name;

            FrmEditAttendance dlg = new FrmEditAttendance();
            dlg.ID = attId;
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadAttendance();
            }
        }

        /// <summary>
        /// 编辑考勤记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            var node = this.tvAttendance.SelectedNode;
            if (node == null)
                return;
            if (Convert.ToInt32(node.Tag) == 1)
            {
                MessageDxUtil.ShowWarning("请选择考勤月度");
                return;
            }
            string attId = node.Name;

            var dep = this.luDepartment.GetSelected();
            if (dep == null || dep.Type != (int)DepartmentType.Department)
            {
                MessageDxUtil.ShowWarning("请选择部门");
                return;
            }

            FrmAttendanceRecordEdit dlg = new FrmAttendanceRecordEdit(attId, dep.Id);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadRecordData();
            }
        }

        /// <summary>
        /// 部门选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luDepartment_DepartmentSelect(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// 分页控件刷新操作
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// 绑定数据后，分配各列的宽度
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.wgvRecord.gridView1.Columns.Count > 0 && this.wgvRecord.gridView1.RowCount > 0)
            {
                //统一设置100宽度
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.wgvRecord.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //可特殊设置特别的宽度
                //SetGridColumWidth("Note", 200);
            }
        }
        #endregion //Event
    }
}

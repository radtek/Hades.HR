using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
    /// LaborAttendanceRecord
    /// </summary>	
    public partial class FrmLaborAttendance : BaseDock
    {
        #region Field
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;
        #endregion //Field

        #region Constructor
        public FrmLaborAttendance()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvRecord.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.wgvRecord.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvRecord.ShowLineNumber = true;
            this.wgvRecord.BestFitColumnWith = true;//是否设置为自动调整宽度，false为不设置
            this.wgvRecord.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.wgvRecord.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);
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
        /// 初始化工作组列表
        /// </summary>
        private void InitWorkTeam()
        {
            var companys = CallerFactory<IDepartmentService>.Instance.Find("Type=2");
            var lines = CallerFactory<IProductionLineService>.Instance.Find("");
            var teams = CallerFactory<IWorkTeamService>.Instance.Find("");

            foreach (var com in companys)
            {
                TreeNode comNode = new TreeNode { Name = com.Id, Text = com.Name, Tag = 1 };
                var node = this.tvLine.Nodes.Add(comNode);

                var lines2 = lines.Where(r => r.CompanyId == com.Id);
                foreach (var line in lines2)
                {
                    TreeNode lineNode = new TreeNode { Name = line.Id, Text = line.Name, Tag = 2 };
                    var node2 = comNode.Nodes.Add(lineNode);

                    var teams2 = teams.Where(r => r.ProductionLineId == line.Id);
                    foreach (var team in teams2)
                    {
                        TreeNode teamNode = new TreeNode { Name = team.Id, Text = team.Name, Tag = 3 };
                        lineNode.Nodes.Add(teamNode);
                    }
                }
            }
        }

        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void LoadRecordData()
        {
            //entity
            this.wgvRecord.DisplayColumns = "WorkTeamName,Number,Name,AttendanceDate,Workload,AbsentType,IsWeekend,IsHoliday,Remark";
            this.wgvRecord.ColumnNameAlias = CallerFactory<ILaborAttendanceRecordViewService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            string where = GetConditionSql();
            PagerInfo pagerInfo = this.wgvRecord.PagerInfo;
            List<LaborAttendanceRecordViewInfo> list = CallerFactory<ILaborAttendanceRecordViewService>.Instance.FindWithPager(where, ref pagerInfo);
            this.wgvRecord.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvRecord.DataSource = new Hades.Pager.WinControl.SortableBindingList<LaborAttendanceRecordViewInfo>(list);
            this.wgvRecord.PrintTitle = "考勤记录报表";

            this.wgvRecord.GridView1.OptionsView.ShowFooter = true;
            var col = this.wgvRecord.GridView1.Columns["Workload"];
            col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Workload", "合计={0:0.##}")});
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
                if (this.dpAttendance.EditValue == null)
                    return "1 = 2";
                condition.AddCondition("AttendanceDate", this.dpAttendance.DateTime.Date, SqlOperator.Equal);

                var node = this.tvLine.SelectedNode;
                if (node != null && Convert.ToInt32(node.Tag) == 3)
                {
                    condition.AddCondition("WorkTeamId", node.Name, SqlOperator.Equal);
                }
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// 载入考勤汇总
        /// </summary>
        /// <param name="month"></param>
        /// <param name="workTeamId"></param>
        /// <returns></returns>
        private DataTable LoadSummaryAttendance(DateTime month, string workTeamId)
        {
            DateTime d1 = new DateTime(month.Year, month.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);

            string sql = string.Format("WorkTeamId = '{0}' AND AttendanceDate between '{1}' AND '{2}'", workTeamId, d1, d2);
            var records = CallerFactory<ILaborAttendanceRecordViewService>.Instance.Find(sql);

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn { ColumnName = "number", Caption = "工号" });
            dt.Columns.Add(new DataColumn { ColumnName = "name", Caption = "姓名" });

            int days = DateTime.DaysInMonth(month.Year, month.Month);
            for (int i = 1; i <= days; i++)
            {
                dt.Columns.Add(new DataColumn { ColumnName = i.ToString() });
            }

            dt.Columns.Add(new DataColumn { ColumnName = "sum", Caption = "合计" });
            dt.Columns.Add(new DataColumn { ColumnName = "weekendsum", Caption = "周末合计" });
            dt.Columns.Add(new DataColumn { ColumnName = "normalsum", Caption = "平时合计" });
            dt.Columns.Add(new DataColumn { ColumnName = "holidaysum", Caption = "节假日合计" });
            dt.Columns.Add(new DataColumn { ColumnName = "attendanceDays", Caption = "出勤天数" });
            dt.Columns.Add(new DataColumn { ColumnName = "annualDays", Caption = "年假天数" });
            dt.Columns.Add(new DataColumn { ColumnName = "sickDays", Caption = "病假天数" });
            dt.Columns.Add(new DataColumn { ColumnName = "casualDays", Caption = "事假天数" });
            dt.Columns.Add(new DataColumn { ColumnName = "absentDays", Caption = "旷工天数" });
            dt.Columns.Add(new DataColumn { ColumnName = "injuryDays", Caption = "工伤天数" });
            dt.Columns.Add(new DataColumn { ColumnName = "realDays", Caption = "实际天数" });

            var staffs = records.Select(r => r.StaffId).Distinct();
            foreach (var staffId in staffs)
            {
                DataRow row = dt.NewRow();

                var staff = records.First(r => r.StaffId == staffId);
                row["number"] = staff.Number;
                row["name"] = staff.Name;

                for (int i = 1; i <= days; i++)
                {
                    var find = records.SingleOrDefault(r => r.StaffId == staffId && r.AttendanceDate == new DateTime(month.Year, month.Month, i));
                    if (find == null)
                    {
                        row[i.ToString()] = 0;
                    }
                    else
                    {
                        row[i.ToString()] = find.Workload;
                    }
                }

                row["sum"] = records.Where(r => r.StaffId == staffId).Sum(r => r.Workload);
                row["weekendsum"] = records.Where(r => r.StaffId == staffId && r.IsWeekend == true).Sum(r => r.Workload);
                row["normalsum"] = records.Where(r => r.StaffId == staffId && r.IsWeekend == false && r.IsHoliday == false).Sum(r => r.Workload);
                row["holidaysum"] = records.Where(r => r.StaffId == staffId && r.IsHoliday == true).Sum(r => r.Workload);

                row["attendanceDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.None && r.IsWeekend == false && r.IsHoliday == false).Count(); ;
                row["annualDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.AnnualLeave).Count();
                row["sickDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.SickLeave).Count();
                row["casualDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.CasualLeave).Count();
                row["absentDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.AbsentLeave).Count();
                row["injuryDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.InjuryLeave).Count();
                row["realDays"] = Convert.ToInt32(row["attendanceDays"]) - Convert.ToInt32(row["annualDays"]);

                dt.Rows.Add(row);
            }

            return dt;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void FormOnLoad()
        {
            InitWorkTeam();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 班组选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvLine_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.txtWorkTeamName.Text = e.Node.Text;
            this.txtWorkTeamName2.Text = e.Node.Text;
            LoadRecordData();
        }

        /// <summary>
        /// 汇总月度选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (this.dpMonth.EditValue == null)
                return;

            var node = this.tvLine.SelectedNode;
            if (node != null && Convert.ToInt32(node.Tag) == 3)
            {
                var dt = LoadSummaryAttendance(this.dpMonth.DateTime.Date, node.Name);

                this.dgcSummary.DataSource = dt;
                this.dgvSummary.PopulateColumns();
            }            
        }

        /// <summary>
        /// 考勤日期选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpAttendance_EditValueChanged(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// 编辑考勤记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            var node = this.tvLine.SelectedNode;
            if (node == null || Convert.ToInt32(node.Tag) != 3)
            {
                MessageDxUtil.ShowWarning("请选择班组");
                return;
            }
            if (this.dpAttendance.EditValue == null)
            {
                MessageDxUtil.ShowWarning("请选择考勤日期");
                return;
            }

            var teamId = node.Name;
            var date = this.dpAttendance.DateTime.Date;

            FrmEditLaborAttendanceRecord dlg = new FrmEditLaborAttendanceRecord(date, teamId);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadRecordData();
            }
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

        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            else if (columnName == "AbsentType")
            {
                e.DisplayText = ((AbsentType)e.Value).DisplayName();
            }
        }


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
        #endregion //Event

        
    }
}

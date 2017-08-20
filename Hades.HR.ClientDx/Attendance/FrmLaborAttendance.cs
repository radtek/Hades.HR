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
                condition.AddCondition("AttendanceDate", this.dpAttendance.DateTime.Date, SqlOperator.Equal);

                var node = this.tvLine.SelectedNode;
                if (node == null && Convert.ToInt32(node.Tag) == 3)
                {
                    condition.AddCondition("WorkTeamId", node.Name, SqlOperator.Equal);
                }
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
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

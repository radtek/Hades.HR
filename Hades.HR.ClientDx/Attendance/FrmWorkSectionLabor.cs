using System;
using System.Text;
using System.Data;
using System.Drawing;
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
    /// WorkSectionLabor
    /// </summary>	
    public partial class FrmWorkSectionLabor : BaseDock
    {
        #region Constructor
        public FrmWorkSectionLabor()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvLabor.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvLabor.AppendedMenu = this.contextMenuStrip1;
            this.wgvLabor.ShowLineNumber = true;
            this.wgvLabor.BestFitColumnWith = true;//是否设置为自动调整宽度，false为不设置

            this.wgvLabor.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.wgvLabor.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

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
            SearchCondition condition = new SearchCondition(); ;

            var teamId = this.treeLine.GetSelectedTeamId();
            condition.AddCondition("WorkTeamId", teamId, SqlOperator.Equal);

            var date = this.dpDate.DateTime;
            condition.AddCondition("Year", date.Year, SqlOperator.Equal);
            condition.AddCondition("Month", date.Month, SqlOperator.Equal);

            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
            //entity
            this.wgvLabor.DisplayColumns = "WorkTeamName,WorkSectionName,Number,Name,StaffLevelName,InPosition,Remark";
            this.wgvLabor.ColumnNameAlias = CallerFactory<IWorkSectionLaborViewService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            string where = GetConditionSql();

            var list = CallerFactory<IWorkSectionLaborViewService>.Instance.Find2(where, "ORDER BY SortCode");

            this.wgvLabor.DataSource = list;
            this.wgvLabor.PrintTitle = "WorkSectionLabor报表";
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void FormOnLoad()
        {
            this.dpDate.DateTime = DateTime.Now;
            this.treeLine.Init();
        }
        #endregion //Method


        #region Event
        /// <summary>
        /// 班组选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeLine_TeamSeleted(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 月份选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpDate_EditValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 编辑工段职员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var teamId = this.treeLine.GetSelectedTeamId();

            if (string.IsNullOrEmpty(teamId))
            {
                return;
            }
            else
            {
                var date = this.dpDate.DateTime;
                FrmEditWorkSectionLabor frm = new FrmEditWorkSectionLabor(date.Year, date.Month, teamId);
                frm.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
                frm.ShowDialog();

                BindData();
            }
        }

        /// <summary>
        /// 分页控件刷新操作
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
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
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm");//yyyy-MM-dd
                    }
                }
            }
            else if (columnName == "InPosition")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "在岗" : "不在岗";
            }
        }
        #endregion //Event
    }
}

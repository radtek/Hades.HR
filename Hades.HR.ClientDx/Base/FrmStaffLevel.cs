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
    /// StaffLevel
    /// </summary>	
    public partial class FrmStaffLevel : BaseDock
    {
        #region Field
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;
        #endregion //Field

        #region Constructor
        public FrmStaffLevel()
        {
            InitializeComponent();

            InitDictItem();

            //this.wgvLevel.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.wgvLevel.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            this.wgvLevel.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            this.wgvLevel.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            this.wgvLevel.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.wgvLevel.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvLevel.AppendedMenu = this.contextMenuStrip1;
            this.wgvLevel.ShowLineNumber = true;
            this.wgvLevel.BestFitColumnWith = true;
            this.wgvLevel.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.wgvLevel.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);
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
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
            //entity
            this.wgvLevel.DisplayColumns = "Name,Salary,SortCode,Remark";
            this.wgvLevel.ColumnNameAlias = CallerFactory<IStaffLevelService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            List<StaffLevelInfo> list = CallerFactory<IStaffLevelService>.Instance.Find2("", "ORDER BY SortCode");
            this.wgvLevel.DataSource = list;
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
            BindData();
        }

        #endregion //Method

        #region Event
        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
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
            //else if (columnName == "Age")
            //{
            //    e.DisplayText = string.Format("{0}岁", e.Value);
            //}
            //else if (columnName == "ReceivedMoney")
            //{
            //    if (e.Value != null)
            //    {
            //        e.DisplayText = e.Value.ToString().ToDecimal().ToString("C");
            //    }
            //}
        }

        /// <summary>
        /// 新增数据操作
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmEditStaffLevel dlg = new FrmEditStaffLevel();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }

        /// <summary>
        /// 分页控件新增操作
        /// </summary>
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }


        /// <summary>
        /// 分页控件编辑项操作
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            string ID = this.wgvLevel.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvLevel.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvLevel.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditStaffLevel dlg = new FrmEditStaffLevel();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    BindData();
                }
            }
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

            int[] rowSelected = this.wgvLevel.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                string ID = this.wgvLevel.GridView1.GetRowCellDisplayText(iRow, "Id");
                CallerFactory<IStaffLevelService>.Instance.Delete(ID);
            }

            BindData();
        }

        /// <summary>
        /// 分页控件全部导出操作前的操作
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.wgvLevel.AllToExport = CallerFactory<IStaffLevelService>.Instance.FindToDataTable(where);
        }
        #endregion //Event
    }
}

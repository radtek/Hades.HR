using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmStaffOverview : BaseDock
    {
        #region Field
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;
        #endregion //Field

        #region Constructor
        public FrmStaffOverview()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvStaff.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            //this.wgvStaff.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            this.wgvStaff.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvStaff.AppendedMenu = this.contextMenuStrip1;
            this.wgvStaff.ShowLineNumber = true;
            this.wgvStaff.BestFitColumnWith = false;//是否设置为自动调整宽度，false为不设置
            this.wgvStaff.gridView1.DataSourceChanged += new EventHandler(gridView1_DataSourceChanged);
            this.wgvStaff.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.wgvStaff.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

            //关联回车键进行查询
            foreach (Control control in this.layoutControl1.Controls)
            {
                control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
            }
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
            this.wgvStaff.DisplayColumns = "Number,Name,Gender,CompanyId,DepartmentId,PositionId,Birthday,NativePlace,Nationality,IdentityCard,Phone,OfficePhone,Email,HomeAddress,Political,PartyDate,Education,Degree,WorkingDate,Marriage,ChildStatus,Titles,Duty,JobType,Enabled";
            this.wgvStaff.ColumnNameAlias = CallerFactory<IStaffService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            string where = GetConditionSql();
            var page = this.wgvStaff.PagerInfo;
            List<StaffInfo> list = CallerFactory<IStaffService>.Instance.FindWithPager(where, ref page);
            this.wgvStaff.DataSource = list;//new Hades.Pager.WinControl.SortableBindingList<StaffInfo>(list);
            this.wgvStaff.PrintTitle = "职员报表";
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
                condition.AddCondition("Number", this.txtNumber.Text.Trim(), SqlOperator.Like);
                condition.AddCondition("Name", this.txtName.Text.Trim(), SqlOperator.Like);
                condition.AddCondition("IdentityCard", this.txtIdentityCard.Text.Trim(), SqlOperator.Like);

                var dep = this.depTree.GetSelectedObject();
                if (dep != null)
                {
                    var departments = CallerFactory<IDepartmentService>.Instance.FindWithChildren(dep.Id);

                    var idList = departments.Select(r => r.Id).ToList();
                    string ids = string.Join(",", idList);
                    ids = ids.TransSQLInStrFormat();

                    condition.AddCondition("DepartmentId", ids, SqlOperator.In);
                }
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// 查看职员
        /// </summary>
        private void ViewStaff()
        {
            string ID = this.wgvStaff.gridView1.GetFocusedRowCellDisplayText("Id");

            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvStaff.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvStaff.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmStaffView dlg = new FrmStaffView();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
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
            this.depTree.DataSource = CallerFactory<IDepartmentService>.Instance.Find2("deleted=0", "ORDER BY SortCode");
            this.depTree.Expand();

            BindData();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 选择部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentSelect(object sender, EventArgs e)
        {
            BindData();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            advanceCondition = null;//必须重置查询条件，否则可能会使用高级查询条件了
            BindData();
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
            else if (columnName == "CompanyId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var company = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = company.Name;
                }
            }
            else if (columnName == "DepartmentId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var dep = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = dep.Name;
                }
            }
            else if (columnName == "PositionId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var pos = CallerFactory<IPositionService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = pos.Name;
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "已启用" : "未启用";
            }
        }

        /// <summary>
        /// 绑定数据后，分配各列的宽度
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.wgvStaff.gridView1.Columns.Count > 0 && this.wgvStaff.gridView1.RowCount > 0)
            {
                //统一设置100宽度
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.wgvStaff.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //可特殊设置特别的宽度
                //SetGridColumWidth("Note", 200);
            }
        }

        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        /// <summary>
        /// 分页控件刷新操作
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 提供给控件回车执行查询的操作
        /// </summary>
        private void SearchControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// 双击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wgvStaff_OnGridViewMouseDoubleClick(object sender, EventArgs e)
        {
            ViewStaff();
        }

        /// <summary>
        /// 菜单 - 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuView_Click(object sender, EventArgs e)
        {
            ViewStaff();
        }
        #endregion //Event
    }
}

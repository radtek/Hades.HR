using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    /// 月考勤窗体
    /// </summary>
    public partial class FrmMonthAttendance : BaseDock
    {
        #region Constructor
        public FrmMonthAttendance()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvAttendance.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);      
            this.wgvAttendance.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            this.wgvAttendance.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);           
            this.wgvAttendance.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);          
            this.wgvAttendance.ShowLineNumber = true;
            this.wgvAttendance.BestFitColumnWith = true;//是否设置为自动调整宽度，false为不设置
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
            SearchCondition condition = new SearchCondition();
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
            //entity
            this.wgvAttendance.DisplayColumns = "Year,Month,Days,Remark";
            this.wgvAttendance.ColumnNameAlias = CallerFactory<IAttendanceService>.Instance.GetColumnNameAlias();//字段列显示名称转义
                        
            PagerInfo pagerInfo = this.wgvAttendance.PagerInfo;
            List<AttendanceInfo> list = CallerFactory<IAttendanceService>.Instance.FindWithPager("", ref pagerInfo);
            this.wgvAttendance.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvAttendance.DataSource = new Hades.Pager.WinControl.SortableBindingList<AttendanceInfo>(list);
            this.wgvAttendance.PrintTitle = "LaborMonthAttendance报表";
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

        /// <summary>
        /// 分页控件编辑项操作
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            string ID = this.wgvAttendance.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvAttendance.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvAttendance.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditAttendance dlg = new FrmEditAttendance();
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
        /// 新增数据操作
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmEditAttendance dlg = new FrmEditAttendance();
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
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        #endregion //Event
    }
}

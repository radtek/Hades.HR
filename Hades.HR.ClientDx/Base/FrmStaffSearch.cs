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
using Hades.Dictionary.Facade;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    /// <summary>
    /// 职员搜索
    /// </summary>
    public partial class FrmStaffSearch : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 职员类型
        /// </summary>
        private StaffType staffType;

        /// <summary>
        /// 选择员工
        /// </summary>
        private StaffInfo selectedStaff; 
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 职员搜索
        /// </summary>
        /// <param name="staffType">职员类型</param>
        public FrmStaffSearch(StaffType staffType)
        {
            InitializeComponent();

            this.staffType = staffType;
            this.wgvStaff.ShowLineNumber = true;
            this.wgvStaff.BestFitColumnWith = false;
            this.wgvStaff.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvStaff_CustomColumnDisplayText);

            //关联回车键进行查询
            //foreach (Control control in this.layoutControl1.Controls)
            //{
            //    control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
            //}

            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 根据查询条件构造查询语句
        /// </summary> 
        private string GetConditionSql()
        {
            //如果存在高级查询对象信息，则使用高级查询条件，否则使用主表条件查询
            SearchCondition condition = new SearchCondition();
            
            if (Convert.ToInt32(this.cmbType.EditValue) == 1)
                condition.AddCondition("Number", this.txtFind.Text.Trim(), SqlOperator.Like);
            else
                condition.AddCondition("Name", this.txtFind.Text.Trim(), SqlOperator.Like);

            condition.AddCondition("StaffType", (int)this.staffType, SqlOperator.Equal);
            condition.AddCondition("Enabled", 1, SqlOperator.Equal);
            condition.AddCondition("Deleted", 0, SqlOperator.Equal);
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
            //entity
            this.wgvStaff.DisplayColumns = "Number,Name,StaffType,CompanyId,DepartmentId,PositionId,ProductionLineId,WorkTeamId,Gender,Birthday,IdentityCard,Phone,Titles,Duty,JobType,Enabled";
            this.wgvStaff.ColumnNameAlias = CallerFactory<IStaffService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            string where = GetConditionSql();

            var list = CallerFactory<IStaffService>.Instance.Find(where);
            this.wgvStaff.DataSource = list;
            this.wgvStaff.PrintTitle = "职员报表";
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void FormOnLoad()
        {
            //BindData();
        }

        /// <summary>
        /// 编辑状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {
            string ID = this.wgvStaff.gridView1.GetFocusedRowCellDisplayText("Id");

            var staffs = this.wgvStaff.DataSource as List<StaffInfo>;
            var index = this.wgvStaff.gridView1.GetFocusedDataSourceRowIndex();

            this.selectedStaff = staffs[index];

            this.DialogResult = DialogResult.OK;

            return true;
        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            string ID = this.wgvStaff.gridView1.GetFocusedRowCellDisplayText("Id");

            var staffs = this.wgvStaff.DataSource as List<StaffInfo>;
            var index = this.wgvStaff.gridView1.GetFocusedDataSourceRowIndex();

            this.selectedStaff = staffs[index];

            this.DialogResult = DialogResult.OK;

            return true;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFind.Text.Trim()))
            {
                MessageDxUtil.ShowTips("请输入搜索条件");
                return;
            }

            int type = (int)this.cmbType.EditValue;
            
            if (type == 1)
            {
                if (this.txtFind.Text.Trim().Length < 2)
                {
                    MessageDxUtil.ShowTips("请至少输入2位工号");
                    return;
                }
            }

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
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvStaff_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            else if (columnName == "StaffType")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "管理员工" : "计件员工";
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
            else if (columnName == "ProductionLineId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var pos = CallerFactory<IProductionLineService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = pos.Name;
                }
            }
            else if (columnName == "WorkTeamId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var pos = CallerFactory<IWorkTeamService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = pos.Name;
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "已启用" : "未启用";
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 选择职员
        /// </summary>
        public StaffInfo SelectedStaff
        {
            get
            {
                return selectedStaff;
            }
        }
        #endregion //Property
    }
}

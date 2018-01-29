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
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;
using Hades.Framework.ControlUtil;

namespace Hades.HR.UI
{
    /// <summary>
    /// 职员管理窗体
    /// </summary>	
    public partial class FrmStaff : BaseDock
    {
        #region Field
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;

        /// <summary>
        /// 缓存部门信息
        /// </summary>
        private List<DepartmentInfo> departmentList;
        #endregion //Field

        #region Constructor
        public FrmStaff()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvStaff.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            //this.wgvStaff.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            //this.wgvStaff.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            this.wgvStaff.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.wgvStaff.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvStaff.AppendedMenu = this.contextMenuStrip1;
            this.wgvStaff.ShowLineNumber = true;
            this.wgvStaff.BestFitColumnWith = false;//是否设置为自动调整宽度，false为不设置
            this.wgvStaff.gridView1.DataSourceChanged += new EventHandler(gridView1_DataSourceChanged);
            this.wgvStaff.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvStaff_CustomColumnDisplayText);
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
            this.wgvStaff.DisplayColumns = "Number,Name,StaffType,CompanyId,DepartmentId,PositionId,Gender,Birthday,NativePlace,Nationality,IdentityCard,Phone,OfficePhone,Email,HomeAddress,Political,PartyDate,Education,Degree,WorkingDate,Marriage,ChildStatus,Titles,Duty,JobType,Enabled";
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
            this.departmentList = CallerFactory<IDepartmentService>.Instance.Find("");
            BindData();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 菜单 - 查看职员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuViewStaff_Click(object sender, EventArgs e)
        {
            ViewStaff();
        }

        /// <summary>
        /// 菜单 - 新增职员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddStaff_Click(object sender, EventArgs e)
        {
            FrmStaffEdit dlg = new FrmStaffEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }

        /// <summary>
        /// 菜单 - 编辑职员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditStaff_Click(object sender, EventArgs e)
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
                FrmStaffEdit dlg = new FrmStaffEdit();
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
        /// 编辑基本工资信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditBaseSalary_Click(object sender, EventArgs e)
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
                FrmEditSalaryBase dlg = new FrmEditSalaryBase();
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

        private void dlg_OnDataSaved(object sender, EventArgs e)
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

        #region Grid Event
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
            else if (columnName == "CompanyId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var company = this.departmentList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (company != null)
                    {
                        e.DisplayText = company.Name;
                    }
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
            else if (columnName == "StaffType")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "管理员工" : "计件员工";
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
        /// 分页控件新增操作
        /// </summary>
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            menuAddStaff_Click(null, null);
        }

        /// <summary>
        /// 分页控件删除操作
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            string id = this.wgvStaff.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IStaffService>.Instance.MarkDelete(id);

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
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 双击控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wgvStaff_OnGridViewMouseDoubleClick(object sender, EventArgs e)
        {
            ViewStaff();
        }
        #endregion //Grid Event
        #endregion //Event

        #region System
        /// <summary>
        /// 分页控件全部导出操作前的操作
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.wgvStaff.AllToExport = CallerFactory<IStaffService>.Instance.FindToDataTable(where);
        }


        private string moduleName = "Staff";
        /// <summary>
        /// 导入Excel的操作
        /// </summary>          
        private void btnImport_Click(object sender, EventArgs e)
        {
            string templateFile = string.Format("{0}-模板.xls", moduleName);
            FrmImportExcelData dlg = new FrmImportExcelData();
            dlg.SetTemplate(templateFile, System.IO.Path.Combine(Application.StartupPath, templateFile));
            dlg.OnDataSave += new FrmImportExcelData.SaveDataHandler(ExcelData_OnDataSave);
            dlg.OnRefreshData += new EventHandler(ExcelData_OnRefreshData);
            dlg.ShowDialog();
        }

        void ExcelData_OnRefreshData(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 如果字段存在，则获取对应的值，否则返回默认空
        /// </summary>
        /// <param name="row">DataRow对象</param>
        /// <param name="columnName">字段列名</param>
        /// <returns></returns>
        private string GetRowData(DataRow row, string columnName)
        {
            string result = "";
            if (row.Table.Columns.Contains(columnName))
            {
                result = row[columnName].ToString();
            }
            return result;
        }

        bool ExcelData_OnDataSave(DataRow dr)
        {
            bool success = false;
            bool converted = false;
            DateTime dtDefault = Convert.ToDateTime("1900-01-01");
            DateTime dt;
            StaffInfo info = new StaffInfo();
            info.Id = GetRowData(dr, "Id");
            info.Number = GetRowData(dr, "Number");
            info.Name = GetRowData(dr, "Name");
            info.Gender = GetRowData(dr, "Gender");

            string Birthday = GetRowData(dr, "Birthday");
            if (!string.IsNullOrEmpty(Birthday))
            {
                converted = DateTime.TryParse(Birthday, out dt);
                if (converted && dt > dtDefault)
                {
                    info.Birthday = dt;
                }
            }
            else
            {
                info.Birthday = DateTime.Now;
            }

            info.NativePlace = GetRowData(dr, "NativePlace");
            info.Nationality = GetRowData(dr, "Nationality");
            info.IdentityCard = GetRowData(dr, "IdentityCard");
            info.Phone = GetRowData(dr, "Phone");
            info.OfficePhone = GetRowData(dr, "OfficePhone");
            info.Email = GetRowData(dr, "Email");
            info.HomeAddress = GetRowData(dr, "HomeAddress");
            info.Political = GetRowData(dr, "Political");

            string PartyDate = GetRowData(dr, "PartyDate");
            if (!string.IsNullOrEmpty(PartyDate))
            {
                converted = DateTime.TryParse(PartyDate, out dt);
                if (converted && dt > dtDefault)
                {
                    info.PartyDate = dt;
                }
            }
            else
            {
                info.PartyDate = DateTime.Now;
            }

            info.Education = GetRowData(dr, "Education");
            info.Degree = GetRowData(dr, "Degree");
            //info.WorkingDate = GetRowData(dr, "WorkingDate");
            info.Marriage = GetRowData(dr, "Marriage");
            info.ChildStatus = GetRowData(dr, "ChildStatus");
            info.Titles = GetRowData(dr, "Titles");
            info.Duty = GetRowData(dr, "Duty");
            info.JobType = GetRowData(dr, "JobType");
            info.Introduce = GetRowData(dr, "Introduce");
            info.Remark = GetRowData(dr, "Remark");
            info.AttachId = GetRowData(dr, "AttachId");
            info.CompanyId = GetRowData(dr, "CompanyId");
            info.DepartmentId = GetRowData(dr, "DepartmentId");
            info.PositionId = GetRowData(dr, "PositionId");
            info.Creator = GetRowData(dr, "Creator");
            info.CreatorId = GetRowData(dr, "CreatorId");

            string CreateTime = GetRowData(dr, "CreateTime");
            if (!string.IsNullOrEmpty(CreateTime))
            {
                converted = DateTime.TryParse(CreateTime, out dt);
                if (converted && dt > dtDefault)
                {
                    info.CreateTime = dt;
                }
            }
            else
            {
                info.CreateTime = DateTime.Now;
            }

            info.EditorId = GetRowData(dr, "EditorId");
            info.Deleted = GetRowData(dr, "Deleted").ToInt32();
            info.Enabled = GetRowData(dr, "Enabled").ToInt32();

            success = CallerFactory<IStaffService>.Instance.Insert(info);
            return success;
        }

        /// <summary>
        /// 导出Excel的操作
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            if (!string.IsNullOrEmpty(file))
            {
                string where = GetConditionSql();
                List<StaffInfo> list = CallerFactory<IStaffService>.Instance.Find(where);
                DataTable dtNew = DataTableHelper.CreateTable("序号|int,Id,Number,Name,Gender,Birthday,NativePlace,Nationality,IdentityCard,Phone,OfficePhone,Email,HomeAddress,Political,PartyDate,Education,Degree,WorkingDate,Marriage,ChildStatus,Titles,Duty,JobType,Introduce,Remark,AttachId,CompanyId,DepartmentId,PositionId,Creator,CreatorId,CreateTime,EditorId,Deleted,Enabled");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["序号"] = j++;
                    dr["Id"] = list[i].Id;
                    dr["Number"] = list[i].Number;
                    dr["Name"] = list[i].Name;
                    dr["Gender"] = list[i].Gender;
                    dr["Birthday"] = list[i].Birthday;
                    dr["NativePlace"] = list[i].NativePlace;
                    dr["Nationality"] = list[i].Nationality;
                    dr["IdentityCard"] = list[i].IdentityCard;
                    dr["Phone"] = list[i].Phone;
                    dr["OfficePhone"] = list[i].OfficePhone;
                    dr["Email"] = list[i].Email;
                    dr["HomeAddress"] = list[i].HomeAddress;
                    dr["Political"] = list[i].Political;
                    dr["PartyDate"] = list[i].PartyDate;
                    dr["Education"] = list[i].Education;
                    dr["Degree"] = list[i].Degree;
                    dr["WorkingDate"] = list[i].WorkingDate;
                    dr["Marriage"] = list[i].Marriage;
                    dr["ChildStatus"] = list[i].ChildStatus;
                    dr["Titles"] = list[i].Titles;
                    dr["Duty"] = list[i].Duty;
                    dr["JobType"] = list[i].JobType;
                    dr["Introduce"] = list[i].Introduce;
                    dr["Remark"] = list[i].Remark;
                    dr["AttachId"] = list[i].AttachId;
                    dr["CompanyId"] = list[i].CompanyId;
                    dr["DepartmentId"] = list[i].DepartmentId;
                    dr["PositionId"] = list[i].PositionId;
                    dr["Creator"] = list[i].Creator;
                    dr["CreatorId"] = list[i].CreatorId;
                    dr["CreateTime"] = list[i].CreateTime;
                    dr["EditorId"] = list[i].EditorId;
                    dr["Deleted"] = list[i].Deleted;
                    dr["Enabled"] = list[i].Enabled;
                    dtNew.Rows.Add(dr);
                }

                try
                {
                    string error = "";
                    AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageDxUtil.ShowError(string.Format("导出Excel出现错误：{0}", error));
                    }
                    else
                    {
                        if (MessageDxUtil.ShowYesNoAndTips("导出成功，是否打开文件？") == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
        }

        private FrmAdvanceSearch dlg;
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            if (dlg == null)
            {
                dlg = new FrmAdvanceSearch();
                dlg.FieldTypeTable = CallerFactory<IStaffService>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = CallerFactory<IStaffService>.Instance.GetColumnNameAlias();
                dlg.DisplayColumns = "Id,Number,Name,Gender,Birthday,NativePlace,Nationality,IdentityCard,Phone,OfficePhone,Email,HomeAddress,Political,PartyDate,Education,Degree,WorkingDate,Marriage,ChildStatus,Titles,Duty,JobType,Introduce,Remark,AttachId,CompanyId,DepartmentId,PositionId,Creator,CreatorId,CreateTime,EditorId,Deleted,Enabled";

                #region 下拉列表数据

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("人员类型"));//字典列表
                //dlg.AddColumnListItem("Sex", "男,女");//固定列表
                //dlg.AddColumnListItem("Credit", BLLFactory<Staff>.Instance.GetFieldList("Credit"));//动态列表

                #endregion

                dlg.ConditionChanged += new FrmAdvanceSearch.ConditionChangedEventHandler(dlg_ConditionChanged);
            }
            dlg.ShowDialog();
        }

        void dlg_ConditionChanged(SearchCondition condition)
        {
            advanceCondition = condition;
            BindData();
        }
        #endregion //System
    }
}

using System;
using System.Text;
using System.Data;
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
    /// Position
    /// </summary>	
    public partial class FrmPosition : BaseDock
    {
        #region Constructor
        public FrmPosition()
        {
            InitializeComponent();

            InitDictItem();
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
        /// 初始化数据
        /// </summary>
        private void LoadData()
        {
            var departments = CallerFactory<IDepartmentService>.Instance.FindAll();
            this.depTree.DataSource = departments;
        }

        /// <summary>
        /// 载入部门包含岗位
        /// </summary>
        /// <param name="department"></param>
        private void LoadPositions(DepartmentInfo department)
        {
            var positions = CallerFactory<IPositionService>.Instance.FindByDepartment(department.Id);

            this.wgvPosition.DisplayColumns = "Name,Number,Quota,SortCode,Remark,Enabled";
            this.wgvPosition.ColumnNameAlias = CallerFactory<IPositionService>.Instance.GetColumnNameAlias();

            this.wgvPosition.DataSource = positions;
            this.wgvPosition.PrintTitle = "岗位报表";            
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void FormOnLoad()
        {
            LoadData();

            this.depTree.Expand();

            this.wgvPosition.AppendedMenu = this.contextMenuStrip1;
            this.wgvPosition.ShowLineNumber = true;
            this.wgvPosition.BestFitColumnWith = true;

            //         this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            //         this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            //         this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            

            this.wgvPosition.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dlg_OnDataSaved(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 选择部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentSelect(object sender, EventArgs e)
        {
            var department = this.depTree.GetSelectedObject();
            if (department != null)
            {
                this.txtDepartmentName.Text = department.Name;
                this.txtDepartmentNumber.Text = department.Number;
                LoadPositions(department);
            }
        }

        /// <summary>
        /// 新增数据操作
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmPositionEdit dlg = new FrmPositionEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadData();
            }
        }

        /// <summary>
        /// 菜单 - 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuView_Click(object sender, EventArgs e)
        {
            string ID = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvPosition.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvPosition.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmPositionView dlg = new FrmPositionView();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// 菜单 - 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEdit_Click(object sender, EventArgs e)
        {
            string ID = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvPosition.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvPosition.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmPositionEdit dlg = new FrmPositionEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// 菜单 - 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, EventArgs e)
        {
            string id = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }
            
            CallerFactory<IPositionService>.Instance.MarkDelete(id);
            LoadData();
        }

        #region Grid Event
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
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "已启用" : "未启用";
            }

        }
        #endregion //Grid Event
        #endregion //Event


      
        
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;
        
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
                //condition.AddNumericCondition("DepartmentId", this.txtDepartmentId1, this.txtDepartmentId2); //数值类型
                //condition.AddCondition("Name", this.txtName.Text.Trim(), SqlOperator.Like);
                //condition.AddCondition("Number", this.txtNumber.Text.Trim(), SqlOperator.Like);
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
            //this.winGridViewPager1.DisplayColumns = "DepartmentId,Name,Number,Quota,SortCode,Remark,Deleted,Enabled";
            //this.winGridViewPager1.ColumnNameAlias = BLLFactory<Position>.Instance.GetColumnNameAlias();//字段列显示名称转义

            //#region 添加别名解析

            ////this.winGridViewPager1.AddColumnAlias("DepartmentId", "DepartmentId");
            ////this.winGridViewPager1.AddColumnAlias("Name", "Name");
            ////this.winGridViewPager1.AddColumnAlias("Number", "Number");
            ////this.winGridViewPager1.AddColumnAlias("Quota", "Quota");
            ////this.winGridViewPager1.AddColumnAlias("SortCode", "SortCode");
            ////this.winGridViewPager1.AddColumnAlias("Remark", "Remark");
            ////this.winGridViewPager1.AddColumnAlias("Deleted", "Deleted");
            ////this.winGridViewPager1.AddColumnAlias("Enabled", "Enabled");

            //#endregion

            //string where = GetConditionSql();
	           // List<PositionInfo> list = BLLFactory<Position>.Instance.FindWithPager(where, this.winGridViewPager1.PagerInfo);
            //this.winGridViewPager1.DataSource = list;//new WHC.Pager.WinControl.SortableBindingList<PositionInfo>(list);
            //    this.winGridViewPager1.PrintTitle = "Position报表";
         }
        
   
     
		 		 		 		 		 		 		 		 		 		  		  		 		 
        private string moduleName = "Position";
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
        
        bool ExcelData_OnDataSave(DataRow dr)
        {
            bool success = false;
   //         bool converted = false;
   //         DateTime dtDefault = Convert.ToDateTime("1900-01-01");
   //         DateTime dt;
   //         PositionInfo info = new PositionInfo();
   //         info.Id = new Guid(GetRowData(dr, "Id"));
   //           info.DepartmentId = GetRowData(dr, "DepartmentId").ToInt32();
   //           info.Name = GetRowData(dr, "Name");
   //           info.Number = GetRowData(dr, "Number");
   //           info.Quota = GetRowData(dr, "Quota").ToInt32();
   //           info.SortCode = GetRowData(dr, "SortCode");
   //           info.Remark = GetRowData(dr, "Remark");
   //           info.Creator = GetRowData(dr, "Creator");
   //           info.CreatorId = GetRowData(dr, "CreatorId");
  
   //         string CreateTime = GetRowData(dr, "CreateTime");
   //         if (!string.IsNullOrEmpty(CreateTime))
   //         {
			//	converted = DateTime.TryParse(CreateTime, out dt);
   //             if (converted && dt > dtDefault)
   //             {
   //                 info.CreateTime = dt;
   //             }
			//}
   //         else
   //         {
   //             info.CreateTime = DateTime.Now;
   //         }

   //            info.EditorId = GetRowData(dr, "EditorId");
   //            info.Deleted = GetRowData(dr, "Deleted").ToInt32();
   //           info.Enabled = GetRowData(dr, "Enabled").ToInt32();
  
   //         success = BLLFactory<Position>.Instance.Insert(info);
             return success;
        }

        /// <summary>
        /// 导出Excel的操作
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            //if (!string.IsNullOrEmpty(file))
            //{
            //    string where = GetConditionSql();
            //    List<PositionInfo> list = BLLFactory<Position>.Instance.Find(where);
            //     DataTable dtNew = DataTableHelper.CreateTable("序号|int,Id,DepartmentId,Name,Number,Quota,SortCode,Remark,Creator,CreatorId,CreateTime,EditorId,Deleted,Enabled");
            //    DataRow dr;
            //    int j = 1;
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        dr = dtNew.NewRow();
            //        dr["序号"] = j++;
            //        dr["Id"] = list[i].Id;
            //         dr["DepartmentId"] = list[i].DepartmentId;
            //         dr["Name"] = list[i].Name;
            //         dr["Number"] = list[i].Number;
            //         dr["Quota"] = list[i].Quota;
            //         dr["SortCode"] = list[i].SortCode;
            //         dr["Remark"] = list[i].Remark;
            //         dr["Creator"] = list[i].Creator;
            //         dr["CreatorId"] = list[i].CreatorId;
            //         dr["CreateTime"] = list[i].CreateTime;
            //          dr["EditorId"] = list[i].EditorId;
            //          dr["Deleted"] = list[i].Deleted;
            //         dr["Enabled"] = list[i].Enabled;
            //         dtNew.Rows.Add(dr);
            //    }

            //    try
            //    {
            //        string error = "";
            //        AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
            //        if (!string.IsNullOrEmpty(error))
            //        {
            //            MessageDxUtil.ShowError(string.Format("导出Excel出现错误：{0}", error));
            //        }
            //        else
            //        {
            //            if (MessageDxUtil.ShowYesNoAndTips("导出成功，是否打开文件？") == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                System.Diagnostics.Process.Start(file);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        LogTextHelper.Error(ex);
            //        MessageDxUtil.ShowError(ex.Message);
            //    }
            //}
         }
         
        private FrmAdvanceSearch dlg;

    }
}

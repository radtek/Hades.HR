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
        #region Constructor
        public FrmLaborAttendance()
        {
            InitializeComponent();

            InitDictItem();

   //         this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
   //         this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
   //         this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
   //         this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
   //         this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
   //         this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
   //         this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;
   //         this.winGridViewPager1.ShowLineNumber = true;
   //         this.winGridViewPager1.BestFitColumnWith = false;//是否设置为自动调整宽度，false为不设置
			//this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
   //         this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
   //         this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

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

            foreach(var com in companys)
            {
                TreeNode comNode = new TreeNode { Name = com.Id, Text = com.Name, Tag = 1 };
                var node = this.tvLine.Nodes.Add(comNode);

                var lines2 = lines.Where(r => r.CompanyId == com.Id);
                foreach(var line in lines2)
                {
                    TreeNode lineNode = new TreeNode { Name = line.Id, Text = line.Name, Tag = 2 };
                    var node2 = comNode.Nodes.Add(lineNode);

                    var teams2 = teams.Where(r => r.ProductionLineId == line.Id);
                    foreach(var team in teams2)
                    {
                        TreeNode teamNode = new TreeNode { Name = team.Id, Text = team.Name, Tag = 3 };
                        lineNode.Nodes.Add(teamNode);
                    }
                }

            }
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
      
        private void dpAttendance_EditValueChanged(object sender, EventArgs e)
        {

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
                //LoadRecordData();
            }
        }
        #endregion //Event

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

        private void SetGridColumWidth(string columnName, int width)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = this.wgvRecord.gridView1.Columns.ColumnByFieldName(columnName);
            if (column != null)
            {
                column.Width = width;
            }
        }

    
        
    
        
        /// <summary>
        /// 分页控件刷新操作
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
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

            int[] rowSelected = this.wgvRecord.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                string ID = this.wgvRecord.GridView1.GetRowCellDisplayText(iRow, "ID");
                CallerFactory<ILaborAttendanceRecordService>.Instance.Delete(ID);
            }	 
             
            BindData();
        }
        
        /// <summary>
        /// 分页控件编辑项操作
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            string ID = this.wgvRecord.gridView1.GetFocusedRowCellDisplayText("ID");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvRecord.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvRecord.GridView1.GetRowCellDisplayText(i, "ID");
                IDList.Add(strTemp);
            }

            //if (!string.IsNullOrEmpty(ID))
            //{
            //    FrmEditLaborAttendanceRecord dlg = new FrmEditLaborAttendanceRecord();
            //    dlg.ID = ID;
            //    dlg.IDList = IDList;
            //    dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            //    dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
                
            //    if (DialogResult.OK == dlg.ShowDialog())
            //    {
            //        BindData();
            //    }
            //}
        }        
        
        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 分页控件新增操作
        /// </summary>        
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }
        
        /// <summary>
        /// 分页控件全部导出操作前的操作
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.wgvRecord.AllToExport = CallerFactory<ILaborAttendanceRecordService>.Instance.FindToDataTable(where);
         }

        /// <summary>
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
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
                //condition.AddCondition("StaffId", this.txtStaffId.Text.Trim(), SqlOperator.Like);
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
            this.wgvRecord.DisplayColumns = "StaffId,AttendanceDate,Workload,AbsentType";
            this.wgvRecord.ColumnNameAlias = CallerFactory<ILaborAttendanceRecordService>.Instance.GetColumnNameAlias();//字段列显示名称转义

            #region 添加别名解析

            //this.winGridViewPager1.AddColumnAlias("StaffId", "StaffId");
            //this.winGridViewPager1.AddColumnAlias("AttendanceDate", "AttendanceDate");
            //this.winGridViewPager1.AddColumnAlias("Workload", "Workload");
            //this.winGridViewPager1.AddColumnAlias("AbsentType", "AbsentType");

            #endregion

            string where = GetConditionSql();
            PagerInfo pagerInfo = this.wgvRecord.PagerInfo;
               List<LaborAttendanceRecordInfo> list = CallerFactory<ILaborAttendanceRecordService>.Instance.FindWithPager(where, ref pagerInfo);
            this.wgvRecord.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvRecord.DataSource = new Hades.Pager.WinControl.SortableBindingList<LaborAttendanceRecordInfo>(list);
               this.wgvRecord.PrintTitle = "LaborAttendanceRecord报表";
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
        /// 新增数据操作
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //FrmEditLaborAttendanceRecord dlg = new FrmEditLaborAttendanceRecord();
            //dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            //dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
            
            //if (DialogResult.OK == dlg.ShowDialog())
            //{
            //    BindData();
            //}
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

		 		 		 		 		 
        private string moduleName = "LaborAttendanceRecord";
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
            LaborAttendanceRecordInfo info = new LaborAttendanceRecordInfo();
            info.Id = GetRowData(dr, "Id");
              info.StaffId = GetRowData(dr, "StaffId");
  
            string AttendanceDate = GetRowData(dr, "AttendanceDate");
            if (!string.IsNullOrEmpty(AttendanceDate))
            {
				converted = DateTime.TryParse(AttendanceDate, out dt);
                if (converted && dt > dtDefault)
                {
                    info.AttendanceDate = dt;
                }
			}
            else
            {
                info.AttendanceDate = DateTime.Now;
            }

              info.Workload = GetRowData(dr, "Workload").ToDecimal();
              info.AbsentType = GetRowData(dr, "AbsentType").ToInt32();
  
            success = CallerFactory<ILaborAttendanceRecordService>.Instance.Insert(info);
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
                List<LaborAttendanceRecordInfo> list = CallerFactory<ILaborAttendanceRecordService>.Instance.Find(where);
                 DataTable dtNew = DataTableHelper.CreateTable("序号|int,Id,StaffId,AttendanceDate,Workload,AbsentType");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["序号"] = j++;
                    dr["Id"] = list[i].Id;
                     dr["StaffId"] = list[i].StaffId;
                     dr["AttendanceDate"] = list[i].AttendanceDate;
                     dr["Workload"] = list[i].Workload;
                     dr["AbsentType"] = list[i].AbsentType;
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
                dlg.FieldTypeTable = CallerFactory<ILaborAttendanceRecordService>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = CallerFactory<ILaborAttendanceRecordService>.Instance.GetColumnNameAlias();                
                 dlg.DisplayColumns = "Id,StaffId,AttendanceDate,Workload,AbsentType";

                #region 下拉列表数据

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("人员类型"));//字典列表
                //dlg.AddColumnListItem("Sex", "男,女");//固定列表
                //dlg.AddColumnListItem("Credit", BLLFactory<LaborAttendanceRecord>.Instance.GetFieldList("Credit"));//动态列表

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

    }
}

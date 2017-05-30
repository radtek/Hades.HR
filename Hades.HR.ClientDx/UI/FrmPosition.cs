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
        /// ��ʼ���ֵ��б�����
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void LoadData()
        {
            var departments = CallerFactory<IDepartmentService>.Instance.FindAll();
            this.depTree.DataSource = departments;
        }

        /// <summary>
        /// ���벿�Ű�����λ
        /// </summary>
        /// <param name="department"></param>
        private void LoadPositions(DepartmentInfo department)
        {
            var positions = CallerFactory<IPositionService>.Instance.FindByDepartment(department.Id);

            this.wgvPosition.DisplayColumns = "Name,Number,Quota,SortCode,Remark,Enabled";
            this.wgvPosition.ColumnNameAlias = CallerFactory<IPositionService>.Instance.GetColumnNameAlias();

            this.wgvPosition.DataSource = positions;
            this.wgvPosition.PrintTitle = "��λ����";            
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
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
        /// ���ݱ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dlg_OnDataSaved(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// ѡ����
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
        /// �������ݲ���
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmPositionEdit dlg = new FrmPositionEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadData();
            }
        }

        /// <summary>
        /// �˵� - �鿴
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
        /// �˵� - �༭
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
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// �˵� - ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, EventArgs e)
        {
            string id = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���ļ�¼ô��") == DialogResult.No)
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
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "������" : "δ����";
            }

        }
        #endregion //Grid Event
        #endregion //Event


      
        
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;
        
        /// <summary>
        /// ���ݲ�ѯ���������ѯ���
        /// </summary> 
        private string GetConditionSql()
        {
            //������ڸ߼���ѯ������Ϣ����ʹ�ø߼���ѯ����������ʹ������������ѯ
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {
                condition = new SearchCondition();
                //condition.AddNumericCondition("DepartmentId", this.txtDepartmentId1, this.txtDepartmentId2); //��ֵ����
                //condition.AddCondition("Name", this.txtName.Text.Trim(), SqlOperator.Like);
                //condition.AddCondition("Number", this.txtNumber.Text.Trim(), SqlOperator.Like);
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        
        /// <summary>
        /// ���б�����
        /// </summary>
        private void BindData()
        {
        	//entity
            //this.winGridViewPager1.DisplayColumns = "DepartmentId,Name,Number,Quota,SortCode,Remark,Deleted,Enabled";
            //this.winGridViewPager1.ColumnNameAlias = BLLFactory<Position>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            //#region ��ӱ�������

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
            //    this.winGridViewPager1.PrintTitle = "Position����";
         }
        
   
     
		 		 		 		 		 		 		 		 		 		  		  		 		 
        private string moduleName = "Position";
        /// <summary>
        /// ����Excel�Ĳ���
        /// </summary>          
        private void btnImport_Click(object sender, EventArgs e)
        {
            string templateFile = string.Format("{0}-ģ��.xls", moduleName);
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
        /// ����Excel�Ĳ���
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            //if (!string.IsNullOrEmpty(file))
            //{
            //    string where = GetConditionSql();
            //    List<PositionInfo> list = BLLFactory<Position>.Instance.Find(where);
            //     DataTable dtNew = DataTableHelper.CreateTable("���|int,Id,DepartmentId,Name,Number,Quota,SortCode,Remark,Creator,CreatorId,CreateTime,EditorId,Deleted,Enabled");
            //    DataRow dr;
            //    int j = 1;
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        dr = dtNew.NewRow();
            //        dr["���"] = j++;
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
            //            MessageDxUtil.ShowError(string.Format("����Excel���ִ���{0}", error));
            //        }
            //        else
            //        {
            //            if (MessageDxUtil.ShowYesNoAndTips("�����ɹ����Ƿ���ļ���") == System.Windows.Forms.DialogResult.Yes)
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

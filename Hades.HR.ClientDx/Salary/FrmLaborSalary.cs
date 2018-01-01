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

using Hades.HR.BLL;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    /// <summary>
    /// LaborSalary
    /// </summary>	
    public partial class FrmLaborSalary : BaseDock
    {
        public FrmLaborSalary()
        {
            InitializeComponent();

            InitDictItem();

            this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;
            this.winGridViewPager1.ShowLineNumber = true;
            this.winGridViewPager1.BestFitColumnWith = false;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
			this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

            //�����س������в�ѯ
            foreach (Control control in this.layoutControl1.Controls)
            {
                control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
            }
        }
        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName == "OrderStatus")
            //{
            //    string status = this.winGridViewPager1.gridView1.GetRowCellValue(e.RowHandle, "OrderStatus").ToString();
            //    Color color = Color.White;
            //    if (status == "�����")
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
            //    e.DisplayText = string.Format("{0}��", e.Value);
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
        /// �����ݺ󣬷�����еĿ��
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.winGridViewPager1.gridView1.Columns.Count > 0 && this.winGridViewPager1.gridView1.RowCount > 0)
            {
                //ͳһ����100���
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridViewPager1.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //�����������ر�Ŀ��
                //SetGridColumWidth("Note", 200);
            }
        }

        private void SetGridColumWidth(string columnName, int width)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = this.winGridViewPager1.gridView1.Columns.ColumnByFieldName(columnName);
            if (column != null)
            {
                column.Width = width;
            }
        }

        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void  FormOnLoad()
        {   
            BindData();
        }
        
        /// <summary>
        /// ��ʼ���ֵ��б�����
        /// </summary>
        private void InitDictItem()
        {
			//��ʼ������
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ˢ�²���
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ɾ������
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���ļ�¼ô��") == DialogResult.No)
            {
                return;
            }

            int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                string ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "ID");
                BLLFactory<LaborSalary>.Instance.Delete(ID);
            }
             
            BindData();
        }
        
        /// <summary>
        /// ��ҳ�ؼ��༭�����
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            string ID = this.winGridViewPager1.gridView1.GetFocusedRowCellDisplayText("ID");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.winGridViewPager1.gridView1.RowCount; i++)
            {
                string strTemp = this.winGridViewPager1.GridView1.GetRowCellDisplayText(i, "ID");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditLaborSalary dlg = new FrmEditLaborSalary();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
                
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    BindData();
                }
            }
        }        
        
        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// ��ҳ�ؼ���������
        /// </summary>        
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ȫ����������ǰ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.winGridViewPager1.AllToExport = BLLFactory<LaborSalary>.Instance.FindToDataTable(where);
         }

        /// <summary>
        /// ��ҳ�ؼ���ҳ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
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
                condition.AddCondition("StaffId", this.txtStaffId.Text.Trim(), SqlOperator.Like);
                condition.AddNumericCondition("Year", this.txtYear1, this.txtYear2); //��ֵ����
                condition.AddNumericCondition("Month", this.txtMonth1, this.txtMonth2); //��ֵ����
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
            this.winGridViewPager1.DisplayColumns = "StaffId,Year,Month,StaffLevelId,LevelSalary,BaseSalary,OverSalary,WeekendSalary,HolidaySalary,Estimation,Allowance,TotalSalary,NoonShift,NightShift,OtherNoon,OtherNight,ShiftAmount,Remark";
            this.winGridViewPager1.ColumnNameAlias = BLLFactory<LaborSalary>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            #region ��ӱ�������

            //this.winGridViewPager1.AddColumnAlias("StaffId", "StaffId");
            //this.winGridViewPager1.AddColumnAlias("Year", "Year");
            //this.winGridViewPager1.AddColumnAlias("Month", "Month");
            //this.winGridViewPager1.AddColumnAlias("StaffLevelId", "StaffLevelId");
            //this.winGridViewPager1.AddColumnAlias("LevelSalary", "LevelSalary");
            //this.winGridViewPager1.AddColumnAlias("BaseSalary", "BaseSalary");
            //this.winGridViewPager1.AddColumnAlias("OverSalary", "OverSalary");
            //this.winGridViewPager1.AddColumnAlias("WeekendSalary", "WeekendSalary");
            //this.winGridViewPager1.AddColumnAlias("HolidaySalary", "HolidaySalary");
            //this.winGridViewPager1.AddColumnAlias("Estimation", "Estimation");
            //this.winGridViewPager1.AddColumnAlias("Allowance", "Allowance");
            //this.winGridViewPager1.AddColumnAlias("TotalSalary", "TotalSalary");
            //this.winGridViewPager1.AddColumnAlias("NoonShift", "NoonShift");
            //this.winGridViewPager1.AddColumnAlias("NightShift", "NightShift");
            //this.winGridViewPager1.AddColumnAlias("OtherNoon", "OtherNoon");
            //this.winGridViewPager1.AddColumnAlias("OtherNight", "OtherNight");
            //this.winGridViewPager1.AddColumnAlias("ShiftAmount", "ShiftAmount");
            //this.winGridViewPager1.AddColumnAlias("Remark", "Remark");

            #endregion

            string where = GetConditionSql();
	            List<LaborSalaryInfo> list = BLLFactory<LaborSalary>.Instance.FindWithPager(where, this.winGridViewPager1.PagerInfo);
            this.winGridViewPager1.DataSource = list;//new WHC.Pager.WinControl.SortableBindingList<LaborSalaryInfo>(list);
                this.winGridViewPager1.PrintTitle = "LaborSalary����";
         }
        
        /// <summary>
        /// ��ѯ���ݲ���
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
        	advanceCondition = null;//�������ò�ѯ������������ܻ�ʹ�ø߼���ѯ������
            BindData();
        }
        
        /// <summary>
        /// �������ݲ���
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmEditLaborSalary dlg = new FrmEditLaborSalary();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }
        
        /// <summary>
        /// �ṩ���ؼ��س�ִ�в�ѯ�Ĳ���
        /// </summary>
        private void SearchControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }        

		 		 		 		 		 		 		 		 		 		 		 		 		 		 		 		 		 		 		  		  
        private string moduleName = "LaborSalary";
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

        /// <summary>
        /// ����ֶδ��ڣ����ȡ��Ӧ��ֵ�����򷵻�Ĭ�Ͽ�
        /// </summary>
        /// <param name="row">DataRow����</param>
        /// <param name="columnName">�ֶ�����</param>
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
            LaborSalaryInfo info = new LaborSalaryInfo();
            info.Id = GetRowData(dr, "Id");
              info.StaffId = GetRowData(dr, "StaffId");
              info.Year = GetRowData(dr, "Year").ToInt32();
              info.Month = GetRowData(dr, "Month").ToInt32();
              info.StaffLevelId = GetRowData(dr, "StaffLevelId");
              info.LevelSalary = GetRowData(dr, "LevelSalary").ToDecimal();
              info.BaseSalary = GetRowData(dr, "BaseSalary").ToDecimal();
              info.OverSalary = GetRowData(dr, "OverSalary").ToDecimal();
              info.WeekendSalary = GetRowData(dr, "WeekendSalary").ToDecimal();
              info.HolidaySalary = GetRowData(dr, "HolidaySalary").ToDecimal();
              info.Estimation = GetRowData(dr, "Estimation").ToDecimal();
              info.Allowance = GetRowData(dr, "Allowance").ToDecimal();
              info.TotalSalary = GetRowData(dr, "TotalSalary").ToDecimal();
              info.NoonShift = GetRowData(dr, "NoonShift").ToInt32();
              info.NightShift = GetRowData(dr, "NightShift").ToInt32();
              info.OtherNoon = GetRowData(dr, "OtherNoon").ToInt32();
              info.OtherNight = GetRowData(dr, "OtherNight").ToInt32();
              info.ShiftAmount = GetRowData(dr, "ShiftAmount").ToDecimal();
              info.Remark = GetRowData(dr, "Remark");
               info.EditorId = GetRowData(dr, "EditorId");
   
            success = BLLFactory<LaborSalary>.Instance.Insert(info);
             return success;
        }

        /// <summary>
        /// ����Excel�Ĳ���
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            if (!string.IsNullOrEmpty(file))
            {
                string where = GetConditionSql();
                List<LaborSalaryInfo> list = BLLFactory<LaborSalary>.Instance.Find(where);
                 DataTable dtNew = DataTableHelper.CreateTable("���|int,Id,StaffId,Year,Month,StaffLevelId,LevelSalary,BaseSalary,OverSalary,WeekendSalary,HolidaySalary,Estimation,Allowance,TotalSalary,NoonShift,NightShift,OtherNoon,OtherNight,ShiftAmount,Remark,EditorId");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["���"] = j++;
                    dr["Id"] = list[i].Id;
                     dr["StaffId"] = list[i].StaffId;
                     dr["Year"] = list[i].Year;
                     dr["Month"] = list[i].Month;
                     dr["StaffLevelId"] = list[i].StaffLevelId;
                     dr["LevelSalary"] = list[i].LevelSalary;
                     dr["BaseSalary"] = list[i].BaseSalary;
                     dr["OverSalary"] = list[i].OverSalary;
                     dr["WeekendSalary"] = list[i].WeekendSalary;
                     dr["HolidaySalary"] = list[i].HolidaySalary;
                     dr["Estimation"] = list[i].Estimation;
                     dr["Allowance"] = list[i].Allowance;
                     dr["TotalSalary"] = list[i].TotalSalary;
                     dr["NoonShift"] = list[i].NoonShift;
                     dr["NightShift"] = list[i].NightShift;
                     dr["OtherNoon"] = list[i].OtherNoon;
                     dr["OtherNight"] = list[i].OtherNight;
                     dr["ShiftAmount"] = list[i].ShiftAmount;
                     dr["Remark"] = list[i].Remark;
                      dr["EditorId"] = list[i].EditorId;
                      dtNew.Rows.Add(dr);
                }

                try
                {
                    string error = "";
                    AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageDxUtil.ShowError(string.Format("����Excel���ִ���{0}", error));
                    }
                    else
                    {
                        if (MessageDxUtil.ShowYesNoAndTips("�����ɹ����Ƿ���ļ���") == System.Windows.Forms.DialogResult.Yes)
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
                dlg.FieldTypeTable = BLLFactory<LaborSalary>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = BLLFactory<LaborSalary>.Instance.GetColumnNameAlias();                
                 dlg.DisplayColumns = "Id,StaffId,Year,Month,StaffLevelId,LevelSalary,BaseSalary,OverSalary,WeekendSalary,HolidaySalary,Estimation,Allowance,TotalSalary,NoonShift,NightShift,OtherNoon,OtherNight,ShiftAmount,Remark,EditorId";

                #region �����б�����

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("��Ա����"));//�ֵ��б�
                //dlg.AddColumnListItem("Sex", "��,Ů");//�̶��б�
                //dlg.AddColumnListItem("Credit", BLLFactory<LaborSalary>.Instance.GetFieldList("Credit"));//��̬�б�

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

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
using Hades.Framework.ControlUtil;

using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    /// <summary>
    /// Attendance
    /// </summary>	
    public partial class FrmAttendance : BaseDock
    {
        public FrmAttendance()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvRecord.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.wgvRecord.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            this.wgvRecord.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            this.wgvRecord.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            this.wgvRecord.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.wgvRecord.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvRecord.AppendedMenu = this.contextMenuStrip1;
            this.wgvRecord.ShowLineNumber = true;
            this.wgvRecord.BestFitColumnWith = false;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
			this.wgvRecord.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            this.wgvRecord.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.wgvRecord.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);
                     
        }

        #region Function
        /// <summary>
        /// ��ʼ���ֵ��б�����
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������
        }

        /// <summary>
        /// �����¶ȿ���
        /// </summary>
        private void LoadAttendance()
        {
            var data = CallerFactory<IAttendanceService>.Instance.Find("");

            var years = data.GroupBy(r => r.Year).Select(g => g.Key).OrderByDescending(s => s);

            this.tvAttendance.Nodes.Clear();
            foreach(var year in years)
            {
                TreeNode yearNode = new TreeNode { Name = year.ToString(), Text = year.ToString() + "��", Tag = 1 };
                var node = this.tvAttendance.Nodes.Add(yearNode);

                var months = data.Where(r => r.Year == year).OrderByDescending(r => r.Month);
                foreach(var month in months)
                {
                    TreeNode monthNode = new TreeNode { Name = month.Id, Text = month.Month.ToString() + "��", Tag = 2 };
                    yearNode.Nodes.Add(monthNode);
                }
            }
        }

        /// <summary>
        /// �����¶ȿ���
        /// </summary>
        private void AddAttendance()
        {
            FrmEditAttendance dlg = new FrmEditAttendance();
            //dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadAttendance();
            }
        }

        /// <summary>
        /// ���б�����
        /// </summary>
        private void LoadRecordData()
        {
            //entity
            this.wgvRecord.DisplayColumns = "StaffId,AttendanceDays,AnnualLeave,SickLeave,CasualLeave,InjuryLeave,MarriageLeave,LeaveDays,NormalOvertime,NormalOvertimeSalary,WeekendOvertime,WeekendOvertimeSalary,HolidayOvertime,HolidayOvertimeSalary,OvertimeSalarySum,NoonShift,NightShift,OtherShift,LunchAllowance,LeaderAllowance,Deduction,Nutrition,Remark";
            this.wgvRecord.ColumnNameAlias = CallerFactory<IAttendanceRecordService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��
                     
            string where = GetConditionSql();
            PagerInfo pagerInfo = this.wgvRecord.PagerInfo;
            List<AttendanceRecordInfo> list = CallerFactory<IAttendanceRecordService>.Instance.FindWithPager(where, ref pagerInfo);
            this.wgvRecord.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvRecord.DataSource = new Hades.Pager.WinControl.SortableBindingList<AttendanceRecordInfo>(list);
            this.wgvRecord.PrintTitle = "���ڼ�¼����";
        }

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

                var node = this.tvAttendance.SelectedNode;
                if (node != null && Convert.ToInt32(node.Tag) == 2)
                {
                    condition.AddCondition("AttendanceId", node.Name, SqlOperator.Equal);
                }
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��������
        /// </summary>
        public override void FormOnLoad()
        {
            LoadAttendance();
            LoadRecordData();

            this.luDepartment.Init();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// �¶ȿ���ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvAttendance_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// �����¶ȿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAttendance_Click(object sender, EventArgs e)
        {
            AddAttendance();
        }

        /// <summary>
        /// �༭�¶ȿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditAttendance_Click(object sender, EventArgs e)
        {
            var node = this.tvAttendance.SelectedNode;
            if (node == null)
                return;
            if (Convert.ToInt32(node.Tag) == 1)
            {
                MessageDxUtil.ShowWarning("��ѡ�����¶�");
                return;
            }

            string attId = node.Name;

            FrmEditAttendance dlg = new FrmEditAttendance();        
            dlg.ID = attId;             
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadAttendance();
            }
        }

        /// <summary>
        /// �༭���ڼ�¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            var node = this.tvAttendance.SelectedNode;
            if (node == null)
                return;
            if (Convert.ToInt32(node.Tag) == 1)
            {
                MessageDxUtil.ShowWarning("��ѡ�����¶�");
                return;
            }
            string attId = node.Name;

            var depId = this.luDepartment.GetSelectedId();
            if (string.IsNullOrEmpty(depId))
            {
                MessageDxUtil.ShowWarning("��ѡ����");
                return;
            }

            FrmAttendanceRecordEdit dlg = new FrmAttendanceRecordEdit(attId, depId);          
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            if (DialogResult.OK == dlg.ShowDialog())
            {
                //LoadAttendance();
            }
        }

        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luDepartment_DepartmentSelect(object sender, EventArgs e)
        {

        }
        #endregion //Event

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
            if (this.wgvRecord.gridView1.Columns.Count > 0 && this.wgvRecord.gridView1.RowCount > 0)
            {
                //ͳһ����100���
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.wgvRecord.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //�����������ر�Ŀ��
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

            int[] rowSelected = this.wgvRecord.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                string ID = this.wgvRecord.GridView1.GetRowCellDisplayText(iRow, "ID");
                CallerFactory<IAttendanceService>.Instance.Delete(ID);
            }	 
             
            BindData();
        }
        
        /// <summary>
        /// ��ҳ�ؼ��༭�����
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

            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditAttendance dlg = new FrmEditAttendance();
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
            this.wgvRecord.AllToExport = CallerFactory<IAttendanceService>.Instance.FindToDataTable(where);
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
        /// ���б�����
        /// </summary>
        private void BindData()
        {
        	//entity
            this.wgvRecord.DisplayColumns = "Year,Month,Days,Remark";
            this.wgvRecord.ColumnNameAlias = CallerFactory<IAttendanceService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            #region ��ӱ�������

            //this.winGridViewPager1.AddColumnAlias("Year", "Year");
            //this.winGridViewPager1.AddColumnAlias("Month", "Month");
            //this.winGridViewPager1.AddColumnAlias("Days", "Days");
            //this.winGridViewPager1.AddColumnAlias("Remark", "Remark");

            #endregion

            string where = GetConditionSql();
            PagerInfo pagerInfo = this.wgvRecord.PagerInfo;
               List<AttendanceInfo> list = CallerFactory<IAttendanceService>.Instance.FindWithPager(where, ref pagerInfo);
            this.wgvRecord.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvRecord.DataSource = new Hades.Pager.WinControl.SortableBindingList<AttendanceInfo>(list);
               this.wgvRecord.PrintTitle = "Attendance����";
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
            FrmEditAttendance dlg = new FrmEditAttendance();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }

		 		 		 		 		 
        private string moduleName = "Attendance";
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
            AttendanceInfo info = new AttendanceInfo();
            info.Id = GetRowData(dr, "Id");
              info.Year = GetRowData(dr, "Year").ToInt32();
              info.Month = GetRowData(dr, "Month").ToInt32();
              info.Days = GetRowData(dr, "Days").ToInt32();
              info.Remark = GetRowData(dr, "Remark");
  
            success = CallerFactory<IAttendanceService>.Instance.Insert(info);
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
                List<AttendanceInfo> list = CallerFactory<IAttendanceService>.Instance.Find(where);
                 DataTable dtNew = DataTableHelper.CreateTable("���|int,Id,Year,Month,Days,Remark");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["���"] = j++;
                    dr["Id"] = list[i].Id;
                     dr["Year"] = list[i].Year;
                     dr["Month"] = list[i].Month;
                     dr["Days"] = list[i].Days;
                     dr["Remark"] = list[i].Remark;
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
                dlg.FieldTypeTable = CallerFactory<IAttendanceService>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = CallerFactory<IAttendanceService>.Instance.GetColumnNameAlias();                
                 dlg.DisplayColumns = "Id,Year,Month,Days,Remark";

                #region �����б�����

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("��Ա����"));//�ֵ��б�
                //dlg.AddColumnListItem("Sex", "��,Ů");//�̶��б�
                //dlg.AddColumnListItem("Credit", BLLFactory<Attendance>.Instance.GetFieldList("Credit"));//��̬�б�

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

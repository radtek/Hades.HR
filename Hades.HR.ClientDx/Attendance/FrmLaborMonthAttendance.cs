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
using Hades.HR.Util;

namespace Hades.HR.UI
{
    /// <summary>
    /// LaborMonthAttendance
    /// </summary>	
    public partial class FrmLaborMonthAttendance : BaseDock
    {
        #region Field
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        private List<WorkTeamInfo> workTeamList;

        /// <summary>
        /// ����ְԱ��Ϣ
        /// </summary>
        private List<StaffInfo> staffList;
        #endregion //Field

        #region Constructor
        public FrmLaborMonthAttendance()
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
            this.winGridViewPager1.gridView1.DataSourceChanged += new EventHandler(gridView1_DataSourceChanged);
            this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

            //�����س������в�ѯ
            foreach (Control control in this.layoutControl1.Controls)
            {
                control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
            }
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
        /// ���ݲ�ѯ���������ѯ���
        /// </summary> 
        private string GetConditionSql()
        {
            //������ڸ߼���ѯ������Ϣ����ʹ�ø߼���ѯ����������ʹ������������ѯ
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {
                condition = new SearchCondition();
                DateTime month = this.dpMonth.DateTime;
                string teamId = this.wtTree.GetSelectedTeamId();

                condition.AddCondition("Year", month.Year, SqlOperator.Equal);
                condition.AddCondition("Month", month.Month, SqlOperator.Equal);
                condition.AddCondition("WorkTeamId", teamId, SqlOperator.Equal);
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// ���б�����
        /// </summary>
        private void BindData()
        {
            if (this.dpMonth.EditValue == null)
                return;

            string teamId = this.wtTree.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
                return;

            //entity
            this.winGridViewPager1.DisplayColumns = "StaffId,WorkTeamId,AttendanceDays,AnnualLeave,SickLeave,CasualLeave,InjuryLeave,MarriageLeave,MaternityLeave,FuneralLeave,AbsentLeave,MonthWorkload,BaseWorkload,OverWorkload,WeekendWorkload,HolidayWorkload,NoonShift,NightShift,OtherNoon,OtherNight,Remark";            
            this.winGridViewPager1.ColumnNameAlias = CallerFactory<ILaborMonthAttendanceService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            string where = GetConditionSql();
            var pageInfo = this.winGridViewPager1.PagerInfo;
            List<LaborMonthAttendanceInfo> list = CallerFactory<ILaborMonthAttendanceService>.Instance.FindWithPager(where, ref pageInfo);

            this.winGridViewPager1.DataSource = list;
            //    this.winGridViewPager1.PrintTitle = "LaborMonthAttendance����";
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            this.workTeamList = CallerFactory<IWorkTeamService>.Instance.Find2("", "");
            this.staffList = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");
            this.wtTree.Init();
        }
        #endregion //Method

        #region Event
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dpMonth.EditValue == null)
            {
                MessageDxUtil.ShowWarning("��ѡ�����·�");
                return;
            }

            string teamId = this.wtTree.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
            {
                MessageDxUtil.ShowWarning("��ѡ�����");
                return;
            }

            FrmEditLaborMonthAttendance frm = new FrmEditLaborMonthAttendance(this.dpMonth.DateTime.Year, this.dpMonth.DateTime.Month, teamId);
            frm.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            frm.ShowDialog();
        }

        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpMonth_EditValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wtTree_TeamSeleted(object sender, EventArgs e)
        {
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
            else if (columnName == "StaffId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var st = this.staffList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (st != null)
                    {
                        e.DisplayText = st.Name;
                    }
                    else
                    {
                        var st2 = CallerFactory<IStaffService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = st2.Name;
                    }
                }
            }
            else if (columnName == "WorkTeamId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var wt = this.workTeamList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (wt != null)
                    {
                        e.DisplayText = wt.Name;
                    }
                    else
                    {
                        var wt2 = CallerFactory<IWorkTeamService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = wt2.Name;
                    }
                }
            }
        }
        #endregion //Event

        #region System
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
                CallerFactory<ILaborMonthAttendanceService>.Instance.Delete(ID);
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
                FrmEditLaborMonthAttendance dlg = new FrmEditLaborMonthAttendance();
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
            this.winGridViewPager1.AllToExport = CallerFactory<ILaborMonthAttendanceService>.Instance.FindToDataTable(where);
        }

        /// <summary>
        /// ��ҳ�ؼ���ҳ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
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
            FrmEditLaborMonthAttendance dlg = new FrmEditLaborMonthAttendance();
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


        private string moduleName = "LaborMonthAttendance";
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
            LaborMonthAttendanceInfo info = new LaborMonthAttendanceInfo();
            info.Id = GetRowData(dr, "Id");
            info.Year = GetRowData(dr, "Year").ToInt32();
            info.Month = GetRowData(dr, "Month").ToInt32();
            info.StaffId = GetRowData(dr, "StaffId");
            info.WorkTeamId = GetRowData(dr, "WorkTeamId");
            info.AttendanceDays = GetRowData(dr, "AttendanceDays").ToInt32();
            info.AnnualLeave = GetRowData(dr, "AnnualLeave").ToInt32();
            info.SickLeave = GetRowData(dr, "SickLeave").ToInt32();
            info.CasualLeave = GetRowData(dr, "CasualLeave").ToInt32();
            info.InjuryLeave = GetRowData(dr, "InjuryLeave").ToInt32();
            info.MarriageLeave = GetRowData(dr, "MarriageLeave").ToInt32();
            info.MaternityLeave = GetRowData(dr, "MaternityLeave").ToInt32();
            info.FuneralLeave = GetRowData(dr, "FuneralLeave").ToInt32();
            info.AbsentLeave = GetRowData(dr, "AbsentLeave").ToInt32();
            info.MonthWorkload = GetRowData(dr, "MonthWorkload").ToDecimal();
            info.BaseWorkload = GetRowData(dr, "BaseWorkload").ToDecimal();
            info.OverWorkload = GetRowData(dr, "OverWorkload").ToDecimal();
            info.WeekendWorkload = GetRowData(dr, "WeekendWorkload").ToDecimal();
            info.HolidayWorkload = GetRowData(dr, "HolidayWorkload").ToDecimal();
            info.NoonShift = GetRowData(dr, "NoonShift").ToInt32();
            info.NightShift = GetRowData(dr, "NightShift").ToInt32();
            info.OtherNoon = GetRowData(dr, "OtherNoon").ToInt32();
            info.OtherNight = GetRowData(dr, "OtherNight").ToInt32();
            info.Remark = GetRowData(dr, "Remark");

            success = CallerFactory<ILaborMonthAttendanceService>.Instance.Insert(info);
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
                List<LaborMonthAttendanceInfo> list = CallerFactory<ILaborMonthAttendanceService>.Instance.Find(where);
                DataTable dtNew = DataTableHelper.CreateTable("���|int,Id,Year,Month,StaffId,WorkTeamId,AttendanceDays,AnnualLeave,SickLeave,CasualLeave,InjuryLeave,MarriageLeave,MaternityLeave,FuneralLeave,AbsentLeave,MonthWorkload,BaseWorkload,OverWorkload,WeekendWorkload,HolidayWorkload,NoonShift,NightShift,OtherNoon,OtherNight,Remark");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["���"] = j++;
                    dr["Id"] = list[i].Id;
                    dr["Year"] = list[i].Year;
                    dr["Month"] = list[i].Month;
                    dr["StaffId"] = list[i].StaffId;
                    dr["WorkTeamId"] = list[i].WorkTeamId;
                    dr["AttendanceDays"] = list[i].AttendanceDays;
                    dr["AnnualLeave"] = list[i].AnnualLeave;
                    dr["SickLeave"] = list[i].SickLeave;
                    dr["CasualLeave"] = list[i].CasualLeave;
                    dr["InjuryLeave"] = list[i].InjuryLeave;
                    dr["MarriageLeave"] = list[i].MarriageLeave;
                    dr["MaternityLeave"] = list[i].MaternityLeave;
                    dr["FuneralLeave"] = list[i].FuneralLeave;
                    dr["AbsentLeave"] = list[i].AbsentLeave;
                    dr["MonthWorkload"] = list[i].MonthWorkload;
                    dr["BaseWorkload"] = list[i].BaseWorkload;
                    dr["OverWorkload"] = list[i].OverWorkload;
                    dr["WeekendWorkload"] = list[i].WeekendWorkload;
                    dr["HolidayWorkload"] = list[i].HolidayWorkload;
                    dr["NoonShift"] = list[i].NoonShift;
                    dr["NightShift"] = list[i].NightShift;
                    dr["OtherNoon"] = list[i].OtherNoon;
                    dr["OtherNight"] = list[i].OtherNight;
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
                dlg.FieldTypeTable = CallerFactory<ILaborMonthAttendanceService>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = CallerFactory<ILaborMonthAttendanceService>.Instance.GetColumnNameAlias();
                dlg.DisplayColumns = "Id,Year,Month,StaffId,WorkTeamId,AttendanceDays,AnnualLeave,SickLeave,CasualLeave,InjuryLeave,MarriageLeave,MaternityLeave,FuneralLeave,AbsentLeave,MonthWorkload,BaseWorkload,OverWorkload,WeekendWorkload,HolidayWorkload,NoonShift,NightShift,OtherNoon,OtherNight,Remark";

                #region �����б�����

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("��Ա����"));//�ֵ��б�
                //dlg.AddColumnListItem("Sex", "��,Ů");//�̶��б�
                //dlg.AddColumnListItem("Credit", BLLFactory<LaborMonthAttendance>.Instance.GetFieldList("Credit"));//��̬�б�

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

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
    /// WorkTeamDailyWorkload
    /// </summary>	
    public partial class FrmWorkTeamDailyWorkload : BaseDock
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
        public FrmWorkTeamDailyWorkload()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvWorkload.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvWorkload_CustomColumnDisplayText);
            this.wgvWorkload.AppendedMenu = this.contextMenuStrip1;

            this.wgvLabor.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvLabor_CustomColumnDisplayText);
            //         this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            //         this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            //         this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            //         this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            //         this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            //         this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            //         this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;
            //         this.winGridViewPager1.ShowLineNumber = true;
            //         this.winGridViewPager1.BestFitColumnWith = false;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
            //this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            //         this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            //         this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

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
                // condition.AddCondition("WorkTeamId", this.txtWorkTeamId.Text.Trim(), SqlOperator.Like);
                // condition.AddDateCondition("AttendanceDate", this.txtAttendanceDate1, this.txtAttendanceDate2); //��������
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
            //this.winGridViewPager1.DisplayColumns = "WorkTeamId,AttendanceDate,ProductionHours,ChangeHours,RepairHours,ElectricHours,PersonCount,Remark";
            //this.winGridViewPager1.ColumnNameAlias = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            //string where = GetConditionSql();
            //PagerInfo pagerInfo = this.winGridViewPager1.PagerInfo;
            //List<WorkTeamDailyWorkloadInfo> list = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindWithPager(where, ref pagerInfo);
            //this.winGridViewPager1.PagerInfo.RecordCount = pagerInfo.RecordCount;
            //this.winGridViewPager1.DataSource = new Hades.Pager.WinControl.SortableBindingList<WorkTeamDailyWorkloadInfo>(list);
            //this.winGridViewPager1.PrintTitle = "WorkTeamDailyWorkload����";
        }

        /// <summary>
        /// ������鹤��������
        /// </summary>
        private void LoadWorkTeamWorkload()
        {
            if (this.dpAttendance.EditValue == null)
                return;
            DateTime attendanceDate = this.dpAttendance.DateTime;

            string teamId = this.wtTree.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
                return;

            this.wgvWorkload.DisplayColumns = "WorkTeamId,AttendanceDate,ProductionHours,ChangeHours,RepairHours,ElectricHours,PersonCount,Remark";
            this.wgvWorkload.ColumnNameAlias = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            var data = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Find(string.Format("AttendanceDate='{0}' AND WorkTeamId='{1}'", attendanceDate, teamId));
            this.wgvWorkload.DataSource = data;
        }

        /// <summary>
        /// ����Ա��������
        /// </summary>
        private void LoadLaborWorkload()
        {
            if (this.dpAttendance.EditValue == null)
                return;
            DateTime attendanceDate = this.dpAttendance.DateTime;

            string teamId = this.wtTree.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
                return;

            this.wgvLabor.DisplayColumns = "WorkTeamId,ActualWorkTeamId,StaffId,ProductionHours,ChangeHours,RepairHours,ElectricHours,LeaveHours,AllowanceHours,Remark";
            this.wgvLabor.ColumnNameAlias = CallerFactory<ILaborDailyWorkloadService>.Instance.GetColumnNameAlias();

            var data = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("AttendanceDate='{0}' AND WorkTeamId='{1}'", attendanceDate, teamId));

            this.wgvLabor.DataSource = data;
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

            BindData();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ��������ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpAttendance_EditValueChanged(object sender, EventArgs e)
        {
            LoadWorkTeamWorkload();
            LoadLaborWorkload();
        }

        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wtTree_TeamSeleted(object sender, EventArgs e)
        {
            LoadWorkTeamWorkload();
            LoadLaborWorkload();
        }

        /// <summary>
        /// ����Ա��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            if (this.dpAttendance.EditValue == null)
            {
                MessageDxUtil.ShowWarning("��ѡ��������");
                return;
            }

            string teamId = this.wtTree.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
            {
                MessageDxUtil.ShowWarning("��ѡ�����");
                return;
            }

            FrmSetDailyLabor frm = new FrmSetDailyLabor(this.dpAttendance.DateTime, teamId);
            frm.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            frm.ShowDialog();

            LoadWorkTeamWorkload();
            LoadLaborWorkload();
        }

        /// <summary>
        /// �༭������ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuProduction_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkload.gridView1.GetFocusedRowCellDisplayText("Id");
            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditProductionWorkload dlg = new FrmEditProductionWorkload();
                dlg.ID = ID;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeamWorkload();
                    LoadLaborWorkload();
                }
            }
        }

        /// <summary>
        /// �༭������ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuChange_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkload.gridView1.GetFocusedRowCellDisplayText("Id");
            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditChangeWorkload dlg = new FrmEditChangeWorkload();
                dlg.ID = ID;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeamWorkload();
                    LoadLaborWorkload();
                }
            }
        }

        /// <summary>
        /// �༭���޹�ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuRepair_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkload.gridView1.GetFocusedRowCellDisplayText("Id");
            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditRepairWorkload dlg = new FrmEditRepairWorkload();
                dlg.ID = ID;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeamWorkload();
                    LoadLaborWorkload();
                }
            }
        }

        /// <summary>
        /// �༭���޹�ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuElectric_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkload.gridView1.GetFocusedRowCellDisplayText("Id");
            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditElectricWorkload dlg = new FrmEditElectricWorkload();
                dlg.ID = ID;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadWorkTeamWorkload();
                    LoadLaborWorkload();
                }
            }
        }
        #endregion //Event

        #region Grid
        void wgvWorkload_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");//yyyy-MM-dd
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
            //else if (columnName == "Age")
            //{
            //    e.DisplayText = string.Format("{0}��", e.Value);
            //}
        }

        void wgvLabor_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");//yyyy-MM-dd
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
            else if (columnName == "ActualWorkTeamId")
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
        }
        #endregion //Grid

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
            //if (this.winGridViewPager1.gridView1.Columns.Count > 0 && this.winGridViewPager1.gridView1.RowCount > 0)
            //{
            //    //ͳһ����100���
            //    foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridViewPager1.gridView1.Columns)
            //    {
            //        column.Width = 100;
            //    }

            //    //�����������ر�Ŀ��
            //    //SetGridColumWidth("Note", 200);
            //}
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

            //int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            //foreach (int iRow in rowSelected)
            //{
            //    string ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "ID");
            //    CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Delete(ID);
            //}	 

            //BindData();
        }

        /// <summary>
        /// ��ҳ�ؼ��༭�����
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            //string ID = this.winGridViewPager1.gridView1.GetFocusedRowCellDisplayText("ID");
            //List<string> IDList = new List<string>();
            //for (int i = 0; i < this.winGridViewPager1.gridView1.RowCount; i++)
            //{
            //    string strTemp = this.winGridViewPager1.GridView1.GetRowCellDisplayText(i, "ID");
            //    IDList.Add(strTemp);
            //}

            //if (!string.IsNullOrEmpty(ID))
            //{
            //    FrmEditWorkTeamDailyWorkload dlg = new FrmEditWorkTeamDailyWorkload();
            //    dlg.ID = ID;
            //    dlg.IDList = IDList;
            //    dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            //    dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

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
        /// ��ҳ�ؼ�ȫ����������ǰ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            //string where = GetConditionSql();
            //this.winGridViewPager1.AllToExport = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindToDataTable(where);
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
        #endregion //System
    }
}

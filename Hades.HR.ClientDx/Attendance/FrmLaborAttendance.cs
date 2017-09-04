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
        #region Field
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;
        #endregion //Field

        #region Constructor
        public FrmLaborAttendance()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvRecord.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.wgvRecord.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvRecord.ShowLineNumber = true;
            this.wgvRecord.BestFitColumnWith = true;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
            this.wgvRecord.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.wgvRecord.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);
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
        /// �����������
        /// </summary>
        private void LoadSummaryData()
        {
            if (this.dpMonth.EditValue == null)
                return;

            var teamId = this.treeLine.GetSelectedTeamId();
            if (!string.IsNullOrEmpty(teamId))
            {
                var dt = GetSummaryAttendance(this.dpMonth.DateTime.Date, teamId);

                this.dgcSummary.DataSource = dt;
                this.dgvSummary.PopulateColumns();

                int days = DateTime.DaysInMonth(this.dpMonth.DateTime.Date.Year, this.dpMonth.DateTime.Date.Month);
                for (int i = 1; i <= days; i++)
                {
                    var col = this.dgvSummary.Columns[i.ToString()];
                    col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, i.ToString(), "{0:0.##}")});
                }
            }
            //var node = this.tvLine.SelectedNode;
            //if (node != null && Convert.ToInt32(node.Tag) == 3)
            //{
            //    var dt = GetSummaryAttendance(this.dpMonth.DateTime.Date, node.Name);

            //    this.dgcSummary.DataSource = dt;
            //    this.dgvSummary.PopulateColumns();

            //    int days = DateTime.DaysInMonth(this.dpMonth.DateTime.Date.Year, this.dpMonth.DateTime.Date.Month);
            //    for (int i = 1; i <= days; i++)
            //    {
            //        var col = this.dgvSummary.Columns[i.ToString()];
            //        col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, i.ToString(), "{0:0.##}")});
            //    }
            //}
        }

        /// <summary>
        /// ���б�����
        /// </summary>
        private void LoadRecordData()
        {
            //entity
            this.wgvRecord.DisplayColumns = "WorkTeamName,WorkSectionName,Number,Name,AttendanceDate,Workload,AbsentType,IsWeekend,IsHoliday,Remark";
            this.wgvRecord.ColumnNameAlias = CallerFactory<ILaborAttendanceRecordViewService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            string where = GetConditionSql();
            PagerInfo pagerInfo = this.wgvRecord.PagerInfo;
            List<LaborAttendanceRecordViewInfo> list = CallerFactory<ILaborAttendanceRecordViewService>.Instance.FindWithPager(where, ref pagerInfo);
            this.wgvRecord.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvRecord.DataSource = new Hades.Pager.WinControl.SortableBindingList<LaborAttendanceRecordViewInfo>(list);
            this.wgvRecord.PrintTitle = "���ڼ�¼����";

            this.wgvRecord.GridView1.OptionsView.ShowFooter = true;
            var col = this.wgvRecord.GridView1.Columns["Workload"];
            col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Workload", "�ϼ�={0:0.##}")});
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
                if (this.dpAttendance.EditValue == null)
                    return "1 = 2";
                condition.AddCondition("AttendanceDate", this.dpAttendance.DateTime.Date, SqlOperator.Equal);

                int type = this.treeLine.GetSelectType();

                if (type == 3)
                {
                    var teamId = this.treeLine.GetSelectedTeamId();
                    condition.AddCondition("WorkTeamId", teamId, SqlOperator.Equal);
                }
                else
                    return "1 = 2";
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// ���뿼�ڻ���
        /// </summary>
        /// <param name="month"></param>
        /// <param name="workTeamId"></param>
        /// <returns></returns>
        private DataTable GetSummaryAttendance(DateTime month, string workTeamId)
        {
            DateTime d1 = new DateTime(month.Year, month.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);

            string sql = string.Format("WorkTeamId = '{0}' AND AttendanceDate between '{1}' AND '{2}'", workTeamId, d1, d2);
            var records = CallerFactory<ILaborAttendanceRecordViewService>.Instance.Find(sql);

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn { ColumnName = "number", Caption = "����" });
            dt.Columns.Add(new DataColumn { ColumnName = "name", Caption = "����" });

            int days = DateTime.DaysInMonth(month.Year, month.Month);
            for (int i = 1; i <= days; i++)
            {
                dt.Columns.Add(new DataColumn { ColumnName = i.ToString() });
            }

            dt.Columns.Add(new DataColumn { ColumnName = "sum", Caption = "�ϼ�" });
            dt.Columns.Add(new DataColumn { ColumnName = "weekendsum", Caption = "��ĩ�ϼ�" });
            dt.Columns.Add(new DataColumn { ColumnName = "normalsum", Caption = "ƽʱ�ϼ�" });
            dt.Columns.Add(new DataColumn { ColumnName = "holidaysum", Caption = "�ڼ��պϼ�" });
            dt.Columns.Add(new DataColumn { ColumnName = "attendanceDays", Caption = "��������" });
            dt.Columns.Add(new DataColumn { ColumnName = "annualDays", Caption = "�������" });
            dt.Columns.Add(new DataColumn { ColumnName = "sickDays", Caption = "��������" });
            dt.Columns.Add(new DataColumn { ColumnName = "casualDays", Caption = "�¼�����" });
            dt.Columns.Add(new DataColumn { ColumnName = "absentDays", Caption = "��������" });
            dt.Columns.Add(new DataColumn { ColumnName = "injuryDays", Caption = "��������" });
            dt.Columns.Add(new DataColumn { ColumnName = "realDays", Caption = "ʵ������" });

            var staffs = records.Select(r => r.StaffId).Distinct();
            foreach (var staffId in staffs)
            {
                DataRow row = dt.NewRow();

                var staff = records.First(r => r.StaffId == staffId);
                row["number"] = staff.Number;
                row["name"] = staff.Name;

                for (int i = 1; i <= days; i++)
                {
                    var find = records.SingleOrDefault(r => r.StaffId == staffId && r.AttendanceDate == new DateTime(month.Year, month.Month, i));
                    if (find == null)
                    {
                        row[i.ToString()] = "";
                    }
                    else
                    {
                        if (find.AbsentType == (int)AbsentType.None)
                            row[i.ToString()] = find.Workload;
                        else
                            row[i.ToString()] = ((AbsentType)find.AbsentType).DisplayName();
                    }
                }

                row["sum"] = records.Where(r => r.StaffId == staffId).Sum(r => r.Workload);
                row["weekendsum"] = records.Where(r => r.StaffId == staffId && r.IsWeekend == true).Sum(r => r.Workload);
                row["normalsum"] = records.Where(r => r.StaffId == staffId && r.IsWeekend == false && r.IsHoliday == false).Sum(r => r.Workload);
                row["holidaysum"] = records.Where(r => r.StaffId == staffId && r.IsHoliday == true).Sum(r => r.Workload);

                row["attendanceDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.None && r.IsWeekend == false && r.IsHoliday == false).Count(); ;
                row["annualDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.AnnualLeave).Count();
                row["sickDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.SickLeave).Count();
                row["casualDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.CasualLeave).Count();
                row["absentDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.AbsentLeave).Count();
                row["injuryDays"] = records.Where(r => r.StaffId == staffId && r.AbsentType == (int)AbsentType.InjuryLeave).Count();
                row["realDays"] = Convert.ToInt32(row["attendanceDays"]) - Convert.ToInt32(row["annualDays"]);

                dt.Rows.Add(row);
            }

            return dt;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            this.treeLine.Init();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeLine_TeamSeleted(object sender, EventArgs e)
        {
            var teamId =  this.treeLine.GetSelectedTeamId();

            var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(teamId);
            this.txtWorkTeamName.Text = workTeam.Name;
            this.txtWorkTeamName2.Text = workTeam.Name;

            LoadRecordData();
            LoadSummaryData();
        }

        /// <summary>
        /// �����¶�ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpMonth_EditValueChanged(object sender, EventArgs e)
        {
            LoadSummaryData();
        }

        /// <summary>
        /// ��������ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpAttendance_EditValueChanged(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// �༭���ڼ�¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            var teamId = this.treeLine.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
            {
                MessageDxUtil.ShowWarning("��ѡ�����");
                return;
            }
            if (this.dpAttendance.EditValue == null)
            {
                MessageDxUtil.ShowWarning("��ѡ��������");
                return;
            }

            var date = this.dpAttendance.DateTime.Date;

            FrmEditLaborAttendanceRecord dlg = new FrmEditLaborAttendanceRecord(date, teamId);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadRecordData();
            }
        }

        /// <summary>
        /// ��ҳ�ؼ�ˢ�²���
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// ��ҳ�ؼ���ҳ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            LoadRecordData();
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
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");//yyyy-MM-dd
                    }
                }
            }
            else if (columnName == "AbsentType")
            {
                e.DisplayText = ((AbsentType)e.Value).DisplayName();
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
        #endregion //Event        

    }
}

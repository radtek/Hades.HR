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
using Hades.HR.Util;

namespace Hades.HR.UI
{
    /// <summary>
    /// �Ƽ������տ��ڼ�¼
    /// </summary>
    public partial class FrmEditLaborAttendanceRecord : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private LaborAttendanceRecordInfo tempInfo = new LaborAttendanceRecordInfo();

        /// <summary>
        /// ��������
        /// </summary>
        private string workTeamId;

        /// <summary>
        /// ��������
        /// </summary>
        private DateTime attendanceDate;

        /// <summary>
        /// ���湤��
        /// </summary>
        private List<WorkSectionInfo> workSections;

        /// <summary>
        /// ���ְԱ
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditLaborAttendanceRecord(DateTime attendanceDate, string workTeamId)
        {
            InitializeComponent();

            this.attendanceDate = attendanceDate;
            this.workTeamId = workTeamId;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// ��ʼ�������ֵ�
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������

            this.repoCmbAbsentType.Items.AddEnum(typeof(AbsentType), true);
        }

        /// <summary>
        /// ��ʼ�����ڼ�¼
        /// </summary>
        /// <returns></returns>
        private List<LaborAttendanceRecordInfo> InitRecords()
        {
            var sectionLabors = CallerFactory<IWorkSectionLaborService>.Instance.Find2(string.Format("WorkTeamId = '{0}' AND Year = {1} AND Month = {2}", this.workTeamId, this.attendanceDate.Year, this.attendanceDate.Month), "ORDER BY SortCode");

            var records = CallerFactory<ILaborAttendanceRecordService>.Instance.Find(string.Format("AttendanceDate='{0}'", attendanceDate));
            
            List<LaborAttendanceRecordInfo> data = new List<LaborAttendanceRecordInfo>();
            foreach (var item in sectionLabors)
            {
                LaborAttendanceRecordInfo info = new LaborAttendanceRecordInfo();
                info.AttendanceDate = this.attendanceDate;
                info.WorkTeamId = workTeamId;
                info.WorkSectionId = item.WorkSectionId;
                info.StaffId = item.StaffId;
                info.StandardWorkload = 0;

                var record = records.SingleOrDefault(r => r.StaffId == item.StaffId & r.WorkTeamId == workTeamId);
                if (record != null)
                {
                    info.StandardWorkload = record.StandardWorkload;
                    info.Workload = record.Workload;
                    info.AbsentType = record.AbsentType;
                    info.Remark = record.Remark;
                }

                data.Add(info);
            }

            return data;
        }

        /// <summary>
        /// �����¼
        /// </summary>
        private string SaveRecords()
        {
            var records = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            foreach (var item in records)
            {
                item.IsWeekend = this.chkIsWeekend.Checked;
                item.IsHoliday = this.chkIsHoliday.Checked;
            }

            var result = CallerFactory<ILaborAttendanceRecordService>.Instance.InsertRecords(records);
            return result;
        }

        /// <summary>
        /// ѡ��Ա��
        /// </summary>
        private void SelectStaff()
        {
            var selected = this.dgvAttendance.GetSelectedRows();
            if (selected.Length == 0)
                return;

            var dsIndex = this.dgvAttendance.GetDataSourceRowIndex(selected[0]);
            var labor = this.bsAttendanceRecord[dsIndex] as LaborAttendanceRecordInfo;

            FrmStaffSearch frm = new FrmStaffSearch(StaffType.Labor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (this.staffs.All(r => r.Id != frm.SelectedStaff.Id))
                {
                    this.staffs.Add(frm.SelectedStaff);
                }

                labor.StaffId = frm.SelectedStaff.Id;

                //var salaryBase = CallerFactory<IStaffSalaryBaseService>.Instance.FindByID(frm.SelectedStaff.Id);
                //if (salaryBase != null)
                //    labor.StaffLevelId = salaryBase.StaffLevelId;

                this.dgvAttendance.UpdateCurrentRow();
            }
        }

        private void AddStaff()
        {
            LaborAttendanceRecordInfo info = new LaborAttendanceRecordInfo();
            info.WorkTeamId = this.workTeamId;
            info.WorkSectionId = "";
            info.AttendanceDate = this.attendanceDate;

            this.dgvAttendance.BeginDataUpdate();

            var data = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            data.Add(info);

            this.dgvAttendance.EndDataUpdate();
        }
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            InitDictItem();

            var team = CallerFactory<IWorkTeamService>.Instance.FindByID(this.workTeamId);
            this.txtWorkTeamName.Text = team.Name;

            this.workSections = CallerFactory<IWorkSectionService>.Instance.Find(string.Format("WorkTeamId = '{0}'", workTeamId));

            this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 2 AND Enabled = 1 AND Deleted = 0");
            
            var records = InitRecords();
            this.bsAttendanceRecord.DataSource = records;

            this.txtAttendanceDate.Text = this.attendanceDate.ToDateString();
            if (records.Count > 0)
            {
                var item = records.First();
                this.chkIsWeekend.Checked = item.IsWeekend;
                this.chkIsHoliday.Checked = item.IsHoliday;
            }
        }

        public override void ClearScreen()
        {
            this.tempInfo = new LaborAttendanceRecordInfo();
            base.ClearScreen();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!(ActiveControl is Button))
            {
                if (keyData == Keys.Down || keyData == Keys.Enter)
                {
                    return false;
                }
                else if (keyData == Keys.Up)
                {
                    return false;
                }

                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ���òο�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetStandard_Click(object sender, EventArgs e)
        {
            var records = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            this.dgvAttendance.BeginDataUpdate();

            foreach (var item in records)
            {
                item.StandardWorkload = this.spStandard.Value;
            }

            this.dgvAttendance.EndDataUpdate();
        }

        /// <summary>
        /// ʹ�òο�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUseStandard_Click(object sender, EventArgs e)
        {
            var records = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            this.dgvAttendance.BeginDataUpdate();

            foreach(var item in records)
            {
                item.Workload = item.StandardWorkload;
            }

            this.dgvAttendance.EndDataUpdate();
        }

        /// <summary>
        /// ��ʽ����ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendance_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "StaffId")
            {
                if (e.Value != null)
                {
                    var s = this.staffs.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Name;
                }
            }
            else if (columnName == "WorkSectionId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var s = this.workSections.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Name;
                }
            }
        }

        /// <summary>
        /// ��������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendance_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsAttendanceRecord.Count)
                return;

            var record = this.bsAttendanceRecord[rowIndex] as LaborAttendanceRecordInfo;

            if (e.Column.FieldName == "StaffNumber" && e.IsGetData)
            {
                var s = this.staffs.SingleOrDefault(r => r.Id == record.StaffId);
                if (s == null)
                    e.Value = "";
                else
                    e.Value = s.Number;
            }
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                this.dgvAttendance.CloseEditor();

                string result = SaveRecords();
                if (string.IsNullOrEmpty(result))
                {
                    this.DialogResult = DialogResult.OK;

                    return true;
                }
                else
                {
                    MessageDxUtil.ShowWarning(result);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowWarning(ex.Message);
                return false;
            }
        }
       
        /// <summary>
        /// ѡ��Ա��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repoActionButton_Click(object sender, EventArgs e)
        {
            SelectStaff();
        }
        
        /// <summary>
        /// ����Ա��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddStaff();
        }

        /// <summary>
        /// ɾ��Ա��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dgvAttendance.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsAttendanceRecord.Count)
                return;

            var data = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            var info = data[rowIndex];
            if (string.IsNullOrEmpty(info.WorkSectionId))
            {
                data.RemoveAt(rowIndex);
            }
            else
            {
                info.StaffId = "";
                info.StandardWorkload = 0;
                info.Workload = 0;
            }

            this.bsAttendanceRecord.ResetBindings(false);
            return;
        }
        #endregion //Event
    }
}

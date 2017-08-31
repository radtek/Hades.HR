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
            var data = CallerFactory<ILaborAttendanceRecordService>.Instance.Find(string.Format("AttendanceDate='{0}'", attendanceDate));
            this.staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("StaffType=2 AND WorkTeamId='{0}' AND Enabled=1 AND Deleted=0", workTeamId));

            List<LaborAttendanceRecordInfo> records = new List<LaborAttendanceRecordInfo>();
            foreach (var item in staffs)
            {
                var find = data.SingleOrDefault(r => r.StaffId == item.Id);
                if (find != null)
                {
                    records.Add(find);
                }
                else
                {
                    LaborAttendanceRecordInfo info = new LaborAttendanceRecordInfo();
                    info.Id = Guid.NewGuid().ToString();
                    info.AttendanceDate = this.attendanceDate;
                    info.StaffId = item.Id;

                    records.Add(info);
                }
            }

            return records;
        }

        /// <summary>
        /// �����¼
        /// </summary>
        private string SaveRecords()
        {
            //CallerFactory<ILaborAttendanceRecordService>.Instance.DeleteByCondition(string.Format("AttendanceDate='{0}' AND WorkTeamId='{1}'", attendanceDate, workTeamId));

            var records = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            foreach (var item in records)
            {
                item.AttendanceDate = this.attendanceDate;
                item.WorkTeamId = this.workTeamId;
                item.IsWeekend = this.chkIsWeekend.Checked;
                item.IsHoliday = this.chkIsHoliday.Checked;

                //CallerFactory<ILaborAttendanceRecordService>.Instance.Insert(item);
            }

            var result = CallerFactory<ILaborAttendanceRecordService>.Instance.InsertRecords(records);
            return result;
        }
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            InitDictItem();

            var team = CallerFactory<IWorkTeamService>.Instance.FindByID(this.workTeamId);
            this.txtWorkTeamName.Text = team.Name;

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
        /// ��ʽ����ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendance_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "StaffId")
            {
                var s = this.staffs.SingleOrDefault(r => r.Id == e.Value.ToString());
                if (s == null)
                    e.DisplayText = "";
                else
                    e.DisplayText = s.Name;
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
                e.Value = s.Number;
            }
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

            this.bsAttendanceRecord.RemoveAt(rowIndex);
            this.bsAttendanceRecord.ResetBindings(false);
            return;
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
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
        #endregion //Event
    }
}

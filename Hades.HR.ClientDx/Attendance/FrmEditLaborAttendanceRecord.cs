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

        private string workTeamId;

        private DateTime attendanceDate;

        /// <summary>
        /// ���ְԱ
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditLaborAttendanceRecord()
        {
            InitializeComponent();

            this.workTeamId = "3aafbe8c-98db-41db-bccc-0171ff20e89a";
            this.attendanceDate = DateTime.Now;
        }

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
            this.staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("WorkTeamId='{0}'", workTeamId));

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
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborAttendanceRecordInfo info)
        {
            //info.StaffId = txtStaffId.Text;
            //      info.AttendanceDate = txtAttendanceDate.DateTime;
            //      info.Workload = txtWorkload.Value;
            //          info.AbsentType = Convert.ToInt32(txtAbsentType.Value);
        }
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            InitDictItem();
            var records = InitRecords();
            this.bsAttendanceRecord.DataSource = records;
        }

        public override void ClearScreen()
        {
            this.tempInfo = new LaborAttendanceRecordInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            #region MyRegion
            //if (this.txtStaffId.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("������");
            //    this.txtStaffId.Focus();
            //    result = false;
            //}
            // else if (this.txtAttendanceDate.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("������");
            //    this.txtAttendanceDate.Focus();
            //    result = false;
            //}
            // else if (this.txtWorkload.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("������");
            //    this.txtWorkload.Focus();
            //    result = false;
            //}
            // else if (this.txtAbsentType.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("������");
            //    this.txtAbsentType.Focus();
            //    result = false;
            //}
            #endregion

            return result;
        }

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�

            if (!string.IsNullOrEmpty(ID))
            {
                #region ��ʾ��Ϣ
                LaborAttendanceRecordInfo info = CallerFactory<ILaborAttendanceRecordService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    //txtStaffId.Text = info.StaffId;
                    //          txtAttendanceDate.SetDateTime(info.AttendanceDate);	
                    //      txtWorkload.Value = info.Workload;
                    //          txtAbsentType.Value = info.AbsentType;
                }
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborAttendanceRecord/Edit");             
            }
            else
            {

                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborAttendanceRecord/Add");  
            }

            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        /// <summary>
        /// �����¼
        /// </summary>
        private void SaveRecords()
        {
            var records = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            foreach (var item in records)
            {
                //item.LeaveDays = item.AnnualLeave + item.SickLeave + item.CasualLeave + item.InjuryLeave + item.MarriageLeave + item.AbsentLeave;
                //item.OvertimeSalarySum = item.NormalOvertimeSalary + item.WeekendOvertimeSalary + item.HolidayOvertimeSalary;
                CallerFactory<ILaborAttendanceRecordService>.Instance.InsertUpdate(item, item.Id);
            }
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveRecords();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowWarning(ex.Message);
            }
        }
        #endregion //Event
    }
}

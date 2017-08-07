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
        }

        public FrmEditLaborAttendanceRecord(DateTime attendanceDate, string workTeamId)
        {
            InitializeComponent();

            this.workTeamId = workTeamId;
        }
        #endregion //Constructor

        #region Function
        private List<LaborAttendanceRecordInfo> InitRecords()
        {
            //List<LaborAttendanceRecordInfo> data = new List<LaborAttendanceRecordInfo>();

            var data = CallerFactory<ILaborAttendanceRecordService>.Instance.Find(string.Format("AttendanceDate='{0}'", attendanceDate));
            this.staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("WorkTeamId='{0}'", workTeamId));

            
            return data;
        }
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            var records = InitRecords();
            this.bsAttendanceRecord.DataSource = records;

            
        }
        #endregion //Method

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
        /// ��ʼ�������ֵ�
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������
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

        //private void SetAttachInfo(LaborAttendanceRecordInfo info)
        //{
        //    this.attachmentGUID.AttachmentGUID = info.AttachGUID;
        //    this.attachmentGUID.userId = LoginUserInfo.Name;

        //    string name = txtName.Text;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        string dir = string.Format("{0}", name);
        //        this.attachmentGUID.Init(dir, tempInfo.ID, LoginUserInfo.Name);
        //    }
        //}

        public override void ClearScreen()
        {
            this.tempInfo = new LaborAttendanceRecordInfo();
            base.ClearScreen();
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

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborAttendanceRecordInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<ILaborAttendanceRecordService>.Instance.Insert(info);
                if (succeed)
                {
                    //�����������������

                    return true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// �༭״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {

            LaborAttendanceRecordInfo info = CallerFactory<ILaborAttendanceRecordService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<ILaborAttendanceRecordService>.Instance.Update(info, info.Id);
                    if (succeed)
                    {
                        //�����������������

                        return true;
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
            return false;
        }
    }
}

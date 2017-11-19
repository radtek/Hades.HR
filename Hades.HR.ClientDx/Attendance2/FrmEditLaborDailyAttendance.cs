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
    public partial class FrmEditLaborDailyAttendance : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private LaborDailyAttendanceInfo tempInfo = new LaborDailyAttendanceInfo();

        /// <summary>
        /// ��������
        /// </summary>
        private DateTime attendanceDate;

        /// <summary>
        /// ��ǰ��������
        /// </summary>
        private string currentWorkTeamId;
        #endregion //Field

        #region Constructor
        public FrmEditLaborDailyAttendance()
        {
            InitializeComponent();
        }

        public FrmEditLaborDailyAttendance(DateTime attendanceDate, string workTeamId)
        {
            this.attendanceDate = attendanceDate;
            this.currentWorkTeamId = workTeamId;

            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// ��ʼ�������ֵ�
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������
        }

        /// <summary>
        /// �������Ĭ��Ա��
        /// </summary>
        private void LoadDefaultStaff()
        {
            var staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("WorkTeamId='{0}' AND Delete=0", this.currentWorkTeamId);


        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborDailyAttendanceInfo info)
        {
            //info.WorkTeamId = txtWorkTeamId.Text;
            //info.AttendanceDate = txtAttendanceDate.Text;
            //info.StaffId = txtStaffId.Text;
            //info.StaffLevelId = txtStaffLevelId.Text;
            //info.AbsentType = Convert.ToInt32(txtAbsentType.Value);
            //info.TotalHours = txtTotalHours.Value;
            //info.IsWeekend = txtIsWeekend.Text.ToBoolean();
            //info.IsHoliday = txtIsHoliday.Text.ToBoolean();
            //info.Remark = txtRemark.Text;
        }
        #endregion //Function

        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new LaborDailyAttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�

            WorkTeamInfo workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(this.currentWorkTeamId);
            

            if (!string.IsNullOrEmpty(ID))
            {
                #region ��ʾ��Ϣ
                LaborDailyAttendanceInfo info = CallerFactory<ILaborDailyAttendanceService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    //txtWorkTeamId.Text = info.WorkTeamId;
                    //txtAttendanceDate.Text = info.AttendanceDate;
                    //txtStaffId.Text = info.StaffId;
                    //txtStaffLevelId.Text = info.StaffLevelId;
                    //txtAbsentType.Value = info.AbsentType;
                    //txtTotalHours.Value = info.TotalHours;
                    //txtIsWeekend.Text = info.IsWeekend.ToString();
                    //txtIsHoliday.Text = info.IsHoliday.ToString();
                    //txtRemark.Text = info.Remark;
                }
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborDailyAttendance/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborDailyAttendance/Add");  
            }
        }

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            //if (this.txtAttendanceDate.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("������");
            //    this.txtAttendanceDate.Focus();
            //    result = false;
            //}
            //else if (this.txtStaffId.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("������");
            //    this.txtStaffId.Focus();
            //    result = false;
            //}

            return result;
        }
        #endregion //Method

        

         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborDailyAttendanceInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<ILaborDailyAttendanceService>.Instance.Insert(info);
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

            LaborDailyAttendanceInfo info = CallerFactory<ILaborDailyAttendanceService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<ILaborDailyAttendanceService>.Instance.Update(info, info.Id);
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

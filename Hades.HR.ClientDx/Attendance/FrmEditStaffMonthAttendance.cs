using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

using WHC.Framework.ControlUtil.Facade;
using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmEditStaffMonthAttendance : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private StaffMonthAttendanceInfo tempInfo = new StaffMonthAttendanceInfo();
    	
        public FrmEditStaffMonthAttendance()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            #region MyRegion
            if (this.txtStaffId.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtStaffId.Focus();
                result = false;
            }
             else if (this.txtDepartmentId.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtDepartmentId.Focus();
                result = false;
            }
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
                StaffMonthAttendanceInfo info = CallerFactory<IStaffMonthAttendanceService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
	                    txtStaffId.Text = info.StaffId;
           	                    txtDepartmentId.Text = info.DepartmentId;
                                   txtAttendanceDays.Value = info.AttendanceDays;
                               txtAnnualLeave.Value = info.AnnualLeave;
                               txtSickLeave.Value = info.SickLeave;
                               txtCasualLeave.Value = info.CasualLeave;
                               txtInjuryLeave.Value = info.InjuryLeave;
                               txtMarriageLeave.Value = info.MarriageLeave;
                               txtMaternityLeave.Value = info.MaternityLeave;
                               txtFuneralLeave.Value = info.FuneralLeave;
                               txtAbsentLeave.Value = info.AbsentLeave;
                               txtNormalOvertime.Value = info.NormalOvertime;
                               txtWeekendOvertime.Value = info.WeekendOvertime;
                               txtHolidayOvertime.Value = info.HolidayOvertime;
                               txtNoonShift.Value = info.NoonShift;
                               txtNightShift.Value = info.NightShift;
                               txtOtherNoon.Value = info.OtherNoon;
                               txtOtherNight.Value = info.OtherNight;
       	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("StaffMonthAttendance/Edit");             
            }
            else
            {
                   
                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffMonthAttendance/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(StaffMonthAttendanceInfo info)
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
            this.tempInfo = new StaffMonthAttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffMonthAttendanceInfo info)
        {
	            info.StaffId = txtStaffId.Text;
       	            info.DepartmentId = txtDepartmentId.Text;
                       info.AttendanceDays = Convert.ToInt32(txtAttendanceDays.Value);
                       info.AnnualLeave = Convert.ToInt32(txtAnnualLeave.Value);
                       info.SickLeave = Convert.ToInt32(txtSickLeave.Value);
                       info.CasualLeave = Convert.ToInt32(txtCasualLeave.Value);
                       info.InjuryLeave = Convert.ToInt32(txtInjuryLeave.Value);
                       info.MarriageLeave = Convert.ToInt32(txtMarriageLeave.Value);
                       info.MaternityLeave = Convert.ToInt32(txtMaternityLeave.Value);
                       info.FuneralLeave = Convert.ToInt32(txtFuneralLeave.Value);
                       info.AbsentLeave = Convert.ToInt32(txtAbsentLeave.Value);
                       info.NormalOvertime = txtNormalOvertime.Value;
                       info.WeekendOvertime = txtWeekendOvertime.Value;
                       info.HolidayOvertime = txtHolidayOvertime.Value;
                       info.NoonShift = Convert.ToInt32(txtNoonShift.Value);
                       info.NightShift = Convert.ToInt32(txtNightShift.Value);
                       info.OtherNoon = Convert.ToInt32(txtOtherNoon.Value);
                       info.OtherNight = Convert.ToInt32(txtOtherNight.Value);
       	            info.Remark = txtRemark.Text;
               }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            StaffMonthAttendanceInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<IStaffMonthAttendanceService>.Instance.Insert(info);
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

            StaffMonthAttendanceInfo info = CallerFactory<IStaffMonthAttendanceService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IStaffMonthAttendanceService>.Instance.Update(info, info.ID);
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

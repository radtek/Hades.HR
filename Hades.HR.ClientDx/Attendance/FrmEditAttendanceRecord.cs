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
    public partial class FrmEditAttendanceRecord : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private AttendanceRecordInfo tempInfo = new AttendanceRecordInfo();
    	
        public FrmEditAttendanceRecord()
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
            if (this.txtAttendanceDays.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtAttendanceDays.Focus();
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
                AttendanceRecordInfo info = CallerFactory<IAttendanceRecordService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
	                    txtAttendanceId.Text = info.AttendanceId;
           	                    txtStaffId.Text = info.StaffId;
                                   txtAttendanceDays.Value = info.AttendanceDays;
                               txtAnnualLeave.Value = info.AnnualLeave;
                               txtSickLeave.Value = info.SickLeave;
                               txtCasualLeave.Value = info.CasualLeave;
                               txtInjuryLeave.Value = info.InjuryLeave;
                               txtMarriageLeave.Value = info.MarriageLeave;
                               txtLeaveDays.Value = info.LeaveDays;
                               txtNormalOvertime.Value = info.NormalOvertime;
                               txtNormalOvertimeSalary.Value = info.NormalOvertimeSalary;
                               txtWeekendOvertime.Value = info.WeekendOvertime;
                               txtWeekendOvertimeSalary.Value = info.WeekendOvertimeSalary;
                               txtHolidayOvertime.Value = info.HolidayOvertime;
                               txtHolidayOvertimeSalary.Value = info.HolidayOvertimeSalary;
                               txtOvertimeSalarySum.Value = info.OvertimeSalarySum;
                               txtNoonShift.Value = info.NoonShift;
                               txtNightShift.Value = info.NightShift;
                               txtOtherShift.Value = info.OtherShift;
                               txtLunchAllowance.Value = info.LunchAllowance;
                               txtLeaderAllowance.Value = info.LeaderAllowance;
                               txtDeduction.Value = info.Deduction;
                               txtNutrition.Value = info.Nutrition;
       	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("AttendanceRecord/Edit");             
            }
            else
            {
                        
                //this.btnOK.Enabled = Portal.gc.HasFunction("AttendanceRecord/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(AttendanceRecordInfo info)
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
            this.tempInfo = new AttendanceRecordInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(AttendanceRecordInfo info)
        {
	            info.AttendanceId = txtAttendanceId.Text;
       	            info.StaffId = txtStaffId.Text;
                       info.AttendanceDays = Convert.ToInt32(txtAttendanceDays.Value);
                       info.AnnualLeave = Convert.ToInt32(txtAnnualLeave.Value);
                       info.SickLeave = Convert.ToInt32(txtSickLeave.Value);
                       info.CasualLeave = Convert.ToInt32(txtCasualLeave.Value);
                       info.InjuryLeave = Convert.ToInt32(txtInjuryLeave.Value);
                       info.MarriageLeave = Convert.ToInt32(txtMarriageLeave.Value);
                       info.LeaveDays = Convert.ToInt32(txtLeaveDays.Value);
                       info.NormalOvertime = Convert.ToInt32(txtNormalOvertime.Value);
                       info.NormalOvertimeSalary = txtNormalOvertimeSalary.Value;
                       info.WeekendOvertime = Convert.ToInt32(txtWeekendOvertime.Value);
                       info.WeekendOvertimeSalary = txtWeekendOvertimeSalary.Value;
                       info.HolidayOvertime = Convert.ToInt32(txtHolidayOvertime.Value);
                       info.HolidayOvertimeSalary = txtHolidayOvertimeSalary.Value;
                       info.OvertimeSalarySum = txtOvertimeSalarySum.Value;
                       info.NoonShift = Convert.ToInt32(txtNoonShift.Value);
                       info.NightShift = Convert.ToInt32(txtNightShift.Value);
                       info.OtherShift = Convert.ToInt32(txtOtherShift.Value);
                       info.LunchAllowance = txtLunchAllowance.Value;
                       info.LeaderAllowance = txtLeaderAllowance.Value;
                       info.Deduction = txtDeduction.Value;
                       info.Nutrition = txtNutrition.Value;
       	            info.Remark = txtRemark.Text;
               }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            AttendanceRecordInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<IAttendanceRecordService>.Instance.Insert(info);
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

            AttendanceRecordInfo info = CallerFactory<IAttendanceRecordService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IAttendanceRecordService>.Instance.Update(info, info.Id);
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

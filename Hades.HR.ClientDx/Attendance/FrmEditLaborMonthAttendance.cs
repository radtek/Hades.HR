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
    public partial class FrmEditLaborMonthAttendance : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private LaborMonthAttendanceInfo tempInfo = new LaborMonthAttendanceInfo();
    	
        public FrmEditLaborMonthAttendance()
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
             else if (this.txtAttendanceDays.Text.Trim().Length == 0)
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
                LaborMonthAttendanceInfo info = CallerFactory<ILaborMonthAttendanceService>.Instance.FindByID(ID);
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
                               txtAbsentLeave.Value = info.AbsentLeave;
       	                    txtPositionLevel.Text = info.PositionLevel;
                                   txtLevelSalary.Value = info.LevelSalary;
                               txtMonthWorkload.Value = info.MonthWorkload;
                               txtBaseWorkload.Value = info.BaseWorkload;
                               txtWeekendWorkload.Value = info.WeekendWorkload;
                               txtHolidayWorkload.Value = info.HolidayWorkload;
                               txtEstimation.Value = info.Estimation;
                               txtAllowance.Value = info.Allowance;
                               txtWorkshopDeduction.Value = info.WorkshopDeduction;
                               txtWorkshopBonus.Value = info.WorkshopBonus;
                               txtBonusDeduction.Value = info.BonusDeduction;
                               txtNoonShift.Value = info.NoonShift;
                               txtNightShift.Value = info.NightShift;
                               txtOtherNoon.Value = info.OtherNoon;
                               txtOtherNight.Value = info.OtherNight;
                               txtShiftAmount.Value = info.ShiftAmount;
                               txtQualityBonus.Value = info.QualityBonus;
                               txtDeduction.Value = info.Deduction;
                               txtNutrition.Value = info.Nutrition;
                               txtEquipmentBonus.Value = info.EquipmentBonus;
                               txtSafetyBonus.Value = info.SafetyBonus;
                               txtFiveSBonus.Value = info.FiveSBonus;
                               txtHotBonus.Value = info.HotBonus;
                               txtLunchAllowance.Value = info.LunchAllowance;
       	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborMonthAttendance/Edit");             
            }
            else
            {
                                  
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborMonthAttendance/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(LaborMonthAttendanceInfo info)
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
            this.tempInfo = new LaborMonthAttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborMonthAttendanceInfo info)
        {
	            info.AttendanceId = txtAttendanceId.Text;
       	            info.StaffId = txtStaffId.Text;
                       info.AttendanceDays = Convert.ToInt32(txtAttendanceDays.Value);
                       info.AnnualLeave = Convert.ToInt32(txtAnnualLeave.Value);
                       info.SickLeave = Convert.ToInt32(txtSickLeave.Value);
                       info.CasualLeave = Convert.ToInt32(txtCasualLeave.Value);
                       info.InjuryLeave = Convert.ToInt32(txtInjuryLeave.Value);
                       info.MarriageLeave = Convert.ToInt32(txtMarriageLeave.Value);
                       info.AbsentLeave = Convert.ToInt32(txtAbsentLeave.Value);
       	            info.PositionLevel = txtPositionLevel.Text;
                       info.LevelSalary = txtLevelSalary.Value;
                       info.MonthWorkload = txtMonthWorkload.Value;
                       info.BaseWorkload = txtBaseWorkload.Value;
                       info.WeekendWorkload = txtWeekendWorkload.Value;
                       info.HolidayWorkload = txtHolidayWorkload.Value;
                       info.Estimation = txtEstimation.Value;
                       info.Allowance = txtAllowance.Value;
                       info.WorkshopDeduction = txtWorkshopDeduction.Value;
                       info.WorkshopBonus = txtWorkshopBonus.Value;
                       info.BonusDeduction = txtBonusDeduction.Value;
                       info.NoonShift = Convert.ToInt32(txtNoonShift.Value);
                       info.NightShift = Convert.ToInt32(txtNightShift.Value);
                       info.OtherNoon = Convert.ToInt32(txtOtherNoon.Value);
                       info.OtherNight = Convert.ToInt32(txtOtherNight.Value);
                       info.ShiftAmount = txtShiftAmount.Value;
                       info.QualityBonus = txtQualityBonus.Value;
                       info.Deduction = txtDeduction.Value;
                       info.Nutrition = txtNutrition.Value;
                       info.EquipmentBonus = txtEquipmentBonus.Value;
                       info.SafetyBonus = txtSafetyBonus.Value;
                       info.FiveSBonus = txtFiveSBonus.Value;
                       info.HotBonus = txtHotBonus.Value;
                       info.LunchAllowance = txtLunchAllowance.Value;
       	            info.Remark = txtRemark.Text;
               }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborMonthAttendanceInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<ILaborMonthAttendanceService>.Instance.Insert(info);
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

            LaborMonthAttendanceInfo info = CallerFactory<ILaborMonthAttendanceService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<ILaborMonthAttendanceService>.Instance.Update(info, info.Id);
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

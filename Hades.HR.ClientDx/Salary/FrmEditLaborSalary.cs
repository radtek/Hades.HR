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

using Hades.HR.BLL;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmEditLaborSalary : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private LaborSalaryInfo tempInfo = new LaborSalaryInfo();
    	
        public FrmEditLaborSalary()
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
                LaborSalaryInfo info = BLLFactory<LaborSalary>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
	                    txtStaffId.Text = info.StaffId;
                                   txtYear.Value = info.Year;
                               txtMonth.Value = info.Month;
       	                    txtStaffLevelId.Text = info.StaffLevelId;
                                   txtLevelSalary.Value = info.LevelSalary;
                               txtBaseSalary.Value = info.BaseSalary;
                               txtOverSalary.Value = info.OverSalary;
                               txtWeekendSalary.Value = info.WeekendSalary;
                               txtHolidaySalary.Value = info.HolidaySalary;
                               txtEstimation.Value = info.Estimation;
                               txtAllowance.Value = info.Allowance;
                               txtTotalSalary.Value = info.TotalSalary;
                               txtNoonShift.Value = info.NoonShift;
                               txtNightShift.Value = info.NightShift;
                               txtOtherNoon.Value = info.OtherNoon;
                               txtOtherNight.Value = info.OtherNight;
                               txtShiftAmount.Value = info.ShiftAmount;
       	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborSalary/Edit");             
            }
            else
            {
                  
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborSalary/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(LaborSalaryInfo info)
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
            this.tempInfo = new LaborSalaryInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborSalaryInfo info)
        {
	            info.StaffId = txtStaffId.Text;
                       info.Year = Convert.ToInt32(txtYear.Value);
                       info.Month = Convert.ToInt32(txtMonth.Value);
       	            info.StaffLevelId = txtStaffLevelId.Text;
                       info.LevelSalary = txtLevelSalary.Value;
                       info.BaseSalary = txtBaseSalary.Value;
                       info.OverSalary = txtOverSalary.Value;
                       info.WeekendSalary = txtWeekendSalary.Value;
                       info.HolidaySalary = txtHolidaySalary.Value;
                       info.Estimation = txtEstimation.Value;
                       info.Allowance = txtAllowance.Value;
                       info.TotalSalary = txtTotalSalary.Value;
                       info.NoonShift = Convert.ToInt32(txtNoonShift.Value);
                       info.NightShift = Convert.ToInt32(txtNightShift.Value);
                       info.OtherNoon = Convert.ToInt32(txtOtherNoon.Value);
                       info.OtherNight = Convert.ToInt32(txtOtherNight.Value);
                       info.ShiftAmount = txtShiftAmount.Value;
       	            info.Remark = txtRemark.Text;
               }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborSalaryInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = BLLFactory<LaborSalary>.Instance.Insert(info);
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

            LaborSalaryInfo info = BLLFactory<LaborSalary>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = BLLFactory<LaborSalary>.Instance.Update(info, info.Id);
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

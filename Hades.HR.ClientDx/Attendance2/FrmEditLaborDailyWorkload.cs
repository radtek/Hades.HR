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
    public partial class FrmEditLaborDailyWorkload : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private LaborDailyWorkloadInfo tempInfo = new LaborDailyWorkloadInfo();
    	
        public FrmEditLaborDailyWorkload()
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
            if (this.txtWorkTeamId.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtWorkTeamId.Focus();
                result = false;
            }
             else if (this.txtStaffId.Text.Trim().Length == 0)
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
                LaborDailyWorkloadInfo info = CallerFactory<ILaborDailyWorkloadService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
	                    txtWorkTeamWorkloadId.Text = info.WorkTeamWorkloadId;
           	                    txtWorkTeamId.Text = info.WorkTeamId;
           	                    txtActualWorkTeamId.Text = info.ActualWorkTeamId;
                               txtAttendanceDate.SetDateTime(info.AttendanceDate);	
   	                    txtStaffId.Text = info.StaffId;
                                   txtProductionHours.Value = info.ProductionHours;
                               txtChangeHours.Value = info.ChangeHours;
                               txtRepairHours.Value = info.RepairHours;
                               txtElectricHours.Value = info.ElectricHours;
                               txtLeaveHours.Value = info.LeaveHours;
                               txtAllowanceHours.Value = info.AllowanceHours;
       	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborDailyWorkload/Edit");             
            }
            else
            {
            
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborDailyWorkload/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(LaborDailyWorkloadInfo info)
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
            this.tempInfo = new LaborDailyWorkloadInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborDailyWorkloadInfo info)
        {
	            info.WorkTeamWorkloadId = txtWorkTeamWorkloadId.Text;
       	            info.WorkTeamId = txtWorkTeamId.Text;
       	            info.ActualWorkTeamId = txtActualWorkTeamId.Text;
                   info.AttendanceDate = txtAttendanceDate.DateTime;
   	            info.StaffId = txtStaffId.Text;
                       info.ProductionHours = txtProductionHours.Value;
                       info.ChangeHours = txtChangeHours.Value;
                       info.RepairHours = txtRepairHours.Value;
                       info.ElectricHours = txtElectricHours.Value;
                       info.LeaveHours = txtLeaveHours.Value;
                       info.AllowanceHours = txtAllowanceHours.Value;
       	            info.Remark = txtRemark.Text;
               }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborDailyWorkloadInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<ILaborDailyWorkloadService>.Instance.Insert(info);
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

            LaborDailyWorkloadInfo info = CallerFactory<ILaborDailyWorkloadService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<ILaborDailyWorkloadService>.Instance.Update(info, info.Id);
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

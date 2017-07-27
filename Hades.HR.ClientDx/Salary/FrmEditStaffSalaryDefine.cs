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
    public partial class FrmEditStaffSalaryDefine : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private StaffSalaryDefineInfo tempInfo = new StaffSalaryDefineInfo();
    	
        public FrmEditStaffSalaryDefine()
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
            if (this.txtFinanceDepartment.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtFinanceDepartment.Focus();
                result = false;
            }
             else if (this.txtCardNumber.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtCardNumber.Focus();
                result = false;
            }
             else if (this.txtSalaryLevel.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtSalaryLevel.Focus();
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
                StaffSalaryDefineInfo info = CallerFactory<IStaffSalaryDefineService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
	                    txtFinanceDepartment.Text = info.FinanceDepartment;
           	                    txtCardNumber.Text = info.CardNumber;
           	                    txtSalaryLevel.Text = info.SalaryLevel;
                                   txtBaseBonus.Value = info.BaseBonus;
                               txtDepartmentBonus.Value = info.DepartmentBonus;
                               txtReserveFund.Value = info.ReserveFund;
                               txtInsurance.Value = info.Insurance;
       	                    txtRemark.Text = info.Remark;
           	                    txtEditor.Text = info.Editor;
           	                    txtEditorId.Text = info.EditorId;
                               txtEditTime.SetDateTime(info.EditTime);	
                     } 
                #endregion
                //this.btnOK.Enabled = HasFunction("StaffSalaryDefine/Edit");             
            }
            else
            {
                        txtEditor.Text = LoginUserInfo.Name;//Ĭ��Ϊ��ǰ��¼�û�
                  txtEditTime.DateTime = DateTime.Now; //Ĭ�ϵ�ǰʱ��
 
                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffSalaryDefine/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(StaffSalaryDefineInfo info)
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
            this.tempInfo = new StaffSalaryDefineInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffSalaryDefineInfo info)
        {
	            info.FinanceDepartment = txtFinanceDepartment.Text;
       	            info.CardNumber = txtCardNumber.Text;
       	            info.SalaryLevel = txtSalaryLevel.Text;
                       info.BaseBonus = txtBaseBonus.Value;
                       info.DepartmentBonus = txtDepartmentBonus.Value;
                       info.ReserveFund = txtReserveFund.Value;
                       info.Insurance = txtInsurance.Value;
       	            info.Remark = txtRemark.Text;
       	            info.Editor = txtEditor.Text;
       	            info.EditorId = txtEditorId.Text;
                   info.EditTime = txtEditTime.DateTime;
           }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            StaffSalaryDefineInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<IStaffSalaryDefineService>.Instance.Insert(info);
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

            StaffSalaryDefineInfo info = CallerFactory<IStaffSalaryDefineService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IStaffSalaryDefineService>.Instance.Update(info, info.Id);
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

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
    public partial class FrmEditStaffBonus : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private StaffBonusInfo tempInfo = new StaffBonusInfo();
    	
        public FrmEditStaffBonus()
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
            if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtName.Focus();
                result = false;
            }
             else if (this.txtAmount.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtAmount.Focus();
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
                StaffBonusInfo info = BLLFactory<StaffBonus>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
	                    txtStaffId.Text = info.StaffId;
           	                    txtName.Text = info.Name;
                                   txtAmount.Value = info.Amount;
       	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("StaffBonus/Edit");             
            }
            else
            {
    
                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffBonus/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(StaffBonusInfo info)
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
            this.tempInfo = new StaffBonusInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffBonusInfo info)
        {
	            info.StaffId = txtStaffId.Text;
       	            info.Name = txtName.Text;
                       info.Amount = txtAmount.Value;
       	            info.Remark = txtRemark.Text;
               }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            StaffBonusInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = BLLFactory<StaffBonus>.Instance.Insert(info);
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

            StaffBonusInfo info = BLLFactory<StaffBonus>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = BLLFactory<StaffBonus>.Instance.Update(info, info.Id);
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

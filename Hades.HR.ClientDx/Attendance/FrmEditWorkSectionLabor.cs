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
    public partial class FrmEditWorkSectionLabor : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private WorkSectionLaborInfo tempInfo = new WorkSectionLaborInfo();
    	
        public FrmEditWorkSectionLabor()
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
            if (this.txtYear.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtYear.Focus();
                result = false;
            }
             else if (this.txtMonth.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtMonth.Focus();
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
                WorkSectionLaborInfo info = CallerFactory<IWorkSectionLaborService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
                        txtYear.Value = info.Year;
                               txtMonth.Value = info.Month;
       	                    txtWorkSectionId.Text = info.WorkSectionId;
           	                    txtStaffId.Text = info.StaffId;
           	                    txtStaffLevel.Text = info.StaffLevel;
           	                    txtRemark.Text = info.Remark;
           	                    txtEditor.Text = info.Editor;
           	                    txtEditorId.Text = info.EditorId;
                               txtEditTime.SetDateTime(info.EditTime);	
                     } 
                #endregion
                //this.btnOK.Enabled = HasFunction("WorkSectionLabor/Edit");             
            }
            else
            {
                      txtEditor.Text = LoginUserInfo.Name;//Ĭ��Ϊ��ǰ��¼�û�
                  txtEditTime.DateTime = DateTime.Now; //Ĭ�ϵ�ǰʱ��
 
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkSectionLabor/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(WorkSectionLaborInfo info)
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
            this.tempInfo = new WorkSectionLaborInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WorkSectionLaborInfo info)
        {
                info.Year = Convert.ToInt32(txtYear.Value);
                       info.Month = Convert.ToInt32(txtMonth.Value);
       	            info.WorkSectionId = txtWorkSectionId.Text;
       	            info.StaffId = txtStaffId.Text;
       	            info.StaffLevel = txtStaffLevel.Text;
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
            WorkSectionLaborInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<IWorkSectionLaborService>.Instance.Insert(info);
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

            WorkSectionLaborInfo info = CallerFactory<IWorkSectionLaborService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IWorkSectionLaborService>.Instance.Update(info, info.Id);
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

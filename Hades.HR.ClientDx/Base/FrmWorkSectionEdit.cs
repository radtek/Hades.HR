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
    /// �༭���δ���
    /// </summary>
    public partial class FrmWorkSectionEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WorkSectionInfo tempInfo = new WorkSectionInfo();
        #endregion //Field

        #region Constructor
        public FrmWorkSectionEdit()
        {
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
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WorkSectionInfo info)
        {
            info.Name = txtName.Text;
            info.Number = txtNumber.Text;
            info.CompanyId = this.luCompany.GetSelectedId();
            info.Caption = this.txtCaption.Text;
            info.SortCode = txtSortCode.Text;
            info.Remark = txtRemark.Text;
            info.Enabled = Convert.ToInt32(cmbEnabled.EditValue);

            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��������
        /// </summary>
        public override void FormOnLoad()
        {
            this.luCompany.Init();
            base.FormOnLoad();
        }

        public override void ClearScreen()
        {
            this.tempInfo = new WorkSectionInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("����������");
                this.txtName.Focus();
                result = false;
            }
            else if (string.IsNullOrEmpty(this.luCompany.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("��ѡ��������˾");
                this.luCompany.Focus();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�

            if (!string.IsNullOrEmpty(ID))
            {
                WorkSectionInfo info = CallerFactory<IWorkSectionService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    txtName.Text = info.Name;
                    txtNumber.Text = info.Number;
                    txtCaption.Text = info.Caption;

                    this.luCompany.SetSelected(info.CompanyId);

                    txtSortCode.Text = info.SortCode;
                    txtRemark.Text = info.Remark;
                    cmbEnabled.EditValue = info.Enabled;
                }

                this.Text = "�༭����";
                //this.btnOK.Enabled = HasFunction("WorkSection/Edit");             
            }
            else
            {
                this.Text = "��������";
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkSection/Add");  
            }
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WorkSectionInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);
            info.Deleted = 0;

            try
            {
                bool succeed = CallerFactory<IWorkSectionService>.Instance.Insert(info);
                if (succeed)
                {
                    //�����������������

                    return true;
                }
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
            WorkSectionInfo info = CallerFactory<IWorkSectionService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    bool succeed = CallerFactory<IWorkSectionService>.Instance.Update(info, info.Id);
                    if (succeed)
                    {
                        //�����������������

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
            return false;
        }
        #endregion //Method

        #region Event

        #endregion //Event
    }
}

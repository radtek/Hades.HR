using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

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
    /// ��ӱ༭����
    /// </summary>
    public partial class FrmDepartmentEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private DepartmentInfo tempInfo = new DepartmentInfo();
        #endregion //Field

        #region Constructor
        public FrmDepartmentEdit()
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
        private void SetInfo(DepartmentInfo info)
        {
            info.PID = this.luParent.GetSelectedId();
            info.Number = txtNumber.Text;
            info.Name = txtName.Text;
            info.SortCode = txtSortCode.Text;
            info.Type = Convert.ToInt32(cmbType.EditValue);
            info.Address = txtAddress.Text;
            info.Principal = txtPrincipal.Text;
            info.Quota = Convert.ToInt32(spQuota.Value);
            info.Fax = txtFax.Text;
            info.InnerPhone = txtInnerPhone.Text;
            info.OuterPhone = txtOuterPhone.Text;
            info.Remark = txtRemark.Text;
            info.FoundDate = dpFoundDate.DateTime;
            info.CloseDate = dpCloseDate.DateTime;
            info.Enabled = Convert.ToInt32(cmbEnabled.EditValue);

            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }
        #endregion //Function

        #region Metohd
        /// <summary>
        /// ��������
        /// </summary>
        public override void FormOnLoad()
        {
            this.luParent.Init();
            this.cmbType.Properties.Items.AddEnum(typeof(DepartmentType));

            base.FormOnLoad();
        }

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�

            if (!string.IsNullOrEmpty(ID))  //�༭
            {
                this.Text = "�༭����";
                DepartmentInfo info = CallerFactory<IDepartmentService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    txtNumber.Text = info.Number;
                    txtName.Text = info.Name;
                    luParent.SetSelected(info.PID);
                    txtSortCode.Text = info.SortCode;
                    cmbType.EditValue = (DepartmentType)info.Type;
                    txtAddress.Text = info.Address;
                    txtPrincipal.Text = info.Principal;
                    spQuota.Value = info.Quota;
                    txtFax.Text = info.Fax;
                    txtInnerPhone.Text = info.InnerPhone;
                    txtOuterPhone.Text = info.OuterPhone;
                    dpFoundDate.SetDateTime(info.FoundDate);
                    dpCloseDate.SetDateTime(info.CloseDate);
                    txtRemark.Text = info.Remark;
                    cmbEnabled.EditValue = info.Enabled;
                }

                //this.btnOK.Enabled = HasFunction("Department/Edit");             
            }
            else  //����
            {
                this.Text = "��������";
                //this.btnOK.Enabled = Portal.gc.HasFunction("Department/Add");  
            }

            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        public override void ClearScreen()
        {
            this.tempInfo = new DepartmentInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            if (this.txtNumber.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("�����벿�Ŵ���");
                this.txtNumber.Focus();
                result = false;
            }
            else if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("�����벿������");
                this.txtName.Focus();
                result = false;
            }
            else if (this.cmbType.EditValue == null)
            {
                MessageDxUtil.ShowTips("��ѡ��������");
                this.cmbType.Focus();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            DepartmentInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            info.Creator = this.LoginUserInfo.Name;
            info.CreatorId = this.LoginUserInfo.ID;
            info.CreateTime = DateTime.Now;
            info.Deleted = 0;

            try
            {
                bool succeed = CallerFactory<IDepartmentService>.Instance.CheckDuplicate(info);
                if (!succeed)
                {
                    MessageDxUtil.ShowWarning("���Ŵ����ظ�");
                    return false;
                }

                succeed = CallerFactory<IDepartmentService>.Instance.Insert(info);
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
            DepartmentInfo info = CallerFactory<IDepartmentService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    bool succeed = CallerFactory<IDepartmentService>.Instance.CheckDuplicate(info);
                    if (!succeed)
                    {
                        MessageDxUtil.ShowWarning("���Ŵ����ظ�");
                        return false;
                    }

                    succeed = CallerFactory<IDepartmentService>.Instance.Update(info, info.Id);
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
    }
}

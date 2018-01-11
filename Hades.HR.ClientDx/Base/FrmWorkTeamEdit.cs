using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Hades.Dictionary;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.BLL;
using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmWorkTeamEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WorkTeamInfo tempInfo = new WorkTeamInfo();
        #endregion //Field

        #region Constructor
        public FrmWorkTeamEdit()
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
        private void SetInfo(WorkTeamInfo info)
        {
            info.Name = txtName.Text;
            info.Number = txtNumber.Text;
            info.CompanyId = luCompany.GetSelectedId();
            info.WorkSectionId = luWorkSection.GetSelectedId();
            info.Quota = Convert.ToInt32(spQuota.Value);
            info.Principal = txtPrincipal.Text;
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

        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�

            if (!string.IsNullOrEmpty(ID))
            {
                this.Text = "�༭����";
                WorkTeamInfo info = CallerFactory<IWorkTeamService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    txtName.Text = info.Name;
                    txtNumber.Text = info.Number;
                    spQuota.Value = info.Quota;

                    this.luCompany.SetSelected(info.CompanyId);
                    this.luWorkSection.SetSelected(info.WorkSectionId);

                    txtPrincipal.Text = info.Principal;
                    txtSortCode.Text = info.SortCode;
                    txtRemark.Text = info.Remark;
                    cmbEnabled.EditValue = info.Enabled;
                }

                //this.btnOK.Enabled = HasFunction("WorkTeam/Edit");             
            }
            else
            {
                this.Text = "��������";
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkTeam/Add");  
            }
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WorkTeamInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            info.Creator = this.LoginUserInfo.Name;
            info.CreatorId = this.LoginUserInfo.ID;
            info.CreateTime = DateTime.Now;
            info.Deleted = 0;

            try
            {
                #region ��������

                bool succeed = CallerFactory<IWorkTeamService>.Instance.Insert(info);
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
            WorkTeamInfo info = CallerFactory<IWorkTeamService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);
                info.Deleted = 0;

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IWorkTeamService>.Instance.Update(info, info.Id);
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
        #endregion //Method

        #region Event
        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luCompany_DepartmentSelect(object sender, EventArgs e)
        {
            string cid = this.luCompany.GetSelectedId();
            if (!string.IsNullOrEmpty(cid))
                this.luWorkSection.Init(cid);
        }
        #endregion //Event
    }
}

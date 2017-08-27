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
            info.WorkTeamId = luWorkTeam.GetSelectedId();
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
            else if (string.IsNullOrEmpty(this.luProductionLine.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("��ѡ������������");
                this.luProductionLine.Focus();
                result = false;
            }
            else if (string.IsNullOrEmpty(this.luWorkTeam.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("��ѡ����������");
                this.luWorkTeam.Focus();
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
                    var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(info.WorkTeamId);

                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    txtName.Text = info.Name;
                    txtNumber.Text = info.Number;

                    this.luCompany.SetSelected(workTeam.CompanyId);
                    this.luProductionLine.SetSelected(workTeam.ProductionLineId);
                    this.luWorkTeam.SetSelected(info.WorkTeamId);

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
                #region ��������

                bool succeed = CallerFactory<IWorkSectionService>.Instance.Insert(info);
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
        private void luCompany_DepartmentSelect(object sender, EventArgs e)
        {
            var depId = this.luCompany.GetSelectedId();
            if (!string.IsNullOrEmpty(depId))
            {
                this.luProductionLine.Init(depId);
            }
        }       

        private void luProductionLine_ProductionLineSelect(object sender, EventArgs e)
        {
            var lineId = this.luProductionLine.GetSelectedId();
            if (!string.IsNullOrEmpty(lineId))
            {
                this.luWorkTeam.Init(lineId);
            }
        }
        #endregion //Event
    }
}

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
using Hades.HR.BLL;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmEditBonusDefine : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private BonusDefineInfo tempInfo = new BonusDefineInfo();
        #endregion //Field

        #region Constructor
        public FrmEditBonusDefine()
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
        private void SetInfo(BonusDefineInfo info)
        {
            info.Name = txtName.Text;
            info.Remark = txtRemark.Text;
        }
        #endregion //Function

        #region Method
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

            return result;
        }

        public override void ClearScreen()
        {
            this.tempInfo = new BonusDefineInfo();
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
                #region ��ʾ��Ϣ
                BonusDefineInfo info = CallerFactory<IBonusDefineService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    txtName.Text = info.Name;
                    txtRemark.Text = info.Remark;
                }
                #endregion
                this.Text = "�༭������Ŀ";
                //this.btnOK.Enabled = HasFunction("BonusDefine/Edit");             
            }
            else
            {
                this.Text = "����������Ŀ";
                //this.btnOK.Enabled = Portal.gc.HasFunction("BonusDefine/Add");  
            }
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            BonusDefineInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<IBonusDefineService>.Instance.Insert(info);
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
            BonusDefineInfo info = CallerFactory<IBonusDefineService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IBonusDefineService>.Instance.Update(info, info.Id);
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
    }
}

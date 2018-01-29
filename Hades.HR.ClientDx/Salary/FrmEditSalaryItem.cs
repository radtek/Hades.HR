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
    public partial class FrmEditSalaryItem : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private SalaryItemInfo tempInfo = new SalaryItemInfo();
        #endregion //Field

        #region Constructor
        public FrmEditSalaryItem()
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
        private void SetInfo(SalaryItemInfo info)
        {
            info.Name = txtName.Text;
            info.Code = txtCode.Text;
            info.Cardinal = txtCardinal.Value;
            info.Coefficient = txtCoefficient.Value;
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

            #region MyRegion
            if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtName.Focus();
                result = false;
            }
            else if (this.txtCode.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtCode.Focus();
                result = false;
            }
            else if (this.txtCardinal.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtCardinal.Focus();
                result = false;
            }
            else if (this.txtCoefficient.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtCoefficient.Focus();
                result = false;
            }
            #endregion

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
                this.Text = "�༭������Ŀ";
                SalaryItemInfo info = CallerFactory<ISalaryItemService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    txtName.Text = info.Name;
                    txtCode.Text = info.Code;
                    txtCardinal.Value = info.Cardinal;
                    txtCoefficient.Value = info.Coefficient;
                    txtRemark.Text = info.Remark;
                }
               
                //this.btnOK.Enabled = HasFunction("SalaryItem/Edit");             
            }
            else
            {
                this.Text = "����������Ŀ";
                //this.btnOK.Enabled = Portal.gc.HasFunction("SalaryItem/Add");  
            }
            
        }

        public override void ClearScreen()
        {
            this.tempInfo = new SalaryItemInfo();
            base.ClearScreen();
        }        

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            SalaryItemInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<ISalaryItemService>.Instance.Insert(info);
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

            SalaryItemInfo info = CallerFactory<ISalaryItemService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<ISalaryItemService>.Instance.Update(info, info.Id);
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

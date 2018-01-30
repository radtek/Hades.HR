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
    public partial class FrmWarehouseEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WarehouseInfo tempInfo = new WarehouseInfo();
        #endregion //Field

        #region Constructor
        public FrmWarehouseEdit()
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
        private void SetInfo(WarehouseInfo info)
        {            
            info.Number = txtNumber.Text;
            info.Name = txtName.Text;
            info.CompanyId = this.luCompany.GetSelectedId();
            info.SortCode = txtSortCode.Text;
            info.Address = txtAddress.Text;
            info.InnerPhone = txtInnerPhone.Text;
            info.OuterPhone = txtOuterPhone.Text;
            info.Remark = txtRemark.Text;
            info.Enabled = Convert.ToInt32(this.cmbEnabled.EditValue);

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
            this.tempInfo = new WarehouseInfo();
            base.ClearScreen();
        }       

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��
            
            var comId = this.luCompany.GetSelectedId();
            if (this.txtNumber.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("���������");
                this.txtNumber.Focus();
                result = false;
            }
             else if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("����������");
                this.txtName.Focus();
                result = false;
            }
            else if (string.IsNullOrEmpty(comId) || comId == "-1")
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
                this.Text = "�༭�ֿ�";
                WarehouseInfo info = CallerFactory<IWarehouseService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                    
                    txtNumber.Text = info.Number;
                    txtName.Text = info.Name;
                    luCompany.SetSelected(info.CompanyId);
                    txtSortCode.Text = info.SortCode;
                    txtAddress.Text = info.Address;
                    txtInnerPhone.Text = info.InnerPhone;
                    txtOuterPhone.Text = info.OuterPhone;
                    txtRemark.Text = info.Remark;

                    cmbEnabled.EditValue = info.Enabled;
                }

                //this.btnOK.Enabled = HasFunction("Warehouse/Edit");             
            }
            else
            {
                this.Text = "�����ֿ�";
                //this.btnOK.Enabled = Portal.gc.HasFunction("Warehouse/Add");  
            }
        } 
        
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WarehouseInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            info.Deleted = 0;

            try
            {
                #region ��������

                bool succeed = CallerFactory<IWarehouseService>.Instance.Insert(info);
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

            WarehouseInfo info = CallerFactory<IWarehouseService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IWarehouseService>.Instance.Update(info, info.Id);
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

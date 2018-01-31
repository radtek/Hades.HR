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
using DevExpress.XtraEditors.Controls;

namespace Hades.HR.UI
{
    public partial class FrmEditSalaryBase : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private SalaryBaseInfo tempInfo = new SalaryBaseInfo();
        #endregion //Field

        #region Constructor
        public FrmEditSalaryBase()
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
        private void SetInfo(SalaryBaseInfo info)
        {
            info.Id = ID;
            info.FinanceDepartmentId = luDepartment.GetSelectedId();
            info.CardNumber = txtCardNumber.Text;
            info.StaffLevelId = cmbStaffLevel.EditValue.ToString();
            info.BaseBonus = txtBaseBonus.Value;
            info.DepartmentBonus = txtDepartmentBonus.Value;
            info.ReserveFund = txtReserveFund.Value;
            info.Insurance = txtInsurance.Value;
            info.HighTemp = txtHighTemp.Value;
            info.Remark = txtRemark.Text;

            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }
        #endregion //Function
        
        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new SalaryBaseInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            var depId = this.luDepartment.GetSelectedId();
            if (string.IsNullOrEmpty(depId) || depId == "-1")
            {
                MessageDxUtil.ShowTips("��ѡ�������");
                result = false;
            }
            else if (this.luDepartment.GetSelected().Type != (int)DepartmentType.Department)
            {
                MessageDxUtil.ShowTips("��ѡ����");
                result = false;
            }
            else if (this.cmbStaffLevel.EditValue == null)
            {
                MessageDxUtil.ShowTips("��ѡ��ְԱ�ȼ�");
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

            this.luDepartment.Init();

            var levels = CallerFactory<IStaffLevelService>.Instance.Find2("", "ORDER BY SortCode");
            foreach (var item in levels)
            {
                this.cmbStaffLevel.Properties.Items.Add(new ImageComboBoxItem(item.Name, item.Id));
            }

            this.Text = "�༭ְԱ��������";
            if (!string.IsNullOrEmpty(ID))
            {
                StaffInfo staff = CallerFactory<IStaffService>.Instance.FindByID(ID);
                this.txtStaffNumber.Text = staff.Number;
                this.txtStaffName.Text = staff.Name;

                SalaryBaseInfo info = CallerFactory<ISalaryBaseService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    luDepartment.SetSelected(info.FinanceDepartmentId);
                    txtCardNumber.Text = info.CardNumber;
                    cmbStaffLevel.EditValue = info.StaffLevelId;
                    txtBaseBonus.Value = info.BaseBonus;
                    txtDepartmentBonus.Value = info.DepartmentBonus;
                    txtReserveFund.Value = info.ReserveFund;
                    txtInsurance.Value = info.Insurance;
                    txtRemark.Text = info.Remark;
                }

                //this.btnOK.Enabled = HasFunction("StaffSalaryDefine/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffSalaryDefine/Add");  
            }
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            return false;
        }

        /// <summary>
        /// �༭״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {
            SalaryBaseInfo info = new SalaryBaseInfo();

            SetInfo(info);

            try
            {
                bool succeed = CallerFactory<ISalaryBaseService>.Instance.InsertUpdate(info, info.Id);
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
        #endregion //Method
    }
}

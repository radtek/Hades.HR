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
    /// �༭Ա��������Ϣ
    /// </summary>
    public partial class FrmStaffSalaryEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private StaffSalaryInfo tempInfo = new StaffSalaryInfo();
        #endregion //Field

        #region Constructor
        public FrmStaffSalaryEdit()
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
        private void SetInfo(StaffSalaryInfo info)
        {
            info.Id = this.ID;
            info.FinanceDepartment = this.luDepartment.GetSelectedId();
            info.CardNumber = txtCardNumber.Text;
            info.BaseSalary = txtBaseSalary.Value;
            info.BaseBonus = txtBaseBonus.Value;
            info.DepartmentBonus = txtDepartmentBonus.Value;
            info.ReserveFund = txtReserveFund.Value;
            info.Insurance = txtInsurance.Value;
            info.Remark = txtRemark.Text;

            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            StaffSalaryInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                bool result = false;
                var entity = CallerFactory<IStaffSalaryService>.Instance.FindByID(info.Id);
                if (entity == null)
                {
                    result = CallerFactory<IStaffSalaryService>.Instance.Insert(info);
                }
                else
                {
                    result = CallerFactory<IStaffSalaryService>.Instance.Update(info, info.Id);
                }

                return result;
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
            return false;
        }

        #endregion //Function

        #region Method
        /// <summary>
        /// ��������
        /// </summary>
        public override void FormOnLoad()
        {
            this.luDepartment.Init();

            base.FormOnLoad();
        }

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            if (string.IsNullOrEmpty(this.luDepartment.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("��ѡ����������");
                this.luDepartment.Focus();
                result = false;
            }

            var dep = this.luDepartment.GetSelected();
            if (dep.Type == (int)DepartmentType.Group || dep.Type == (int)DepartmentType.Company)
            {
                MessageDxUtil.ShowTips("�������Ų���Ϊ���Ż�˾");
                this.luDepartment.Focus();
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
                this.Text = "�༭Ա��������Ϣ";
                StaffSalaryInfo info = CallerFactory<IStaffSalaryService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    luDepartment.SetSelected(info.FinanceDepartment);
                    txtCardNumber.Text = info.CardNumber;
                    txtBaseSalary.Value = info.BaseSalary;
                    txtBaseBonus.Value = info.BaseBonus;
                    txtDepartmentBonus.Value = info.DepartmentBonus;
                    txtReserveFund.Value = info.ReserveFund;
                    txtInsurance.Value = info.Insurance;
                    txtRemark.Text = info.Remark;
                }
              
                //this.btnOK.Enabled = HasFunction("StaffSalary/Edit");             
            }
            else
            {

                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffSalary/Add");  
            }

            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        public override void ClearScreen()
        {
            this.tempInfo = new StaffSalaryInfo();
            base.ClearScreen();
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
            return Save();
        }
        #endregion //Method
    }
}

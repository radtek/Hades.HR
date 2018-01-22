using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

using WHC.Framework.ControlUtil.Facade;
using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmEditStaffSalary : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private StaffSalaryInfo tempInfo = new StaffSalaryInfo();
    	
        public FrmEditStaffSalary()
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
            if (this.txtStaffId.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtStaffId.Focus();
                result = false;
            }
             else if (this.txtDepartmentId.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtDepartmentId.Focus();
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
                StaffSalaryInfo info = CallerFactory<IStaffSalaryService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
                        txtYear.Value = info.Year;
                               txtMonth.Value = info.Month;
       	                    txtStaffId.Text = info.StaffId;
           	                    txtDepartmentId.Text = info.DepartmentId;
           	                    txtStaffLevelId.Text = info.StaffLevelId;
                                   txtLevelSalary.Value = info.LevelSalary;
                               txtBaseBonus.Value = info.BaseBonus;
                               txtDepartmentBonus.Value = info.DepartmentBonus;
                               txtReserveFund.Value = info.ReserveFund;
                               txtInsurance.Value = info.Insurance;
                               txtNormalOvertimeSalary.Value = info.NormalOvertimeSalary;
                               txtWeekendOvertimeSalary.Value = info.WeekendOvertimeSalary;
                               txtHolidayOvertimeSalary.Value = info.HolidayOvertimeSalary;
                               txtOvertimeSalarySum.Value = info.OvertimeSalarySum;
                               txtTotalSalary.Value = info.TotalSalary;
       	                    txtRemark.Text = info.Remark;
           	                    txtEditor.Text = info.Editor;
           	                    txtEditorId.Text = info.EditorId;
                               txtEditTime.SetDateTime(info.EditTime);	
                     } 
                #endregion
                //this.btnOK.Enabled = HasFunction("StaffSalary/Edit");             
            }
            else
            {
                                txtEditor.Text = LoginUserInfo.Name;//Ĭ��Ϊ��ǰ��¼�û�
                  txtEditTime.DateTime = DateTime.Now; //Ĭ�ϵ�ǰʱ��
 
                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffSalary/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(StaffSalaryInfo info)
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
            this.tempInfo = new StaffSalaryInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffSalaryInfo info)
        {
                info.Year = Convert.ToInt32(txtYear.Value);
                       info.Month = Convert.ToInt32(txtMonth.Value);
       	            info.StaffId = txtStaffId.Text;
       	            info.DepartmentId = txtDepartmentId.Text;
       	            info.StaffLevelId = txtStaffLevelId.Text;
                       info.LevelSalary = txtLevelSalary.Value;
                       info.BaseBonus = txtBaseBonus.Value;
                       info.DepartmentBonus = txtDepartmentBonus.Value;
                       info.ReserveFund = txtReserveFund.Value;
                       info.Insurance = txtInsurance.Value;
                       info.NormalOvertimeSalary = txtNormalOvertimeSalary.Value;
                       info.WeekendOvertimeSalary = txtWeekendOvertimeSalary.Value;
                       info.HolidayOvertimeSalary = txtHolidayOvertimeSalary.Value;
                       info.OvertimeSalarySum = txtOvertimeSalarySum.Value;
                       info.TotalSalary = txtTotalSalary.Value;
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
            StaffSalaryInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<IStaffSalaryService>.Instance.Insert(info);
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

            StaffSalaryInfo info = CallerFactory<IStaffSalaryService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IStaffSalaryService>.Instance.Update(info, info.ID);
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

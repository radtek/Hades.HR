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
    /// �����༭�¿���
    /// </summary>
    public partial class FrmEditAttendance : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private AttendanceInfo tempInfo = new AttendanceInfo();
        #endregion //Field

        #region Constructor
        public FrmEditAttendance()
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
        private void SetInfo(AttendanceInfo info)
        {
            info.Year = Convert.ToInt32(txtYear.Value);
            info.Month = Convert.ToInt32(txtMonth.Value);
            info.Days = Convert.ToInt32(txtDays.Value);
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

            if (this.txtYear.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtYear.Focus();
                result = false;
            }
            else if (this.txtMonth.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtMonth.Focus();
                result = false;
            }
            else if (this.txtDays.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtDays.Focus();
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
                AttendanceInfo info = CallerFactory<IAttendanceService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    txtYear.Value = info.Year;
                    txtMonth.Value = info.Month;
                    txtDays.Value = info.Days;
                    txtRemark.Text = info.Remark;
                }

                this.Text = "�༭�¶ȿ���";
                //this.btnOK.Enabled = HasFunction("Attendance/Edit");             
            }
            else
            {
                this.Text = "�����¶ȿ���";
                //this.btnOK.Enabled = Portal.gc.HasFunction("Attendance/Add");  
            }
        }

        public override void ClearScreen()
        {
            this.tempInfo = new AttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            AttendanceInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                bool succeed = CallerFactory<IAttendanceService>.Instance.Insert(info);
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

            AttendanceInfo info = CallerFactory<IAttendanceService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    bool succeed = CallerFactory<IAttendanceService>.Instance.Update(info, info.Id);
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

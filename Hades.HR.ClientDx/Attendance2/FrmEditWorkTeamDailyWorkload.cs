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
    public partial class FrmEditWorkTeamDailyWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();
        #endregion //Field

        #region Constructor
        public FrmEditWorkTeamDailyWorkload()
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
        /// �����깤���б�
        /// </summary>
        /// <param name="dt"></param>
        private void GenerateList(DateTime dt)
        {
            Random random = new Random(dt.Day);

            this.lvComplete.Items.Clear();
            int days = random.Next(2, 6);
            for (int i = 0; i < days; i++)
            {
                string number = string.Format("{0:D4}{1:D2}{2:D3}-{3:D3}", dt.Year, dt.Month, dt.Day, i);
                this.lvComplete.Items.Add(number);
            }
        }
        
        /// <summary>
        /// �����깤����
        /// </summary>
        private void GenerateComplete()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            CompleteForm form1 = new CompleteForm();
            form1.Name = "Ͱ��ȦԲ";
            form1.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form1.Quota = 196;

            CompleteForm form2 = new CompleteForm();
            form2.Name = "Ͱ���㺸";
            form2.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form2.Quota = 98;

            CompleteForm form3 = new CompleteForm();
            form3.Name = "Ͱ���캸";
            form3.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form3.Quota = 196;

            List<CompleteForm> data = new List<CompleteForm>();
            data.Add(form1);
            data.Add(form2);
            data.Add(form3);

            this.wgvComplete.DisplayColumns = "Name,Production,Quota,Workload";
            this.wgvComplete.DataSource = data;
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WorkTeamDailyWorkloadInfo info)
        {
            info.WorkTeamId = luWorkTeam.GetSelectedId();
            info.AttendanceDate = txtAttendanceDate.DateTime;
            info.ProductionHours = txtProductionHours.Value;

            info.PersonCount = Convert.ToInt32(txtPersonCount.Value);
            info.Remark = txtRemark.Text;

            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }
        #endregion //Function

        #region Method

        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamDailyWorkloadInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            if (string.IsNullOrEmpty(this.luWorkTeam.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("��ѡ�����");
                result = false;
            }
            else if (this.txtAttendanceDate.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtAttendanceDate.Focus();
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

            this.Text = "�༭�����չ�����";

            if (!string.IsNullOrEmpty(ID))
            {
                WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);
                if (info != null)
                {                    
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                   // txtWorkTeamId.Text = info.WorkTeamId;
                    txtAttendanceDate.SetDateTime(info.AttendanceDate);
                    txtProductionHours.Value = info.ProductionHours;
                    txtPersonCount.Value = info.PersonCount;
                    txtRemark.Text = info.Remark;
                 
                }

                //this.btnOK.Enabled = HasFunction("WorkTeamDailyWorkload/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkTeamDailyWorkload/Add");  
            }

            GenerateComplete();

            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WorkTeamDailyWorkloadInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Insert(info);
                if (succeed)
                {
                    //������������������

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

            WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Update(info, info.Id);
                    if (succeed)
                    {
                        //������������������
                       
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
        private void txtAttendanceDate_EditValueChanged(object sender, EventArgs e)
        {
            GenerateList(this.txtAttendanceDate.DateTime);
        }
        
        /// <summary>
        /// �깤��ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvComplete.SelectedIndex != -1)
            {
                GenerateComplete();
            }
        }
        #endregion //Event
    }

    public class CompleteForm
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public decimal Production { get; set; }

        /// <summary>
        /// �Ƽ�����
        /// </summary>
        public decimal Quota { get; set; }

        /// <summary>
        /// ���������ʱ
        /// </summary>
        public decimal Workload { get; set; }
    }
}
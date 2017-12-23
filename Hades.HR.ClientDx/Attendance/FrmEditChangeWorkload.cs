using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
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
    /// �༭������ʱ����
    /// </summary>
    public partial class FrmEditChangeWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// ��ػ�����ID
        /// </summary>
        private string changeId = "";

        /// <summary>
        /// ���滻��������ϸ
        /// </summary>
        private List<ChangeDetails> changeDetails = new List<ChangeDetails>();

        /// <summary>
        /// ���滻������
        /// </summary>
        public List<ReplaceMachineManHoursInfo> replaceInfo;

        /// <summary>
        /// �ݴ滻����ʱ����
        /// </summary>
        private List<LaborChangeWorkloadInfo> laborChanges = new List<LaborChangeWorkloadInfo>();

        /// <summary>
        /// ����Ա���չ�����
        /// </summary>
        private List<LaborDailyWorkloadInfo> laborWorkloads = new List<LaborDailyWorkloadInfo>();
        
        /// <summary>
        /// ����ְԱ����
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditChangeWorkload()
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
        /// �����깤����
        /// </summary>
        private void GenerateChangeDetails()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            this.changeId = Guid.NewGuid().ToString();

            ChangeDetails details1 = new ChangeDetails();
            details1.Name = "��������";
            details1.Quota = 8m;
            details1.Number = random.Next(1, 8);
            details1.Workload = Math.Round(details1.Quota * details1.Number / 60, 2);
           
            ChangeDetails details2 = new ChangeDetails();
            details2.Name = "��������10mm����";
            details2.Quota = 8m;
            details2.Number = random.Next(1, 7);
            details2.Workload = Math.Round(details2.Quota * details2.Number / 60, 2);

            ChangeDetails details3 = new ChangeDetails();
            details3.Name = "��1ֻ������";
            details3.Quota = 10m;
            details3.Number = random.Next(1, 5);
            details3.Workload = Math.Round(details3.Quota * details3.Number / 60, 2);

            ChangeDetails details4 = new ChangeDetails();
            details4.Name = "��1ֻ�����";
            details4.Quota = 10m;
            details4.Number = random.Next(1, 9);
            details4.Workload = Math.Round(details4.Quota * details4.Number / 60, 2);

            changeDetails.Add(details1);
            changeDetails.Add(details2);
            changeDetails.Add(details3);
            changeDetails.Add(details4);
        }

        /// <summary>
        /// ���뻻������
        /// </summary>
        private void LoadChangeDetails()
        {
            string sql = string.Format("WorkTeamId = '{0}' AND WorkingDate = '{1}'", this.tempInfo.WorkTeamId, this.tempInfo.AttendanceDate);
            this.replaceInfo = CallerFactory<IReplaceMachineManHoursService>.Instance.Find(sql);
        }

        /// <summary>
        /// ��ʾ������¼
        /// </summary>
        private void DisplayDetails()
        {
            this.wgvChange.DisplayColumns = "Name,Quota,Number,Workload";

            this.wgvChange.AddColumnAlias("Name", "����");
            this.wgvChange.AddColumnAlias("Quota", "��׼����(m)");
            this.wgvChange.AddColumnAlias("Number", "����");
            this.wgvChange.AddColumnAlias("Workload", "������ʱ(h)");

            var data = this.changeDetails;
            this.wgvChange.DataSource = data;
        }

        /// <summary>
        /// ����Ա����ػ�����ʱ
        /// </summary>
        private void LoadLaborChanges(string changeId)
        {
            var data = CallerFactory<ILaborChangeWorkloadService>.Instance.Find(string.Format("ChangeId = '{0}'", changeId));

            this.laborChanges.AddRange(data);
        }

        /// <summary>
        /// ��ʾԱ����������
        /// </summary>
        private void DisplayLaborChange()
        {
            if (this.laborChanges.Count == 0)
            {
                var staffs = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", this.ID));

                List<LaborChangeWorkloadInfo> data = new List<LaborChangeWorkloadInfo>();
                foreach (var item in staffs)
                {
                    LaborChangeWorkloadInfo info = new LaborChangeWorkloadInfo();
                    info.ChangeId = changeId;
                    info.WorkTeamId = this.tempInfo.WorkTeamId;
                    info.StaffId = item.StaffId;

                    data.Add(info);
                }

                this.bsLaborWorkload.DataSource = data;
            }
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WorkTeamDailyWorkloadInfo info)
        {
            //info.WorkTeamId = txtWorkTeamId.Text;
            //info.StaffId = txtStaffId.Text;
            //info.ChangeHours = txtChangeHours.Value;
            //info.AssignType = Convert.ToInt32(txtAssignType.Value);
            //info.Remark = txtRemark.Text;
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
                WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);
              
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(info.WorkTeamId);
                    this.txtWorkTeamName.Text = workTeam.Name;
                    this.txtAttendanceDate.Text = info.AttendanceDate.ToString("yyyy-MM-dd");

                    this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");

                    GenerateChangeDetails();
                    DisplayDetails();

                    this.spChangeHours.Value = this.changeDetails.Sum(r => r.Workload);

                    this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                    LoadLaborChanges(this.changeId);
                    DisplayLaborChange();
                }

                //this.btnOK.Enabled = HasFunction("LaborChangeWorkload/Edit");             
            }
            else
            {

                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborChangeWorkload/Add");  
            }

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

                //bool succeed = CallerFactory<ILaborChangeWorkloadService>.Instance.Insert(info);
                //if (succeed)
                //{
                //    //�����������������

                //    return true;
                //}
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
                try
                {
                    this.laborChanges = this.bsLaborWorkload.DataSource as List<LaborChangeWorkloadInfo>;

                    info.ChangeHours = this.changeDetails.Sum(r => r.Workload);

                    if (laborChanges.Sum(r => r.ChangeHours) > info.ChangeHours)
                    {
                        MessageDxUtil.ShowWarning("���任����ʱ��������");
                        return false;
                    }

                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Update(info, info.Id);

                    foreach (var item in this.laborChanges)
                    {
                        // ���ӻ�����ʱ����
                        CallerFactory<ILaborChangeWorkloadService>.Instance.Insert(item);
                    }

                    foreach (var item in this.laborWorkloads)
                    {
                        var hours = this.laborChanges.Where(r => r.StaffId == item.StaffId).Sum(r => r.ChangeHours);
                        item.ChangeHours = hours;

                        CallerFactory<ILaborDailyWorkloadService>.Instance.Update(item, item.Id);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
           return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!(ActiveControl is Button))
            {
                if (keyData == Keys.Down || keyData == Keys.Enter)
                {
                    return false;
                }
                else if (keyData == Keys.Up)
                {
                    return false;
                }

                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ��ʽ��������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "StaffId")
            {
                if (e.Value != null)
                {
                    var s = this.staffs.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Name;
                }
            }
        }

        /// <summary>
        /// �Զ���������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsLaborWorkload.Count)
                return;

            var record = this.bsLaborWorkload[rowIndex] as LaborChangeWorkloadInfo;

            if (e.Column.FieldName == "StaffNumber" && e.IsGetData)
            {
                var s = this.staffs.SingleOrDefault(r => r.Id == record.StaffId);
                if (s == null)
                    e.Value = "";
                else
                    e.Value = s.Number;
            }
        }
        #endregion //Event
    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class ChangeDetails
    {
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��׼����
        /// </summary>
        public decimal Quota { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public decimal Number { get; set; }

        /// <summary>
        /// ��ʱ
        /// </summary>
        public decimal Workload { get; set; }
    }
}

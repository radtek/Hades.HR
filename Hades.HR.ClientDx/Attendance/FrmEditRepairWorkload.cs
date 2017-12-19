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
    /// �༭���޹�ʱ����
    /// </summary>
    public partial class FrmEditRepairWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// ������޵�
        /// </summary>
        public MachineMaintenanceManHoursInfo machineInfo;

        /// <summary>
        /// �ݴ���޹�ʱ����
        /// </summary>
        private List<LaborRepairWorkloadInfo> laborRepairs = new List<LaborRepairWorkloadInfo>();

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
        public FrmEditRepairWorkload()
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
        /// ���ɻ�������
        /// </summary>
        private void GenerateRepair()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            machineInfo.ID = Guid.NewGuid().ToString();
            machineInfo.ManHours = Convert.ToInt32(Math.Round(Convert.ToDecimal(random.NextDouble() * 10), 2));
        }

        /// <summary>
        /// ������޵�
        /// </summary>
        private void LoadMachineInfo()
        {
            string sql = string.Format("WorkTeamId = '{0}' AND WorkingDate = '{1}'", this.tempInfo.WorkTeamId, this.tempInfo.AttendanceDate);
            this.machineInfo = CallerFactory<IMachineMaintenanceManHoursService>.Instance.FindSingle(sql);
        }

        /// <summary>
        /// �����Ѵ�Ա����ػ��޹�ʱ
        /// </summary>
        /// <param name="repairId"></param>
        private void LoadLaborRepair(string repairId)
        {
            var data = CallerFactory<ILaborRepairWorkloadService>.Instance.Find(string.Format("RepairId = '{0}'", repairId));
            this.laborRepairs.AddRange(data);
        }

        /// <summary>
        /// ��ʾԱ����������
        /// </summary>
        private void DisplayLaborRepair()
        {
            if (this.laborRepairs.Count == 0)
            {
                var staffs = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", this.ID));

                List<LaborRepairWorkloadInfo> data = new List<LaborRepairWorkloadInfo>();
                foreach (var item in staffs)
                {
                    LaborRepairWorkloadInfo info = new LaborRepairWorkloadInfo();
                    info.RepairId = this.machineInfo.ID;
                    info.WorkTeamId = this.tempInfo.WorkTeamId;
                    info.StaffId = item.StaffId;
                    info.AttendanceDate = this.tempInfo.AttendanceDate;

                    data.Add(info);
                }

                this.bsLaborWorkload.DataSource = data;
            }
            else
            {
                this.bsLaborWorkload.DataSource = this.laborRepairs;
            }
        }

        /// <summary>
        /// ���㹤ʱ
        /// </summary>
        private void CalculateHours()
        {
            decimal totalHours = this.machineInfo.ManHours;

            var selected = this.dgvStaff.GetSelectedRows();
            if (selected.Length == 0)
                return;

            var one = Math.Round(totalHours / selected.Length, 3);

            for (int i = 0; i < this.dgvStaff.RowCount; i++)
            {
                int dsIndex = this.dgvStaff.GetDataSourceRowIndex(i);
                var workload = this.bsLaborWorkload[dsIndex] as LaborRepairWorkloadInfo;
                if (dgvStaff.IsRowSelected(i))
                {
                    workload.RepairHours = one;
                }
                else
                {
                    workload.RepairHours = 0;
                }
            }

            this.dgvStaff.RefreshData();
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

                    // GenerateRepair();

                    LoadMachineInfo();

                    if (this.machineInfo != null)
                    {
                        this.spRepairHours.Value = this.machineInfo.ManHours; ;
                        this.txtRemark.Text = this.machineInfo.Remark;

                        this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                        LoadLaborRepair(this.machineInfo.ID);

                        DisplayLaborRepair();
                    }
                    else
                    {
                        this.spRepairHours.Value = 0;
                        this.txtRemark.Text = "";
                    }
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
                //bool succeed = CallerFactory<ILaborChangeWorkloadService>.Instance.Insert(info);
                //if (succeed)
                //{
                //    //�����������������

                //    return true;
                //}
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
                    this.laborRepairs = this.bsLaborWorkload.DataSource as List<LaborRepairWorkloadInfo>;
                    info.RepairHours = this.machineInfo.ManHours;

                    if (this.laborRepairs.Sum(r => r.RepairHours) == 0)
                    {
                        MessageDxUtil.ShowWarning("���޹�ʱδ����");
                        return false;
                    }

                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.SaveRepair(this.ID, this.machineInfo.ManHours, laborRepairs);
                       
                    return succeed;
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

            var record = this.bsLaborWorkload[rowIndex] as LaborRepairWorkloadInfo;

            if (e.Column.FieldName == "StaffNumber" && e.IsGetData)
            {
                var s = this.staffs.SingleOrDefault(r => r.Id == record.StaffId);
                if (s == null)
                    e.Value = "";
                else
                    e.Value = s.Number;
            }
        }

        /// <summary>
        /// Ա��ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            CalculateHours();
        }
        #endregion //Event
    }
}

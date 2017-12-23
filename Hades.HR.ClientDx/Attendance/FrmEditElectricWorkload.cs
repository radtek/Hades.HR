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
    public partial class FrmEditElectricWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// ������޵�
        /// </summary>
        public ElectricMaintenanceManHoursInfo electricInfo;

        /// <summary>
        /// �ݴ���޹�ʱ����
        /// </summary>
        private List<LaborElectricWorkloadInfo> laborElectric = new List<LaborElectricWorkloadInfo>();

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
        public FrmEditElectricWorkload()
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
        /// ���ɵ�������
        /// </summary>
        private void GenerateElectric()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            electricInfo.ID = Guid.NewGuid().ToString();
            electricInfo.ManHours = Convert.ToInt32(Math.Round(Convert.ToDecimal(random.NextDouble() * 10), 2));
        }

        /// <summary>
        /// ������޵�
        /// </summary>
        private void LoadElectric()
        {
            string sql = string.Format("WorkTeamId = '{0}' AND WorkingDate = '{1}'", this.tempInfo.WorkTeamId, this.tempInfo.AttendanceDate);
            this.electricInfo = CallerFactory<IElectricMaintenanceManHoursService>.Instance.FindSingle(sql);
        }

        /// <summary>
        /// �����Ѵ�Ա����ص��޹�ʱ
        /// </summary>
        /// <param name="electricId"></param>
        private void LoadLaborElectric(string electricId)
        {
            var data = CallerFactory<ILaborElectricWorkloadService>.Instance.Find(string.Format("ElectricId = '{0}'", electricId));
            this.laborElectric.AddRange(data);
        }

        /// <summary>
        /// ��ʾԱ���������
        /// </summary>
        private void DisplayLaborRepair()
        {
            if (this.laborElectric.Count == 0)
            {
                var staffs = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", this.ID));

                List<LaborElectricWorkloadInfo> data = new List<LaborElectricWorkloadInfo>();
                foreach (var item in staffs)
                {
                    LaborElectricWorkloadInfo info = new LaborElectricWorkloadInfo();
                    info.ElectricId = this.electricInfo.ID;
                    info.WorkTeamId = this.tempInfo.WorkTeamId;
                    info.StaffId = item.StaffId;

                    data.Add(info);
                }

                this.bsLaborWorkload.DataSource = data;
            }
            else
            {
                this.bsLaborWorkload.DataSource = this.laborElectric;

                this.dgvStaff.SelectionChanged -= new DevExpress.Data.SelectionChangedEventHandler(this.dgvStaff_SelectionChanged);
                for (int i = 0; i < laborElectric.Count; i++)
                {
                    if (this.laborElectric[i].ElectricHours != 0)
                    {
                        this.dgvStaff.SelectRow(i);
                    }
                }

                this.dgvStaff.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.dgvStaff_SelectionChanged);
            }
        }

        /// <summary>
        /// ���㹤ʱ
        /// </summary>
        private void CalculateHours()
        {
            decimal totalHours = this.electricInfo.ManHours;

            var selected = this.dgvStaff.GetSelectedRows();
            if (selected.Length == 0)
                return;

            var one = Math.Round(totalHours / selected.Length, 3);

            for (int i = 0; i < this.dgvStaff.RowCount; i++)
            {
                int dsIndex = this.dgvStaff.GetDataSourceRowIndex(i);
                var workload = this.bsLaborWorkload[dsIndex] as LaborElectricWorkloadInfo;
                if (dgvStaff.IsRowSelected(i))
                {
                    workload.ElectricHours = one;
                }
                else
                {
                    workload.ElectricHours = 0;
                }
            }

            this.dgvStaff.RefreshData();
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

                    LoadElectric();

                    if (this.electricInfo != null)
                    {
                        this.spElectricHours.Value = this.electricInfo.ManHours;
                        this.txtRemark.Text = this.electricInfo.Remark;

                        this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                        LoadLaborElectric(this.electricInfo.ID);

                        DisplayLaborRepair();
                    }
                    else
                    {
                        this.spElectricHours.Value = 0;
                        this.txtRemark.Text = "";
                    }
                }

                //this.btnOK.Enabled = HasFunction("LaborChangeWorkload/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborChangeWorkload/Add");  
            }
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
                    if (this.electricInfo == null)
                    {
                        MessageDxUtil.ShowWarning("�����޵��޹�ʱ");
                        return false;
                    }

                    this.laborElectric = this.bsLaborWorkload.DataSource as List<LaborElectricWorkloadInfo>;
                    info.ElectricHours = this.electricInfo.ManHours;

                    if (this.laborElectric.Sum(r => r.ElectricHours) == 0)
                    {
                        MessageDxUtil.ShowWarning("���޹�ʱδ����");
                        return false;
                    }

                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.SaveElectric(this.ID, this.electricInfo.ManHours, laborElectric);

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

            var record = this.bsLaborWorkload[rowIndex] as LaborElectricWorkloadInfo;

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

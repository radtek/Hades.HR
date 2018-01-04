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
        private void DisplayChangeDetails()
        {
            this.wgvChange.DisplayColumns = "ItemId,Amount,ManHour";

            this.wgvChange.AddColumnAlias("ItemId", "����");
            this.wgvChange.AddColumnAlias("Amount", "����");
            this.wgvChange.AddColumnAlias("ManHour", "������ʱ(h)");

            var data = this.replaceInfo;
            this.wgvChange.DataSource = data;
        }

        /// <summary>
        /// ����Ա����ػ�����ʱ
        /// </summary>
        private void LoadLaborChanges()
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
                                        
                    LoadChangeDetails();

                    if (this.replaceInfo.Count > 0)
                    {
                        this.spChangeHours.Value = this.replaceInfo.Sum(r => r.ManHours);
                        this.txtRemark.Text = "";

                        this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                        DisplayChangeDetails();
                        // LoadLaborChanges(this.changeId);
                        DisplayLaborChange();
                    }
                    else
                    {
                        this.spChangeHours.Value = 0;
                        this.txtRemark.Text = "";
                    }

                    //DisplayDetails();

                  
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
                    this.laborChanges = this.bsLaborWorkload.DataSource as List<LaborChangeWorkloadInfo>;

                    info.ChangeHours = this.replaceInfo.Sum(r => r.ManHours);

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

        private void btnSaveAssign_Click(object sender, EventArgs e)
        {

        }

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
}

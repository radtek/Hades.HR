using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
    public partial class FrmEditLeaveWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// �ݴ���ٹ�ʱ����
        /// </summary>
        private List<LaborLeaveWorkloadInfo> laborLeave = new List<LaborLeaveWorkloadInfo>();

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
        public FrmEditLeaveWorkload()
        {
            InitializeComponent();
            InitAuthorizedUI();
        }
        #endregion //Constructor
        
        #region initialize
        public override void FormOnLoad()
        {
            InitDictItem();//�����ֵ����
            base.FormOnLoad();
        }

        private string controlID = "LaborLeaveWorkload"; //ACL ControlID

        /// <summary>
        /// ����Ȩ�����ι���
        /// </summary>
        private void InitAuthorizedUI()
        {
            //this.btnAdd.Visible = HasFunction(controlID+"/Add");
        }

        /// <summary>
        /// ��ʼ�������ֵ�
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������
        }

        #endregion

        #region Data Display
        /// <summary>
        /// �����Ѵ�Ա�������ٹ�ʱ
        /// </summary>
        private void LoadLaborLeave()
        {
            var data = CallerFactory<ILaborLeaveWorkloadService>.Instance.Find(string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}'", tempInfo.WorkTeamId, tempInfo.AttendanceDate));
            this.laborLeave.AddRange(data);
        }

        /// <summary>
        /// ��ʾԱ���������
        /// </summary>
        private void DisplayLaborLeave()
        {
            if (this.laborLeave.Count == 0)
            {
                var staffs = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", this.ID));

                List<LaborLeaveWorkloadInfo> data = new List<LaborLeaveWorkloadInfo>();
                foreach (var item in staffs)
                {
                    LaborLeaveWorkloadInfo info = new LaborLeaveWorkloadInfo();                    
                    info.WorkTeamId = this.tempInfo.WorkTeamId;
                    info.StaffId = item.StaffId;
                    info.AttendanceDate = this.tempInfo.AttendanceDate;

                    data.Add(info);
                }

                this.bsLaborWorkload.DataSource = data;
            }
            else
            {
                this.bsLaborWorkload.DataSource = this.laborLeave;
            }
        }

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
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
                                        
                    this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                    LoadLaborLeave();
                    DisplayLaborLeave();
                }
            }
            else
            {

                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborLeaveWorkload/Add");  
            }
        }      

        /// <summary>
        /// �������
        /// </summary>
        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamDailyWorkloadInfo();
            base.ClearScreen();
        }
        #endregion

        #region Save Data

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
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborLeaveWorkloadInfo info)
        {
            //info.WorkTeamId = txtWorkTeamId.Text;
            //info.AttendanceDate = txtAttendanceDate.DateTime;
            //info.StaffId = txtStaffId.Text;
            //info.LeaveHours = txtLeaveHours.Value;
            //info.AllowanceHours = txtAllowanceHours.Value;
            //info.AssignType = Convert.ToInt32(txtAssignType.Value);
            //info.Remark = txtRemark.Text;
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
                    this.laborLeave = this.bsLaborWorkload.DataSource as List<LaborLeaveWorkloadInfo>;
                    if (laborLeave.Sum(r => r.LeaveHours) != laborLeave.Sum(r => r.AllowanceHours))
                    {
                        MessageDxUtil.ShowWarning("��ٿ۳���ʱ�Ͳ�����ʱ����");
                        return false;
                    }   
                                     
                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.SaveLeave(this.ID, this.laborLeave);
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
        #endregion
    }
}

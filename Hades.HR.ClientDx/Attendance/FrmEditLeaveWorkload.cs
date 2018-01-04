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
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// 暂存请假工时数据
        /// </summary>
        private List<LaborLeaveWorkloadInfo> laborLeave = new List<LaborLeaveWorkloadInfo>();

        /// <summary>
        /// 缓存员工日工作量
        /// </summary>
        private List<LaborDailyWorkloadInfo> laborWorkloads = new List<LaborDailyWorkloadInfo>();

        /// <summary>
        /// 缓存职员数据
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
            InitDictItem();//数据字典加载
            base.FormOnLoad();
        }

        private string controlID = "LaborLeaveWorkload"; //ACL ControlID

        /// <summary>
        /// 根据权限屏蔽功能
        /// </summary>
        private void InitAuthorizedUI()
        {
            //this.btnAdd.Visible = HasFunction(controlID+"/Add");
        }

        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
        }

        #endregion

        #region Data Display
        /// <summary>
        /// 载入已存员工相关请假工时
        /// </summary>
        private void LoadLaborLeave()
        {
            var data = CallerFactory<ILaborLeaveWorkloadService>.Instance.Find(string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}'", tempInfo.WorkTeamId, tempInfo.AttendanceDate));
            this.laborLeave.AddRange(data);
        }

        /// <summary>
        /// 显示员工请假数据
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
                    info.AssignType = 1;

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
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            if (!string.IsNullOrEmpty(ID))
            {
                WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);

                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

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
        /// 清空输入
        /// </summary>
        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamDailyWorkloadInfo();
            base.ClearScreen();
        }
        #endregion

        #region Save Data

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过
            
            return result;
        }

        /// <summary>
        /// 编辑状态下的数据保存
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
                        MessageDxUtil.ShowWarning("请假扣除工时和补贴工时不等");
                        return false;
                    }   
                                     
                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.SaveLeave(this.ID, this.laborLeave);
                    if (succeed)
                    {
                        //可添加其他关联操作

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

        #region Event
        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvLeave_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvLeave_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsLaborWorkload.Count)
                return;

            var record = this.bsLaborWorkload[rowIndex] as LaborLeaveWorkloadInfo;

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

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
    public partial class FrmSetDailyLabor : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 临时对象
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// 考勤日期
        /// </summary>
        private DateTime attendanceDate;

        /// <summary>
        /// 当前关联班组
        /// </summary>
        private string currentWorkTeamId;

        /// <summary>
        /// 班组日工作量记录ID
        /// </summary>
        private string dailyWorkloadId = "";
        #endregion //Field

        #region Constructor
        public FrmSetDailyLabor()
        {
            InitializeComponent();
        }

        public FrmSetDailyLabor(DateTime attendanceDate, string workTeamId)
        {
            this.attendanceDate = attendanceDate;
            this.currentWorkTeamId = workTeamId;

            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
        }

        /// <summary>
        /// 载入班组默认员工
        /// </summary>
        private void LoadDefaultStaff()
        {
            var staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("WorkTeamId='{0}' AND Enabled=1 AND Deleted=0", this.currentWorkTeamId));

            this.bsStaff.DataSource = staffs;
        }

        /// <summary>
        /// 载入选择员工
        /// </summary>
        private void LoadDailyStaff()
        {
            var staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("WorkTeamId='{0}' AND Enabled=1 AND Deleted=0", this.currentWorkTeamId));

            this.bsStaff.DataSource = staffs;
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborDailyAttendanceInfo info)
        {
            //info.WorkTeamId = txtWorkTeamId.Text;
            //info.AttendanceDate = txtAttendanceDate.Text;
            //info.StaffId = txtStaffId.Text;
            //info.StaffLevelId = txtStaffLevelId.Text;
            //info.AbsentType = Convert.ToInt32(txtAbsentType.Value);
            //info.TotalHours = txtTotalHours.Value;
            //info.IsWeekend = txtIsWeekend.Text.ToBoolean();
            //info.IsHoliday = txtIsHoliday.Text.ToBoolean();
            //info.Remark = txtRemark.Text;
        }

        /// <summary>
        /// 设置选择员工
        /// </summary>
        private List<LaborDailyWorkloadInfo> SetSelectStaff(WorkTeamDailyWorkloadInfo wt)
        {
            var indexs = this.dgvStaff.GetSelectedRows();

            List<LaborDailyWorkloadInfo> data = new List<LaborDailyWorkloadInfo>();
            for (int i = 0; i < indexs.Length; i++)
            {
                int dsIndex = this.dgvStaff.GetDataSourceRowIndex(indexs[i]);
                var staff = this.bsStaff[dsIndex] as StaffInfo;

                LaborDailyWorkloadInfo info = new LaborDailyWorkloadInfo();
                info.WorkTeamWorkloadId = wt.Id;
                info.WorkTeamId = wt.WorkTeamId;
                info.ActualWorkTeamId = staff.WorkTeamId;
                info.StaffId = staff.Id;
                info.AttendanceDate = wt.AttendanceDate;

                data.Add(info);
            }

            return data;
        }
        #endregion //Function

        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamDailyWorkloadInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            WorkTeamInfo workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(this.currentWorkTeamId);
            this.txtWorkTeamName.Text = workTeam.Name;
            this.txtAttendanceDate.Text = this.attendanceDate.ToString("yyyy-MM-dd");

            this.tempInfo = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindSingle(string.Format("WorkTeamId='{0}' AND AttendanceDate='{1}'", currentWorkTeamId, attendanceDate));
            if (tempInfo == null)
            {
                LoadDefaultStaff();
            }
            else
            {
                this.dailyWorkloadId = tempInfo.Id;

                LoadDailyStaff();
            }

        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                if (string.IsNullOrEmpty(dailyWorkloadId))  //新增
                {
                    WorkTeamDailyWorkloadInfo info = new WorkTeamDailyWorkloadInfo();
                    info.Id = Guid.NewGuid().ToString();
                    info.WorkTeamId = this.currentWorkTeamId;
                    info.AttendanceDate = this.attendanceDate;
                    info.Editor = this.LoginUserInfo.Name;
                    info.EditorId = this.LoginUserInfo.ID;
                    info.EditTime = DateTime.Now;

                    var data = SetSelectStaff(info);
                    info.PersonCount = data.Count;

                    CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Insert(info);

                    foreach (var item in data)
                    {
                        CallerFactory<ILaborDailyWorkloadService>.Instance.Insert(item);
                    }
                }
                else
                {

                }

                return true;
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }

            return false;
        }
        #endregion //Method
    }
}

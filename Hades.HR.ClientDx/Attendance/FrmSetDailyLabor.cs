using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
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
            List<StaffInfo> staffs = new List<StaffInfo>();
           
            var team = CallerFactory<IStaffService>.Instance.Find(string.Format("WorkTeamId='{0}' AND Enabled=1 AND Deleted=0", this.currentWorkTeamId));
            staffs.AddRange(team);                      

            this.bsStaff.DataSource = staffs;
            this.bsStaff.ResetBindings(false);

            var selected = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId = '{0}'", this.dailyWorkloadId));

            foreach (var item in selected)
            {
                int index = this.dgvStaff.GetRowHandle(staffs.FindIndex(r => r.Id == item.StaffId));
               
                this.dgvStaff.SelectRow(index);
            }
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
                    info.Remark = this.txtRemark.Text;
                    info.Editor = this.LoginUserInfo.Name;
                    info.EditorId = this.LoginUserInfo.ID;
                    info.EditTime = DateTime.Now;

                    var data = SetSelectStaff(info);

                    bool result = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.SetDailyLabor(info, data);
                    if (result)
                        return true;
                }
                else
                {
                    WorkTeamDailyWorkloadInfo info = tempInfo;
                  
                    info.WorkTeamId = this.currentWorkTeamId;
                    info.AttendanceDate = this.attendanceDate;
                    info.Remark = this.txtRemark.Text;
                    info.Editor = this.LoginUserInfo.Name;
                    info.EditorId = this.LoginUserInfo.ID;
                    info.EditTime = DateTime.Now;

                    var data = SetSelectStaff(info);

                    bool result = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.SetDailyLabor(info, data);
                    if (result)
                        return true;
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }

            MessageDxUtil.ShowError("保存失败");
            return false;
        }
        #endregion //Method
    }
}

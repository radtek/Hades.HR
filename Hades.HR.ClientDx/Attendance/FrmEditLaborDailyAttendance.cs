using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Hades.Pager.Entity;
using Hades.Dictionary;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;

using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Facade;
using Hades.HR.Entity;
using Hades.HR.Util;


namespace Hades.HR.UI
{
    public partial class FrmEditLaborDailyAttendance : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 关联班组ID
        /// </summary>
        private string workTeamId;

        /// <summary>
        /// 考勤日期
        /// </summary>
        private DateTime attendanceDate;

        /// <summary>
        /// 关联班组
        /// </summary>
        private WorkTeamInfo workTeam;

        /// <summary>
        /// 缓存职员
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditLaborDailyAttendance(string workTeamId, DateTime attendanceDate)
        {
            InitializeComponent();
            this.workTeamId = workTeamId;
            this.attendanceDate = attendanceDate;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
            this.repoAbsent.Items.AddEnum(typeof(AbsentType), true);
        }

        /// <summary>
        /// 载入考勤数据
        /// </summary>
        private void LoadAttendance()
        {
            string sql = string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}'", this.workTeamId, this.attendanceDate);
            var data = CallerFactory<ILaborDailyAttendanceService>.Instance.Find(sql);

            if (data.Count > 0)
                this.bsLabor.DataSource = data;
            else
            {
                string sql2 = string.Format("ActualWorkTeamId = '{0}' AND AttendanceDate = '{1}'", this.workTeamId, this.attendanceDate);
                var workloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(sql2);

                var temp = this.staffs.Where(r => r.WorkTeamId == workTeamId & r.Enabled == 1 & r.Deleted == 0);
                foreach (var item in temp)
                {
                    LaborDailyAttendanceInfo info = new LaborDailyAttendanceInfo();
                    info.StaffId = item.Id;
                    info.WorkTeamId = item.WorkTeamId;
                    info.AttendanceDate = this.attendanceDate;

                    var wl = workloads.SingleOrDefault(r => r.StaffId == item.Id);
                    if (wl != null)
                    {
                        info.WorkHours = wl.ProductionHours + wl.ChangeHours + wl.RepairHours + wl.ElectricHours - wl.LeaveHours
                            + wl.AllowanceHours + wl.AuditHours;
                    }
                    else
                        info.WorkHours = 0;

                    data.Add(info);
                }

                this.bsLabor.DataSource = data;
            }
        }

        private List<LaborDailyAttendanceInfo> SetAttendance()
        {
            var data = this.bsLabor.DataSource as List<LaborDailyAttendanceInfo>;

            return data;
        }
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            this.Text = "员工日考勤";

            this.workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(this.workTeamId);

            this.txtWorkTeamName.Text = workTeam.Name;
            this.txtAttendanceDate.Text = attendanceDate.ToString("yyyy-MM-dd");

            this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");

            LoadAttendance();

            base.FormOnLoad();
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                var attendance = this.bsLabor.DataSource as List<LaborDailyAttendanceInfo>;

                var result = CallerFactory<ILaborDailyAttendanceService>.Instance.SaveAttendance(this.workTeamId, this.attendanceDate, attendance);

                return result;
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);

                return false;
            }
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvLabor_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            else if (columnName == "WorkTeamId")
            {
                if (e.Value != null)
                {
                    e.DisplayText = this.workTeam.Name;
                }
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvLabor_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsLabor.Count)
                return;

            var record = this.bsLabor[rowIndex] as LaborDailyAttendanceInfo;

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
        /// 选择周末
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsWeekend_CheckedChanged(object sender, EventArgs e)
        {
            var data = this.bsLabor.DataSource as List<LaborDailyAttendanceInfo>;
            foreach (var item in data)
            {
                item.IsWeekend = this.chkIsWeekend.Checked;
            }
            this.bsLabor.ResetBindings(false);
        }

        /// <summary>
        /// 选择节假日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsHoliday_CheckedChanged(object sender, EventArgs e)
        {
            var data = this.bsLabor.DataSource as List<LaborDailyAttendanceInfo>;
            foreach (var item in data)
            {
                item.IsHoliday = this.chkIsHoliday.Checked;
            }
            this.bsLabor.ResetBindings(false);
        }
        #endregion //Event
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    /// 编辑考勤记录
    /// </summary>
    public partial class FrmAttendanceRecordEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 月度考勤ID
        /// </summary>
        private string attendanceId;

        /// <summary>
        /// 部门ID
        /// </summary>
        private string departmentId;

        /// <summary>
        /// 相关职员
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmAttendanceRecordEdit(string attendanceId, string departmentId)
        {
            InitializeComponent();

            this.attendanceId = attendanceId;
            this.departmentId = departmentId;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化职员考勤记录
        /// </summary>
        /// <returns></returns>
        private List<AttendanceRecordInfo> InitRecords()
        {
            var data = CallerFactory<IAttendanceRecordService>.Instance.Find(string.Format("AttendanceId='{0}'", attendanceId));

            this.staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("DepartmentId='{0}'", departmentId));

            List<AttendanceRecordInfo> records = new List<AttendanceRecordInfo>();

            foreach (var item in staffs)
            {
                var find = data.SingleOrDefault(r => r.StaffId == item.Id);
                if (find != null)
                {
                    records.Add(find);
                }
                else
                {
                    AttendanceRecordInfo info = new AttendanceRecordInfo();
                    info.Id = Guid.NewGuid().ToString();
                    info.AttendanceId = this.attendanceId;
                    info.StaffId = item.Id;

                    records.Add(info);
                }
            }

            return records;
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        private void SaveRecords()
        {
            var records = this.bsAttendanceRecord.DataSource as List<AttendanceRecordInfo>;

            foreach (var item in records)
            {
                item.LeaveDays = item.AnnualLeave + item.SickLeave + item.CasualLeave + item.InjuryLeave + item.MarriageLeave + item.AbsentLeave;
                item.OvertimeSalarySum = item.NormalOvertimeSalary + item.WeekendOvertimeSalary + item.HolidayOvertimeSalary;
                CallerFactory<IAttendanceRecordService>.Instance.InsertUpdate(item, item.Id);
            }
        }
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            var dep = CallerFactory<IDepartmentService>.Instance.FindByID(this.departmentId);
            this.txtDepartmentName.Text = dep.Name;

            var attendance = CallerFactory<IAttendanceService>.Instance.FindByID(this.attendanceId);
            this.txtAttendanceDate.Text = string.Format("{0}年{1}月", attendance.Year, attendance.Month);
            this.txtDays.Text = attendance.Days.ToString();
            this.txtRemark.Text = attendance.Remark;

            var records = InitRecords();
            this.bsAttendanceRecord.DataSource = records;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendance_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "StaffId")
            {
                var s = this.staffs.SingleOrDefault(r => r.Id == e.Value.ToString());
                if (s == null)
                    e.DisplayText = "";
                else
                    e.DisplayText = s.Name;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveRecords();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowWarning(ex.Message);
            }
        }
        #endregion //Event
    }
}

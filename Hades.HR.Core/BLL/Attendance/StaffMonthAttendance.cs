using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.Pager.Entity;
using Hades.Framework.ControlUtil;

namespace Hades.HR.BLL
{
    /// <summary>
    /// StaffMonthAttendance
    /// </summary>
	public class StaffMonthAttendance : BaseBLL<StaffMonthAttendanceInfo>
    {
        #region Constructor
        public StaffMonthAttendance() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取职员考勤记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public List<StaffMonthAttendanceInfo> GetRecords(int year, int month, string departmentId)
        {
            string sql = string.Format("Year = {0} AND Month = {1} AND DepartmentId = '{2}'", year, month, departmentId);

            var records = this.Find(sql);
            if (records.Count != 0)
                return records;

            Staff staffBll = new Staff();

            List<StaffMonthAttendanceInfo> data = new List<StaffMonthAttendanceInfo>();

            var staffs = staffBll.Find("DepartmentId = '{0}' AND Deleted = 0 AND Enabled = 1", departmentId);
            foreach(var staff in staffs)
            {
                StaffMonthAttendanceInfo item = new StaffMonthAttendanceInfo();
                item.Year = year;
                item.Month = month;
                item.StaffId = staff.Id;
                item.DepartmentId = departmentId;

                data.Add(item);
            }

            return data;
        }
        #endregion //Method
    }
}

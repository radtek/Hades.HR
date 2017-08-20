using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.Pager.Entity;
using Hades.Framework.ControlUtil;

namespace Hades.HR.BLL
{
    /// <summary>
    /// LaborAttendanceRecord
    /// </summary>
	public class LaborAttendanceRecord : BaseBLL<LaborAttendanceRecordInfo>
    {
        #region Constructor
        public LaborAttendanceRecord() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 插入班组日考勤记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string InsertRecords(List<LaborAttendanceRecordInfo> data)
        {
            string msg = "";

            foreach (var item in data)
            {
                string sql = string.Format("StaffId = '{0}' AND AttendanceDate = '{1}' AND WorkTeamId != '{2}'", item.StaffId, item.AttendanceDate, item.WorkTeamId);
                var find = base.Find(sql);
                if (find.Count > 0)
                {
                    msg = find.First().StaffId;
                    return msg;
                }
            }

            if (data.Count > 0)
            {
                var attendanceDate = data.First().AttendanceDate;
                var workTeamId = data.First().WorkTeamId;

                base.DeleteByCondition(string.Format("AttendanceDate='{0}' AND WorkTeamId='{1}'", attendanceDate, workTeamId));

                foreach (var item in data)
                {
                    base.Insert(item);
                }
            }

            return msg;
        }
        #endregion //Method
    }
}

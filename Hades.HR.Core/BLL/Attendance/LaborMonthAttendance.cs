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
    /// LaborMonthAttendance
    /// </summary>
	public class LaborMonthAttendance : BaseBLL<LaborMonthAttendanceInfo>
    {
        #region Constructor
        public LaborMonthAttendance() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取班组员工月考勤记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public List<LaborMonthAttendance> GetRecords(int year, int month, string workTeamId)
        {
            List<LaborMonthAttendance> data = new List<LaborMonthAttendance>();


            return data;
        }
        #endregion //Method
    }
}

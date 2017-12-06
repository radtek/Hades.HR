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
    /// LaborDailyWorkload
    /// </summary>
	public class LaborDailyWorkload : BaseBLL<LaborDailyWorkloadInfo>
    {
        #region Constructor
        public LaborDailyWorkload() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 检查员工是否已在其它班组
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="workTeamId">当前班组ID</param>
        /// <param name="laborId">员工ID</param>
        /// <returns></returns>
        public bool CheckLaborDailyExist(DateTime date, string workTeamId, string laborId)
        {
            var labors = this.Find(string.Format("AttendanceDate = '{0}' AND ActualWorkTeamId != '{1}' AND StaffId = '{2}'", date, workTeamId, laborId));
            if (labors.Count > 0)
                return true;
            else
                return false;
        }
        #endregion //Method
    }
}

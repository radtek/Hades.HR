using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WinformCaller
{
    /// <summary>
    /// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
    /// </summary>
    public class LaborDailyAttendanceCaller : BaseLocalService<LaborDailyAttendanceInfo>, ILaborDailyAttendanceService
    {
        #region Field
        private LaborDailyAttendance bll = null;
        #endregion //Field

        #region Constructor
        public LaborDailyAttendanceCaller() : base(BLLFactory<LaborDailyAttendance>.Instance)
        {
            bll = baseBLL as LaborDailyAttendance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 保存员工日考勤记录
        /// </summary>
        /// <param name="workTeamId">班组ID</param>
        /// <param name="attendaceDate">考勤日期</param>
        /// <param name="data">考勤记录</param>
        /// <returns></returns>
        public bool SaveAttendance(string workTeamId, DateTime attendaceDate, List<LaborDailyAttendanceInfo> data)
        {
            return bll.SaveAttendance(workTeamId, attendaceDate, data);
        }
        #endregion //Method
    }
}

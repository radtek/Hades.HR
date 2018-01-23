using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
    public class StaffMonthAttendanceCaller : BaseLocalService<StaffMonthAttendanceInfo>, IStaffMonthAttendanceService
    {
        #region Field
        private StaffMonthAttendance bll = null;
        #endregion //Field

        #region Constructor
        public StaffMonthAttendanceCaller() : base(BLLFactory<StaffMonthAttendance>.Instance)
        {
            bll = baseBLL as StaffMonthAttendance;
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
            return bll.GetRecords(year, month, departmentId);
        }
        #endregion //Method
    }
}

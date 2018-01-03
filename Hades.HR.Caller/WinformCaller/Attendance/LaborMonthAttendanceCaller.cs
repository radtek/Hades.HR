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
    public class LaborMonthAttendanceCaller : BaseLocalService<LaborMonthAttendanceInfo>, ILaborMonthAttendanceService
    {
        #region Field
        private LaborMonthAttendance bll = null;
        #endregion //Field

        #region Constructor
        public LaborMonthAttendanceCaller() : base(BLLFactory<LaborMonthAttendance>.Instance)
        {
            bll = baseBLL as LaborMonthAttendance;
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
        public List<LaborMonthAttendanceInfo> GetRecords(int year, int month, string workTeamId)
        {
            return bll.GetRecords(year, month, workTeamId);
        }

        /// <summary>
        /// 保存员工月考勤记录
        /// </summary>
        /// <param name="data">考勤记录</param>
        /// <param name="year">年度</param>
        /// <param name="month">月度</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public bool SaveRecords(List<LaborMonthAttendanceInfo> data, int year, int month, string workTeamId)
        {
            return bll.SaveRecords(data, year, month, workTeamId);
        }
        #endregion //Method
    }
}

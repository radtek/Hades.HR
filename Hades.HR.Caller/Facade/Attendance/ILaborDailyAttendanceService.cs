using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;

namespace Hades.HR.Facade
{
    [ServiceContract]
    public interface ILaborDailyAttendanceService : IBaseService<LaborDailyAttendanceInfo>
    {
        /// <summary>
        /// 保存员工日考勤记录
        /// </summary>
        /// <param name="workTeamId">班组ID</param>
        /// <param name="attendaceDate">考勤日期</param>
        /// <param name="data">考勤记录</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveAttendance(string workTeamId, DateTime attendaceDate, List<LaborDailyAttendanceInfo> data);
    }
}

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
    public interface ILaborMonthAttendanceService : IBaseService<LaborMonthAttendanceInfo>
    {
        /// <summary>
        /// 获取班组员工月考勤记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        [OperationContract]
        List<LaborMonthAttendanceInfo> GetRecords(int year, int month, string workTeamId);

        /// <summary>
        /// 保存员工月考勤记录
        /// </summary>
        /// <param name="data">考勤记录</param>
        /// <param name="year">年度</param>
        /// <param name="month">月度</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveRecords(List<LaborMonthAttendanceInfo> data, int year, int month, string workTeamId);
    }
}

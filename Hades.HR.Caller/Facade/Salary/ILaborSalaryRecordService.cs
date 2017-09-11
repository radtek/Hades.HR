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
    public interface ILaborSalaryRecordService : IBaseService<LaborSalaryRecordInfo>
    {
        /// <summary>
        /// 计算计件工人工资
        /// </summary>
        /// <param name="attendanceId">考勤ID</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        [OperationContract]
        List<LaborSalaryRecordInfo> CalcLaborSalary(string attendanceId, string workTeamId);

        /// <summary>
        /// 保存计件工人工资
        /// </summary>
        /// <param name="attendanceId">考勤ID</param>
        /// <param name="data">工资数据</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveLaborSalary(string attendanceId, List<LaborSalaryRecordInfo> data);
    }
}

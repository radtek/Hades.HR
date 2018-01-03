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
    public interface ILaborSalaryService : IBaseService<LaborSalaryInfo>
    {
        /// <summary>
        /// 获取计算工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        [OperationContract]
        List<LaborSalaryInfo> GetRecords(int year, int month, string workTeamId);

        /// <summary>
        /// 保存工资记录
        /// </summary>
        /// <param name="data">工资记录</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveRecords(List<LaborSalaryInfo> data, int year, int month, string workTeamId);
    }
}

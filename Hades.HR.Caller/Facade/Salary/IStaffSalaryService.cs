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
    public interface IStaffSalaryService : IBaseService<StaffSalaryInfo>
    {
        /// <summary>
        /// 获取计算工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        [OperationContract]
        List<StaffSalaryInfo> GetRecords(int year, int month, string departmentId);

        /// <summary>
        /// 保存工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveRecords(List<StaffSalaryInfo> data, int year, int month, string departmentId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WCFLibrary
{
	/// <summary>
	/// 基于WCFLibrary的StaffSalary对象调用类
	/// </summary>
    public class StaffSalaryService : BaseLocalService<StaffSalaryInfo>, IStaffSalaryService
    {
        #region Field
        private StaffSalary bll = null;
        #endregion //Field

        #region Constructor
        public StaffSalaryService() : base(BLLFactory<StaffSalary>.Instance)
        {
            bll = baseBLL as StaffSalary;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取计算工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public List<StaffSalaryInfo> GetRecords(int year, int month, string departmentId)
        {
            return bll.GetRecords(year, month, departmentId);
        }

        /// <summary>
        /// 保存工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public bool SaveRecords(List<StaffSalaryInfo> data, int year, int month, string departmentId)
        {
            return bll.SaveRecords(data, year, month, departmentId);
        }
        #endregion //Method
    }
}

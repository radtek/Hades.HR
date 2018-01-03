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
    public class LaborSalaryCaller : BaseLocalService<LaborSalaryInfo>, ILaborSalaryService
    {
        #region Field
        private LaborSalary bll = null;
        #endregion //Field

        #region Constructor
        public LaborSalaryCaller() : base(BLLFactory<LaborSalary>.Instance)
        {
            bll = baseBLL as LaborSalary;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取计算工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>

        public List<LaborSalaryInfo> GetRecords(int year, int month, string workTeamId)
        {
            return bll.GetRecords(year, month, workTeamId);
        }

        /// <summary>
        /// 保存工资记录
        /// </summary>
        /// <param name="data">工资记录</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public bool SaveRecords(List<LaborSalaryInfo> data, int year, int month, string workTeamId)
        {
            return bll.SaveRecords(data, year, month, workTeamId);
        }
        #endregion //Method
    }
}

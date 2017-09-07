using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WCFLibrary
{
    /// <summary>
    /// 基于WCFLibrary的LaborSalaryRecord对象调用类
    /// </summary>
    public class LaborSalaryRecordService : BaseLocalService<LaborSalaryRecordInfo>, ILaborSalaryRecordService
    {
        #region Field
        private LaborSalaryRecord bll = null;
        #endregion //Field

        #region Method
        public LaborSalaryRecordService() : base(BLLFactory<LaborSalaryRecord>.Instance)
        {
            bll = baseBLL as LaborSalaryRecord;
        }
        #endregion //Method

        #region Method
        /// <summary>
        /// 计算计件工人工资
        /// </summary>
        /// <param name="attendanceId">考勤ID</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public List<LaborSalaryRecordInfo> CalcLaborSalary(string attendanceId, string workTeamId)
        {
            return bll.CalcLaborSalary(attendanceId, workTeamId);
        }
        #endregion //Method
    }
}

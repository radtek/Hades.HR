using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public class LaborSalaryRecordCaller : BaseLocalService<LaborSalaryRecordInfo>, ILaborSalaryRecordService
    {
        #region Field
        private LaborSalaryRecord bll = null;
        #endregion //Field

        #region Constructor
        public LaborSalaryRecordCaller() : base(BLLFactory<LaborSalaryRecord>.Instance)
        {
            bll = baseBLL as LaborSalaryRecord;
        }
        #endregion //Constructor

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

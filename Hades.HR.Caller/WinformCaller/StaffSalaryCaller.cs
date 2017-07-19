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
    /// 员工工资信息
    /// </summary>
    public class StaffSalaryCaller : BaseLocalService<StaffSalaryInfo>, IStaffSalaryService
    {
        #region Field
        private StaffSalary bll = null;
        #endregion //Field

        #region Constructor
        public StaffSalaryCaller() : base(BLLFactory<StaffSalary>.Instance)
        {
            bll = baseBLL as StaffSalary;
        }
        #endregion //Constructor
    }
}

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
    /// 员工工资信息视图
    /// </summary>
    public class StaffSalaryViewCaller : BaseLocalService<StaffSalaryViewInfo>, IStaffSalaryViewService
    {
        #region Field
        private StaffSalaryView bll = null;
        #endregion //Field

        #region Constructor
        public StaffSalaryViewCaller() : base(BLLFactory<StaffSalaryView>.Instance)
        {
            bll = baseBLL as StaffSalaryView;
        }
        #endregion //Constructor
    }
}

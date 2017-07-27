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
    public class StaffAttendanceViewCaller : BaseLocalService<StaffAttendanceViewInfo>, IStaffAttendanceViewService
    {
        #region Field
        private StaffAttendanceView bll = null;
        #endregion //Field

        #region Constructor
        public StaffAttendanceViewCaller() : base(BLLFactory<StaffAttendanceView>.Instance)
        {
            bll = baseBLL as StaffAttendanceView;
        }
        #endregion //Constructor
    }
}

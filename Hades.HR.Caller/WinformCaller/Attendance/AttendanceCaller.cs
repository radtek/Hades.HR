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
    public class AttendanceCaller : BaseLocalService<AttendanceInfo>, IAttendanceService
    {
        #region Field
        private Attendance bll = null;
        #endregion //Field

        #region Constructor
        public AttendanceCaller() : base(BLLFactory<Attendance>.Instance)
        {
            bll = baseBLL as Attendance;
        }
        #endregion //Constructor
    }
}

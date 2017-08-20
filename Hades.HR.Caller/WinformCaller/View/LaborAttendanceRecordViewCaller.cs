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
    public class LaborAttendanceRecordViewCaller : BaseLocalService<LaborAttendanceRecordViewInfo>, ILaborAttendanceRecordViewService
    {
        #region Field
        private LaborAttendanceRecordView bll = null;
        #endregion //Field

        #region Constructor
        public LaborAttendanceRecordViewCaller() : base(BLLFactory<LaborAttendanceRecordView>.Instance)
        {
            bll = baseBLL as LaborAttendanceRecordView;
        }
        #endregion //Constructor
    }
}

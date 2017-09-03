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
    public class WorkSectionLaborViewCaller : BaseLocalService<WorkSectionLaborViewInfo>, IWorkSectionLaborViewService
    {
        #region Field
        private WorkSectionLaborView bll = null;
        #endregion //Field

        #region Constructor
        public WorkSectionLaborViewCaller() : base(BLLFactory<WorkSectionLaborView>.Instance)
        {
            bll = baseBLL as WorkSectionLaborView;
        }
        #endregion //Constructor
    }
}

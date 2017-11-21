using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hades.HR.WinformCaller
{
    using Hades.Framework.Commons;
    using Hades.Framework.ControlUtil;
    using Hades.Framework.ControlUtil.Facade;
    using Hades.HR.Entity;
    using Hades.HR.BLL;
    using Hades.HR.Facade;

    /// <summary>
    /// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
    /// </summary>
    public class LaborProductionWorkloadCaller : BaseLocalService<LaborProductionWorkloadInfo>, ILaborProductionWorkloadService
    {
        #region Field
        private LaborProductionWorkload bll = null;
        #endregion //Field

        #region Constructor
        public LaborProductionWorkloadCaller() : base(BLLFactory<LaborProductionWorkload>.Instance)
        {
            bll = baseBLL as LaborProductionWorkload;
        }
        #endregion //Constructor
    }
}

﻿using System;
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
    public class WorkSectionCaller : BaseLocalService<WorkSectionInfo>, IWorkSectionService
    {
        #region Field
        private WorkSection bll = null;
        #endregion //Field

        #region Constructor
        public WorkSectionCaller() : base(BLLFactory<WorkSection>.Instance)
        {
            bll = baseBLL as WorkSection;
        }
        #endregion //Constructor
    }
}

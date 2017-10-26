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
	/// 基于WCFLibrary的WorkSectionLabor对象调用类
	/// </summary>
    public class WorkSectionLaborService : BaseLocalService<WorkSectionLaborInfo>, IWorkSectionLaborService
    {
        #region Field
        private WorkSectionLabor bll = null;
        #endregion //Field

        #region Constructor
        public WorkSectionLaborService() : base(BLLFactory<WorkSectionLabor>.Instance)
        {
            bll = baseBLL as WorkSectionLabor;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 保存职员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SaveLabors(List<WorkSectionLaborInfo> data)
        {
            return bll.SaveLabors(data);
        }
        #endregion //Method
    }
}

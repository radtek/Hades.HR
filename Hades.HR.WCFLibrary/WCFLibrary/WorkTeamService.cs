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
    /// 基于WCFLibrary的WorkTeam对象调用类
    /// </summary>
    public class WorkTeamService : BaseLocalService<WorkTeamInfo>, IWorkTeamService
    {
        #region Field
        private WorkTeam bll = null;
        #endregion //Field

        #region Constructor
        public WorkTeamService() : base(BLLFactory<WorkTeam>.Instance)
        {
            bll = baseBLL as WorkTeam;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool MarkDelete(string id)
        {
            return bll.MarkDelete(id);
        }
        #endregion //Method
    }
}

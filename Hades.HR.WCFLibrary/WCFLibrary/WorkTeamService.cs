using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
        /// 查找所有班组，不包含已删除
        /// </summary>
        /// <returns></returns>
        public List<WorkTeamInfo> FindAll()
        {
            return bll.FindAll();
        }
        #endregion //Method


        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public async Task<List<WorkTeamInfo>> FindByNameAsyn(string name)
        //{
        //   return await Task.Factory.StartNew(() =>
        //   {
        //       return bll.FindByName(name);
        //   }
        //}

    }
}

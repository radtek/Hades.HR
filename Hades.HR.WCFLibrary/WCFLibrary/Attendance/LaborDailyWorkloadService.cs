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
	/// 基于WCFLibrary的LaborDailyWorkload对象调用类
	/// </summary>
    public class LaborDailyWorkloadService : BaseLocalService<LaborDailyWorkloadInfo>, ILaborDailyWorkloadService
    {
        private LaborDailyWorkload bll = null;

        public LaborDailyWorkloadService() : base(BLLFactory<LaborDailyWorkload>.Instance)
        {
            bll = baseBLL as LaborDailyWorkload;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<LaborDailyWorkloadInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public async Task<List<LaborDailyWorkloadInfo>> FindByNameAsyn(string name)
        //{
        //   return await Task.Factory.StartNew(() =>
        //   {
        //       return bll.FindByName(name);
	//   }
        //}

    }
}

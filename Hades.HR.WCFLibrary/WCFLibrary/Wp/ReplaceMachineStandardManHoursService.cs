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
	/// 基于WCFLibrary的ReplaceMachineStandardManHours对象调用类
	/// </summary>
    public class ReplaceMachineStandardManHoursService : BaseLocalService<ReplaceMachineStandardManHoursInfo>, IReplaceMachineStandardManHoursService
    {
        private ReplaceMachineStandardManHours bll = null;

        public ReplaceMachineStandardManHoursService() : base(BLLFactory<ReplaceMachineStandardManHours>.Instance)
        {
            bll = baseBLL as ReplaceMachineStandardManHours;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<ReplaceMachineStandardManHoursInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public async Task<List<ReplaceMachineStandardManHoursInfo>> FindByNameAsyn(string name)
        //{
        //   return await Task.Factory.StartNew(() =>
        //   {
        //       return bll.FindByName(name);
	//   }
        //}

    }
}

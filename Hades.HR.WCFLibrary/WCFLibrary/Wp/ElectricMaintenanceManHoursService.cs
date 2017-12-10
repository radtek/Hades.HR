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
	/// 基于WCFLibrary的ElectricMaintenanceManHours对象调用类
	/// </summary>
    public class ElectricMaintenanceManHoursService : BaseLocalService<ElectricMaintenanceManHoursInfo>, IElectricMaintenanceManHoursService
    {
        private ElectricMaintenanceManHours bll = null;

        public ElectricMaintenanceManHoursService() : base(BLLFactory<ElectricMaintenanceManHours>.Instance)
        {
            bll = baseBLL as ElectricMaintenanceManHours;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<ElectricMaintenanceManHoursInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public async Task<List<ElectricMaintenanceManHoursInfo>> FindByNameAsyn(string name)
        //{
        //   return await Task.Factory.StartNew(() =>
        //   {
        //       return bll.FindByName(name);
	//   }
        //}

    }
}

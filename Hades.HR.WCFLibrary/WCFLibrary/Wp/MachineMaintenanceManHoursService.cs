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
	/// 基于WCFLibrary的MachineMaintenanceManHours对象调用类
	/// </summary>
    public class MachineMaintenanceManHoursService : BaseLocalService<MachineMaintenanceManHoursInfo>, IMachineMaintenanceManHoursService
    {
        private MachineMaintenanceManHours bll = null;

        public MachineMaintenanceManHoursService() : base(BLLFactory<MachineMaintenanceManHours>.Instance)
        {
            bll = baseBLL as MachineMaintenanceManHours;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<MachineMaintenanceManHoursInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public async Task<List<MachineMaintenanceManHoursInfo>> FindByNameAsyn(string name)
        //{
        //   return await Task.Factory.StartNew(() =>
        //   {
        //       return bll.FindByName(name);
	//   }
        //}

    }
}

using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
    public class SalaryBaseCaller : BaseLocalService<SalaryBaseInfo>, ISalaryBaseService
    {
        private SalaryBase bll = null;

        public SalaryBaseCaller() : base(BLLFactory<SalaryBase>.Instance)
        {
            bll = baseBLL as SalaryBase;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<SalaryBaseInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}


	///// <summary>
        ///// 根据名称查找对象Asyn(自定义接口使用范例)
        ///// </summary>
        //public async Task<List<SalaryBaseInfo>> FindByNameAsyn(string name)
        //{
	//   return await Task.Factory.StartNew(() =>
        //   {
        //       return bll.FindByName(name);
	//   }
        //}


    }
}

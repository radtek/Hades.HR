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
	/// 基于WCFLibrary的SalaryItem对象调用类
	/// </summary>
    public class SalaryItemService : BaseLocalService<SalaryItemInfo>, ISalaryItemService
    {
        private SalaryItem bll = null;

        public SalaryItemService() : base(BLLFactory<SalaryItem>.Instance)
        {
            bll = baseBLL as SalaryItem;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<SalaryItemInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}

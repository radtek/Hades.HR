using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

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
    public class SalaryItemCaller : BaseLocalService<SalaryItemInfo>, ISalaryItemService
    {
        private SalaryItem bll = null;

        public SalaryItemCaller() : base(BLLFactory<SalaryItem>.Instance)
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

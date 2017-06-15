﻿using System;
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
	/// 基于WCFLibrary的ProductionLine对象调用类
	/// </summary>
    public class ProductionLineService : BaseLocalService<ProductionLineInfo>, IProductionLineService
    {
        private ProductionLine bll = null;

        public ProductionLineService() : base(BLLFactory<ProductionLine>.Instance)
        {
            bll = baseBLL as ProductionLine;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<ProductionLineInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public async Task<List<ProductionLineInfo>> FindByNameAsyn(string name)
        //{
        //   return await Task.Factory.StartNew(() =>
        //   {
        //       return bll.FindByName(name);
	//   }
        //}

    }
}

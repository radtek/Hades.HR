﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;

namespace Hades.HR.Facade
{
    [ServiceContract]
    public interface IProductionLineService : IBaseService<ProductionLineInfo>
    {
        /// <summary>
        /// 查找所有产线，不包含已删除
        /// </summary>
        /// <returns></returns>
        List<ProductionLineInfo> FindAll();

        /// <summary>
        /// 按公司获取产线
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        List<ProductionLineInfo> FindByCompany(string companyId);
    }
}
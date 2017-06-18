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
	/// 基于WCFLibrary的ProductionLine对象调用类
	/// </summary>
    public class ProductionLineService : BaseLocalService<ProductionLineInfo>, IProductionLineService
    {
        #region Field
        private ProductionLine bll = null;
        #endregion //Field

        #region Constructor
        public ProductionLineService() : base(BLLFactory<ProductionLine>.Instance)
        {
            bll = baseBLL as ProductionLine;
        }
        #endregion //Constructor

        #region Method
        public List<ProductionLineInfo> FindAll()
        {
            return bll.FindAll();
        }

        /// <summary>
        /// 按公司获取产线
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        public List<ProductionLineInfo> FindByCompany(string companyId)
        {
            return bll.FindByCompany(companyId);
        }
        #endregion //Method

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

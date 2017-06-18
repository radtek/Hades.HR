using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WinformCaller
{
    /// <summary>
    ///  基于传统Winform方式，直接访问本地数据库的Facade接口实现类
    /// </summary>
    public class ProductionLineCaller : BaseLocalService<ProductionLineInfo>, IProductionLineService
    {
        #region Field
        private ProductionLine bll = null;
        #endregion //Field

        #region Constructor
        public ProductionLineCaller() : base(BLLFactory<ProductionLine>.Instance)
        {
            bll = baseBLL as ProductionLine;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 查找所有产线，不包含已删除
        /// </summary>
        /// <returns></returns>
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
    }
}

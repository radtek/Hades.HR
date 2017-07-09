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

namespace Hades.HR.ServiceCaller
{
    /// <summary>
    /// 基于WCF服务的Facade接口实现类
    /// </summary>
    public class ProductionLineCaller : BaseWCFService<ProductionLineInfo>, IProductionLineService
    {
        #region Constructor
        public ProductionLineCaller() : base()
        {
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.ProductionLineService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<ProductionLineInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IProductionLineService CreateSubClient()
        {
            CustomClientChannel<IProductionLineService> factory = new CustomClientChannel<IProductionLineService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool MarkDelete(string id)
        {
            bool result = false;

            IProductionLineService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.MarkDelete(id);
            });

            return result;
        }

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Task<bool> MarkDeleteAsyn(string id)
        {
            IProductionLineService service = CreateSubClient();
            return service.MarkDeleteAsyn(id);
        }
        #endregion //Method
    }
}

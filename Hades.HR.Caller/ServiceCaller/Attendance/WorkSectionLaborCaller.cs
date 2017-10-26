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

namespace Hades.HR.ServiceCaller
{
	/// <summary>
	/// 基于WCF服务的Facade接口实现类
	/// </summary>
    public class WorkSectionLaborCaller : BaseWCFService<WorkSectionLaborInfo>, IWorkSectionLaborService
    {
        public WorkSectionLaborCaller()  : base()
        {	
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.WorkSectionLaborService;
        }

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<WorkSectionLaborInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IWorkSectionLaborService CreateSubClient()
        {
            CustomClientChannel<IWorkSectionLaborService> factory = new CustomClientChannel<IWorkSectionLaborService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 保存职员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SaveLabors(List<WorkSectionLaborInfo> data)
        {
            int result = -1;

            IWorkSectionLaborService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveLabors(data);
            });

            return result;
        }
        #endregion //Method

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<WorkSectionLaborInfo> FindByName(string name)
        //{
        //    List<WorkSectionLaborInfo> result = new List<WorkSectionLaborInfo>();

        //    IWorkSectionLaborService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

    }
}

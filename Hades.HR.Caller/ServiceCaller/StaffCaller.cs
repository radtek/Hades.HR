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
    public class StaffCaller : BaseWCFService<StaffInfo>, IStaffService
    {
        public StaffCaller()  : base()
        {	
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.StaffService;
        }

        public bool CheckDuplicate(StaffInfo entity, out string message)
        {
            throw new NotImplementedException();
        }

        public List<StaffInfo> FindByDepartment(string departmentId)
        {
            throw new NotImplementedException();
        }

        public List<StaffInfo> FindByDepartments(List<string> idList)
        {
            throw new NotImplementedException();
        }

        public bool MarkDelete(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<StaffInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IStaffService CreateSubClient()
        {
            CustomClientChannel<IStaffService> factory = new CustomClientChannel<IStaffService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<StaffInfo> FindByName(string name)
        //{
        //    List<StaffInfo> result = new List<StaffInfo>();

        //    IStaffService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

    }
}

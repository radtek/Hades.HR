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
    public class DepartmentCaller : BaseWCFService<DepartmentInfo>, IDepartmentService
    {
        #region Constructor
        public DepartmentCaller()  : base()
        {	
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.DepartmentService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<DepartmentInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IDepartmentService CreateSubClient()
        {
            CustomClientChannel<IDepartmentService> factory = new CustomClientChannel<IDepartmentService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 查找部门及其子部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
        public List<DepartmentInfo> FindWithChildren(string id)
        {
            List<DepartmentInfo> result = new List<DepartmentInfo>();

            IDepartmentService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.FindWithChildren(id);
            });

            return result;
        }

        /// <summary>
        /// 查找部门及其子部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
        public Task<List<DepartmentInfo>> FindWithChildrenAsync(string id)
        {
            List<DepartmentInfo> result = new List<DepartmentInfo>();

            IDepartmentService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.FindWithChildren(id);
            });

            return null;
        }

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool CheckDuplicate(DepartmentInfo entity)
        {
            bool result = false;

            IDepartmentService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.CheckDuplicate(entity);
            });

            return result;
        }

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool MarkDelete(string id)
        {
            bool result = false;

            IDepartmentService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.MarkDelete(id);
            });

            return result;
        }

        #endregion //Method

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<DepartmentInfo> FindByName(string name)
        //{
        //    List<DepartmentInfo> result = new List<DepartmentInfo>();

        //    IDepartmentService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

    }
}

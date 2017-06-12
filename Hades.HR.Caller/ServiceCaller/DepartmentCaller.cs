﻿using System;
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
        /// 查找所有部门，不包含已删除
        /// </summary>
        /// <returns></returns>
        public List<DepartmentInfo> FindAll()
        {
            List<DepartmentInfo> result = new List<DepartmentInfo>();

            IDepartmentService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.FindAll();
            });

            return result;
        }

        /// <summary>
        /// 查找部门列表
        /// </summary>
        /// <param name="deleted">删除标志</param>
        /// <param name="enabled">启用标志</param>
        /// <returns></returns>
        public List<DepartmentInfo> FindList(int deleted, int enabled)
        {
            List<DepartmentInfo> result = new List<DepartmentInfo>();

            IDepartmentService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.FindList(deleted, enabled);
            });

            return result;
        }

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

        public bool MarkDelete(string id)
        {
            throw new NotImplementedException();
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

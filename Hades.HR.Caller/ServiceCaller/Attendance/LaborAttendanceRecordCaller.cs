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
    public class LaborAttendanceRecordCaller : BaseWCFService<LaborAttendanceRecordInfo>, ILaborAttendanceRecordService
    {
        #region Constructor
        public LaborAttendanceRecordCaller()  : base()
        {	
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.LaborAttendanceRecordService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<LaborAttendanceRecordInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ILaborAttendanceRecordService CreateSubClient()
        {
            CustomClientChannel<ILaborAttendanceRecordService> factory = new CustomClientChannel<ILaborAttendanceRecordService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 插入班组日考勤记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string InsertRecords(List<LaborAttendanceRecordInfo> data)
        {
            string result = "";

            ILaborAttendanceRecordService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.InsertRecords(data);
            });

            return result;
        }
        #endregion //Method

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<LaborAttendanceRecordInfo> FindByName(string name)
        //{
        //    List<LaborAttendanceRecordInfo> result = new List<LaborAttendanceRecordInfo>();

        //    ILaborAttendanceRecordService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

    }
}

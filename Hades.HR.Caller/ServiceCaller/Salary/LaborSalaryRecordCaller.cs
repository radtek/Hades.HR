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
    public class LaborSalaryRecordCaller : BaseWCFService<LaborSalaryRecordInfo>, ILaborSalaryRecordService
    {
        #region Constructor
        public LaborSalaryRecordCaller() : base()
        {
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.LaborSalaryRecordService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<LaborSalaryRecordInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ILaborSalaryRecordService CreateSubClient()
        {
            CustomClientChannel<ILaborSalaryRecordService> factory = new CustomClientChannel<ILaborSalaryRecordService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 计算计件工人工资
        /// </summary>
        /// <param name="attendanceId">考勤ID</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public List<LaborSalaryRecordInfo> CalcLaborSalary(string attendanceId, string workTeamId)
        {
            List<LaborSalaryRecordInfo> result = new List<LaborSalaryRecordInfo>();

            ILaborSalaryRecordService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.CalcLaborSalary(attendanceId, workTeamId);
            });

            return result;
        }
        #endregion //Method

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<LaborSalaryRecordInfo> FindByName(string name)
        //{
        //    List<LaborSalaryRecordInfo> result = new List<LaborSalaryRecordInfo>();

        //    ILaborSalaryRecordService service = CreateSubClient();
        //    ICommunicationObject comm = service as ICommunicationObject;
        //    comm.Using(client =>
        //    {
        //        result = service.FindByName(name);
        //    });

        //    return result;
        //}

    }
}

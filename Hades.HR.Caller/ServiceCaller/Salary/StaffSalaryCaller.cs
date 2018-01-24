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
    public class StaffSalaryCaller : BaseWCFService<StaffSalaryInfo>, IStaffSalaryService
    {
        #region Constructor
        public StaffSalaryCaller() : base()
        {
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.StaffSalaryService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<StaffSalaryInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IStaffSalaryService CreateSubClient()
        {
            CustomClientChannel<IStaffSalaryService> factory = new CustomClientChannel<IStaffSalaryService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取计算工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public List<StaffSalaryInfo> GetRecords(int year, int month, string departmentId)
        {
            List<StaffSalaryInfo> result = new List<StaffSalaryInfo>();

            IStaffSalaryService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetRecords(year, month, departmentId);
            });

            return result;
        }

        /// <summary>
        /// 保存工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public bool SaveRecords(List<StaffSalaryInfo> data, int year, int month, string departmentId)
        {
            bool result = false;

            IStaffSalaryService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveRecords(data, year, month, departmentId);
            });

            return result;
        }
        #endregion //Method
    }
}

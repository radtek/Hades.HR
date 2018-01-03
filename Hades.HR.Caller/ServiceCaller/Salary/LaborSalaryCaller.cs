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
    public class LaborSalaryCaller : BaseWCFService<LaborSalaryInfo>, ILaborSalaryService
    {
        #region Constructor
        public LaborSalaryCaller()  : base()
        {	
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.LaborSalaryService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<LaborSalaryInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ILaborSalaryService CreateSubClient()
        {
            CustomClientChannel<ILaborSalaryService> factory = new CustomClientChannel<ILaborSalaryService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取计算工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public List<LaborSalaryInfo> GetRecords(int year, int month, string workTeamId)
        {
            List<LaborSalaryInfo> result = new List<LaborSalaryInfo>();

            ILaborSalaryService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetRecords(year, month, workTeamId);
            });

            return result;
        }

        /// <summary>
        /// 保存工资记录
        /// </summary>
        /// <param name="data">工资记录</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public bool SaveRecords(List<LaborSalaryInfo> data, int year, int month, string workTeamId)
        {
            bool result = false;

            ILaborSalaryService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveRecords(data, year, month, workTeamId);
            });

            return result;
        }
        #endregion //Method
    }
}

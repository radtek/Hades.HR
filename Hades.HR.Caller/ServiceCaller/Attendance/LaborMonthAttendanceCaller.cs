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
    public class LaborMonthAttendanceCaller : BaseWCFService<LaborMonthAttendanceInfo>, ILaborMonthAttendanceService
    {
        #region Constructor
        public LaborMonthAttendanceCaller()  : base()
        {	
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.LaborMonthAttendanceService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<LaborMonthAttendanceInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ILaborMonthAttendanceService CreateSubClient()
        {
            CustomClientChannel<ILaborMonthAttendanceService> factory = new CustomClientChannel<ILaborMonthAttendanceService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取班组员工月考勤记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public List<LaborMonthAttendanceInfo> GetRecords(int year, int month, string workTeamId)
        {
            List<LaborMonthAttendanceInfo> result = new List<LaborMonthAttendanceInfo>();

            ILaborMonthAttendanceService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.GetRecords(year, month, workTeamId);
            });

            return result;
        }

        /// <summary>
        /// 保存员工月考勤记录
        /// </summary>
        /// <param name="data">考勤记录</param>
        /// <param name="year">年度</param>
        /// <param name="month">月度</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public bool SaveRecords(List<LaborMonthAttendanceInfo> data, int year, int month, string workTeamId)
        {
            bool result = false;

            ILaborMonthAttendanceService service = CreateSubClient();
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

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
    public class LaborDailyAttendanceCaller : BaseWCFService<LaborDailyAttendanceInfo>, ILaborDailyAttendanceService
    {
        #region Constructor
        public LaborDailyAttendanceCaller()  : base()
        {	
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.LaborDailyAttendanceService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<LaborDailyAttendanceInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ILaborDailyAttendanceService CreateSubClient()
        {
            CustomClientChannel<ILaborDailyAttendanceService> factory = new CustomClientChannel<ILaborDailyAttendanceService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 保存员工日考勤记录
        /// </summary>
        /// <param name="workTeamId">班组ID</param>
        /// <param name="attendaceDate">考勤日期</param>
        /// <param name="data">考勤记录</param>
        /// <returns></returns>
        public bool SaveAttendance(string workTeamId, DateTime attendaceDate, List<LaborDailyAttendanceInfo> data)
        {
            bool result = false;

            ILaborDailyAttendanceService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveAttendance(workTeamId, attendaceDate, data);
            });

            return result;
        }
        #endregion //Method
    }
}

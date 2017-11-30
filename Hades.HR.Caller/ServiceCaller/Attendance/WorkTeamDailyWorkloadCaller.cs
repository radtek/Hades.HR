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
    public class WorkTeamDailyWorkloadCaller : BaseWCFService<WorkTeamDailyWorkloadInfo>, IWorkTeamDailyWorkloadService
    {
        #region Constructor
        public WorkTeamDailyWorkloadCaller() : base()
        {
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.WorkTeamDailyWorkloadService;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<WorkTeamDailyWorkloadInfo> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IWorkTeamDailyWorkloadService CreateSubClient()
        {
            CustomClientChannel<IWorkTeamDailyWorkloadService> factory = new CustomClientChannel<IWorkTeamDailyWorkloadService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 初始化班组日工作量及本班人员
        /// </summary>
        /// <param name="workTeam">班组日考勤</param>
        /// <param name="labors">员工日考勤</param>
        /// <returns></returns>
        public bool InsertDailyLabor(WorkTeamDailyWorkloadInfo workTeam, List<LaborDailyWorkloadInfo> labors)
        {
            bool result = false;

            IWorkTeamDailyWorkloadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.InsertDailyLabor(workTeam, labors);
            });

            return result;
        }
        #endregion //Method
    }
}

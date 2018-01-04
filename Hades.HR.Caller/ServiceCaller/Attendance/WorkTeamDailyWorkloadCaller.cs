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
        /// 设置班组日工作量及本班人员
        /// </summary>
        /// <param name="workTeamWorkload">班组日考勤</param>
        /// <param name="labors">员工日考勤</param>
        /// <returns></returns>
        public bool SetDailyLabor(WorkTeamDailyWorkloadInfo workTeamWorkload, List<LaborDailyWorkloadInfo> labors)
        {
            bool result = false;

            IWorkTeamDailyWorkloadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SetDailyLabor(workTeamWorkload, labors);
            });

            return result;
        }

        /// <summary>
        /// 保存产量工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">产量总工时</param>
        /// <param name="productWorkloads">员工产量工作量信息</param>
        /// <returns></returns>       
        public bool SaveProduction(string workTeamWorkloadId, decimal totalHours, List<LaborProductionWorkloadInfo> productWorkloads)
        {
            bool result = false;

            IWorkTeamDailyWorkloadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveProduction(workTeamWorkloadId, totalHours, productWorkloads);
            });

            return result;
        }


        /// <summary>
        /// 保存员工换机工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">换机总工时</param>
        /// <param name="changeWorkloads">员工换机工时信息</param>
        /// <returns></returns>
        public bool SaveChange(string workTeamWorkloadId, decimal totalHours, List<LaborChangeWorkloadInfo> changeWorkloads)
        {
            bool result = false;

            IWorkTeamDailyWorkloadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveChange(workTeamWorkloadId, totalHours, changeWorkloads);
            });

            return result;
        }

        /// <summary>
        /// 保存员工机修工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">机修总工时</param>
        /// <param name="repairWorkloads">员工机修工时信息</param>
        /// <returns></returns>        
        public bool SaveRepair(string workTeamWorkloadId, decimal totalHours, List<LaborRepairWorkloadInfo> repairWorkloads)
        {
            bool result = false;

            IWorkTeamDailyWorkloadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveRepair(workTeamWorkloadId, totalHours, repairWorkloads);
            });

            return result;
        }

        /// <summary>
        /// 保存员工电修工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">电修总工时</param>
        /// <param name="electricWorkloads">员工电修工时信息</param>
        /// <returns></returns>
        public bool SaveElectric(string workTeamWorkloadId, decimal totalHours, List<LaborElectricWorkloadInfo> electricWorkloads)
        {
            bool result = false;

            IWorkTeamDailyWorkloadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveElectric(workTeamWorkloadId, totalHours, electricWorkloads);
            });

            return result;
        }

        /// <summary>
        /// 保存员工请假工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="leaveWorkloads">员工请假工时信息</param>
        /// <returns></returns>
        public bool SaveLeave(string workTeamWorkloadId, List<LaborLeaveWorkloadInfo> leaveWorkloads)
        {
            bool result = false;

            IWorkTeamDailyWorkloadService service = CreateSubClient();
            ICommunicationObject comm = service as ICommunicationObject;
            comm.Using(client =>
            {
                result = service.SaveLeave(workTeamWorkloadId, leaveWorkloads);
            });

            return result;
        }
        #endregion //Method
    }
}

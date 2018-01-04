using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;

namespace Hades.HR.Facade
{
    [ServiceContract]
    public interface IWorkTeamDailyWorkloadService : IBaseService<WorkTeamDailyWorkloadInfo>
    {
        /// <summary>
        /// 设置班组日工作量及本班人员
        /// </summary>
        /// <param name="workTeamWorkload">班组日考勤</param>
        /// <param name="labors">员工日考勤</param>
        /// <returns></returns>
        [OperationContract]
        bool SetDailyLabor(WorkTeamDailyWorkloadInfo workTeamWorkload, List<LaborDailyWorkloadInfo> labors);

        /// <summary>
        /// 保存产量工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">产量总工时</param>
        /// <param name="productWorkloads">员工产量工作量信息</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveProduction(string workTeamWorkloadId, decimal totalHours, List<LaborProductionWorkloadInfo> productWorkloads);

        /// <summary>
        /// 保存员工换机工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">换机总工时</param>
        /// <param name="changeWorkloads">员工换机工时信息</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveChange(string workTeamWorkloadId, decimal totalHours, List<LaborChangeWorkloadInfo> changeWorkloads);

        /// <summary>
        /// 保存员工机修工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">机修总工时</param>
        /// <param name="repairWorkloads">员工机修工时信息</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveRepair(string workTeamWorkloadId, decimal totalHours, List<LaborRepairWorkloadInfo> repairWorkloads);

        /// <summary>
        /// 保存员工电修工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">电修总工时</param>
        /// <param name="electricWorkloads">员工电修工时信息</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveElectric(string workTeamWorkloadId, decimal totalHours, List<LaborElectricWorkloadInfo> electricWorkloads);

        /// <summary>
        /// 保存员工请假工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="leaveWorkloads">员工请假工时信息</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveLeave(string workTeamWorkloadId, List<LaborLeaveWorkloadInfo> leaveWorkloads);
    }
}

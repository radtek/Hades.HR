using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WinformCaller
{
    /// <summary>
    /// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
    /// </summary>
    public class WorkTeamDailyWorkloadCaller : BaseLocalService<WorkTeamDailyWorkloadInfo>, IWorkTeamDailyWorkloadService
    {
        #region Field
        private WorkTeamDailyWorkload bll = null;
        #endregion //Field

        #region Constructor
        public WorkTeamDailyWorkloadCaller() : base(BLLFactory<WorkTeamDailyWorkload>.Instance)
        {
            bll = baseBLL as WorkTeamDailyWorkload;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 设置班组日工作量及本班人员
        /// </summary>
        /// <param name="workTeamWorkload">班组日考勤</param>
        /// <param name="labors">员工日考勤</param>
        /// <returns></returns>
        public bool SetDailyLabor(WorkTeamDailyWorkloadInfo workTeamWorkload, List<LaborDailyWorkloadInfo> labors)
        {
            return bll.SetDailyLabor(workTeamWorkload, labors);
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
            return bll.SaveProduction(workTeamWorkloadId, totalHours, productWorkloads);
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
            return bll.SaveChange(workTeamWorkloadId, totalHours, changeWorkloads);
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
            return bll.SaveRepair(workTeamWorkloadId, totalHours, repairWorkloads);
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
            return bll.SaveElectric(workTeamWorkloadId, totalHours, electricWorkloads);
        }

        /// <summary>
        /// 保存员工请假工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="leaveWorkloads">员工请假工时信息</param>
        /// <returns></returns>        
        public bool SaveLeave(string workTeamWorkloadId, List<LaborLeaveWorkloadInfo> leaveWorkloads)
        {
            return bll.SaveLeave(workTeamWorkloadId, leaveWorkloads);
        }
        #endregion //Method
    }
}

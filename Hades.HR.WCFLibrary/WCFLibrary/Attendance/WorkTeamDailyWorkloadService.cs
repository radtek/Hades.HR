using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WCFLibrary
{
    /// <summary>
    /// 基于WCFLibrary的WorkTeamDailyWorkload对象调用类
    /// </summary>
    public class WorkTeamDailyWorkloadService : BaseLocalService<WorkTeamDailyWorkloadInfo>, IWorkTeamDailyWorkloadService
    {
        #region Field
        private WorkTeamDailyWorkload bll = null;
        #endregion //Field

        #region Constructor
        public WorkTeamDailyWorkloadService() : base(BLLFactory<WorkTeamDailyWorkload>.Instance)
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
        #endregion //Method
    }
}

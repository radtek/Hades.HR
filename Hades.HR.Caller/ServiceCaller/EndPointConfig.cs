using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hades.HR.ServiceCaller
{
    /// <summary>
    /// 终结点配置项名称列表
    /// </summary>
    internal class EndPointConfig
    {
        /// <summary>
        /// WCF配置文件路径
        /// </summary>
        public const string WcfConfig = "HRWcfConfig.config";

        #region Base
        public const string DepartmentService = "WSHttpBinding_IDepartmentService";
        public const string PositionService = "WSHttpBinding_IPositionService";
        public const string StaffService = "WSHttpBinding_IStaffService";

        public const string ProductionLineService = "WSHttpBinding_IProductionLineService";
        public const string WorkTeamService = "WSHttpBinding_IWorkTeamService";
        public const string WorkSectionService = "WSHttpBinding_IWorkSectionService";

        public const string StaffLevelService = "WSHttpBinding_IStaffLevelService";

        public const string WarehouseService = "WSHttpBinding_IWarehouseService";
        public const string WarehouseManagerService = "WSHttpBinding_IWarehouseManagerService";
        #endregion //Base

        #region Attendance
        public const string AttendanceService = "WSHttpBinding_IAttendanceService";

        public const string LaborDailyAttendanceService = "WSHttpBinding_ILaborDailyAttendanceService";
        public const string LaborDailyWorkloadService = "WSHttpBinding_ILaborDailyWorkloadService";
        public const string WorkTeamDailyWorkloadService = "WSHttpBinding_IWorkTeamDailyWorkloadService";

        public const string LaborChangeWorkloadService = "WSHttpBinding_ILaborChangeWorkloadService";
        public const string LaborProductionWorkloadService = "WSHttpBinding_ILaborProductionWorkloadService";
        public const string LaborElectricWorkloadService = "WSHttpBinding_ILaborElectricWorkloadService";
        public const string LaborRepairWorkloadService = "WSHttpBinding_ILaborRepairWorkloadService";

        public const string LaborMonthAttendanceService = "WSHttpBinding_ILaborMonthAttendanceService";
        #endregion //Attendance

        #region Salary
        public const string SalaryBaseService = "WSHttpBinding_ISalaryBaseService";

        public const string LaborSalaryService = "WSHttpBinding_ILaborSalaryService";
        #endregion //Salary

        #region Wp
        public const string CompletionListService = "WSHttpBinding_ICompletionListService";
        public const string ElectricMaintenanceManHoursService = "WSHttpBinding_IElectricMaintenanceManHoursService";
        public const string MachineMaintenanceManHoursService = "WSHttpBinding_IMachineMaintenanceManHoursService";
        public const string ReplaceMachineCategoryService = "WSHttpBinding_IReplaceMachineCategoryService";
        public const string ReplaceMachineManHoursService = "WSHttpBinding_IReplaceMachineManHoursService";
        public const string ReplaceMachineStandardManHoursService = "WSHttpBinding_IReplaceMachineStandardManHoursService";
        #endregion //Wp

        #region View

        #endregion //View
    }
}

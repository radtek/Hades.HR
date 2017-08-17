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

        public const string DepartmentService = "WSHttpBinding_IDepartmentService";
        public const string PositionService = "WSHttpBinding_IPositionService";
        public const string StaffService = "WSHttpBinding_IStaffService";

        public const string ProductionLineService = "WSHttpBinding_IProductionLineService";
        public const string WorkTeamService = "WSHttpBinding_IWorkTeamService";

        public const string WarehouseService = "WSHttpBinding_IWarehouseService";
        public const string WarehouseManagerService = "WSHttpBinding_IWarehouseManagerService";

        public const string SalaryLevelService = "WSHttpBinding_ISalaryLevelService";
        public const string BonusDefineService = "WSHttpBinding_IBonusDefineService";
        public const string StaffSalaryDefineService = "WSHttpBinding_IStaffSalaryDefineService";

        public const string AttendanceService = "WSHttpBinding_IAttendanceService";
        public const string AttendanceRecordService = "WSHttpBinding_IAttendanceRecordService";

        public const string LaborAttendanceRecordService = "WSHttpBinding_ILaborAttendanceRecordService";
        public const string LaborMonthAttendanceService = "WSHttpBinding_ILaborMonthAttendanceService";

        public const string StaffAttendanceViewService = "WSHttpBinding_IStaffAttendanceViewService";
    }
}

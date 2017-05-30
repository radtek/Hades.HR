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
    }
}

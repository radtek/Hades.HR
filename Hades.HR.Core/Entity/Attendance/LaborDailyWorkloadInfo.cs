using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborDailyWorkloadInfo
    /// </summary>
    [DataContract]
    public class LaborDailyWorkloadInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public LaborDailyWorkloadInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.ProductionHours = 0;
            this.ChangeHours = 0;
            this.RepairHours = 0;
            this.ElectricHours = 0;
            this.LeaveHours = 0;
            this.AllowanceHours = 0;

        }

        #region Property Members

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string WorkTeamWorkloadId { get; set; }

        [DataMember]
        public virtual string WorkTeamId { get; set; }

        [DataMember]
        public virtual string ActualWorkTeamId { get; set; }

        [DataMember]
        public virtual DateTime AttendanceDate { get; set; }

        [DataMember]
        public virtual string StaffId { get; set; }

        [DataMember]
        public virtual decimal ProductionHours { get; set; }

        [DataMember]
        public virtual decimal ChangeHours { get; set; }

        [DataMember]
        public virtual decimal RepairHours { get; set; }

        [DataMember]
        public virtual decimal ElectricHours { get; set; }

        [DataMember]
        public virtual decimal LeaveHours { get; set; }

        [DataMember]
        public virtual decimal AllowanceHours { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }
        #endregion
    }
}
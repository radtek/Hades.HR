using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborRepairWorkloadInfo
    /// </summary>
    [DataContract]
    public class LaborRepairWorkloadInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public LaborRepairWorkloadInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.RepairHours = 0;
            this.AssignType = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string RepairId { get; set; }

        [DataMember]
        public virtual string WorkTeamId { get; set; }

        [DataMember]
        public virtual string StaffId { get; set; }

        [DataMember]
        public virtual decimal RepairHours { get; set; }

        [DataMember]
        public virtual int AssignType { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }


        #endregion

    }
}
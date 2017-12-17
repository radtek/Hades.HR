using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// ReplaceMachineManHoursInfo
    /// </summary>
    [DataContract]
    public class ReplaceMachineManHoursInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public ReplaceMachineManHoursInfo()
        {
            this.ID = System.Guid.NewGuid().ToString();
            this.Amount = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string ID { get; set; }

        [DataMember]
        public virtual string WorkteamId { get; set; }

        [DataMember]
        public virtual string ItemId { get; set; }

        [DataMember]
        public virtual DateTime WorkingDate { get; set; }

        [DataMember]
        public virtual decimal Amount { get; set; }

        [DataMember]
        public virtual decimal ManHour { get; set; }

        [DataMember]
        public virtual string CreatorId { get; set; }

        [DataMember]
        public virtual string Creator { get; set; }

        [DataMember]
        public virtual DateTime CreateTime { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }
        #endregion
    }
}
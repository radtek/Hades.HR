using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// ReplaceMachineStandardManHoursInfo
    /// </summary>
    [DataContract]
    public class ReplaceMachineStandardManHoursInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public ReplaceMachineStandardManHoursInfo()
        {
            this.ID = System.Guid.NewGuid().ToString();
            this.StandardManHours = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string ID { get; set; }

        [DataMember]
        public virtual string MasterCategoryId { get; set; }

        [DataMember]
        public virtual string ItemId { get; set; }

        [DataMember]
        public virtual string ItemName { get; set; }

        [DataMember]
        public virtual int StandardManHours { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }
        #endregion

    }
}
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// AttendanceInfo
    /// </summary>
    [DataContract]
    public class AttendanceInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public AttendanceInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Year = 0;
            this.Month = 0;
            this.Days = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual int Year { get; set; }

        [DataMember]
        public virtual int Month { get; set; }

        [DataMember]
        public virtual int Days { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }
        #endregion
    }
}
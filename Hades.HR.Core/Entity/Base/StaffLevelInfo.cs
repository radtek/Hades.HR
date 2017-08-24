using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// StaffLevelInfo
    /// </summary>
    [DataContract]
    public class StaffLevelInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public StaffLevelInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Salary = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual decimal Salary { get; set; }

        [DataMember]
        public virtual string SortCode { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }
        #endregion
    }
}
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// HR_WorkSectionLaborView
    /// </summary>
    [DataContract]
    public class WorkSectionLaborViewInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public WorkSectionLaborViewInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Year = 0;
            this.Month = 0;
            this.InPosition = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string Number { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string WorkTeamName { get; set; }

        [DataMember]
        public virtual string WorkSectionName { get; set; }

        [DataMember]
        public virtual string StaffLevelName { get; set; }

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual int Year { get; set; }

        [DataMember]
        public virtual int Month { get; set; }

        [DataMember]
        public virtual string WorkTeamId { get; set; }

        [DataMember]
        public virtual string WorkSectionId { get; set; }

        [DataMember]
        public virtual string StaffId { get; set; }

        [DataMember]
        public virtual string StaffLevelId { get; set; }

        [DataMember]
        public virtual int InPosition { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }

        [DataMember]
        public virtual string SortCode { get; set; }
        #endregion
    }
}
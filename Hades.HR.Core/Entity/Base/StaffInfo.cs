using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// StaffInfo
    /// </summary>
    [DataContract]
    public class StaffInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public StaffInfo()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Deleted = 0;
            this.Enabled = 0;
        }

        #region Property Members
        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string Number { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Gender { get; set; }

        [DataMember]
        public virtual DateTime Birthday { get; set; }

        [DataMember]
        public virtual string NativePlace { get; set; }

        [DataMember]
        public virtual string Nationality { get; set; }

        [DataMember]
        public virtual string IdentityCard { get; set; }

        [DataMember]
        public virtual string Phone { get; set; }

        [DataMember]
        public virtual string OfficePhone { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string QQ { get; set; }

        [DataMember]
        public virtual string HomeAddress { get; set; }

        [DataMember]
        public virtual string Political { get; set; }

        [DataMember]
        public virtual DateTime PartyDate { get; set; }

        [DataMember]
        public virtual string Education { get; set; }

        [DataMember]
        public virtual string Degree { get; set; }

        [DataMember]
        public virtual DateTime WorkingDate { get; set; }

        [DataMember]
        public virtual string Marriage { get; set; }

        [DataMember]
        public virtual string ChildStatus { get; set; }

        [DataMember]
        public virtual string Titles { get; set; }

        [DataMember]
        public virtual string Duty { get; set; }

        [DataMember]
        public virtual string JobType { get; set; }

        [DataMember]
        public virtual string Introduce { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }

        [DataMember]
        public virtual byte[] Protraint { get; set; }

        [DataMember]
        public virtual string AttachId { get; set; }

        [DataMember]
        public virtual int StaffType { get; set; }

        [DataMember]
        public virtual string CompanyId { get; set; }

        [DataMember]
        public virtual string DepartmentId { get; set; }

        [DataMember]
        public virtual string PositionId { get; set; }

        [DataMember]
        public virtual string ProductionLineId { get; set; }

        [DataMember]
        public virtual string WorkTeamId { get; set; }

        [DataMember]
        public virtual int JobStatus { get; set; }

        [DataMember]
        public virtual string Creator { get; set; }

        [DataMember]
        public virtual string CreatorId { get; set; }

        [DataMember]
        public virtual DateTime CreateTime { get; set; }

        [DataMember]
        public virtual string Editor { get; set; }

        [DataMember]
        public virtual string EditorId { get; set; }

        [DataMember]
        public virtual DateTime EditTime { get; set; }

        [DataMember]
        public virtual int Deleted { get; set; }

        [DataMember]
        public virtual int Enabled { get; set; }
        #endregion
    }
}
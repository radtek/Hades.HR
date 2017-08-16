using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborAttendanceRecordInfo
    /// </summary>
    [DataContract]
    public class LaborAttendanceRecordInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public LaborAttendanceRecordInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Workload = 0;
            this.AbsentType = 0;
            this.IsWeekend = false;
            this.IsHoliday = false;
        }

        #region Property Members

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string StaffId { get; set; }

        [DataMember]
        public virtual string WorkTeamId { get; set; }

        [DataMember]
        public virtual DateTime AttendanceDate { get; set; }

        [DataMember]
        public virtual decimal Workload { get; set; }

        [DataMember]
        public virtual int AbsentType { get; set; }

        [DataMember]
        public virtual bool IsWeekend { get; set; }

        [DataMember]
        public virtual bool IsHoliday { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }
        #endregion
    }
}
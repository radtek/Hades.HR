using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborDailyAttendanceInfo
    /// </summary>
    [DataContract]
    public class LaborDailyAttendanceInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public LaborDailyAttendanceInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
                 this.AbsentType= 0;
             this.TotalHours= 0;
             this.IsWeekend= false;
             this.IsHoliday= false;
   
		}

        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

		[DataMember]
        public virtual string WorkTeamId { get; set; }

		[DataMember]
        public virtual string AttendanceDate { get; set; }

		[DataMember]
        public virtual string StaffId { get; set; }

		[DataMember]
        public virtual string StaffLevelId { get; set; }

		[DataMember]
        public virtual int AbsentType { get; set; }

		[DataMember]
        public virtual decimal TotalHours { get; set; }

		[DataMember]
        public virtual bool IsWeekend { get; set; }

		[DataMember]
        public virtual bool IsHoliday { get; set; }

		[DataMember]
        public virtual string Remark { get; set; }


        #endregion

    }
}
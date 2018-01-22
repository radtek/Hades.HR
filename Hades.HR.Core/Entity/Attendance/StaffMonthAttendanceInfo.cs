using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// StaffMonthAttendanceInfo
    /// </summary>
    [DataContract]
    public class StaffMonthAttendanceInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public StaffMonthAttendanceInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
             this.Year= 0;
             this.Month= 0;
               this.AttendanceDays= 0;
             this.AnnualLeave= 0;
             this.SickLeave= 0;
             this.CasualLeave= 0;
             this.InjuryLeave= 0;
             this.MarriageLeave= 0;
             this.MaternityLeave= 0;
             this.FuneralLeave= 0;
             this.AbsentLeave= 0;
             this.NormalOvertime= 0;
             this.WeekendOvertime= 0;
             this.HolidayOvertime= 0;
             this.NoonShift= 0;
             this.NightShift= 0;
             this.OtherNoon= 0;
             this.OtherNight= 0;
   
		}

        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

		[DataMember]
        public virtual int Year { get; set; }

		[DataMember]
        public virtual int Month { get; set; }

		[DataMember]
        public virtual string StaffId { get; set; }

		[DataMember]
        public virtual string DepartmentId { get; set; }

		[DataMember]
        public virtual int AttendanceDays { get; set; }

		[DataMember]
        public virtual int AnnualLeave { get; set; }

		[DataMember]
        public virtual int SickLeave { get; set; }

		[DataMember]
        public virtual int CasualLeave { get; set; }

		[DataMember]
        public virtual int InjuryLeave { get; set; }

		[DataMember]
        public virtual int MarriageLeave { get; set; }

		[DataMember]
        public virtual int MaternityLeave { get; set; }

		[DataMember]
        public virtual int FuneralLeave { get; set; }

		[DataMember]
        public virtual int AbsentLeave { get; set; }

		[DataMember]
        public virtual decimal NormalOvertime { get; set; }

		[DataMember]
        public virtual decimal WeekendOvertime { get; set; }

		[DataMember]
        public virtual decimal HolidayOvertime { get; set; }

		[DataMember]
        public virtual int NoonShift { get; set; }

		[DataMember]
        public virtual int NightShift { get; set; }

		[DataMember]
        public virtual int OtherNoon { get; set; }

		[DataMember]
        public virtual int OtherNight { get; set; }

		[DataMember]
        public virtual string Remark { get; set; }


        #endregion

    }
}
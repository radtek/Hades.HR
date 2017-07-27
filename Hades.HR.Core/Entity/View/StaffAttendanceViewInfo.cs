using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// HR_StaffAttendanceView
    /// </summary>
    [DataContract]
    public class StaffAttendanceViewInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public StaffAttendanceViewInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.AttendanceDays = 0;
            this.AnnualLeave = 0;
            this.SickLeave = 0;
            this.CasualLeave = 0;
            this.InjuryLeave = 0;
            this.MarriageLeave = 0;
            this.LeaveDays = 0;
            this.NormalOvertime = 0;
            this.NormalOvertimeSalary = 0;
            this.WeekendOvertime = 0;
            this.WeekendOvertimeSalary = 0;
            this.HolidayOvertime = 0;
            this.HolidayOvertimeSalary = 0;
            this.OvertimeSalarySum = 0;
            this.NoonShift = 0;
            this.NightShift = 0;
            this.OtherShift = 0;
            this.LunchAllowance = 0;
            this.LeaderAllowance = 0;
            this.Deduction = 0;
            this.Nutrition = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string AttendanceId { get; set; }

        [DataMember]
        public virtual string StaffId { get; set; }

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
        public virtual int LeaveDays { get; set; }

        [DataMember]
        public virtual int NormalOvertime { get; set; }

        [DataMember]
        public virtual decimal NormalOvertimeSalary { get; set; }

        [DataMember]
        public virtual int WeekendOvertime { get; set; }

        [DataMember]
        public virtual decimal WeekendOvertimeSalary { get; set; }

        [DataMember]
        public virtual int HolidayOvertime { get; set; }

        [DataMember]
        public virtual decimal HolidayOvertimeSalary { get; set; }

        [DataMember]
        public virtual decimal OvertimeSalarySum { get; set; }

        [DataMember]
        public virtual int NoonShift { get; set; }

        [DataMember]
        public virtual int NightShift { get; set; }

        [DataMember]
        public virtual int OtherShift { get; set; }

        [DataMember]
        public virtual decimal LunchAllowance { get; set; }

        [DataMember]
        public virtual decimal LeaderAllowance { get; set; }

        [DataMember]
        public virtual decimal Deduction { get; set; }

        [DataMember]
        public virtual decimal Nutrition { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }

        [DataMember]
        public virtual string Number { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string DepartmentName { get; set; }

        [DataMember]
        public virtual string DepartmentId { get; set; }
        #endregion
    }
}
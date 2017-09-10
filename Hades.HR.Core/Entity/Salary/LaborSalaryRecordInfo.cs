using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborSalaryRecordInfo
    /// </summary>
    [DataContract]
    public class LaborSalaryRecordInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public LaborSalaryRecordInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.AttendanceDays = 0;
            this.AnnualLeave = 0;
            this.SickLeave = 0;
            this.CasualLeave = 0;
            this.InjuryLeave = 0;
            this.MarriageLeave = 0;
            this.AbsentLeave = 0;
            this.LevelSalary = 0;
            this.MonthWorkload = 0;
            this.BaseWorkload = 0;
            this.BaseSalary = 0;
            this.OverWorkload = 0;
            this.OverSalary = 0;
            this.WeekendWorkload = 0;
            this.WeekendSalary = 0;
            this.HolidayWorkload = 0;
            this.HolidaySalary = 0;
            this.Estimation = 0;
            this.Allowance = 0;
            this.WorkshopDeduction = 0;
            this.WorkshopBonus = 0;
            this.BonusDeduction = 0;
            this.TotalSalary = 0;
            this.NoonShift = 0;
            this.NightShift = 0;
            this.OtherNoon = 0;
            this.OtherNight = 0;
            this.ShiftAmount = 0;
            this.QualityBonus = 0;
            this.Deduction = 0;
            this.Nutrition = 0;
            this.EquipmentBonus = 0;
            this.SafetyBonus = 0;
            this.FiveSBonus = 0;
            this.HotBonus = 0;
            this.LunchAllowance = 0;
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
        public virtual int AbsentLeave { get; set; }

        [DataMember]
        public virtual string StaffLevelId { get; set; }

        [DataMember]
        public virtual decimal LevelSalary { get; set; }

        [DataMember]
        public virtual decimal MonthWorkload { get; set; }

        [DataMember]
        public virtual decimal BaseWorkload { get; set; }

        [DataMember]
        public virtual decimal BaseSalary { get; set; }
        
        [DataMember]
        public virtual decimal OverWorkload { get; set; }

        [DataMember]
        public virtual decimal OverSalary { get; set; }

        [DataMember]
        public virtual decimal WeekendWorkload { get; set; }

        [DataMember]
        public virtual decimal WeekendSalary { get; set; }

        [DataMember]
        public virtual decimal HolidayWorkload { get; set; }

        [DataMember]
        public virtual decimal HolidaySalary { get; set; }

        [DataMember]
        public virtual decimal Estimation { get; set; }

        [DataMember]
        public virtual decimal Allowance { get; set; }

        [DataMember]
        public virtual decimal WorkshopDeduction { get; set; }

        [DataMember]
        public virtual decimal WorkshopBonus { get; set; }

        [DataMember]
        public virtual decimal BonusDeduction { get; set; }

        [DataMember]
        public virtual decimal TotalSalary { get; set; }

        [DataMember]
        public virtual int NoonShift { get; set; }

        [DataMember]
        public virtual int NightShift { get; set; }

        [DataMember]
        public virtual int OtherNoon { get; set; }

        [DataMember]
        public virtual int OtherNight { get; set; }

        [DataMember]
        public virtual decimal ShiftAmount { get; set; }

        [DataMember]
        public virtual decimal QualityBonus { get; set; }

        [DataMember]
        public virtual decimal Deduction { get; set; }

        [DataMember]
        public virtual decimal Nutrition { get; set; }

        [DataMember]
        public virtual decimal EquipmentBonus { get; set; }

        [DataMember]
        public virtual decimal SafetyBonus { get; set; }

        [DataMember]
        public virtual decimal FiveSBonus { get; set; }

        [DataMember]
        public virtual decimal HotBonus { get; set; }

        [DataMember]
        public virtual decimal LunchAllowance { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }
        #endregion
    }
}
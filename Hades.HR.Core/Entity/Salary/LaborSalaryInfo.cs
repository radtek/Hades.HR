using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborSalaryInfo
    /// </summary>
    [DataContract]
    public class LaborSalaryInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public LaborSalaryInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Year = 0;
            this.Month = 0;
            this.LevelSalary = 0;
            this.BaseSalary = 0;
            this.OverSalary = 0;
            this.WeekendSalary = 0;
            this.HolidaySalary = 0;
            this.Estimation = 0;
            this.Allowance = 0;
            this.TotalSalary = 0;
            this.ShiftAmount = 0;
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
        public virtual string WorkTeamId { get; set; }

        [DataMember]
        public virtual string FinanceDepartmentId { get; set; }

        [DataMember]
        public virtual string StaffLevelId { get; set; }

        [DataMember]
        public virtual decimal LevelSalary { get; set; }

        [DataMember]
        public virtual decimal BaseSalary { get; set; }

        [DataMember]
        public virtual decimal OverSalary { get; set; }

        [DataMember]
        public virtual decimal WeekendSalary { get; set; }

        [DataMember]
        public virtual decimal HolidaySalary { get; set; }

        [DataMember]
        public virtual decimal Estimation { get; set; }

        [DataMember]
        public virtual decimal Allowance { get; set; }

        [DataMember]
        public virtual decimal TotalSalary { get; set; }

        [DataMember]
        public virtual decimal ShiftAmount { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }

        [DataMember]
        public virtual string Editor { get; set; }

        [DataMember]
        public virtual string EditorId { get; set; }

        [DataMember]
        public virtual DateTime EditTime { get; set; }
        #endregion
    }
}
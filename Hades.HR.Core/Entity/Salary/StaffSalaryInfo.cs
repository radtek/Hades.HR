using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// StaffSalaryInfo
    /// </summary>
    [DataContract]
    public class StaffSalaryInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public StaffSalaryInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
             this.Year= 0;
             this.Month= 0;
                this.LevelSalary= 0;
             this.BaseBonus= 0;
             this.DepartmentBonus= 0;
             this.ReserveFund= 0;
             this.Insurance= 0;
             this.NormalOvertimeSalary= 0;
             this.WeekendOvertimeSalary= 0;
             this.HolidayOvertimeSalary= 0;
             this.OvertimeSalarySum= 0;
             this.TotalSalary= 0;
      
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
        public virtual string StaffLevelId { get; set; }

		[DataMember]
        public virtual decimal LevelSalary { get; set; }

		[DataMember]
        public virtual decimal BaseBonus { get; set; }

		[DataMember]
        public virtual decimal DepartmentBonus { get; set; }

		[DataMember]
        public virtual decimal ReserveFund { get; set; }

		[DataMember]
        public virtual decimal Insurance { get; set; }

		[DataMember]
        public virtual decimal NormalOvertimeSalary { get; set; }

		[DataMember]
        public virtual decimal WeekendOvertimeSalary { get; set; }

		[DataMember]
        public virtual decimal HolidayOvertimeSalary { get; set; }

		[DataMember]
        public virtual decimal OvertimeSalarySum { get; set; }

		[DataMember]
        public virtual decimal TotalSalary { get; set; }

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
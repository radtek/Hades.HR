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
            this.Id = System.Guid.NewGuid();
            this.FinanceDepartment = System.Guid.NewGuid();
            this.BaseSalary = 0;
            this.BaseBonus = 0;
            this.DepartmentBonus = 0;
            this.ReserveFund = 0;
            this.Insurance = 0;

        }

        #region Property Members

        [DataMember]
        public virtual Guid Id { get; set; }

        [DataMember]
        public virtual Guid FinanceDepartment { get; set; }

        [DataMember]
        public virtual string CardNumber { get; set; }

        [DataMember]
        public virtual decimal BaseSalary { get; set; }

        [DataMember]
        public virtual decimal BaseBonus { get; set; }

        [DataMember]
        public virtual decimal DepartmentBonus { get; set; }

        [DataMember]
        public virtual decimal ReserveFund { get; set; }

        [DataMember]
        public virtual decimal Insurance { get; set; }


        #endregion

    }
}
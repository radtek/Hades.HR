using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// HR_StaffSalaryView
    /// </summary>
    [DataContract]
    public class StaffSalaryViewInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public StaffSalaryViewInfo()
        {
            this.BaseSalary = 0;
            this.BaseBonus = 0;
            this.DepartmentBonus = 0;
            this.Insurance = 0;
            this.ReserveFund = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string Number { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string FinanceDepartment { get; set; }

        [DataMember]
        public virtual string CardNumber { get; set; }

        [DataMember]
        public virtual decimal BaseSalary { get; set; }

        [DataMember]
        public virtual decimal BaseBonus { get; set; }

        [DataMember]
        public virtual decimal DepartmentBonus { get; set; }

        [DataMember]
        public virtual decimal Insurance { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }

        [DataMember]
        public virtual decimal ReserveFund { get; set; }

        [DataMember]
        public virtual string Editor { get; set; }

        [DataMember]
        public virtual string EditorId { get; set; }

        [DataMember]
        public virtual DateTime EditTime { get; set; }
        #endregion
    }
}
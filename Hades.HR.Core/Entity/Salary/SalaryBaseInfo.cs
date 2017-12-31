using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// SalaryBaseInfo
    /// </summary>
    [DataContract]
    public class SalaryBaseInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public SalaryBaseInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
                this.StaffLevelId= "0";
             this.BaseBonus= 0;
             this.DepartmentBonus= 0;
             this.ReserveFund= 0;
             this.Insurance= 0;
             this.HighTemp= 0;
      
		}

        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

		[DataMember]
        public virtual string StaffId { get; set; }

		[DataMember]
        public virtual string FinanceDepartmentId { get; set; }

		[DataMember]
        public virtual string CardNumber { get; set; }

		[DataMember]
        public virtual string StaffLevelId { get; set; }

		[DataMember]
        public virtual decimal BaseBonus { get; set; }

		[DataMember]
        public virtual decimal DepartmentBonus { get; set; }

		[DataMember]
        public virtual decimal ReserveFund { get; set; }

		[DataMember]
        public virtual decimal Insurance { get; set; }

		[DataMember]
        public virtual decimal HighTemp { get; set; }

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
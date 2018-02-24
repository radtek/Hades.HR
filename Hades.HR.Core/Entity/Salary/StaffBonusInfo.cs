using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// StaffBonusInfo
    /// </summary>
    [DataContract]
    public class StaffBonusInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public StaffBonusInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
             this.Year= 0;
             this.Month= 0;
                 this.Amount= 0;
             this.TotalBonus= 0;
      
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
        public virtual string FinanceDepartmentId { get; set; }

		[DataMember]
        public virtual string BonusCode { get; set; }

		[DataMember]
        public virtual decimal Amount { get; set; }

		[DataMember]
        public virtual decimal TotalBonus { get; set; }

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
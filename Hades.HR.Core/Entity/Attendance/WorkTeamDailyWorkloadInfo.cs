using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// WorkTeamDailyWorkloadInfo
    /// </summary>
    [DataContract]
    public class WorkTeamDailyWorkloadInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public WorkTeamDailyWorkloadInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
               this.ProductionHours= 0;
             this.ChangeHours= 0;
             this.RepairHours= 0;
             this.ElectricHours= 0;
             this.PersonCount= 0;
      
		}

        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

		[DataMember]
        public virtual string WorkTeamId { get; set; }

		[DataMember]
        public virtual DateTime AttendanceDate { get; set; }

		[DataMember]
        public virtual decimal ProductionHours { get; set; }

		[DataMember]
        public virtual decimal ChangeHours { get; set; }

		[DataMember]
        public virtual decimal RepairHours { get; set; }

		[DataMember]
        public virtual decimal ElectricHours { get; set; }

		[DataMember]
        public virtual int PersonCount { get; set; }

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
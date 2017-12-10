using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// MachineMaintenanceManHoursInfo
    /// </summary>
    [DataContract]
    public class MachineMaintenanceManHoursInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public MachineMaintenanceManHoursInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
              this.ManHours= 0;
              this.CreatorId= 0;
     
		}

        #region Property Members
        
		[DataMember]
        public virtual string ID { get; set; }

		[DataMember]
        public virtual string WorkTeamId { get; set; }

		[DataMember]
        public virtual int ManHours { get; set; }

		[DataMember]
        public virtual DateTime WorkingDate { get; set; }

		[DataMember]
        public virtual int CreatorId { get; set; }

		[DataMember]
        public virtual string Creator { get; set; }

		[DataMember]
        public virtual DateTime CreateTime { get; set; }

		[DataMember]
        public virtual string Remark { get; set; }


        #endregion

    }
}
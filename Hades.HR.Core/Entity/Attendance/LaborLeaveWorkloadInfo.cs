using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborLeaveWorkloadInfo
    /// </summary>
    [DataContract]
    public class LaborLeaveWorkloadInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public LaborLeaveWorkloadInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
                this.LeaveHours= 0;
             this.AllowanceHours= 0;
             this.AssignType= 0;
   
		}

        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

		[DataMember]
        public virtual string WorkTeamId { get; set; }

		[DataMember]
        public virtual DateTime AttendanceDate { get; set; }

		[DataMember]
        public virtual string StaffId { get; set; }

		[DataMember]
        public virtual decimal LeaveHours { get; set; }

		[DataMember]
        public virtual decimal AllowanceHours { get; set; }

		[DataMember]
        public virtual int AssignType { get; set; }

		[DataMember]
        public virtual string Remark { get; set; }


        #endregion

    }
}
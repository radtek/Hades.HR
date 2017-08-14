using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborAttendanceInfo
    /// </summary>
    [DataContract]
    public class LaborAttendanceInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public LaborAttendanceInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
             this.Year= 0;
             this.Month= 0;
             this.Days= 0;
      
		}

        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

		[DataMember]
        public virtual int Year { get; set; }

		[DataMember]
        public virtual int Month { get; set; }

		[DataMember]
        public virtual int Days { get; set; }

		[DataMember]
        public virtual string Remark { get; set; }

		[DataMember]
        public virtual string Editor { get; set; }

		[DataMember]
        public virtual string EditorId { get; set; }

		[DataMember]
        public virtual DateTime EditorTime { get; set; }


        #endregion

    }
}
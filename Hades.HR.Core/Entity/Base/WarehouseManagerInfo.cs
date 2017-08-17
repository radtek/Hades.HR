using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// WarehouseManagerInfo
    /// </summary>
    [DataContract]
    public class WarehouseManagerInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public WarehouseManagerInfo()
		{
                this.Deleted= 0;
             this.Enabled= 0;
  
		}

        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

		[DataMember]
        public virtual string WarehouseId { get; set; }

		[DataMember]
        public virtual string ManagerId { get; set; }

		[DataMember]
        public virtual string Remark { get; set; }

		[DataMember]
        public virtual int Deleted { get; set; }

		[DataMember]
        public virtual int Enabled { get; set; }


        #endregion

    }
}
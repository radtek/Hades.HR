using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// CompletionListInfo
    /// </summary>
    [DataContract]
    public class CompletionListInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public CompletionListInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
                     this.AcceptanceAmount= 0;
             this.UnqualifiedAmount= 0;
             this.DiscardAmount= 0;
                this.ReceiveAmount= 0;
             this.ReturnAmount= 0;
       
		}

        #region Property Members
        
		[DataMember]
        public virtual string ID { get; set; }

		[DataMember]
        public virtual string CompletionListID { get; set; }

		[DataMember]
        public virtual string DispatchListNumber { get; set; }

		[DataMember]
        public virtual string PPrSetId { get; set; }

		[DataMember]
        public virtual string WorkteamId { get; set; }

		[DataMember]
        public virtual string WorkteamName { get; set; }

		[DataMember]
        public virtual DateTime StartTime { get; set; }

		[DataMember]
        public virtual DateTime EndTime { get; set; }

		[DataMember]
        public virtual string Status { get; set; }

		[DataMember]
        public virtual int AcceptanceAmount { get; set; }

		[DataMember]
        public virtual int UnqualifiedAmount { get; set; }

		[DataMember]
        public virtual int DiscardAmount { get; set; }

		[DataMember]
        public virtual string NextProcess { get; set; }

		[DataMember]
        public virtual string NextWorkteamId { get; set; }

		[DataMember]
        public virtual string Receiver { get; set; }

		[DataMember]
        public virtual int ReceiveAmount { get; set; }

		[DataMember]
        public virtual int ReturnAmount { get; set; }

		[DataMember]
        public virtual string Drawer { get; set; }

		[DataMember]
        public virtual DateTime BillingDate { get; set; }

		[DataMember]
        public virtual string Auditor { get; set; }

		[DataMember]
        public virtual DateTime AuditTime { get; set; }

		[DataMember]
        public virtual string Remark { get; set; }


        #endregion

    }
}
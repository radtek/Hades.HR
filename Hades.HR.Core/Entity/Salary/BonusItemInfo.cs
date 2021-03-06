﻿using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// BonusItemInfo
    /// </summary>
    [DataContract]
    public class BonusItemInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public BonusItemInfo()
		{
            this.Id= System.Guid.NewGuid().ToString();
               this.CalcType= 0;
             this.Cardinal= 0;
             this.Coefficient= 0;
             this.Limit= 0;
   
		}

        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

		[DataMember]
        public virtual string Name { get; set; }

		[DataMember]
        public virtual string Code { get; set; }

		[DataMember]
        public virtual int CalcType { get; set; }

		[DataMember]
        public virtual decimal Cardinal { get; set; }

		[DataMember]
        public virtual decimal Coefficient { get; set; }

		[DataMember]
        public virtual decimal Limit { get; set; }

		[DataMember]
        public virtual string Remark { get; set; }


        #endregion

    }
}
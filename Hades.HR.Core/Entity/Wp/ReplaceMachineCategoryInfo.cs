using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// ReplaceMachineCategoryInfo
    /// </summary>
    [DataContract]
    public class ReplaceMachineCategoryInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public ReplaceMachineCategoryInfo()
		{
            this.ID= System.Guid.NewGuid().ToString();
    
		}

        #region Property Members
        
		[DataMember]
        public virtual string ID { get; set; }

		[DataMember]
        public virtual string MasterCateogoryId { get; set; }

		[DataMember]
        public virtual string MasterCategoryName { get; set; }


        #endregion

    }
}
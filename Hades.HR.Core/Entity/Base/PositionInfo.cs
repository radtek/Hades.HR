using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace Hades.HR.Entity
{
    using Hades.Framework.ControlUtil;

    /// <summary>
    /// PositionInfo
    /// </summary>
    [DataContract]
    public class PositionInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public PositionInfo()
        {
            this.Quota = 0;
            this.Deleted = 0;
            this.Enabled = 0;
        }

        #region Property Members
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        [DataMember]
        public virtual string Id { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>
        [Display(Name = "所属部门")]
        [DataMember]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        [Display(Name = "岗位名称")]
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 岗位编码
        /// </summary>
        [Display(Name = "岗位编码")]
        [DataMember]
        public virtual string Number { get; set; }

        /// <summary>
        /// 定员人数
        /// </summary>
        [Display(Name = "定员人数")]
        [DataMember]
        public virtual int Quota { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Display(Name = "排序码")]
        [DataMember]
        public virtual string SortCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [DataMember]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [DataMember]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        [Display(Name = "创建人ID")]
        [DataMember]
        public virtual string CreatorId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [DataMember]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 编辑人
        /// </summary>
        [Display(Name = "编辑人")]
        [DataMember]
        public virtual string Editor { get; set; }

        /// <summary>
        /// 编辑人ID
        /// </summary>
        [Display(Name = "编辑人ID")]
        [DataMember]
        public virtual string EditorId { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        [Display(Name = "编辑时间")]
        [DataMember]
        public virtual DateTime EditTime { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        [Display(Name = "删除标志")]
        [DataMember]
        public virtual int Deleted { get; set; }

        /// <summary>
        /// 启用标志
        /// </summary>
        [Display(Name = "启用标志")]
        [DataMember]
        public virtual int Enabled { get; set; }
        #endregion

    }
}
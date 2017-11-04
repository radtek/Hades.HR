using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Hades.HR.Entity
{
    using Hades.Framework.ControlUtil;

    /// <summary>
    /// DepartmentInfo
    /// </summary>
    [DataContract]
    public class DepartmentInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public DepartmentInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Type = 0;
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
        /// 上级部门ID
        /// </summary>
        [Display(Name = "上级部门ID")]
        [DataMember]
        public virtual string PID { get; set; }

        /// <summary>
        /// 部门代码
        /// </summary>
        [Display(Name = "部门代码")]
        [DataMember]
        public virtual string Number { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Display(Name = "部门名称")]
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Display(Name = "排序码")]
        [DataMember]
        public virtual string SortCode { get; set; }

        /// <summary>
        /// 部门类型
        /// </summary>
        [Display(Name = "部门类型")]
        [DataMember]
        public virtual int Type { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        [DataMember]
        public virtual string Address { get; set; }

        /// <summary>
        /// 内线电话
        /// </summary>
        [Display(Name = "内线电话")]
        [DataMember]
        public virtual string InnerPhone { get; set; }

        /// <summary>
        /// 外线电话
        /// </summary>
        [Display(Name = "外线电话")]
        [DataMember]
        public virtual string OuterPhone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [Display(Name = "传真")]
        [DataMember]
        public virtual string Fax { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [Display(Name = "负责人")]
        [DataMember]
        public virtual string Principal { get; set; }

        /// <summary>
        /// 定员人数
        /// </summary>
        [Display(Name = "定员人数")]
        [DataMember]
        public virtual int Quota { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [DataMember]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        [Display(Name = "成立日期")]
        [DataMember]
        public virtual DateTime FoundDate { get; set; }

        /// <summary>
        /// 关闭日期
        /// </summary>
        [Display(Name = "关闭日期")]
        [DataMember]
        public virtual DateTime CloseDate { get; set; }

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
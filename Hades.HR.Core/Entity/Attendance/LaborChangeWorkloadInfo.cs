﻿using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Hades.Framework.ControlUtil;

namespace Hades.HR.Entity
{
    /// <summary>
    /// LaborChangeWorkloadInfo
    /// </summary>
    [DataContract]
    public class LaborChangeWorkloadInfo : BaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public LaborChangeWorkloadInfo()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.ChangeHours = 0;
            this.AssignType = 0;
        }

        #region Property Members

        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string ChangeId { get; set; }

        [DataMember]
        public virtual string WorkTeamId { get; set; }

        [DataMember]
        public virtual DateTime AttendanceDate { get; set; }

        [DataMember]
        public virtual string StaffId { get; set; }

        [DataMember]
        public virtual decimal ChangeHours { get; set; }

        [DataMember]
        public virtual int AssignType { get; set; }

        [DataMember]
        public virtual string Remark { get; set; }
        #endregion
    }
}
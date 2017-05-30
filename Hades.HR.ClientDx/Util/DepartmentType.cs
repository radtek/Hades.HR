using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hades.HR.UI
{
    /// <summary>
    /// 部门类型
    /// </summary>
    public enum DepartmentType
    {
        /// <summary>
        /// 集团
        /// </summary>
        [Display(Name = "集团")]
        Group = 1,

        /// <summary>
        /// 公司
        /// </summary>
        [Display(Name = "公司")]
        Company = 2,

        /// <summary>
        /// 部门
        /// </summary>
        [Display(Name = "部门")]
        Department = 3,

        /// <summary>
        /// 工作组
        /// </summary>
        [Display(Name = "工作组")]
        Team = 4
    }
}

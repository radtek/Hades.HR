using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    
using System.Linq;
using System.Text;

namespace Hades.HR.Util
{
    /// <summary>
    /// 缺勤类型
    /// </summary>
    public enum AbsentType
    {
        [Display(Name = "无")]
        None = 0,

        [Display(Name = "休息")]
        Rest = 1,

        [Display(Name = "年假")]
        AnnualLeave = 2,

        [Display(Name = "病假")]
        SickLeave = 3,

        [Display(Name = "事假")]
        CasualLeave = 4,

        [Display(Name = "工伤假")]
        InjuryLeave = 5,

        [Display(Name = "婚产丧假")]
        MarriageLeave = 6,

        [Display(Name = "旷工")]
        AbsentLeave = 7
    }

    /// <summary>
    /// 职员类型
    /// </summary>
    public enum StaffType
    {
        [Display(Name = "管理员工")]
        Manage = 1,

        [Display(Name = "计件员工")]
        Labor = 2
    }
}

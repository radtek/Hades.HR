using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hades.HR.UI
{
    /// <summary>
    /// 缺勤类型
    /// </summary>
    public enum AbsentType
    {
        [Display(Name = "无")]
        None = 0,

        [Display(Name = "年假")]
        AnnualLeave = 1,

        [Display(Name = "病假")]
        SickLeave = 2,

        [Display(Name = "事假")]
        CasualLeave = 3,

        [Display(Name = "工伤假")]
        InjuryLeave = 4,

        [Display(Name = "婚产丧假")]
        MarriageLeave = 5,

        [Display(Name = "缺勤")]
        AbsentLeave = 6
    }
}

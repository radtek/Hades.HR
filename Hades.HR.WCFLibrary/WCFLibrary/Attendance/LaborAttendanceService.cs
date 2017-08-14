using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WCFLibrary
{
	/// <summary>
	/// 基于WCFLibrary的LaborAttendance对象调用类
	/// </summary>
    public class LaborAttendanceService : BaseLocalService<LaborAttendanceInfo>, ILaborAttendanceService
    {
        private LaborAttendance bll = null;

        public LaborAttendanceService() : base(BLLFactory<LaborAttendance>.Instance)
        {
            bll = baseBLL as LaborAttendance;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<LaborAttendanceInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}

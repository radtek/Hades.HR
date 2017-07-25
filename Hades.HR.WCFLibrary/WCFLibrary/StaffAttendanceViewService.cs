using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WCFLibrary
{
	/// <summary>
	/// 基于WCFLibrary的StaffAttendanceView对象调用类
	/// </summary>
    public class StaffAttendanceViewService : BaseLocalService<StaffAttendanceViewInfo>, IStaffAttendanceViewService
    {
        private StaffAttendanceView bll = null;

        public StaffAttendanceViewService() : base(BLLFactory<StaffAttendanceView>.Instance)
        {
            bll = baseBLL as StaffAttendanceView;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<StaffAttendanceViewInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}

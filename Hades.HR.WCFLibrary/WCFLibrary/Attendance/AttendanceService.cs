﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WCFLibrary
{
	/// <summary>
	/// 基于WCFLibrary的Attendance对象调用类
	/// </summary>
    public class AttendanceService : BaseLocalService<AttendanceInfo>, IAttendanceService
    {
        private Attendance bll = null;

        public AttendanceService() : base(BLLFactory<Attendance>.Instance)
        {
            bll = baseBLL as Attendance;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<AttendanceInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public async Task<List<AttendanceInfo>> FindByNameAsyn(string name)
        //{
        //   return await Task.Factory.StartNew(() =>
        //   {
        //       return bll.FindByName(name);
	//   }
        //}

    }
}

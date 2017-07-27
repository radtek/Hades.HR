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
	/// 基于WCFLibrary的StaffSalaryDefine对象调用类
	/// </summary>
    public class StaffSalaryDefineService : BaseLocalService<StaffSalaryDefineInfo>, IStaffSalaryDefineService
    {
        private StaffSalaryDefine bll = null;

        public StaffSalaryDefineService() : base(BLLFactory<StaffSalaryDefine>.Instance)
        {
            bll = baseBLL as StaffSalaryDefine;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<StaffSalaryDefineInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}

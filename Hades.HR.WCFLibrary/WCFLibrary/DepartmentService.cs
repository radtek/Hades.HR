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
	/// 基于WCFLibrary的Department对象调用类
	/// </summary>
    public class DepartmentService : BaseLocalService<DepartmentInfo>, IDepartmentService
    {
        private Department bll = null;

        public DepartmentService() : base(BLLFactory<Department>.Instance)
        {
            bll = baseBLL as Department;
        }

        public bool CheckDuplicate(DepartmentInfo entity, out string message)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<DepartmentInfo> FindList(int deleted, int enabled)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentInfo> FindWithChildren(string id)
        {
            throw new NotImplementedException();
        }

        public bool MarkDelete(string id)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<DepartmentInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}

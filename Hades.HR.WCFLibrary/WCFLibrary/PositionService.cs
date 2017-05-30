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
	/// 基于WCFLibrary的Position对象调用类
	/// </summary>
    public class PositionService : BaseLocalService<PositionInfo>, IPositionService
    {
        private Position bll = null;

        public PositionService() : base(BLLFactory<Position>.Instance)
        {
            bll = baseBLL as Position;
        }

        public bool CheckDuplicate(PositionInfo entity, out string message)
        {
            throw new NotImplementedException();
        }

        public List<PositionInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<PositionInfo> FindByDepartment(string departmentId)
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
        //public List<PositionInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}

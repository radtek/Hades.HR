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
        #region Field
        private Department bll = null;
        #endregion //Field

        #region Constructor
        public DepartmentService() : base(BLLFactory<Department>.Instance)
        {
            bll = baseBLL as Department;
        }
        #endregion //Constructor

        #region Method
        public bool CheckDuplicate(DepartmentInfo entity)
        {
            return bll.CheckDuplicate(entity);
        }

        /// <summary>
        /// 查找所有部门，不包含已删除
        /// </summary>
        /// <returns></returns>
        public List<DepartmentInfo> FindAll()
        {
            return bll.FindAll();
        }

        /// <summary>
        /// 查找部门列表
        /// </summary>
        /// <param name="deleted">删除标志</param>
        /// <param name="enabled">启用标志</param>
        /// <returns></returns>
        public List<DepartmentInfo> FindList(int deleted, int enabled)
        {
            return bll.FindList(deleted, enabled);
        }

        /// <summary>
        /// 查找部门及其子部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
        public List<DepartmentInfo> FindWithChildren(string id)
        {
            return bll.FindWithChildren(id);
        }

        public bool MarkDelete(string id)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}

using System;
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
        /// <summary>
        /// 查找部门及其子部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
        public List<DepartmentInfo> FindWithChildren(string id)
        {
            return bll.FindWithChildren(id);
        }

        /// <summary>
        /// 查找部门及其子部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
        [OperationContract]
        public async Task<List<DepartmentInfo>> FindWithChildrenAsync(string id)
        {
            var task = Task.Factory.StartNew(() =>
            {
                return bll.FindWithChildren(id);
            });

            return await task;
        }

        public bool CheckDuplicate(DepartmentInfo entity)
        {
            return bll.CheckDuplicate(entity);
        }

        public bool MarkDelete(string id)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}

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
        public async Task<List<DepartmentInfo>> FindWithChildrenAsyn(string id)
        {
            var task = Task.Factory.StartNew(() =>
            {
                return bll.FindWithChildren(id);
            });

            return await task;
        }

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool CheckDuplicate(DepartmentInfo entity)
        {
            return bll.CheckDuplicate(entity);
        }

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public async Task<bool> CheckDuplicateAsyn(DepartmentInfo entity)
        {
            return await Task.Factory.StartNew(() =>
            {
                return bll.CheckDuplicate(entity);
            });
        }

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool MarkDelete(string id)
        {
            return bll.MarkDelete(id);
        }

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> MarkDeleteAsyn(string id)
        {
            return await Task.Factory.StartNew(() =>
            {
                return bll.MarkDelete(id);
            });
        }
        #endregion //Method
    }
}

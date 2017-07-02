using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.WinformCaller
{
	/// <summary>
	/// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
	/// </summary>
    public class DepartmentCaller : BaseLocalService<DepartmentInfo>, IDepartmentService
    {
        private Department bll = null;

        #region Constructor
        public DepartmentCaller() : base(BLLFactory<Department>.Instance)
        {
            bll = baseBLL as Department;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据名称查找对象Asyn(自定义接口使用范例)
        /// </summary>
        //public async Task<List<DepartmentInfo>> FindAllAsync()
        //{
        //    return await Task.Run(() =>
        //    {
        //        return bll.FindAll();
        //    });
        //}

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
            return await Task.Factory.StartNew(() =>
            {
                return bll.FindWithChildren(id);
            });
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
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool MarkDelete(string id)
        {
            return bll.MarkDelete(id);
        }
        #endregion //Method
    }
}

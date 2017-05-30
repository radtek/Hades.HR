using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;

namespace Hades.HR.Facade
{
    [ServiceContract]
    public interface IDepartmentService : IBaseService<DepartmentInfo>
    {
        /// <summary>
        /// 查找所有部门，不包含已删除
        /// </summary>
        /// <returns></returns>
        List<DepartmentInfo> FindAll();

        /// <summary>
        /// 查找部门列表
        /// </summary>
        /// <param name="deleted">删除标志</param>
        /// <param name="enabled">启用标志</param>
        /// <returns></returns>
        List<DepartmentInfo> FindList(int deleted, int enabled);

        /// <summary>
        /// 查找部门及其子部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
        List<DepartmentInfo> FindWithChildren(string id);

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="message">错误消息</param>
        /// <returns></returns>
        bool CheckDuplicate(DepartmentInfo entity, out string message);

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        bool MarkDelete(string id);
    }
}

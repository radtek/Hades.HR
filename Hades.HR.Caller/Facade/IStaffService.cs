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
    public interface IStaffService : IBaseService<StaffInfo>
    {
        /// <summary>
        /// 查找某一部门下员工
        /// </summary>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        List<StaffInfo> FindByDepartment(string departmentId);

        /// <summary>
        /// 查找多个部门员工
        /// </summary>
        /// <param name="ids">部门ID列表</param>
        /// <returns></returns>
        List<StaffInfo> FindByDepartments(List<string> idList);

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="message">错误消息</param>
        /// <returns></returns>
        bool CheckDuplicate(StaffInfo entity, out string message);

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        bool MarkDelete(string id);
    }
}

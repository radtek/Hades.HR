﻿using System;
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
    public interface IPositionService : IBaseService<PositionInfo>
    {
        /// <summary>
        /// 查找所有岗位，不包含已删除
        /// </summary>
        /// <returns></returns>
        List<PositionInfo> FindAll();

        /// <summary>
        /// 根据部门查找岗位
        /// </summary>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        List<PositionInfo> FindByDepartment(string departmentId);

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="message">错误消息</param>
        /// <returns></returns>
        bool CheckDuplicate(PositionInfo entity, out string message);

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        bool MarkDelete(string id);
    }
}

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
    public interface IPositionService : IBaseService<PositionInfo>
    {
        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool CheckDuplicate(PositionInfo entity);

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        bool MarkDelete(string id);
    }
}

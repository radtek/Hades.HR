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
    public interface IWorkSectionLaborService : IBaseService<WorkSectionLaborInfo>
    {
        /// <summary>
        /// 保存职员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        int SaveLabors(List<WorkSectionLaborInfo> data);
    }
}

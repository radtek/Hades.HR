﻿using System;
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
	/// 基于WCFLibrary的Staff对象调用类
	/// </summary>
    public class StaffService : BaseLocalService<StaffInfo>, IStaffService
    {
        #region Field
        private Staff bll = null;
        #endregion //Field

        #region Constructor
        public StaffService() : base(BLLFactory<Staff>.Instance)
        {
            bll = baseBLL as Staff;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool CheckDuplicate(StaffInfo entity)
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

﻿using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

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
    public class StaffCaller : BaseLocalService<StaffInfo>, IStaffService
    {
        #region Field
        private Staff bll = null;
        #endregion //Field

        #region Constructor
        public StaffCaller() : base(BLLFactory<Staff>.Instance)
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

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<StaffInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}

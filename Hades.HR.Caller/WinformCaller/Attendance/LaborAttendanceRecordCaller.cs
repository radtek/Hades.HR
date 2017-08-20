﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public class LaborAttendanceRecordCaller : BaseLocalService<LaborAttendanceRecordInfo>, ILaborAttendanceRecordService
    {
        #region Field
        private LaborAttendanceRecord bll = null;
        #endregion //Field

        #region Constructor
        public LaborAttendanceRecordCaller() : base(BLLFactory<LaborAttendanceRecord>.Instance)
        {
            bll = baseBLL as LaborAttendanceRecord;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 插入班组日考勤记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string InsertRecords(List<LaborAttendanceRecordInfo> data)
        {
            return bll.InsertRecords(data);
        }
        #endregion //Method
    }
}

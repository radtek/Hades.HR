﻿using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Hades.Pager.Entity;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Hades.HR.Entity;
using Hades.HR.IDAL;

namespace Hades.HR.DALSQL
{
    /// <summary>
    /// LaborDailyAttendance
    /// </summary>
	public class LaborDailyAttendance : BaseDALSQL<LaborDailyAttendanceInfo>, ILaborDailyAttendance
    {
        #region 对象实例及构造函数

        public static LaborDailyAttendance Instance
        {
            get
            {
                return new LaborDailyAttendance();
            }
        }
        public LaborDailyAttendance() : base("HR_LaborDailyAttendance", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override LaborDailyAttendanceInfo DataReaderToEntity(IDataReader dataReader)
        {
            LaborDailyAttendanceInfo info = new LaborDailyAttendanceInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.AttendanceDate = reader.GetDateTime("AttendanceDate");
            info.StaffId = reader.GetString("StaffId");
            info.AbsentType = reader.GetInt32("AbsentType");
            info.WorkHours = reader.GetDecimal("WorkHours");
            info.AbsentHours = reader.GetDecimal("AbsentHours");
            info.IsWeekend = reader.GetBoolean("IsWeekend");
            info.IsHoliday = reader.GetBoolean("IsHoliday");
            info.Remark = reader.GetString("Remark");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(LaborDailyAttendanceInfo obj)
        {
            LaborDailyAttendanceInfo info = obj as LaborDailyAttendanceInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("AttendanceDate", info.AttendanceDate);
            hash.Add("StaffId", info.StaffId);
            hash.Add("AbsentType", info.AbsentType);
            hash.Add("WorkHours", info.WorkHours);
            hash.Add("AbsentHours", info.AbsentHours);
            hash.Add("IsWeekend", info.IsWeekend);
            hash.Add("IsHoliday", info.IsHoliday);
            hash.Add("Remark", info.Remark);

            return hash;
        }

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
            dict.Add("Id", "");
            dict.Add("WorkTeamId", "班组名称");
            dict.Add("AttendanceDate", "考勤日期");
            dict.Add("StaffId", "职员姓名");
            dict.Add("AbsentType", "缺勤类型");
            dict.Add("WorkHours", "工作工时");
            dict.Add("AbsentHours", "请假工时");
            dict.Add("IsWeekend", "是否周末");
            dict.Add("IsHoliday", "是否节假日");
            dict.Add("Remark", "备注");
            #endregion

            return dict;
        }
    }
}
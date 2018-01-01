using System;
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
    /// LaborMonthAttendance
    /// </summary>
	public class LaborMonthAttendance : BaseDALSQL<LaborMonthAttendanceInfo>, ILaborMonthAttendance
    {
        #region 对象实例及构造函数

        public static LaborMonthAttendance Instance
        {
            get
            {
                return new LaborMonthAttendance();
            }
        }
        public LaborMonthAttendance() : base("HR_LaborMonthAttendance", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override LaborMonthAttendanceInfo DataReaderToEntity(IDataReader dataReader)
        {
            LaborMonthAttendanceInfo info = new LaborMonthAttendanceInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.Year = reader.GetInt32("Year");
            info.Month = reader.GetInt32("Month");
            info.StaffId = reader.GetString("StaffId");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.AttendanceDays = reader.GetInt32("AttendanceDays");
            info.AnnualLeave = reader.GetInt32("AnnualLeave");
            info.SickLeave = reader.GetInt32("SickLeave");
            info.CasualLeave = reader.GetInt32("CasualLeave");
            info.InjuryLeave = reader.GetInt32("InjuryLeave");
            info.MarriageLeave = reader.GetInt32("MarriageLeave");
            info.MaternityLeave = reader.GetInt32("MaternityLeave");
            info.FuneralLeave = reader.GetInt32("FuneralLeave");
            info.AbsentLeave = reader.GetInt32("AbsentLeave");
            info.MonthWorkload = reader.GetDecimal("MonthWorkload");
            info.BaseWorkload = reader.GetDecimal("BaseWorkload");
            info.OverWorkload = reader.GetDecimal("OverWorkload");
            info.WeekendWorkload = reader.GetDecimal("WeekendWorkload");
            info.HolidayWorkload = reader.GetDecimal("HolidayWorkload");
            info.NoonShift = reader.GetInt32("NoonShift");
            info.NightShift = reader.GetInt32("NightShift");
            info.OtherNoon = reader.GetInt32("OtherNoon");
            info.OtherNight = reader.GetInt32("OtherNight");
            info.Remark = reader.GetString("Remark");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(LaborMonthAttendanceInfo obj)
        {
            LaborMonthAttendanceInfo info = obj as LaborMonthAttendanceInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("Year", info.Year);
            hash.Add("Month", info.Month);
            hash.Add("StaffId", info.StaffId);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("AttendanceDays", info.AttendanceDays);
            hash.Add("AnnualLeave", info.AnnualLeave);
            hash.Add("SickLeave", info.SickLeave);
            hash.Add("CasualLeave", info.CasualLeave);
            hash.Add("InjuryLeave", info.InjuryLeave);
            hash.Add("MarriageLeave", info.MarriageLeave);
            hash.Add("MaternityLeave", info.MaternityLeave);
            hash.Add("FuneralLeave", info.FuneralLeave);
            hash.Add("AbsentLeave", info.AbsentLeave);
            hash.Add("MonthWorkload", info.MonthWorkload);
            hash.Add("BaseWorkload", info.BaseWorkload);
            hash.Add("OverWorkload", info.OverWorkload);
            hash.Add("WeekendWorkload", info.WeekendWorkload);
            hash.Add("HolidayWorkload", info.HolidayWorkload);
            hash.Add("NoonShift", info.NoonShift);
            hash.Add("NightShift", info.NightShift);
            hash.Add("OtherNoon", info.OtherNoon);
            hash.Add("OtherNight", info.OtherNight);
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
            dict.Add("Year", "");
            dict.Add("Month", "");
            dict.Add("StaffId", "");
            dict.Add("WorkTeamId", "");
            dict.Add("AttendanceDays", "");
            dict.Add("AnnualLeave", "");
            dict.Add("SickLeave", "");
            dict.Add("CasualLeave", "");
            dict.Add("InjuryLeave", "");
            dict.Add("MarriageLeave", "");
            dict.Add("MaternityLeave", "");
            dict.Add("FuneralLeave", "");
            dict.Add("AbsentLeave", "");
            dict.Add("MonthWorkload", "");
            dict.Add("BaseWorkload", "");
            dict.Add("OverWorkload", "");
            dict.Add("WeekendWorkload", "");
            dict.Add("HolidayWorkload", "");
            dict.Add("NoonShift", "");
            dict.Add("NightShift", "");
            dict.Add("OtherNoon", "");
            dict.Add("OtherNight", "");
            dict.Add("Remark", "");
            #endregion
            return dict;
        }

    }
}
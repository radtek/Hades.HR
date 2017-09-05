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
    /// LaborSalaryRecord
    /// </summary>
	public class LaborSalaryRecord : BaseDALSQL<LaborSalaryRecordInfo>, ILaborSalaryRecord
	{
		#region 对象实例及构造函数

		public static LaborSalaryRecord Instance
		{
			get
			{
				return new LaborSalaryRecord();
			}
		}
		public LaborSalaryRecord() : base("HR_LaborSalaryRecord","Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override LaborSalaryRecordInfo DataReaderToEntity(IDataReader dataReader)
		{
			LaborSalaryRecordInfo info = new LaborSalaryRecordInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Id = reader.GetString("Id");
			info.AttendanceId = reader.GetString("AttendanceId");
			info.StaffId = reader.GetString("StaffId");
			info.AttendanceDays = reader.GetInt32("AttendanceDays");
			info.AnnualLeave = reader.GetInt32("AnnualLeave");
			info.SickLeave = reader.GetInt32("SickLeave");
			info.CasualLeave = reader.GetInt32("CasualLeave");
			info.InjuryLeave = reader.GetInt32("InjuryLeave");
			info.MarriageLeave = reader.GetInt32("MarriageLeave");
			info.AbsentLeave = reader.GetInt32("AbsentLeave");
			info.StaffLevelId = reader.GetString("StaffLevelId");
			info.LevelSalary = reader.GetDecimal("LevelSalary");
			info.MonthWorkload = reader.GetDecimal("MonthWorkload");
			info.BaseWorkload = reader.GetDecimal("BaseWorkload");
			info.WeekendWorkload = reader.GetDecimal("WeekendWorkload");
			info.HolidayWorkload = reader.GetDecimal("HolidayWorkload");
			info.Estimation = reader.GetDecimal("Estimation");
			info.Allowance = reader.GetDecimal("Allowance");
			info.WorkshopDeduction = reader.GetDecimal("WorkshopDeduction");
			info.WorkshopBonus = reader.GetDecimal("WorkshopBonus");
			info.BonusDeduction = reader.GetDecimal("BonusDeduction");
			info.NoonShift = reader.GetInt32("NoonShift");
			info.NightShift = reader.GetInt32("NightShift");
			info.OtherNoon = reader.GetInt32("OtherNoon");
			info.OtherNight = reader.GetInt32("OtherNight");
			info.ShiftAmount = reader.GetDecimal("ShiftAmount");
			info.QualityBonus = reader.GetDecimal("QualityBonus");
			info.Deduction = reader.GetDecimal("Deduction");
			info.Nutrition = reader.GetDecimal("Nutrition");
			info.EquipmentBonus = reader.GetDecimal("EquipmentBonus");
			info.SafetyBonus = reader.GetDecimal("SafetyBonus");
			info.FiveSBonus = reader.GetDecimal("FiveSBonus");
			info.HotBonus = reader.GetDecimal("HotBonus");
			info.LunchAllowance = reader.GetDecimal("LunchAllowance");
			info.Remark = reader.GetString("Remark");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(LaborSalaryRecordInfo obj)
		{
		    LaborSalaryRecordInfo info = obj as LaborSalaryRecordInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("Id", info.Id);
 			hash.Add("AttendanceId", info.AttendanceId);
 			hash.Add("StaffId", info.StaffId);
 			hash.Add("AttendanceDays", info.AttendanceDays);
 			hash.Add("AnnualLeave", info.AnnualLeave);
 			hash.Add("SickLeave", info.SickLeave);
 			hash.Add("CasualLeave", info.CasualLeave);
 			hash.Add("InjuryLeave", info.InjuryLeave);
 			hash.Add("MarriageLeave", info.MarriageLeave);
 			hash.Add("AbsentLeave", info.AbsentLeave);
 			hash.Add("StaffLevelId", info.StaffLevelId);
 			hash.Add("LevelSalary", info.LevelSalary);
 			hash.Add("MonthWorkload", info.MonthWorkload);
 			hash.Add("BaseWorkload", info.BaseWorkload);
 			hash.Add("WeekendWorkload", info.WeekendWorkload);
 			hash.Add("HolidayWorkload", info.HolidayWorkload);
 			hash.Add("Estimation", info.Estimation);
 			hash.Add("Allowance", info.Allowance);
 			hash.Add("WorkshopDeduction", info.WorkshopDeduction);
 			hash.Add("WorkshopBonus", info.WorkshopBonus);
 			hash.Add("BonusDeduction", info.BonusDeduction);
 			hash.Add("NoonShift", info.NoonShift);
 			hash.Add("NightShift", info.NightShift);
 			hash.Add("OtherNoon", info.OtherNoon);
 			hash.Add("OtherNight", info.OtherNight);
 			hash.Add("ShiftAmount", info.ShiftAmount);
 			hash.Add("QualityBonus", info.QualityBonus);
 			hash.Add("Deduction", info.Deduction);
 			hash.Add("Nutrition", info.Nutrition);
 			hash.Add("EquipmentBonus", info.EquipmentBonus);
 			hash.Add("SafetyBonus", info.SafetyBonus);
 			hash.Add("FiveSBonus", info.FiveSBonus);
 			hash.Add("HotBonus", info.HotBonus);
 			hash.Add("LunchAllowance", info.LunchAllowance);
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
             dict.Add("AttendanceId", "");
             dict.Add("StaffId", "");
             dict.Add("AttendanceDays", "");
             dict.Add("AnnualLeave", "");
             dict.Add("SickLeave", "");
             dict.Add("CasualLeave", "");
             dict.Add("InjuryLeave", "");
             dict.Add("MarriageLeave", "");
             dict.Add("AbsentLeave", "");
             dict.Add("StaffLevelId", "");
             dict.Add("LevelSalary", "");
             dict.Add("MonthWorkload", "");
             dict.Add("BaseWorkload", "");
             dict.Add("WeekendWorkload", "");
             dict.Add("HolidayWorkload", "");
             dict.Add("Estimation", "");
             dict.Add("Allowance", "");
             dict.Add("WorkshopDeduction", "");
             dict.Add("WorkshopBonus", "");
             dict.Add("BonusDeduction", "");
             dict.Add("NoonShift", "");
             dict.Add("NightShift", "");
             dict.Add("OtherNoon", "");
             dict.Add("OtherNight", "");
             dict.Add("ShiftAmount", "");
             dict.Add("QualityBonus", "");
             dict.Add("Deduction", "");
             dict.Add("Nutrition", "");
             dict.Add("EquipmentBonus", "");
             dict.Add("SafetyBonus", "");
             dict.Add("FiveSBonus", "");
             dict.Add("HotBonus", "");
             dict.Add("LunchAllowance", "");
             dict.Add("Remark", "");
             #endregion

            return dict;
        }

    }
}
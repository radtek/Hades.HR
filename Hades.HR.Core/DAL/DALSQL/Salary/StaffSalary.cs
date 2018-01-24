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
    /// StaffSalary
    /// </summary>
	public class StaffSalary : BaseDALSQL<StaffSalaryInfo>, IStaffSalary
    {
        #region 对象实例及构造函数

        public static StaffSalary Instance
        {
            get
            {
                return new StaffSalary();
            }
        }
        public StaffSalary() : base("HR_StaffSalary", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override StaffSalaryInfo DataReaderToEntity(IDataReader dataReader)
        {
            StaffSalaryInfo info = new StaffSalaryInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.Year = reader.GetInt32("Year");
            info.Month = reader.GetInt32("Month");
            info.StaffId = reader.GetString("StaffId");
            info.DepartmentId = reader.GetString("DepartmentId");
            info.StaffLevelId = reader.GetString("StaffLevelId");
            info.LevelSalary = reader.GetDecimal("LevelSalary");
            info.BaseBonus = reader.GetDecimal("BaseBonus");
            info.DepartmentBonus = reader.GetDecimal("DepartmentBonus");
            info.ReserveFund = reader.GetDecimal("ReserveFund");
            info.Insurance = reader.GetDecimal("Insurance");
            info.NormalOvertimeSalary = reader.GetDecimal("NormalOvertimeSalary");
            info.WeekendOvertimeSalary = reader.GetDecimal("WeekendOvertimeSalary");
            info.HolidayOvertimeSalary = reader.GetDecimal("HolidayOvertimeSalary");
            info.OvertimeSalarySum = reader.GetDecimal("OvertimeSalarySum");
            info.TotalSalary = reader.GetDecimal("TotalSalary");
            info.Remark = reader.GetString("Remark");
            info.Editor = reader.GetString("Editor");
            info.EditorId = reader.GetString("EditorId");
            info.EditTime = reader.GetDateTime("EditTime");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(StaffSalaryInfo obj)
        {
            StaffSalaryInfo info = obj as StaffSalaryInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("Year", info.Year);
            hash.Add("Month", info.Month);
            hash.Add("StaffId", info.StaffId);
            hash.Add("DepartmentId", info.DepartmentId);
            hash.Add("StaffLevelId", info.StaffLevelId);
            hash.Add("LevelSalary", info.LevelSalary);
            hash.Add("BaseBonus", info.BaseBonus);
            hash.Add("DepartmentBonus", info.DepartmentBonus);
            hash.Add("ReserveFund", info.ReserveFund);
            hash.Add("Insurance", info.Insurance);
            hash.Add("NormalOvertimeSalary", info.NormalOvertimeSalary);
            hash.Add("WeekendOvertimeSalary", info.WeekendOvertimeSalary);
            hash.Add("HolidayOvertimeSalary", info.HolidayOvertimeSalary);
            hash.Add("OvertimeSalarySum", info.OvertimeSalarySum);
            hash.Add("TotalSalary", info.TotalSalary);
            hash.Add("Remark", info.Remark);
            hash.Add("Editor", info.Editor);
            hash.Add("EditorId", info.EditorId);
            hash.Add("EditTime", info.EditTime);

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
            dict.Add("Year", "年");
            dict.Add("Month", "月");
            dict.Add("StaffId", "职员姓名");
            dict.Add("DepartmentId", "部门名称");
            dict.Add("StaffLevelId", "职员级别");
            dict.Add("LevelSalary", "级别工资");
            dict.Add("BaseBonus", "基本奖金");
            dict.Add("DepartmentBonus", "部门奖金");
            dict.Add("ReserveFund", "公积金");
            dict.Add("Insurance", "保险费");
            dict.Add("NormalOvertimeSalary", "平时加班工资");
            dict.Add("WeekendOvertimeSalary", "周末加班工资");
            dict.Add("HolidayOvertimeSalary", "节假日加班工资");
            dict.Add("OvertimeSalarySum", "加班工资合计");
            dict.Add("TotalSalary", "工资合计");
            dict.Add("Remark", "备注");
            dict.Add("Editor", "");
            dict.Add("EditorId", "");
            dict.Add("EditTime", "");
            #endregion

            return dict;
        }
    }
}
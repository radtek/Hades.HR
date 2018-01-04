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
    /// LaborSalary
    /// </summary>
	public class LaborSalary : BaseDALSQL<LaborSalaryInfo>, ILaborSalary
    {
        #region 对象实例及构造函数

        public static LaborSalary Instance
        {
            get
            {
                return new LaborSalary();
            }
        }
        public LaborSalary() : base("HR_LaborSalary", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override LaborSalaryInfo DataReaderToEntity(IDataReader dataReader)
        {
            LaborSalaryInfo info = new LaborSalaryInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.Year = reader.GetInt32("Year");
            info.Month = reader.GetInt32("Month");
            info.StaffId = reader.GetString("StaffId");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.StaffLevelId = reader.GetString("StaffLevelId");
            info.LevelSalary = reader.GetDecimal("LevelSalary");
            info.BaseSalary = reader.GetDecimal("BaseSalary");
            info.OverSalary = reader.GetDecimal("OverSalary");
            info.WeekendSalary = reader.GetDecimal("WeekendSalary");
            info.HolidaySalary = reader.GetDecimal("HolidaySalary");
            info.Estimation = reader.GetDecimal("Estimation");
            info.Allowance = reader.GetDecimal("Allowance");
            info.TotalSalary = reader.GetDecimal("TotalSalary");
            info.ShiftAmount = reader.GetDecimal("ShiftAmount");
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
        protected override Hashtable GetHashByEntity(LaborSalaryInfo obj)
        {
            LaborSalaryInfo info = obj as LaborSalaryInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("Year", info.Year);
            hash.Add("Month", info.Month);
            hash.Add("StaffId", info.StaffId);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("StaffLevelId", info.StaffLevelId);
            hash.Add("LevelSalary", info.LevelSalary);
            hash.Add("BaseSalary", info.BaseSalary);
            hash.Add("OverSalary", info.OverSalary);
            hash.Add("WeekendSalary", info.WeekendSalary);
            hash.Add("HolidaySalary", info.HolidaySalary);
            hash.Add("Estimation", info.Estimation);
            hash.Add("Allowance", info.Allowance);
            hash.Add("TotalSalary", info.TotalSalary);
            hash.Add("ShiftAmount", info.ShiftAmount);
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
            dict.Add("WorkTeamId", "班组名称");
            dict.Add("StaffLevelId", "职员级别");
            dict.Add("LevelSalary", "级别工资");
            dict.Add("BaseSalary", "基本工资");
            dict.Add("OverSalary", "超产工资");
            dict.Add("WeekendSalary", "周末工资");
            dict.Add("HolidaySalary", "法定假日工资");
            dict.Add("Estimation", "月综合考核奖");
            dict.Add("Allowance", "月度津贴");
            dict.Add("TotalSalary", "工资合计");
            dict.Add("ShiftAmount", "中夜班金额");
            dict.Add("Remark", "备注");
            dict.Add("Editor", "");
            dict.Add("EditorId", "");
            dict.Add("EditTime", "");
            #endregion

            return dict;
        }
    }
}
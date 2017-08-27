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
    /// StaffLevel
    /// </summary>
	public class StaffLevel : BaseDALSQL<StaffLevelInfo>, IStaffLevel
    {
        #region 对象实例及构造函数

        public static StaffLevel Instance
        {
            get
            {
                return new StaffLevel();
            }
        }
        public StaffLevel() : base("HR_StaffLevel", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override StaffLevelInfo DataReaderToEntity(IDataReader dataReader)
        {
            StaffLevelInfo info = new StaffLevelInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.Name = reader.GetString("Name");
            info.Salary = reader.GetDecimal("Salary");
            info.SortCode = reader.GetString("SortCode");
            info.Remark = reader.GetString("Remark");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(StaffLevelInfo obj)
        {
            StaffLevelInfo info = obj as StaffLevelInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("Name", info.Name);
            hash.Add("Salary", info.Salary);
            hash.Add("SortCode", info.SortCode);
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
            dict.Add("Name", "等级名称");
            dict.Add("Salary", "级别工资");
            dict.Add("SortCode", "排序码");
            dict.Add("Remark", "备注");
            #endregion

            return dict;
        }
    }
}
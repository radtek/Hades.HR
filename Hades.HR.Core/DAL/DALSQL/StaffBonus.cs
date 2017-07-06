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
    /// StaffBonus
    /// </summary>
	public class StaffBonus : BaseDALSQL<StaffBonusInfo>, IStaffBonus
    {
        #region 对象实例及构造函数

        public static StaffBonus Instance
        {
            get
            {
                return new StaffBonus();
            }
        }
        public StaffBonus() : base("HR_StaffBonus", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override StaffBonusInfo DataReaderToEntity(IDataReader dataReader)
        {
            StaffBonusInfo info = new StaffBonusInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.StaffId = reader.GetString("StaffId");
            info.Name = reader.GetString("Name");
            info.Amount = reader.GetDecimal("Amount");
            info.Remark = reader.GetString("Remark");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(StaffBonusInfo obj)
        {
            StaffBonusInfo info = obj as StaffBonusInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("StaffId", info.StaffId);
            hash.Add("Name", info.Name);
            hash.Add("Amount", info.Amount);
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
            dict.Add("StaffId", "");
            dict.Add("Name", "");
            dict.Add("Amount", "");
            dict.Add("Remark", "");
            #endregion

            return dict;
        }

    }
}
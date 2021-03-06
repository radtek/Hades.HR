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
    /// BonusItem
    /// </summary>
	public class BonusItem : BaseDALSQL<BonusItemInfo>, IBonusItem
    {
        #region 对象实例及构造函数

        public static BonusItem Instance
        {
            get
            {
                return new BonusItem();
            }
        }
        public BonusItem() : base("HR_BonusItem", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override BonusItemInfo DataReaderToEntity(IDataReader dataReader)
        {
            BonusItemInfo info = new BonusItemInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.Name = reader.GetString("Name");
            info.Code = reader.GetString("Code");
            info.CalcType = reader.GetInt32("CalcType");
            info.Cardinal = reader.GetDecimal("Cardinal");
            info.Coefficient = reader.GetDecimal("Coefficient");
            info.Limit = reader.GetDecimal("Limit");
            info.Remark = reader.GetString("Remark");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(BonusItemInfo obj)
        {
            BonusItemInfo info = obj as BonusItemInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("Name", info.Name);
            hash.Add("Code", info.Code);
            hash.Add("CalcType", info.CalcType);
            hash.Add("Cardinal", info.Cardinal);
            hash.Add("Coefficient", info.Coefficient);
            hash.Add("Limit", info.Limit);
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
            dict.Add("Name", "奖金名称");
            dict.Add("Code", "奖金代码");
            dict.Add("CalcType", "计算方式");
            dict.Add("Cardinal", "基数");
            dict.Add("Coefficient", "系数");
            dict.Add("Limit", "上限");
            dict.Add("Remark", "备注");
            #endregion

            return dict;
        }
    }
}
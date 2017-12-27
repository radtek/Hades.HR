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
    /// ReplaceMachineCategory
    /// </summary>
	public class ReplaceMachineCategory : BaseDALSQL<ReplaceMachineCategoryInfo>, IReplaceMachineCategory
    {
        #region 对象实例及构造函数

        public static ReplaceMachineCategory Instance
        {
            get
            {
                return new ReplaceMachineCategory();
            }
        }
        public ReplaceMachineCategory() : base("WP_ReplaceMachineCategory", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override ReplaceMachineCategoryInfo DataReaderToEntity(IDataReader dataReader)
        {
            ReplaceMachineCategoryInfo info = new ReplaceMachineCategoryInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.MasterCategoryId = reader.GetString("MasterCategoryId");
            info.MasterCategoryName = reader.GetString("MasterCategoryName");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(ReplaceMachineCategoryInfo obj)
        {
            ReplaceMachineCategoryInfo info = obj as ReplaceMachineCategoryInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("MasterCategoryId", info.MasterCategoryId);
            hash.Add("MasterCategoryName", info.MasterCategoryName);

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
            dict.Add("ID", "");
            dict.Add("MasterCategoryId", "");
            dict.Add("MasterCategoryName", "");
            #endregion

            return dict;
        }
    }
}
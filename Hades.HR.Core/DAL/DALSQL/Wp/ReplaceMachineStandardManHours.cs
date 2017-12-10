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
    /// ReplaceMachineStandardManHours
    /// </summary>
	public class ReplaceMachineStandardManHours : BaseDALSQL<ReplaceMachineStandardManHoursInfo>, IReplaceMachineStandardManHours
	{
		#region 对象实例及构造函数

		public static ReplaceMachineStandardManHours Instance
		{
			get
			{
				return new ReplaceMachineStandardManHours();
			}
		}
		public ReplaceMachineStandardManHours() : base("WP_ReplaceMachineStandardManHours","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override ReplaceMachineStandardManHoursInfo DataReaderToEntity(IDataReader dataReader)
		{
			ReplaceMachineStandardManHoursInfo info = new ReplaceMachineStandardManHoursInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.MasterCateogoryId = reader.GetString("MasterCateogoryId");
			info.ItemId = reader.GetString("ItemId");
			info.ItemName = reader.GetString("ItemName");
			info.StandardManHours = reader.GetInt32("StandardManHours");
			info.Remark = reader.GetString("Remark");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(ReplaceMachineStandardManHoursInfo obj)
		{
		    ReplaceMachineStandardManHoursInfo info = obj as ReplaceMachineStandardManHoursInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("MasterCateogoryId", info.MasterCateogoryId);
 			hash.Add("ItemId", info.ItemId);
 			hash.Add("ItemName", info.ItemName);
 			hash.Add("StandardManHours", info.StandardManHours);
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
            dict.Add("ID", "");
             dict.Add("MasterCateogoryId", "");
             dict.Add("ItemId", "");
             dict.Add("ItemName", "");
             dict.Add("StandardManHours", "");
             dict.Add("Remark", "");
             #endregion

            return dict;
        }

    }
}
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
    /// ReplaceMachineManHours
    /// </summary>
	public class ReplaceMachineManHours : BaseDALSQL<ReplaceMachineManHoursInfo>, IReplaceMachineManHours
	{
		#region 对象实例及构造函数

		public static ReplaceMachineManHours Instance
		{
			get
			{
				return new ReplaceMachineManHours();
			}
		}
		public ReplaceMachineManHours() : base("WP_ReplaceMachineManHours","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override ReplaceMachineManHoursInfo DataReaderToEntity(IDataReader dataReader)
		{
			ReplaceMachineManHoursInfo info = new ReplaceMachineManHoursInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.WorkteamId = reader.GetString("WorkteamId");
			info.ItemId = reader.GetString("ItemId");
			info.WorkingDate = reader.GetDateTime("WorkingDate");
			info.Amount = reader.GetInt32("Amount");
			info.CreatorId = reader.GetString("CreatorId");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Remark = reader.GetString("Remark");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(ReplaceMachineManHoursInfo obj)
		{
		    ReplaceMachineManHoursInfo info = obj as ReplaceMachineManHoursInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("WorkteamId", info.WorkteamId);
 			hash.Add("ItemId", info.ItemId);
 			hash.Add("WorkingDate", info.WorkingDate);
 			hash.Add("Amount", info.Amount);
 			hash.Add("CreatorId", info.CreatorId);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
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
             dict.Add("WorkteamId", "");
             dict.Add("ItemId", "");
             dict.Add("WorkingDate", "");
             dict.Add("Amount", "");
             dict.Add("CreatorId", "");
             dict.Add("Creator", "");
             dict.Add("CreateTime", "");
             dict.Add("Remark", "");
             #endregion

            return dict;
        }

    }
}
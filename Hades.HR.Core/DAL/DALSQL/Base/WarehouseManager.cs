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
    /// WarehouseManager
    /// </summary>
	public class WarehouseManager : BaseDALSQL<WarehouseManagerInfo>, IWarehouseManager
	{
		#region 对象实例及构造函数

		public static WarehouseManager Instance
		{
			get
			{
				return new WarehouseManager();
			}
		}
		public WarehouseManager() : base("HR_WarehouseManager","Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override WarehouseManagerInfo DataReaderToEntity(IDataReader dataReader)
		{
			WarehouseManagerInfo info = new WarehouseManagerInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Id = reader.GetString("Id");
			info.WarehouseId = reader.GetString("WarehouseId");
			info.ManagerId = reader.GetString("ManagerId");
			info.Remark = reader.GetString("Remark");
			info.Deleted = reader.GetInt32("Deleted");
			info.Enabled = reader.GetInt32("Enabled");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(WarehouseManagerInfo obj)
		{
		    WarehouseManagerInfo info = obj as WarehouseManagerInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("Id", info.Id);
 			hash.Add("WarehouseId", info.WarehouseId);
 			hash.Add("ManagerId", info.ManagerId);
 			hash.Add("Remark", info.Remark);
 			hash.Add("Deleted", info.Deleted);
 			hash.Add("Enabled", info.Enabled);
 				
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
             dict.Add("WarehouseId", "");
             dict.Add("ManagerId", "");
             dict.Add("Remark", "");
             dict.Add("Deleted", "");
             dict.Add("Enabled", "");
             #endregion

            return dict;
        }

    }
}
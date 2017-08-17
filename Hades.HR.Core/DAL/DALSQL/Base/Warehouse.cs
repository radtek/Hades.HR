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
    /// Warehouse
    /// </summary>
	public class Warehouse : BaseDALSQL<WarehouseInfo>, IWarehouse
	{
		#region 对象实例及构造函数

		public static Warehouse Instance
		{
			get
			{
				return new Warehouse();
			}
		}
		public Warehouse() : base("HR_Warehouse","Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override WarehouseInfo DataReaderToEntity(IDataReader dataReader)
		{
			WarehouseInfo info = new WarehouseInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Id = reader.GetString("Id");
			info.CompanyId = reader.GetString("CompanyId");
			info.Number = reader.GetString("Number");
			info.Name = reader.GetString("Name");
			info.SortCode = reader.GetString("SortCode");
			info.Address = reader.GetString("Address");
			info.InnerPhone = reader.GetString("InnerPhone");
			info.OuterPhone = reader.GetString("OuterPhone");
			info.Remark = reader.GetString("Remark");
			info.Editor = reader.GetString("Editor");
			info.EditorId = reader.GetString("EditorId");
			info.EditTime = reader.GetDateTime("EditTime");
			info.Deleted = reader.GetInt32("Deleted");
			info.Enabled = reader.GetInt32("Enabled");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(WarehouseInfo obj)
		{
		    WarehouseInfo info = obj as WarehouseInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("Id", info.Id);
 			hash.Add("CompanyId", info.CompanyId);
 			hash.Add("Number", info.Number);
 			hash.Add("Name", info.Name);
 			hash.Add("SortCode", info.SortCode);
 			hash.Add("Address", info.Address);
 			hash.Add("InnerPhone", info.InnerPhone);
 			hash.Add("OuterPhone", info.OuterPhone);
 			hash.Add("Remark", info.Remark);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditorId", info.EditorId);
 			hash.Add("EditTime", info.EditTime);
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
             dict.Add("CompanyId", "");
             dict.Add("Number", "");
             dict.Add("Name", "");
             dict.Add("SortCode", "");
             dict.Add("Address", "");
             dict.Add("InnerPhone", "");
             dict.Add("OuterPhone", "");
             dict.Add("Remark", "");
             dict.Add("Editor", "");
             dict.Add("EditorId", "");
             dict.Add("EditTime", "");
             dict.Add("Deleted", "");
             dict.Add("Enabled", "");
             #endregion

            return dict;
        }

    }
}
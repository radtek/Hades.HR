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
    /// LaborAttendance
    /// </summary>
	public class LaborAttendance : BaseDALSQL<LaborAttendanceInfo>, ILaborAttendance
	{
		#region 对象实例及构造函数

		public static LaborAttendance Instance
		{
			get
			{
				return new LaborAttendance();
			}
		}
		public LaborAttendance() : base("HR_LaborAttendance","Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override LaborAttendanceInfo DataReaderToEntity(IDataReader dataReader)
		{
			LaborAttendanceInfo info = new LaborAttendanceInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Id = reader.GetString("Id");
			info.Year = reader.GetInt32("Year");
			info.Month = reader.GetInt32("Month");
			info.Days = reader.GetInt32("Days");
			info.Remark = reader.GetString("Remark");
			info.Editor = reader.GetString("Editor");
			info.EditorId = reader.GetString("EditorId");
			info.EditorTime = reader.GetDateTime("EditorTime");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(LaborAttendanceInfo obj)
		{
		    LaborAttendanceInfo info = obj as LaborAttendanceInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("Id", info.Id);
 			hash.Add("Year", info.Year);
 			hash.Add("Month", info.Month);
 			hash.Add("Days", info.Days);
 			hash.Add("Remark", info.Remark);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditorId", info.EditorId);
 			hash.Add("EditorTime", info.EditorTime);
 				
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
             dict.Add("Year", "");
             dict.Add("Month", "");
             dict.Add("Days", "");
             dict.Add("Remark", "");
             dict.Add("Editor", "");
             dict.Add("EditorId", "");
             dict.Add("EditorTime", "");
             #endregion

            return dict;
        }

    }
}
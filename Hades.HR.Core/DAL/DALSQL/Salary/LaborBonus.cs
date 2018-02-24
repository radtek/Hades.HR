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
    /// LaborBonus
    /// </summary>
	public class LaborBonus : BaseDALSQL<LaborBonusInfo>, ILaborBonus
	{
		#region 对象实例及构造函数

		public static LaborBonus Instance
		{
			get
			{
				return new LaborBonus();
			}
		}
		public LaborBonus() : base("HR_LaborBonus","Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override LaborBonusInfo DataReaderToEntity(IDataReader dataReader)
		{
			LaborBonusInfo info = new LaborBonusInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Id = reader.GetString("Id");
			info.Year = reader.GetInt32("Year");
			info.Month = reader.GetInt32("Month");
			info.StaffId = reader.GetString("StaffId");
			info.WorkTeamId = reader.GetString("WorkTeamId");
			info.FinanceDepartmentId = reader.GetString("FinanceDepartmentId");
			info.BonusCode = reader.GetString("BonusCode");
			info.Amount = reader.GetDecimal("Amount");
			info.TotalBonus = reader.GetDecimal("TotalBonus");
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
        protected override Hashtable GetHashByEntity(LaborBonusInfo obj)
		{
		    LaborBonusInfo info = obj as LaborBonusInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("Id", info.Id);
 			hash.Add("Year", info.Year);
 			hash.Add("Month", info.Month);
 			hash.Add("StaffId", info.StaffId);
 			hash.Add("WorkTeamId", info.WorkTeamId);
 			hash.Add("FinanceDepartmentId", info.FinanceDepartmentId);
 			hash.Add("BonusCode", info.BonusCode);
 			hash.Add("Amount", info.Amount);
 			hash.Add("TotalBonus", info.TotalBonus);
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
             dict.Add("Year", "");
             dict.Add("Month", "");
             dict.Add("StaffId", "");
             dict.Add("WorkTeamId", "");
             dict.Add("FinanceDepartmentId", "");
             dict.Add("BonusCode", "");
             dict.Add("Amount", "");
             dict.Add("TotalBonus", "");
             dict.Add("Remark", "");
             dict.Add("Editor", "");
             dict.Add("EditorId", "");
             dict.Add("EditTime", "");
             #endregion

            return dict;
        }

    }
}
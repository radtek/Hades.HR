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
    /// HR_StaffSalaryView
    /// </summary>
	public class StaffSalaryView : BaseDALSQL<StaffSalaryViewInfo>, IStaffSalaryView
	{
		#region 对象实例及构造函数

		public static StaffSalaryView Instance
		{
			get
			{
				return new StaffSalaryView();
			}
		}
		public StaffSalaryView() : base("HR_StaffSalaryView","Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override StaffSalaryViewInfo DataReaderToEntity(IDataReader dataReader)
		{
			StaffSalaryViewInfo info = new StaffSalaryViewInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Id = reader.GetString("Id");
			info.Number = reader.GetString("Number");
			info.Name = reader.GetString("Name");
			info.FinanceDepartment = reader.GetString("FinanceDepartment");
			info.CardNumber = reader.GetString("CardNumber");
			info.BaseSalary = reader.GetDecimal("BaseSalary");
			info.BaseBonus = reader.GetDecimal("BaseBonus");
			info.DepartmentBonus = reader.GetDecimal("DepartmentBonus");
			info.Insurance = reader.GetDecimal("Insurance");
			info.Remark = reader.GetString("Remark");
			info.ReserveFund = reader.GetDecimal("ReserveFund");
			info.Creator = reader.GetString("Creator");
			info.CreatorId = reader.GetString("CreatorId");
			info.CreateTime = reader.GetDateTime("CreateTime");
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
        protected override Hashtable GetHashByEntity(StaffSalaryViewInfo obj)
		{
		    StaffSalaryViewInfo info = obj as StaffSalaryViewInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("Id", info.Id);
 			hash.Add("Number", info.Number);
 			hash.Add("Name", info.Name);
 			hash.Add("FinanceDepartment", info.FinanceDepartment);
 			hash.Add("CardNumber", info.CardNumber);
 			hash.Add("BaseSalary", info.BaseSalary);
 			hash.Add("BaseBonus", info.BaseBonus);
 			hash.Add("DepartmentBonus", info.DepartmentBonus);
 			hash.Add("Insurance", info.Insurance);
 			hash.Add("Remark", info.Remark);
 			hash.Add("ReserveFund", info.ReserveFund);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreatorId", info.CreatorId);
 			hash.Add("CreateTime", info.CreateTime);
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
             dict.Add("Number", "");
             dict.Add("Name", "");
             dict.Add("FinanceDepartment", "");
             dict.Add("CardNumber", "");
             dict.Add("BaseSalary", "");
             dict.Add("BaseBonus", "");
             dict.Add("DepartmentBonus", "");
             dict.Add("Insurance", "");
             dict.Add("Remark", "");
             dict.Add("ReserveFund", "");
             dict.Add("Creator", "");
             dict.Add("CreatorId", "");
             dict.Add("CreateTime", "");
             dict.Add("Editor", "");
             dict.Add("EditorId", "");
             dict.Add("EditTime", "");
             #endregion

            return dict;
        }

    }
}
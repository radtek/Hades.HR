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
    /// WorkTeamDailyWorkload
    /// </summary>
	public class WorkTeamDailyWorkload : BaseDALSQL<WorkTeamDailyWorkloadInfo>, IWorkTeamDailyWorkload
	{
		#region 对象实例及构造函数

		public static WorkTeamDailyWorkload Instance
		{
			get
			{
				return new WorkTeamDailyWorkload();
			}
		}
		public WorkTeamDailyWorkload() : base("HR_WorkTeamDailyWorkload","Id")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override WorkTeamDailyWorkloadInfo DataReaderToEntity(IDataReader dataReader)
		{
			WorkTeamDailyWorkloadInfo info = new WorkTeamDailyWorkloadInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Id = reader.GetString("Id");
			info.WorkTeamId = reader.GetString("WorkTeamId");
			info.AttendanceDate = reader.GetDateTime("AttendanceDate");
			info.ProductionHours = reader.GetDecimal("ProductionHours");
			info.ChangeHours = reader.GetDecimal("ChangeHours");
			info.RepairHours = reader.GetDecimal("RepairHours");
			info.ElectricHours = reader.GetDecimal("ElectricHours");
			info.PersonCount = reader.GetInt32("PersonCount");
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
        protected override Hashtable GetHashByEntity(WorkTeamDailyWorkloadInfo obj)
		{
		    WorkTeamDailyWorkloadInfo info = obj as WorkTeamDailyWorkloadInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("Id", info.Id);
 			hash.Add("WorkTeamId", info.WorkTeamId);
 			hash.Add("AttendanceDate", info.AttendanceDate);
 			hash.Add("ProductionHours", info.ProductionHours);
 			hash.Add("ChangeHours", info.ChangeHours);
 			hash.Add("RepairHours", info.RepairHours);
 			hash.Add("ElectricHours", info.ElectricHours);
 			hash.Add("PersonCount", info.PersonCount);
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
             dict.Add("WorkTeamId", "");
             dict.Add("AttendanceDate", "");
             dict.Add("ProductionHours", "");
             dict.Add("ChangeHours", "");
             dict.Add("RepairHours", "");
             dict.Add("ElectricHours", "");
             dict.Add("PersonCount", "");
             dict.Add("Remark", "");
             dict.Add("Editor", "");
             dict.Add("EditorId", "");
             dict.Add("EditTime", "");
             #endregion

            return dict;
        }

    }
}
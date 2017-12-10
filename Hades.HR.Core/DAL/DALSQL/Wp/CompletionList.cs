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
    /// CompletionList
    /// </summary>
	public class CompletionList : BaseDALSQL<CompletionListInfo>, ICompletionList
	{
		#region 对象实例及构造函数

		public static CompletionList Instance
		{
			get
			{
				return new CompletionList();
			}
		}
		public CompletionList() : base("WP_CompletionList","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override CompletionListInfo DataReaderToEntity(IDataReader dataReader)
		{
			CompletionListInfo info = new CompletionListInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.CompletionListID = reader.GetString("CompletionListID");
			info.DispatchListNumber = reader.GetString("DispatchListNumber");
			info.PPrSetId = reader.GetString("PPrSetId");
			info.WorkteamId = reader.GetString("WorkteamId");
			info.WorkteamName = reader.GetString("WorkteamName");
			info.StartTime = reader.GetDateTime("StartTime");
			info.EndTime = reader.GetDateTime("EndTime");
			info.Status = reader.GetString("Status");
			info.AcceptanceAmount = reader.GetInt32("AcceptanceAmount");
			info.UnqualifiedAmount = reader.GetInt32("UnqualifiedAmount");
			info.DiscardAmount = reader.GetInt32("DiscardAmount");
			info.NextProcess = reader.GetString("NextProcess");
			info.NextWorkteamId = reader.GetString("NextWorkteamId");
			info.Receiver = reader.GetString("Receiver");
			info.ReceiveAmount = reader.GetInt32("ReceiveAmount");
			info.ReturnAmount = reader.GetInt32("ReturnAmount");
			info.Drawer = reader.GetString("Drawer");
			info.BillingDate = reader.GetDateTime("BillingDate");
			info.Auditor = reader.GetString("Auditor");
			info.AuditTime = reader.GetDateTime("AuditTime");
			info.Remark = reader.GetString("Remark");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(CompletionListInfo obj)
		{
		    CompletionListInfo info = obj as CompletionListInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("CompletionListID", info.CompletionListID);
 			hash.Add("DispatchListNumber", info.DispatchListNumber);
 			hash.Add("PPrSetId", info.PPrSetId);
 			hash.Add("WorkteamId", info.WorkteamId);
 			hash.Add("WorkteamName", info.WorkteamName);
 			hash.Add("StartTime", info.StartTime);
 			hash.Add("EndTime", info.EndTime);
 			hash.Add("Status", info.Status);
 			hash.Add("AcceptanceAmount", info.AcceptanceAmount);
 			hash.Add("UnqualifiedAmount", info.UnqualifiedAmount);
 			hash.Add("DiscardAmount", info.DiscardAmount);
 			hash.Add("NextProcess", info.NextProcess);
 			hash.Add("NextWorkteamId", info.NextWorkteamId);
 			hash.Add("Receiver", info.Receiver);
 			hash.Add("ReceiveAmount", info.ReceiveAmount);
 			hash.Add("ReturnAmount", info.ReturnAmount);
 			hash.Add("Drawer", info.Drawer);
 			hash.Add("BillingDate", info.BillingDate);
 			hash.Add("Auditor", info.Auditor);
 			hash.Add("AuditTime", info.AuditTime);
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
             dict.Add("CompletionListID", "");
             dict.Add("DispatchListNumber", "");
             dict.Add("PPrSetId", "");
             dict.Add("WorkteamId", "");
             dict.Add("WorkteamName", "");
             dict.Add("StartTime", "");
             dict.Add("EndTime", "");
             dict.Add("Status", "");
             dict.Add("AcceptanceAmount", "");
             dict.Add("UnqualifiedAmount", "");
             dict.Add("DiscardAmount", "");
             dict.Add("NextProcess", "");
             dict.Add("NextWorkteamId", "");
             dict.Add("Receiver", "");
             dict.Add("ReceiveAmount", "");
             dict.Add("ReturnAmount", "");
             dict.Add("Drawer", "");
             dict.Add("BillingDate", "");
             dict.Add("Auditor", "");
             dict.Add("AuditTime", "");
             dict.Add("Remark", "");
             #endregion

            return dict;
        }

    }
}
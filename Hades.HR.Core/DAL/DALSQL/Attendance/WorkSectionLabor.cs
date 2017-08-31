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
    /// WorkSectionLabor
    /// </summary>
	public class WorkSectionLabor : BaseDALSQL<WorkSectionLaborInfo>, IWorkSectionLabor
    {
        #region 对象实例及构造函数

        public static WorkSectionLabor Instance
        {
            get
            {
                return new WorkSectionLabor();
            }
        }
        public WorkSectionLabor() : base("HR_WorkSectionLabor", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override WorkSectionLaborInfo DataReaderToEntity(IDataReader dataReader)
        {
            WorkSectionLaborInfo info = new WorkSectionLaborInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.Year = reader.GetInt32("Year");
            info.Month = reader.GetInt32("Month");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.WorkSectionId = reader.GetString("WorkSectionId");
            info.StaffId = reader.GetString("StaffId");
            info.StaffLevel = reader.GetString("StaffLevel");
            info.InPosition = reader.GetInt32("InPosition");
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
        protected override Hashtable GetHashByEntity(WorkSectionLaborInfo obj)
        {
            WorkSectionLaborInfo info = obj as WorkSectionLaborInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("Year", info.Year);
            hash.Add("Month", info.Month);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("WorkSectionId", info.WorkSectionId);
            hash.Add("StaffId", info.StaffId);
            hash.Add("StaffLevel", info.StaffLevel);
            hash.Add("InPosition", info.InPosition);
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
            dict.Add("Year", "年度");
            dict.Add("Month", "月份");
            dict.Add("WorkTeamId", "所属班组");
            dict.Add("WorkSectionId", "所属工段");
            dict.Add("StaffId", "职员");
            dict.Add("StaffLevel", "职员等级");
            dict.Add("InPosition", "是否在岗");
            dict.Add("Remark", "备注");
            dict.Add("Editor", "");
            dict.Add("EditorId", "");
            dict.Add("EditTime", "");
            #endregion

            return dict;
        }
    }
}
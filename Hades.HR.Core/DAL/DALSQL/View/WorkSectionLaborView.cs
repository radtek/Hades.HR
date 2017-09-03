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
    /// HR_WorkSectionLaborView
    /// </summary>
	public class WorkSectionLaborView : BaseDALSQL<WorkSectionLaborViewInfo>, IWorkSectionLaborView
    {
        #region 对象实例及构造函数

        public static WorkSectionLaborView Instance
        {
            get
            {
                return new WorkSectionLaborView();
            }
        }
        public WorkSectionLaborView() : base("HR_WorkSectionLaborView", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override WorkSectionLaborViewInfo DataReaderToEntity(IDataReader dataReader)
        {
            WorkSectionLaborViewInfo info = new WorkSectionLaborViewInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Number = reader.GetString("Number");
            info.Name = reader.GetString("Name");
            info.WorkTeamName = reader.GetString("WorkTeamName");
            info.WorkSectionName = reader.GetString("WorkSectionName");
            info.StaffLevelName = reader.GetString("StaffLevelName");
            info.Id = reader.GetString("Id");
            info.Year = reader.GetInt32("Year");
            info.Month = reader.GetInt32("Month");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.WorkSectionId = reader.GetString("WorkSectionId");
            info.StaffId = reader.GetString("StaffId");
            info.StaffLevelId = reader.GetString("StaffLevelId");
            info.InPosition = reader.GetInt32("InPosition");
            info.Remark = reader.GetString("Remark");
            info.SortCode = reader.GetString("SortCode");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(WorkSectionLaborViewInfo obj)
        {
            WorkSectionLaborViewInfo info = obj as WorkSectionLaborViewInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Number", info.Number);
            hash.Add("Name", info.Name);
            hash.Add("WorkTeamName", info.WorkTeamName);
            hash.Add("WorkSectionName", info.WorkSectionName);
            hash.Add("StaffLevelName", info.StaffLevelName);
            hash.Add("Id", info.Id);
            hash.Add("Year", info.Year);
            hash.Add("Month", info.Month);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("WorkSectionId", info.WorkSectionId);
            hash.Add("StaffId", info.StaffId);
            hash.Add("StaffLevelId", info.StaffLevelId);
            hash.Add("InPosition", info.InPosition);
            hash.Add("Remark", info.Remark);
            hash.Add("SortCode", info.SortCode);

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
            dict.Add("Number", "职员工号");
            dict.Add("Name", "职员姓名");
            dict.Add("WorkTeamName", "班组名称");
            dict.Add("WorkSectionName", "工段名称");
            dict.Add("StaffLevelName", "职员等级");
            dict.Add("Id", "");
            dict.Add("Year", "年度");
            dict.Add("Month", "月份");
            dict.Add("WorkTeamId", "");
            dict.Add("WorkSectionId", "");
            dict.Add("StaffId", "");
            dict.Add("StaffLevelId", "");
            dict.Add("InPosition", "是否在岗");
            dict.Add("Remark", "备注");
            dict.Add("SortCode", "排序码");
            #endregion

            return dict;
        }
    }
}
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
    /// WorkTeam
    /// </summary>
	public class WorkTeam : BaseDALSQL<WorkTeamInfo>, IWorkTeam
    {
        #region 对象实例及构造函数

        public static WorkTeam Instance
        {
            get
            {
                return new WorkTeam();
            }
        }
        public WorkTeam() : base("HR_WorkTeam", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override WorkTeamInfo DataReaderToEntity(IDataReader dataReader)
        {
            WorkTeamInfo info = new WorkTeamInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.Name = reader.GetString("Name");
            info.Number = reader.GetString("Number");
            info.CompanyId = reader.GetString("CompanyId");
            info.ProductionLineId = reader.GetString("ProductionLineId");
            info.SortCode = reader.GetString("SortCode");
            info.Remark = reader.GetString("Remark");
            info.Creator = reader.GetString("Creator");
            info.CreatorId = reader.GetString("CreatorId");
            info.CreateTime = reader.GetDateTime("CreateTime");
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
        protected override Hashtable GetHashByEntity(WorkTeamInfo obj)
        {
            WorkTeamInfo info = obj as WorkTeamInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("Name", info.Name);
            hash.Add("Number", info.Number);
            hash.Add("CompanyId", info.CompanyId);
            hash.Add("ProductionLineId", info.ProductionLineId);
            hash.Add("SortCode", info.SortCode);
            hash.Add("Remark", info.Remark);
            hash.Add("Creator", info.Creator);
            hash.Add("CreatorId", info.CreatorId);
            hash.Add("CreateTime", info.CreateTime);
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
            dict.Add("Name", "班组名称");
            dict.Add("Number", "班组编号");
            dict.Add("CompanyId", "所属公司");
            dict.Add("ProductionLineId", "所属产线");
            dict.Add("SortCode", "排序码");
            dict.Add("Remark", "备注");
            dict.Add("Creator", "");
            dict.Add("CreatorId", "");
            dict.Add("CreateTime", "");
            dict.Add("Editor", "");
            dict.Add("EditorId", "");
            dict.Add("EditTime", "");
            dict.Add("Deleted", "删除状态");
            dict.Add("Enabled", "启用状态");
            #endregion

            return dict;
        }
    }
}
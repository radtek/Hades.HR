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
    /// Department
    /// </summary>
	public class Department : BaseDALSQL<DepartmentInfo>, IDepartment
    {
        #region 对象实例及构造函数

        public static Department Instance
        {
            get
            {
                return new Department();
            }
        }
        public Department() : base("HR_Department", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override DepartmentInfo DataReaderToEntity(IDataReader dataReader)
        {
            DepartmentInfo info = new DepartmentInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.PID = reader.GetString("PID");
            info.Number = reader.GetString("Number");
            info.Name = reader.GetString("Name");
            info.SortCode = reader.GetString("SortCode");
            info.Type = reader.GetInt32("Type");
            info.Address = reader.GetString("Address");
            info.InnerPhone = reader.GetString("InnerPhone");
            info.OuterPhone = reader.GetString("OuterPhone");
            info.Fax = reader.GetString("Fax");
            info.Principal = reader.GetString("Principal");
            info.Remark = reader.GetString("Remark");
            info.FoundDate = reader.GetDateTime("FoundDate");
            info.CloseDate = reader.GetDateTime("CloseDate");
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
        protected override Hashtable GetHashByEntity(DepartmentInfo obj)
        {
            DepartmentInfo info = obj as DepartmentInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("PID", info.PID);
            hash.Add("Number", info.Number);
            hash.Add("Name", info.Name);
            hash.Add("SortCode", info.SortCode);
            hash.Add("Type", info.Type);
            hash.Add("Address", info.Address);
            hash.Add("InnerPhone", info.InnerPhone);
            hash.Add("OuterPhone", info.OuterPhone);
            hash.Add("Fax", info.Fax);
            hash.Add("Principal", info.Principal);
            hash.Add("Remark", info.Remark);
            hash.Add("FoundDate", info.FoundDate);
            hash.Add("CloseDate", info.CloseDate);
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
            dict.Add("PID", "");
            dict.Add("Number", "编码");
            dict.Add("Name", "名称");
            dict.Add("SortCode", "排序码");
            dict.Add("Type", "类型");
            dict.Add("Address", "地址");
            dict.Add("InnerPhone", "内线电话");
            dict.Add("OuterPhone", "外线电话");
            dict.Add("Fax", "传真");
            dict.Add("Principal", "负责人");
            dict.Add("Remark", "备注");
            dict.Add("FoundDate", "");
            dict.Add("CloseDate", "");
            dict.Add("Creator", "");
            dict.Add("CreatorId", "");
            dict.Add("CreateTime", "");
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
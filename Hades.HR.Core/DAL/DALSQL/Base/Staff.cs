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
    /// Staff
    /// </summary>
	public class Staff : BaseDALSQL<StaffInfo>, IStaff
    {
        #region 对象实例及构造函数

        public static Staff Instance
        {
            get
            {
                return new Staff();
            }
        }
        public Staff() : base("HR_Staff", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override StaffInfo DataReaderToEntity(IDataReader dataReader)
        {
            StaffInfo info = new StaffInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.Number = reader.GetString("Number");
            info.Name = reader.GetString("Name");
            info.Gender = reader.GetString("Gender");
            info.Birthday = reader.GetDateTime("Birthday");
            info.NativePlace = reader.GetString("NativePlace");
            info.Nationality = reader.GetString("Nationality");
            info.IdentityCard = reader.GetString("IdentityCard");
            info.Phone = reader.GetString("Phone");
            info.OfficePhone = reader.GetString("OfficePhone");
            info.Email = reader.GetString("Email");
            info.QQ = reader.GetString("QQ");
            info.HomeAddress = reader.GetString("HomeAddress");
            info.Political = reader.GetString("Political");
            info.PartyDate = reader.GetDateTime("PartyDate");
            info.Education = reader.GetString("Education");
            info.Degree = reader.GetString("Degree");
            info.WorkingDate = reader.GetDateTime("WorkingDate");
            info.Marriage = reader.GetString("Marriage");
            info.ChildStatus = reader.GetString("ChildStatus");
            info.Titles = reader.GetString("Titles");
            info.Duty = reader.GetString("Duty");
            info.JobType = reader.GetString("JobType");
            info.Introduce = reader.GetString("Introduce");
            info.Remark = reader.GetString("Remark");
            //info.Protraint = reader.GetBytes("Protraint");
            info.AttachId = reader.GetString("AttachId");
            info.JobStatus = reader.GetInt32("JobStatus");
            info.StaffType = reader.GetInt32("StaffType");
            info.CompanyId = reader.GetString("CompanyId");
            info.DepartmentId = reader.GetString("DepartmentId");
            info.PositionId = reader.GetString("PositionId");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.JobStatus = reader.GetInt32("JobStatus");
            info.OnJobTime = reader.GetDateTime("OnJobTime");
            info.OffJobTime = reader.GetDateTime("OffJobTime");
            info.IsSystem = reader.GetBoolean("IsSystem");
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
        protected override Hashtable GetHashByEntity(StaffInfo obj)
        {
            StaffInfo info = obj as StaffInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("Number", info.Number);
            hash.Add("Name", info.Name);
            hash.Add("Gender", info.Gender);
            hash.Add("Birthday", info.Birthday);
            hash.Add("NativePlace", info.NativePlace);
            hash.Add("Nationality", info.Nationality);
            hash.Add("IdentityCard", info.IdentityCard);
            hash.Add("Phone", info.Phone);
            hash.Add("OfficePhone", info.OfficePhone);
            hash.Add("Email", info.Email);
            hash.Add("QQ", info.QQ);
            hash.Add("HomeAddress", info.HomeAddress);
            hash.Add("Political", info.Political);
            hash.Add("PartyDate", info.PartyDate);
            hash.Add("Education", info.Education);
            hash.Add("Degree", info.Degree);
            hash.Add("WorkingDate", info.WorkingDate);
            hash.Add("Marriage", info.Marriage);
            hash.Add("ChildStatus", info.ChildStatus);
            hash.Add("Titles", info.Titles);
            hash.Add("Duty", info.Duty);
            hash.Add("JobType", info.JobType);
            hash.Add("Introduce", info.Introduce);
            hash.Add("Remark", info.Remark);
            //hash.Add("Protraint", info.Protraint);
            hash.Add("AttachId", info.AttachId);
            hash.Add("StaffType", info.StaffType);
            hash.Add("CompanyId", info.CompanyId);
            hash.Add("DepartmentId", info.DepartmentId);
            hash.Add("PositionId", info.PositionId);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("JobStatus", info.JobStatus);
            hash.Add("OnJobTime", info.OnJobTime);
            hash.Add("OffJobTime", info.OffJobTime);
            hash.Add("IsSystem", info.IsSystem);
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
            dict.Add("Id", "");
            dict.Add("Number", "工号");
            dict.Add("Name", "姓名");
            dict.Add("Gender", "性别");
            dict.Add("Birthday", "出生日期");
            dict.Add("NativePlace", "籍贯");
            dict.Add("Nationality", "民族");
            dict.Add("IdentityCard", "身份证号");
            dict.Add("Phone", "手机");
            dict.Add("OfficePhone", "办公电话");
            dict.Add("Email", "Email");
            dict.Add("QQ", "QQ");
            dict.Add("HomeAddress", "家庭地址");
            dict.Add("Political", "政治面貌");
            dict.Add("PartyDate", "入党时间");
            dict.Add("Education", "学历");
            dict.Add("Degree", "学位");
            dict.Add("WorkingDate", "参加工作时间");
            dict.Add("Marriage", "婚姻状况");
            dict.Add("ChildStatus", "是否独生子女");
            dict.Add("Titles", "职称");
            dict.Add("Duty", "职务");
            dict.Add("JobType", "工种");
            dict.Add("Introduce", "个人介绍");
            dict.Add("Remark", "备注");
            dict.Add("Protraint", "");
            dict.Add("AttachId", "");
            dict.Add("StaffType", "职员类型");
            dict.Add("CompanyId", "所属公司");
            dict.Add("DepartmentId", "工作部门");
            dict.Add("PositionId", "工作岗位");
            dict.Add("WorkTeamId", "所属班组");
            dict.Add("JobStatus", "在职状态");
            dict.Add("OnJobTime", "入职时间");
            dict.Add("OffJobTime", "离职时间");
            dict.Add("IsSystem", "是否系统");
            dict.Add("Creator", "");
            dict.Add("CreatorId", "");
            dict.Add("CreateTime", "");
            dict.Add("Editor", "");
            dict.Add("EditorId", "");
            dict.Add("EditTime", "");
            dict.Add("Deleted", "");
            dict.Add("Enabled", "启用状态");
            #endregion

            return dict;
        }
    }
}
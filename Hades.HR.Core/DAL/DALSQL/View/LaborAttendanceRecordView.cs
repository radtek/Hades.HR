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
    /// HR_LaborAttendanceRecordView
    /// </summary>
	public class LaborAttendanceRecordView : BaseDALSQL<LaborAttendanceRecordViewInfo>, ILaborAttendanceRecordView
    {
        #region 对象实例及构造函数

        public static LaborAttendanceRecordView Instance
        {
            get
            {
                return new LaborAttendanceRecordView();
            }
        }
        public LaborAttendanceRecordView() : base("HR_LaborAttendanceRecordView", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override LaborAttendanceRecordViewInfo DataReaderToEntity(IDataReader dataReader)
        {
            LaborAttendanceRecordViewInfo info = new LaborAttendanceRecordViewInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.StaffId = reader.GetString("StaffId");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.WorkSectionId = reader.GetString("WorkSectionId");
            info.AttendanceDate = reader.GetDateTime("AttendanceDate");
            info.StandardWorkload = reader.GetDecimal("StandardWorkload");
            info.Workload = reader.GetDecimal("Workload");
            info.AbsentType = reader.GetInt32("AbsentType");
            info.IsWeekend = reader.GetBoolean("IsWeekend");
            info.IsHoliday = reader.GetBoolean("IsHoliday");
            info.Remark = reader.GetString("Remark");
            info.Number = reader.GetString("Number");
            info.Name = reader.GetString("Name");
            info.WorkTeamName = reader.GetString("WorkTeamName");
            info.WorkSectionName = reader.GetString("WorkSectionName");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(LaborAttendanceRecordViewInfo obj)
        {
            LaborAttendanceRecordViewInfo info = obj as LaborAttendanceRecordViewInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("StaffId", info.StaffId);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("WorkSectionId", info.WorkSectionId);
            hash.Add("AttendanceDate", info.AttendanceDate);
            hash.Add("StandardWorkload", info.StandardWorkload);
            hash.Add("Workload", info.Workload);
            hash.Add("AbsentType", info.AbsentType);
            hash.Add("IsWeekend", info.IsWeekend);
            hash.Add("IsHoliday", info.IsHoliday);
            hash.Add("Remark", info.Remark);
            hash.Add("Number", info.Number);
            hash.Add("Name", info.Name);
            hash.Add("WorkTeamName", info.WorkTeamName);
            hash.Add("WorkSectionName", info.WorkSectionName);

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
            dict.Add("StaffId", "");
            dict.Add("WorkTeamId", "");
            dict.Add("WorkSectionId", "");
            dict.Add("AttendanceDate", "考勤日期");
            dict.Add("StandardWorkload", "标准工作量");
            dict.Add("Workload", "工作量");
            dict.Add("AbsentType", "缺勤类型");
            dict.Add("IsWeekend", "是否周末");
            dict.Add("IsHoliday", "是否节假日");
            dict.Add("Remark", "备注");
            dict.Add("Number", "工号");
            dict.Add("Name", "姓名");
            dict.Add("WorkTeamName", "班组名称");
            dict.Add("WorkSectionName", "工段名称");
            #endregion

            return dict;
        }
    }
}
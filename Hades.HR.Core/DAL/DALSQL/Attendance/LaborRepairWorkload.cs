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
    /// LaborRepairWorkload
    /// </summary>
	public class LaborRepairWorkload : BaseDALSQL<LaborRepairWorkloadInfo>, ILaborRepairWorkload
    {
        #region 对象实例及构造函数

        public static LaborRepairWorkload Instance
        {
            get
            {
                return new LaborRepairWorkload();
            }
        }
        public LaborRepairWorkload() : base("HR_LaborRepairWorkload", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override LaborRepairWorkloadInfo DataReaderToEntity(IDataReader dataReader)
        {
            LaborRepairWorkloadInfo info = new LaborRepairWorkloadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.RepairId = reader.GetString("RepairId");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.AttendanceDate = reader.GetDateTime("AttendanceDate");
            info.StaffId = reader.GetString("StaffId");
            info.RepairHours = reader.GetDecimal("RepairHours");
            info.AssignType = reader.GetInt32("AssignType");
            info.Remark = reader.GetString("Remark");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(LaborRepairWorkloadInfo obj)
        {
            LaborRepairWorkloadInfo info = obj as LaborRepairWorkloadInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("RepairId", info.RepairId);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("AttendanceDate", info.AttendanceDate);
            hash.Add("StaffId", info.StaffId);
            hash.Add("RepairHours", info.RepairHours);
            hash.Add("AssignType", info.AssignType);
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
            dict.Add("Id", "");
            dict.Add("RepairId", "");
            dict.Add("WorkTeamId", "");
            dict.Add("AttendanceDate", "");
            dict.Add("StaffId", "");
            dict.Add("RepairHours", "");
            dict.Add("AssignType", "");
            dict.Add("Remark", "");
            #endregion

            return dict;
        }
    }
}
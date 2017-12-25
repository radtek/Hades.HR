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
    /// LaborDailyWorkload
    /// </summary>
	public class LaborDailyWorkload : BaseDALSQL<LaborDailyWorkloadInfo>, ILaborDailyWorkload
    {
        #region 对象实例及构造函数

        public static LaborDailyWorkload Instance
        {
            get
            {
                return new LaborDailyWorkload();
            }
        }
        public LaborDailyWorkload() : base("HR_LaborDailyWorkload", "Id")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override LaborDailyWorkloadInfo DataReaderToEntity(IDataReader dataReader)
        {
            LaborDailyWorkloadInfo info = new LaborDailyWorkloadInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.Id = reader.GetString("Id");
            info.WorkTeamWorkloadId = reader.GetString("WorkTeamWorkloadId");
            info.WorkTeamId = reader.GetString("WorkTeamId");
            info.ActualWorkTeamId = reader.GetString("ActualWorkTeamId");
            info.AttendanceDate = reader.GetDateTime("AttendanceDate");
            info.StaffId = reader.GetString("StaffId");
            info.ProductionHours = reader.GetDecimal("ProductionHours");
            info.ChangeHours = reader.GetDecimal("ChangeHours");
            info.RepairHours = reader.GetDecimal("RepairHours");
            info.ElectricHours = reader.GetDecimal("ElectricHours");
            info.LeaveHours = reader.GetDecimal("LeaveHours");
            info.AllowanceHours = reader.GetDecimal("AllowanceHours");
            info.AuditHours = reader.GetDecimal("AuditHours");
            info.Remark = reader.GetString("Remark");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(LaborDailyWorkloadInfo obj)
        {
            LaborDailyWorkloadInfo info = obj as LaborDailyWorkloadInfo;
            Hashtable hash = new Hashtable();

            hash.Add("Id", info.Id);
            hash.Add("WorkTeamWorkloadId", info.WorkTeamWorkloadId);
            hash.Add("WorkTeamId", info.WorkTeamId);
            hash.Add("ActualWorkTeamId", info.ActualWorkTeamId);
            hash.Add("AttendanceDate", info.AttendanceDate);
            hash.Add("StaffId", info.StaffId);
            hash.Add("ProductionHours", info.ProductionHours);
            hash.Add("ChangeHours", info.ChangeHours);
            hash.Add("RepairHours", info.RepairHours);
            hash.Add("ElectricHours", info.ElectricHours);
            hash.Add("LeaveHours", info.LeaveHours);
            hash.Add("AllowanceHours", info.AllowanceHours);
            hash.Add("AuditHours", info.AuditHours);
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
            dict.Add("WorkTeamWorkloadId", "");
            dict.Add("WorkTeamId", "工作班组名称");
            dict.Add("ActualWorkTeamId", "隶属班组名称");
            dict.Add("AttendanceDate", "考勤日期");
            dict.Add("StaffId", "职员姓名");
            dict.Add("ProductionHours", "产量工时");
            dict.Add("ChangeHours", "换机工时");
            dict.Add("RepairHours", "机修工时");
            dict.Add("ElectricHours", "电修工时");
            dict.Add("LeaveHours", "请假工时");
            dict.Add("AllowanceHours", "补贴工时");
            dict.Add("AuditHours", "审批工时");
            dict.Add("Remark", "备注");
            #endregion

            return dict;
        }
    }
}
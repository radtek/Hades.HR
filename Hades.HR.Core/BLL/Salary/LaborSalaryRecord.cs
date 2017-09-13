using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.HR.Util;
using Hades.Pager.Entity;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;

namespace Hades.HR.BLL
{
    /// <summary>
    /// LaborSalaryRecord
    /// </summary>
	public class LaborSalaryRecord : BaseBLL<LaborSalaryRecordInfo>
    {
        #region Constructor
        public LaborSalaryRecord() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 计算计件工人工资
        /// </summary>
        /// <param name="attendanceId">考勤ID</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public List<LaborSalaryRecordInfo> CalcLaborSalary(string attendanceId, string workTeamId)
        {
            List<LaborSalaryRecordInfo> data = new List<LaborSalaryRecordInfo>();

            // 获取级别工资
            StaffLevel blLevel = new StaffLevel();
            var levels = blLevel.Find("");

            // 获取考勤
            Attendance blAttendace = new Attendance();
            var attendaceInfo = blAttendace.FindByID(attendanceId);

            // 获取考勤记录
            DateTime d1 = new DateTime(attendaceInfo.Year, attendaceInfo.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);

            string sql1 = string.Format("WorkTeamId = '{0}' AND AttendanceDate between '{1}' AND '{2}'", workTeamId, d1, d2);

            LaborAttendanceRecord blAttendaceRecord = new LaborAttendanceRecord();
            var records = blAttendaceRecord.Find(sql1);

            // 获取工资记录
            string sql3 = string.Format("AttendanceId = '{0}'", attendanceId);
            var salarys = base.Find(sql3);

            // 获取员工记录
            string sql2 = string.Format("WorkTeamId = '{0}' AND Year = {1} AND Month = {2}", workTeamId, attendaceInfo.Year, attendaceInfo.Month);
                        
            WorkSectionLabor blLabor = new WorkSectionLabor();
            var labors = blLabor.Find(sql2);

            // 计算工资
            foreach (var labor in labors)
            {
                LaborSalaryRecordInfo info = new LaborSalaryRecordInfo();

                info.StaffId = labor.StaffId;

                info.AttendanceDays = records.Where(r => r.StaffId == info.StaffId && r.AbsentType == (int)AbsentType.None && r.IsWeekend == false && r.IsHoliday == false).Count();

                info.AnnualLeave = records.Where(r => r.StaffId == info.StaffId && r.AbsentType == (int)AbsentType.AnnualLeave).Count();
                info.SickLeave = records.Where(r => r.StaffId == info.StaffId && r.AbsentType == (int)AbsentType.SickLeave).Count();
                info.CasualLeave = records.Where(r => r.StaffId == info.StaffId && r.AbsentType == (int)AbsentType.CasualLeave).Count();
                info.AbsentLeave = records.Where(r => r.StaffId == info.StaffId && r.AbsentType == (int)AbsentType.AbsentLeave).Count();
                info.InjuryLeave = records.Where(r => r.StaffId == info.StaffId && r.AbsentType == (int)AbsentType.InjuryLeave).Count();

                info.StaffLevelId = labor.StaffLevelId;

                var level = levels.SingleOrDefault(r => r.Id == info.StaffLevelId);
                if (level == null)
                    info.LevelSalary = 0;
                else
                    info.LevelSalary = level.Salary;
                
                info.MonthWorkload = records.Where(r => r.StaffId == info.StaffId).Sum(r => r.Workload);
                info.BaseWorkload = info.AttendanceDays * 8;
                info.BaseSalary = info.BaseWorkload * info.LevelSalary;
                
                info.WeekendWorkload = records.Where(r => r.StaffId == info.StaffId && r.IsWeekend == true).Sum(r => r.Workload);
                info.WeekendSalary = info.LevelSalary * info.WeekendWorkload * 2;

                info.HolidayWorkload = records.Where(r => r.StaffId == info.StaffId && r.IsWeekend == false && r.IsHoliday == true).Sum(r => r.Workload);
                info.HolidaySalary = info.LevelSalary * info.HolidayWorkload * 3;

                info.OverWorkload = info.MonthWorkload - info.BaseWorkload - info.WeekendWorkload - info.HolidayWorkload;
                info.OverSalary = info.LevelSalary * info.OverWorkload * 1.5m;

                var exist = salarys.SingleOrDefault(r => r.StaffId == labor.StaffId);
                if (exist != null)
                {
                    info.Estimation = exist.Estimation;
                    info.Allowance = exist.Allowance;
                    info.WorkshopDeduction = exist.WorkshopDeduction;
                    info.WorkshopBonus = exist.WorkshopBonus;
                    info.NoonShift = exist.NoonShift;
                    info.NightShift = exist.NightShift;
                    info.OtherNoon = exist.OtherNoon;
                    info.OtherNight = exist.OtherNight;
                    info.ShiftAmount = exist.ShiftAmount;
                    info.QualityBonus = exist.QualityBonus;
                    info.Deduction = exist.Deduction;
                    info.Nutrition = exist.Nutrition;
                    info.EquipmentBonus = exist.EquipmentBonus;
                    info.SafetyBonus = exist.SafetyBonus;
                    info.FiveSBonus = exist.FiveSBonus;
                    info.HotBonus = exist.HotBonus;
                    info.LunchAllowance = exist.LunchAllowance;
                    info.Remark = exist.Remark;
                }

                data.Add(info);
            }

            return data;
        }

        /// <summary>
        /// 保存计件工人工资
        /// </summary>
        /// <param name="attendanceId">考勤ID</param>
        /// <param name="data">工资数据</param>
        /// <returns></returns>
        public bool SaveLaborSalary(string attendanceId, List<LaborSalaryRecordInfo> data)
        {
            try
            {
                foreach(var item in data)
                {
                    item.AttendanceId = attendanceId;

                    item.TotalSalary = item.BaseSalary + item.OverSalary + item.WeekendSalary + item.HolidaySalary +
                        item.Estimation + item.Allowance - item.WorkshopDeduction + item.WorkshopBonus - item.BonusDeduction;

                    base.InsertUpdate(item, item.Id);
                }

                return true;
            }
            catch(Exception ex)
            {
                LogTextHelper.Error(ex);
                return false;
            }

            return true;
        }
        #endregion //Method
    }
}

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.Pager.Entity;
using Hades.Framework.ControlUtil;
using Hades.Framework.Commons;
using Hades.HR.Util;

namespace Hades.HR.BLL
{
    /// <summary>
    /// LaborMonthAttendance
    /// </summary>
	public class LaborMonthAttendance : BaseBLL<LaborMonthAttendanceInfo>
    {
        #region Constructor
        public LaborMonthAttendance() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取班组员工月考勤记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public List<LaborMonthAttendanceInfo> GetRecords(int year, int month, string workTeamId)
        {
            List<LaborMonthAttendanceInfo> data = new List<LaborMonthAttendanceInfo>();

            LaborDailyAttendance dailyAttendBll = new LaborDailyAttendance();

            DateTime start = new DateTime(year, month, 1);
            DateTime end = start.AddMonths(1);

            string sql1 = string.Format("WorkTeamId = '{0}' AND AttendanceDate BETWEEN '{1}' AND '{2}'", workTeamId, start, end);
            var dailyAttendance = dailyAttendBll.Find(sql1);

            var staffIds = dailyAttendance.Select(r => r.StaffId).Distinct();

            foreach (var staffId in staffIds)
            {
                LaborMonthAttendanceInfo record = new LaborMonthAttendanceInfo();

                record.Year = year;
                record.Month = month;
                record.StaffId = staffId;
                record.WorkTeamId = workTeamId;

                record.AttendanceDays = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.None && r.IsWeekend == false && r.IsHoliday == false).Count();

                record.AnnualLeave = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.AnnualLeave).Count();
                record.SickLeave = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.SickLeave).Count();
                record.CasualLeave = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.CasualLeave).Count();
                record.InjuryLeave = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.InjuryLeave).Count();
                record.MarriageLeave = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.MarriageLeave).Count();
                record.MaternityLeave = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.MaternityLeave).Count();
                record.FuneralLeave = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.FuneralLeave).Count();
                record.AbsentLeave = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.AbsentType == (int)AbsentType.AbsentLeave).Count();

                record.MonthWorkload = dailyAttendance.Where(r => r.StaffId == record.StaffId).Sum(r => r.WorkHours + r.AbsentHours);
                record.BaseWorkload = record.AttendanceDays * 8;
                record.WeekendWorkload = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.IsWeekend == true && r.IsHoliday == false).Sum(r => r.WorkHours + r.AbsentHours);
                record.HolidayWorkload = dailyAttendance.Where(r => r.StaffId == record.StaffId && r.IsHoliday == true).Sum(r => r.WorkHours + r.AbsentHours);
                record.OverWorkload = record.MonthWorkload - record.BaseWorkload - record.WeekendWorkload - record.HolidayWorkload;

                data.Add(record);
            }

            return data;
        }

        /// <summary>
        /// 保存员工月考勤记录
        /// </summary>
        /// <param name="data">考勤记录</param>
        /// <param name="year">年度</param>
        /// <param name="month">月度</param>
        /// <param name="workTeamId">班组ID</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool SaveRecords(List<LaborMonthAttendanceInfo> data, int year, int month, string workTeamId, DbTransaction trans = null)
        {
            var dal = this.baseDal as ILaborMonthAttendance;

            bool isLocalTrans = trans == null;
            if (isLocalTrans)
            {
                trans = dal.CreateTransaction();
            }

            try
            {
                string sql = string.Format("WorkTeamId = '{0}' AND Year = {1} AND Month = {2}", workTeamId, year, month);
                dal.DeleteByCondition(sql, trans);

                foreach (var item in data)
                {
                    dal.Insert(item, trans);
                }

                if (isLocalTrans)
                {
                    trans.Commit();
                }

                return true;
            }
            catch (Exception e)
            {
                if (isLocalTrans)
                {
                    trans.Rollback();
                }
                LogTextHelper.Error("保存员工月考勤记录", e);
                return false;
            }
            finally
            {
                if (isLocalTrans)
                {
                    trans = null;
                }
            }
        }
        #endregion //Method
    }
}

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

namespace Hades.HR.BLL
{
    /// <summary>
    /// LaborSalary
    /// </summary>
	public class LaborSalary : BaseBLL<LaborSalaryInfo>
    {
        #region Constructor
        public LaborSalary() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取计算工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public List<LaborSalaryInfo> GetRecords(int year, int month, string workTeamId)
        {
            List<LaborSalaryInfo> data = new List<LaborSalaryInfo>();

            LaborMonthAttendance monthAttendBll = new LaborMonthAttendance();

            StaffLevel levelBll = new StaffLevel();
            var levels = levelBll.Find("");

            SalaryBase salaryBaseBll = new SalaryBase();
            var salaryBase = salaryBaseBll.Find("");

            string sql = string.Format("WorkTeamId = '{0}' AND Year = {1} AND Month = {2}", workTeamId, year, month);
            var attendance = monthAttendBll.Find(sql);

            foreach(var item in attendance)
            {
                LaborSalaryInfo info = new LaborSalaryInfo();
                info.Year = year;
                info.Month = month;
                info.StaffId = item.StaffId;
                info.WorkTeamId = item.WorkTeamId;

                var sb = salaryBase.SingleOrDefault(r => r.Id == info.StaffId);
                if (sb == null)
                {
                    info.StaffLevelId = "";
                    info.BaseSalary = 0;
                }
                else
                {
                    info.StaffLevelId = sb.StaffLevelId;

                    var level = levels.Single(r => r.Id == info.StaffLevelId);
                    info.LevelSalary = level.Salary;

                    info.BaseSalary = item.BaseWorkload * info.LevelSalary;
                    info.WeekendSalary = info.LevelSalary * item.WeekendWorkload * 2;
                    info.HolidaySalary = info.LevelSalary * item.HolidayWorkload * 3;
                    info.OverSalary = info.LevelSalary * item.OverWorkload * 1.5m;
                }

                data.Add(info);
            }

            return data;
        }

        /// <summary>
        /// 保存工资记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="workTeamId">班组ID</param>
        /// <returns></returns>
        public bool SaveRecords(List<LaborSalaryInfo> data, int year, int month, string workTeamId, DbTransaction trans = null)
        {
            var dal = this.baseDal as ILaborSalary;

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
                    item.TotalSalary = item.BaseSalary + item.OverSalary + item.WeekendSalary + item.HolidaySalary +
                        item.Estimation + item.Allowance;
                         
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
                LogTextHelper.Error("保存员工工资记录", e);
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

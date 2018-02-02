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
    /// StaffSalary
    /// </summary>
	public class StaffSalary : BaseBLL<StaffSalaryInfo>
    {
        #region Constructor
        public StaffSalary() : base()
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
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public List<StaffSalaryInfo> GetRecords(int year, int month, string departmentId)
        {
            List<StaffSalaryInfo> data = new List<StaffSalaryInfo>();

            StaffMonthAttendance monthAttendBll = new StaffMonthAttendance();

            StaffLevel levelBll = new StaffLevel();
            var levels = levelBll.Find("");

            SalaryBase salaryBaseBll = new SalaryBase();
            var salaryBase = salaryBaseBll.Find("");

            string sql = string.Format("DepartmentId = '{0}' AND Year = {1} AND Month = {2}", departmentId, year, month);
            var attendance = monthAttendBll.Find(sql);

            SalaryItem salaryItemBll = new SalaryItem();
            var overtimeBase = salaryItemBll.FindByCode("OvertimeBaseSalary");

            foreach (var item in attendance)
            {
                StaffSalaryInfo info = new StaffSalaryInfo();
                info.Year = year;
                info.Month = month;
                info.StaffId = item.StaffId;
                info.DepartmentId = item.DepartmentId;

                var sb = salaryBase.SingleOrDefault(r => r.Id == info.StaffId);
                if (sb == null)
                {
                    info.StaffLevelId = "";
                    info.LevelSalary = 0;
                }
                else
                {
                    info.FinanceDepartmentId = sb.FinanceDepartmentId;
                    info.StaffLevelId = sb.StaffLevelId;

                    var level = levels.Single(r => r.Id == info.StaffLevelId);
                    info.LevelSalary = level.Salary;
                    info.BaseBonus = sb.BaseBonus;
                    info.DepartmentBonus = sb.DepartmentBonus;
                    info.ReserveFund = sb.ReserveFund;
                    info.Insurance = sb.Insurance;

                    if (overtimeBase != null)
                    {
                        info.NormalOvertimeSalary = item.NormalOvertime * overtimeBase.Cardinal * overtimeBase.Coefficient * 1.5m;
                        info.WeekendOvertimeSalary = item.WeekendOvertime * overtimeBase.Cardinal * overtimeBase.Coefficient * 2;
                        info.HolidayOvertimeSalary = item.HolidayOvertime * overtimeBase.Cardinal * overtimeBase.Coefficient * 3;
                    }
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
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public bool SaveRecords(List<StaffSalaryInfo> data, int year, int month, string departmentId, DbTransaction trans = null)
        {
            var dal = this.baseDal as IStaffSalary;

            bool isLocalTrans = trans == null;
            if (isLocalTrans)
            {
                trans = dal.CreateTransaction();
            }

            try
            {
                string sql = string.Format("DepartmentId = '{0}' AND Year = {1} AND Month = {2}", departmentId, year, month);
                dal.DeleteByCondition(sql, trans);

                foreach (var item in data)
                {
                    item.OvertimeSalarySum = item.NormalOvertimeSalary + item.WeekendOvertimeSalary + item.HolidayOvertimeSalary;
                    item.TotalSalary = item.LevelSalary + item.BaseBonus + item.DepartmentBonus + item.Insurance +
                        item.ReserveFund + item.NormalOvertimeSalary + item.WeekendOvertimeSalary + item.HolidayOvertimeSalary;

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

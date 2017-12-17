using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.Framework.Commons;
using Hades.Pager.Entity;
using Hades.Framework.ControlUtil;

namespace Hades.HR.BLL
{
    /// <summary>
    /// 班组日工作量类
    /// </summary>
	public class WorkTeamDailyWorkload : BaseBLL<WorkTeamDailyWorkloadInfo>
    {
        #region Constructor
        public WorkTeamDailyWorkload() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化班组日工作量及本班人员
        /// </summary>
        /// <param name="workTeam">班组日考勤</param>
        /// <param name="labors">员工日考勤</param>
        /// <param name="trans"></param>
        public bool InsertDailyLabor(WorkTeamDailyWorkloadInfo workTeam, List<LaborDailyWorkloadInfo> labors, DbTransaction trans = null)
        {
            var dal = this.baseDal as IWorkTeamDailyWorkload;

            bool isLocalTrans = trans == null;
            if (isLocalTrans)
            {
                trans = dal.CreateTransaction();
            }

            try
            {
                //check labors not in other team
                LaborDailyWorkload laborDailyWorkload = new LaborDailyWorkload();
                foreach(var item in labors)
                {
                    var exist = laborDailyWorkload.CheckLaborDailyExist(workTeam.AttendanceDate, workTeam.Id, item.StaffId);
                    if (exist)
                        return false;
                }

                workTeam.PersonCount = labors.Count;
                dal.Insert(workTeam, trans);

                foreach (var item in labors)
                {
                    laborDailyWorkload.Insert(item, trans);
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
                LogTextHelper.Error("初始化班组日考勤", e);
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

        /// <summary>
        /// 更新班组日考勤员工
        /// </summary>
        /// <param name="workTeam">班组日考勤</param>
        /// <param name="labors">员工日考勤</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool UpdateDailyLabor(WorkTeamDailyWorkloadInfo workTeam, List<LaborDailyWorkloadInfo> labors, DbTransaction trans = null)
        {
            var dal = this.baseDal as IWorkTeamDailyWorkload;

            bool isLocalTrans = trans == null;
            if (isLocalTrans)
            {
                trans = dal.CreateTransaction();
            }

            try
            {
                //check labors not in other team
                LaborDailyWorkload laborDailyWorkload = new LaborDailyWorkload();
                foreach (var item in labors)
                {
                    var exist = laborDailyWorkload.CheckLaborDailyExist(workTeam.AttendanceDate, workTeam.Id, item.StaffId);
                    if (exist)
                        return false;
                }

                workTeam.PersonCount = labors.Count;
                dal.Update(workTeam, workTeam.Id, trans);

                laborDailyWorkload.DeleteByCondition(string.Format("WorkTeamWorkloadId = '{0}'", workTeam.Id), trans);

                foreach (var item in labors)
                {
                    laborDailyWorkload.Insert(item, trans);
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
                LogTextHelper.Error("初始化班组日考勤", e);
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

        /// <summary>
        /// 保存产量工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="productionHours">产量总工时</param>
        /// <param name="productWorkloads">员工产量工作量信息</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool SaveProduction(string workTeamWorkloadId, decimal productionHours, List<LaborProductionWorkloadInfo> productWorkloads, DbTransaction trans = null)
        {
            var dal = this.baseDal as IWorkTeamDailyWorkload;

            bool isLocalTrans = trans == null;
            if (isLocalTrans)
            {
                trans = dal.CreateTransaction();
            }

            try
            {
                var workTeamWorkload = dal.FindByID(workTeamWorkloadId, trans);
                workTeamWorkload.ProductionHours = productionHours;

                dal.Update(workTeamWorkload, workTeamWorkload.Id, trans);

                LaborProductionWorkload productBll = new LaborProductionWorkload();
                foreach (var item in productWorkloads)
                {
                    // 增加产量工时分配
                    productBll.Insert(item, trans);
                }

                LaborDailyWorkload laborWorkloadBll = new LaborDailyWorkload();
                List<LaborDailyWorkloadInfo> laborWorkloads = laborWorkloadBll.Find(string.Format("WorkTeamWorkloadId='{0}'", workTeamWorkloadId));

                foreach(var item in laborWorkloads)
                {
                    var hours = productWorkloads.Where(r => r.StaffId == item.StaffId).Sum(r => r.ProductionHours);
                    item.ProductionHours = hours;

                    laborWorkloadBll.Update(item, item.Id);
                }
                return true;
            }
            catch (Exception e)
            {
                if (isLocalTrans)
                {
                    trans.Rollback();
                }
                LogTextHelper.Error("初始化班组日考勤", e);
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

        /// <summary>
        /// 保存员工电修工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">电修总工时</param>
        /// <param name="electricWorkloads">员工电修工时信息</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool SaveElectric(string workTeamWorkloadId, decimal totalHours, List<LaborElectricWorkloadInfo> electricWorkloads, DbTransaction trans = null)
        {
            var dal = this.baseDal as IWorkTeamDailyWorkload;

            bool isLocalTrans = trans == null;
            if (isLocalTrans)
            {
                trans = dal.CreateTransaction();
            }

            try
            {
                var workTeamWorkload = dal.FindByID(workTeamWorkloadId, trans);

                // 更新班组日工作量表
                workTeamWorkload.ElectricHours = totalHours;
                dal.Update(workTeamWorkload, workTeamWorkload.Id, trans);
                                
                LaborElectricWorkload electricBll = new LaborElectricWorkload();

                // 删除已有员工电修分配记录
                electricBll.DeleteByCondition(string.Format("WorkTeamId = '{0]' AND AttendanceDate = '{1}'", workTeamWorkload.WorkTeamId, workTeamWorkload.AttendanceDate), trans);

                // 增加员工电修记录
                foreach(var item in electricWorkloads)
                {
                    electricBll.Insert(item, trans);
                }

                LaborDailyWorkload laborWorkloadBll = new LaborDailyWorkload();
                List<LaborDailyWorkloadInfo> laborWorkloads = laborWorkloadBll.Find(string.Format("WorkTeamWorkloadId='{0}'", workTeamWorkloadId));

                // 更新员工日工作量内电修数据
                foreach (var item in laborWorkloads)
                {
                    var hours = electricWorkloads.Where(r => r.StaffId == item.StaffId).Sum(r => r.ElectricHours);
                    item.ElectricHours = hours;

                    laborWorkloadBll.Update(item, item.Id, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                if (isLocalTrans)
                {
                    trans.Rollback();
                }
                LogTextHelper.Error("更新员工电修工作量", e);
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

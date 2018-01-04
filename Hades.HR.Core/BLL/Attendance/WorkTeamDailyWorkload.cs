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
        /// 设置班组日工作量及本班人员
        /// </summary>
        /// <param name="workTeamWorkload">班组日考勤</param>
        /// <param name="labors">员工日考勤</param>
        /// <param name="trans"></param>
        public bool SetDailyLabor(WorkTeamDailyWorkloadInfo workTeamWorkload, List<LaborDailyWorkloadInfo> labors, DbTransaction trans = null)
        {
            var dal = this.baseDal as IWorkTeamDailyWorkload;

            bool isLocalTrans = trans == null;
            if (isLocalTrans)
            {
                trans = dal.CreateTransaction();
            }

            try
            {
                //检查员工本日是否在其它班组
                LaborDailyWorkload laborDailyWorkloadBll = new LaborDailyWorkload();
                foreach (var item in labors)
                {
                    var exist = laborDailyWorkloadBll.CheckLaborDailyExist(workTeamWorkload.AttendanceDate, workTeamWorkload.WorkTeamId, item.StaffId);
                    if (exist)
                        return false;
                }

                // 新增班组日工作量记录
                workTeamWorkload.PersonCount = labors.Count;
                dal.InsertUpdate(workTeamWorkload, workTeamWorkload.Id, trans);

                // 删除已有工人日工作量记录
                laborDailyWorkloadBll.DeleteByCondition(string.Format("WorkTeamWorkloadId = '{0}'", workTeamWorkload.Id), trans);

                // 重新添加工人日工作量记录
                foreach (var item in labors)
                {
                    laborDailyWorkloadBll.Insert(item, trans);
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
        /// <param name="totalHours">产量总工时</param>
        /// <param name="productWorkloads">员工产量工作量信息</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool SaveProduction(string workTeamWorkloadId, decimal totalHours, List<LaborProductionWorkloadInfo> productWorkloads, DbTransaction trans = null)
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
                workTeamWorkload.ProductionHours = totalHours;
                dal.Update(workTeamWorkload, workTeamWorkload.Id, trans);

                LaborProductionWorkload productBll = new LaborProductionWorkload();

                // 删除已有员工产量工时分配记录
                productBll.DeleteByCondition(string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}'", workTeamWorkload.WorkTeamId, workTeamWorkload.AttendanceDate), trans);

                // 增加产量工时分配
                foreach (var item in productWorkloads)
                {
                    productBll.Insert(item, trans);
                }

                LaborDailyWorkload laborWorkloadBll = new LaborDailyWorkload();
                List<LaborDailyWorkloadInfo> laborWorkloads = laborWorkloadBll.Find(string.Format("WorkTeamWorkloadId='{0}'", workTeamWorkloadId), trans);

                // 更新员工日工作量内产量数据
                foreach (var item in laborWorkloads)
                {
                    var hours = productWorkloads.Where(r => r.StaffId == item.StaffId).Sum(r => r.ProductionHours);
                    item.ProductionHours = hours;

                    laborWorkloadBll.Update(item, item.Id);
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
                LogTextHelper.Error("保存员工产量工时", e);
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
        /// 保存员工换机工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">换机总工时</param>
        /// <param name="changeWorkloads">员工换机工时信息</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool SaveChange(string workTeamWorkloadId, decimal totalHours, List<LaborChangeWorkloadInfo> changeWorkloads, DbTransaction trans = null)
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
                workTeamWorkload.ChangeHours = totalHours;
                dal.Update(workTeamWorkload, workTeamWorkload.Id, trans);

                LaborChangeWorkload changeBll = new LaborChangeWorkload();

                // 删除已有员工换机分配记录
                changeBll.DeleteByCondition(string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}'", workTeamWorkload.WorkTeamId, workTeamWorkload.AttendanceDate), trans);

                // 增加员工换机记录
                foreach (var item in changeWorkloads)
                {
                    changeBll.Insert(item, trans);
                }

                LaborDailyWorkload laborWorkloadBll = new LaborDailyWorkload();
                List<LaborDailyWorkloadInfo> laborWorkloads = laborWorkloadBll.Find(string.Format("WorkTeamWorkloadId='{0}'", workTeamWorkloadId), trans);

                // 更新员工日工作量内换机数据
                foreach (var item in laborWorkloads)
                {
                    var hours = changeWorkloads.Where(r => r.StaffId == item.StaffId).Sum(r => r.ChangeHours);
                    item.RepairHours = hours;

                    laborWorkloadBll.Update(item, item.Id, trans);
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
                LogTextHelper.Error("更新员工机修工时", e);
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
        /// 保存员工机修工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="totalHours">机修总工时</param>
        /// <param name="repairWorkloads">员工机修工时信息</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool SaveRepair(string workTeamWorkloadId, decimal totalHours, List<LaborRepairWorkloadInfo> repairWorkloads, DbTransaction trans = null)
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
                workTeamWorkload.RepairHours = totalHours;
                dal.Update(workTeamWorkload, workTeamWorkload.Id, trans);

                LaborRepairWorkload repairBll = new LaborRepairWorkload();

                // 删除已有员工机修分配记录
                repairBll.DeleteByCondition(string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}'", workTeamWorkload.WorkTeamId, workTeamWorkload.AttendanceDate), trans);

                // 增加员工机修记录
                foreach (var item in repairWorkloads)
                {
                    repairBll.Insert(item, trans);
                }

                LaborDailyWorkload laborWorkloadBll = new LaborDailyWorkload();
                List<LaborDailyWorkloadInfo> laborWorkloads = laborWorkloadBll.Find(string.Format("WorkTeamWorkloadId='{0}'", workTeamWorkloadId), trans);

                // 更新员工日工作量内机修数据
                foreach (var item in laborWorkloads)
                {
                    var hours = repairWorkloads.Where(r => r.StaffId == item.StaffId).Sum(r => r.RepairHours);
                    item.RepairHours = hours;

                    laborWorkloadBll.Update(item, item.Id, trans);
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
                LogTextHelper.Error("更新员工机修工时", e);
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
                electricBll.DeleteByCondition(string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}'", workTeamWorkload.WorkTeamId, workTeamWorkload.AttendanceDate), trans);

                // 增加员工电修记录
                foreach (var item in electricWorkloads)
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
                LogTextHelper.Error("更新员工电修工时", e);
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
        /// 保存员工请假工时信息
        /// </summary>
        /// <param name="workTeamWorkloadId">班组日工作量ID</param>
        /// <param name="leaveWorkloads">员工请假工时信息</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool SaveLeave(string workTeamWorkloadId, List<LaborLeaveWorkloadInfo> leaveWorkloads, DbTransaction trans = null)
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

                LaborLeaveWorkload leaveBll = new LaborLeaveWorkload();

                // 删除已有员工请假分配记录
                leaveBll.DeleteByCondition(string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}'", workTeamWorkload.WorkTeamId, workTeamWorkload.AttendanceDate), trans);

                // 增加员工请假记录
                foreach (var item in leaveWorkloads)
                {
                    leaveBll.Insert(item, trans);
                }

                LaborDailyWorkload laborWorkloadBll = new LaborDailyWorkload();
                List<LaborDailyWorkloadInfo> laborWorkloads = laborWorkloadBll.Find(string.Format("WorkTeamWorkloadId='{0}'", workTeamWorkloadId));

                // 更新员工日工作量内电修数据
                foreach (var item in laborWorkloads)
                {
                    item.LeaveHours = leaveWorkloads.Where(r => r.StaffId == item.StaffId).Sum(r => r.LeaveHours);
                    item.AllowanceHours = leaveWorkloads.Where(r => r.StaffId == item.StaffId).Sum(r => r.AllowanceHours);

                    laborWorkloadBll.Update(item, item.Id, trans);
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
                LogTextHelper.Error("更新员工请假工时", e);
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

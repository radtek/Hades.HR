using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

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
                workTeam.PersonCount = labors.Count;
                dal.Insert(workTeam, trans);

                foreach (var item in labors)
                {
                    LaborDailyWorkload laborBll = new LaborDailyWorkload();
                    laborBll.Insert(item, trans);
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
        #endregion //Method
    }
}

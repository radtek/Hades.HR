using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;

namespace Hades.HR.BLL
{
    /// <summary>
    /// LaborDailyAttendance
    /// </summary>
	public class LaborDailyAttendance : BaseBLL<LaborDailyAttendanceInfo>
    {
        #region Constructor
        public LaborDailyAttendance() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        public bool SaveAttendance(string workTeamId, DateTime attendaceDate, List<LaborDailyAttendanceInfo> data, DbTransaction trans = null)
        {
            var dal = this.baseDal as ILaborDailyAttendance;

            bool isLocalTrans = trans == null;
            if (isLocalTrans)
            {
                trans = dal.CreateTransaction();
            }

            try
            {
                // 删除已有工人日考勤记录
                dal.DeleteByCondition(string.Format("WorkTeamId = '{0}' AND AttendanceDate = '{1}", workTeamId, attendaceDate), trans);

                foreach(var item in data)
                {
                    dal.Insert(item, trans);
                }

                // 重新添加工人日考勤记录
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
                LogTextHelper.Error("保存员工考勤记录", e);
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

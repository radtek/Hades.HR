using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.Pager.Entity;
using Hades.Framework.ControlUtil;

namespace Hades.HR.BLL
{
    /// <summary>
    /// WorkTeam
    /// </summary>
	public class WorkTeam : BaseBLL<WorkTeamInfo>
    {
        #region Constructor
        public WorkTeam() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 查找所有班组，不包含已删除
        /// </summary>
        /// <returns></returns>
        public List<WorkTeamInfo> FindAll()
        {
            string sql = "deleted=0";
            return base.Find(sql, "ORDER BY SortCode");
        }
        #endregion //Method
    }
}

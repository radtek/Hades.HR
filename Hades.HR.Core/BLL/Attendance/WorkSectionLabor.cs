using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.Pager.Entity;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;

namespace Hades.HR.BLL
{
    /// <summary>
    /// WorkSectionLabor
    /// </summary>
	public class WorkSectionLabor : BaseBLL<WorkSectionLaborInfo>
    {
        #region Constructor
        public WorkSectionLabor() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 保存职员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SaveLabors(List<WorkSectionLaborInfo> data)
        {
            int index = 0;
            // 检查是否职员已经存在
            foreach (var item in data)
            {
                string sql = string.Format("Year = {0} AND Month = {1} AND StaffId = '{2}' AND WorkTeamId != '{3}'",
                    item.Year, item.Month, item.StaffId, item.WorkTeamId);

                var result = this.Find(sql);
                if (result.Count > 0)
                    return index;

                index++;
            }

            foreach (var item in data)
            {
                this.InsertUpdate(item, item.Id);
            }

            return -1;
        }
        #endregion //Method
    }
}

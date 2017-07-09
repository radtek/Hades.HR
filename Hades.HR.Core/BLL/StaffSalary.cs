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
        /// 查找所有工资基本信息
        /// </summary>
        /// <returns></returns>
        public List<StaffSalaryInfo> FindAll()
        {
            List<StaffSalaryInfo> data = new List<StaffSalaryInfo>();

            Staff staffBll = new Staff();
            staffBll.Find("");

            string sql = "deleted=0";
            var salarys = base.Find(sql, "ORDER BY SortCode");
            

            return data;

        }
        #endregion //Method
    }
}

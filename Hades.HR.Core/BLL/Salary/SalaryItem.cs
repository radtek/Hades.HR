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
    /// SalaryItem
    /// </summary>
	public class SalaryItem : BaseBLL<SalaryItemInfo>
    {
        #region Constructor
        public SalaryItem() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据代码查找
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public SalaryItemInfo FindByCode(string code)
        {
            string sql = string.Format("Code = '{0}'", code);

            var find = this.FindSingle(sql);
            return find;
        }
        #endregion //Method
    }
}

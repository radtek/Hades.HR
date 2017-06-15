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
    /// ProductionLine
    /// </summary>
	public class ProductionLine : BaseBLL<ProductionLineInfo>
    {
        #region Constructor
        public ProductionLine() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 查找所有产线，不包含已删除
        /// </summary>
        /// <returns></returns>
        public List<ProductionLineInfo> FindAll()
        {
            string sql = "deleted=0";
            return base.Find(sql, "ORDER BY SortCode");
        }
        #endregion //Method
    }
}

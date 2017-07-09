using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Hades.HR.Entity;
using Hades.HR.IDAL;
using Hades.Pager.Entity;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;

namespace Hades.HR.BLL
{
    /// <summary>
    /// Staff
    /// </summary>
	public class Staff : BaseBLL<StaffInfo>
    {
        #region Constructor
        public Staff() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 查找多个部门员工
        /// </summary>
        /// <param name="ids">部门ID列表</param>
        /// <returns></returns>
        public List<StaffInfo> FindByDepartments(List<string> idList)
        {
            string ids = string.Join(",", idList);
            ids = ids.TransSQLInStrFormat();

            string sql = $"DepartmentId IN({ids})";
            return base.Find(sql);
        }

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool CheckDuplicate(StaffInfo entity)
        {
            string sql = "";
            string message = "";
            if (string.IsNullOrEmpty(entity.Id))
            {
                sql = string.Format("Number = '{0}'", entity.Number);
            }
            else
            {
                sql = string.Format("Number = '{0}' AND Id != '{1}'", entity.Number, entity.Id);
            }
            var result = base.Find(sql);
            if (result.Count > 0)
            {
                message = "工号已存在";
                return false;
            }
            else
            {
                message = "";
                return true;
            }
        }

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool MarkDelete(string id)
        {
            var entity = base.FindByID(id);
            entity.Deleted = 1;

            return base.Update(entity, id);
        }
        #endregion //Method
    }
}

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
    /// Position
    /// </summary>
	public class Position : BaseBLL<PositionInfo>
    {
        #region Constructor
        public Position() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 查找所有岗位，不包含已删除
        /// </summary>
        /// <returns></returns>
        public List<PositionInfo> FindAll()
        {
            string sql = "deleted=0";
            return base.Find(sql, "ORDER BY SortCode");
        }

        /// <summary>
        /// 根据部门查找岗位
        /// </summary>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public List<PositionInfo> FindByDepartment(string departmentId)
        {
            string sql = $"DepartmentId = '{departmentId}'";
            return base.Find(sql, "ORDER BY SortCode");
        }

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="message">错误消息</param>
        /// <returns></returns>
        public bool CheckDuplicate(PositionInfo entity, out string message)
        {
            string sql = "";
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
                message = "岗位编码已存在";
                return false;
            }
            else
            {
                message = "";
                return true;
            }
        }

        /// <summary>
        /// 新增岗位
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public override bool Insert(PositionInfo obj, DbTransaction trans = null)
        {
            obj.Id = Guid.NewGuid().ToString();
            return base.Insert(obj, trans);
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

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
    /// Department
    /// </summary>
	public class Department : BaseBLL<DepartmentInfo>
    {
        #region Constructor
        public Department() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 递归载入所有子部门
        /// </summary>
        /// <param name="parentId">父部门ID</param>
        /// <returns></returns>
        private List<DepartmentInfo> LoadChildren(string parentId)
        {
            List<DepartmentInfo> data = new List<DepartmentInfo>();

            string sql = $"PID='{parentId}' AND deleted=0 AND enabled=1";
            var children = base.Find(sql);

            data.AddRange(children);

            foreach (var item in children)
            {
                var c = LoadChildren(item.Id);
                data.AddRange(c);
            }

            return data;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 查找所有部门，不包含已删除
        /// </summary>
        /// <returns></returns>
        public List<DepartmentInfo> FindAll()
        {
            string sql = "deleted=0";
            return base.Find(sql, "ORDER BY SortCode");
        }

        /// <summary>
        /// 查找部门列表
        /// </summary>
        /// <param name="deleted">删除标志</param>
        /// <param name="enabled">启用标志</param>
        /// <returns></returns>
        public List<DepartmentInfo> FindList(int deleted, int enabled)
        {
            string sql = $"deleted={deleted} AND enabled={enabled}";
            return base.Find(sql, "ORDER BY SortCode");
        }

        /// <summary>
        /// 获取指定类型部门
        /// </summary>
        /// <param name="types">部门类型</param>
        /// <returns></returns>
        public List<DepartmentInfo> FindByTypes(int[] types)
        {
            string sql = "";
            for (int i = 0; i < types.Length; i++)
            {
                sql += $" Type = {types[i]} AND";
            }
            sql = sql.Remove(sql.Length - 3);

            return base.Find(sql);
        }

        /// <summary>
        /// 查找上级部门
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public DepartmentInfo FindParent(DepartmentInfo entity)
        {
            if (string.IsNullOrEmpty(entity.PID))
                return null;

            return base.FindByID(entity.Id);
        }

        /// <summary>
        /// 查找部门及其子部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
        public List<DepartmentInfo> FindWithChildren(string id)
        {
            List<DepartmentInfo> data = new List<DepartmentInfo>();
            var parent = base.FindByID(id);
            if (parent == null)
                return data;

            data.Add(parent);

            var children = LoadChildren(id);
            data.AddRange(children);
            return data;
        }

        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool CheckDuplicate(DepartmentInfo entity)
        {
            string message = "";
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
                message = "部门编码已存在";
                return false;
            }
            else
            {
                message = "";
                return true;
            }
        }

        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public override bool Insert(DepartmentInfo obj, DbTransaction trans = null)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hades.HR.UI
{
    using Hades.Framework.Commons;
    using Hades.Framework.ControlUtil;
    using Hades.Framework.ControlUtil.Facade;
    using Hades.HR.Entity;
    using Hades.HR.BLL;
    using Hades.HR.Facade;

    /// <summary>
    /// 岗位下拉框
    /// </summary>
    public partial class PositionLookup : UserControl
    {
        #region Constructor
        public PositionLookup()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="departmentId">所属部门ID</param>
        public void Init(string departmentId)
        {
            var data = CallerFactory<IPositionService>.Instance.FindByDepartment(departmentId);
            this.bsPosition.DataSource = data;
        }

        /// <summary>
        /// 设置选中岗位
        /// </summary>
        /// <param name="positionId"></param>
        public void SetSelected(string positionId)
        {
            if (string.IsNullOrEmpty(positionId))
                this.luPosition.EditValue = null;
            else
            {
                var data = this.bsPosition.DataSource as List<PositionInfo>;
                if (data.Any(r => r.Id == positionId))
                    this.luPosition.EditValue = positionId;
                else
                    this.luPosition.EditValue = null;
            }
        }

        /// <summary>
        /// 获取当前选中岗位ID
        /// </summary>
        /// <returns></returns>
        public string GetSelectedId()
        {
            if (this.luPosition.EditValue == null)
                return "";
            else
            {
                var pos = this.luPosition.GetSelectedDataRow() as PositionInfo;
                return pos.Id;
            }
        }
        #endregion //Method
    }
}

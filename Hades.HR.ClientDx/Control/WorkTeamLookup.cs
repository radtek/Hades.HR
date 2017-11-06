using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hades.HR.UI
{
    using Hades.Framework.ControlUtil.Facade;
    using Hades.HR.Entity;
    using Hades.HR.BLL;
    using Hades.HR.Facade;

    /// <summary>
    /// 班组选择控件
    /// </summary>
    public partial class WorkTeamLookup : UserControl
    {
        #region Constructor
        public WorkTeamLookup()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="companyId">所属公司ID</param>
        public void Init(string companyId)
        {
            var data = CallerFactory<IWorkTeamService>.Instance.Find2(string.Format("CompanyId='{0}' AND Deleted=0", companyId), "ORDER BY SortCode");
            this.bsWorkTeam.DataSource = data;
        }        

        /// <summary>
        /// 设置选中班组
        /// </summary>
        /// <param name="workTeamId"></param>
        public void SetSelected(string workTeamId)
        {
            if (string.IsNullOrEmpty(workTeamId))
                this.luWorkTeam.EditValue = null;
            else
            {
                var data = this.bsWorkTeam.DataSource as List<WorkTeamInfo>;
                if (data.Any(r => r.Id == workTeamId))
                    this.luWorkTeam.EditValue = workTeamId;
                else
                    this.luWorkTeam.EditValue = null;
            }
        }

        /// <summary>
        /// 获取当前选中班组ID
        /// </summary>
        /// <returns></returns>
        public string GetSelectedId()
        {
            if (this.luWorkTeam.EditValue == null)
                return "";
            else
            {
                var pos = this.luWorkTeam.GetSelectedDataRow() as WorkTeamInfo;
                return pos.Id;
            }
        }
        #endregion //Method
    }
}

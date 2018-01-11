using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.BLL;
using Hades.HR.Facade;

namespace Hades.HR.UI
{
    public partial class WorkSectionLookup : UserControl
    {
        #region Constructor
        public WorkSectionLookup()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void Init()
        {
            var data = CallerFactory<IWorkSectionService>.Instance.Find2("Deleted=0", "ORDER BY SortCode");
            this.bsWorkSection.DataSource = data;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="companyId">所属公司ID</param>
        public void Init(string companyId)
        {
            var data = CallerFactory<IWorkSectionService>.Instance.Find2(string.Format("CompanyId='{0}' AND Deleted=0", companyId), "ORDER BY SortCode");
            this.bsWorkSection.DataSource = data;
        }

        /// <summary>
        /// 设置选中班组
        /// </summary>
        /// <param name="workSectionId"></param>
        public void SetSelected(string workSectionId)
        {
            if (string.IsNullOrEmpty(workSectionId))
                this.luWorkSection.EditValue = null;
            else
            {
                var data = this.bsWorkSection.DataSource as List<WorkSectionInfo>;
                if (data.Any(r => r.Id == workSectionId))
                    this.luWorkSection.EditValue = workSectionId;
                else
                    this.luWorkSection.EditValue = null;
            }
        }

        /// <summary>
        /// 获取当前选中班组ID
        /// </summary>
        /// <returns></returns>
        public string GetSelectedId()
        {
            if (this.luWorkSection.EditValue == null)
                return "";
            else
            {
                var pos = this.luWorkSection.GetSelectedDataRow() as WorkSectionInfo;
                return pos.Id;
            }
        }
        #endregion //Method
    }
}

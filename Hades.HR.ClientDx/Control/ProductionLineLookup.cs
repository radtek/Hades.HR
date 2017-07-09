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
    /// 产线下拉选择框
    /// </summary>
    public partial class ProductionLineLookup : UserControl
    {
        #region Constructor
        public ProductionLineLookup()
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
            var data = CallerFactory<IProductionLineService>.Instance.Find2(string.Format("CompanyId='{0}' AND Deleted=0", companyId), "ORDER BY SortCode");
            this.bsProductionLine.DataSource = data;
        }

        /// <summary>
        /// 设置选中产线
        /// </summary>
        /// <param name="productionLineId"></param>
        public void SetSelected(string productionLineId)
        {
            if (string.IsNullOrEmpty(productionLineId))
                this.luProductionLine.EditValue = null;
            else
            {
                var data = this.bsProductionLine.DataSource as List<ProductionLineInfo>;
                if (data.Any(r => r.Id == productionLineId))
                    this.luProductionLine.EditValue = productionLineId;
                else
                    this.luProductionLine.EditValue = null;
            }
        }

        /// <summary>
        /// 获取当前选中产线ID
        /// </summary>
        /// <returns></returns>
        public string GetSelectedId()
        {
            if (this.luProductionLine.EditValue == null)
                return "";
            else
            {
                var pos = this.luProductionLine.GetSelectedDataRow() as ProductionLineInfo;
                return pos.Id;
            }
        }
        #endregion //Method
    }
}

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
    using Hades.Framework.Commons;
    using Hades.Framework.ControlUtil;
    using Hades.Framework.ControlUtil.Facade;
    using Hades.HR.Entity;
    using Hades.HR.Facade;

    /// <summary>
    /// 员工奖金表格控件
    /// </summary>
    public partial class StaffBonusGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否显示姓名
        /// </summary>
        private bool showName;

        /// <summary>
        /// 能否编辑
        /// </summary>
        private bool editable;
        #endregion //Field

        #region Constructor
        public StaffBonusGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="staffId"></param>
        public void Init(string staffId)
        {
            var data = CallerFactory<IStaffBonusService>.Instance.Find(string.Format("StaffId='{0}'", staffId));
            var all = CallerFactory<IBonusDefineService>.Instance.Find("");

            foreach(var item in all)
            {
                if (data.Any(r => r.Name == item.Name))
                    continue;

                StaffBonusInfo info = new StaffBonusInfo();
                info.Id = Guid.NewGuid().ToString();
                info.StaffId = staffId;
                info.Name = item.Name;
                info.Amount = 0;
                info.Remark = "";

                data.Add(info);
            }

            this.bsBonus.DataSource = data;
        }
        #endregion //Method

        #region Event
        private void StaffBonusGrid_Load(object sender, EventArgs e)
        {
            this.colStaffId.Visible = this.showName;
            this.dgvBonus.OptionsBehavior.Editable = this.editable;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<StaffBonusInfo> DataSource
        {
            get
            {
                return this.bsBonus.DataSource as List<StaffBonusInfo>;
            }
            set
            {
                this.dgvBonus.BeginDataUpdate();
                this.bsBonus.DataSource = value;
                this.dgvBonus.EndDataUpdate();
            }
        }

        /// <summary>
        /// 是否显示姓名
        /// </summary>
        [Description("是否显示姓名"), Category("界面"), Browsable(true)]
        public bool ShowName
        {
            get
            {
                return showName;
            }

            set
            {
                showName = value;
            }
        }

        /// <summary>
        /// 能否编辑
        /// </summary>
        [Description("能否编辑"), Category("界面"), Browsable(true)]
        public bool Editable
        {
            get
            {
                return editable;
            }

            set
            {
                editable = value;
            }
        }
        #endregion //Property
    }
}

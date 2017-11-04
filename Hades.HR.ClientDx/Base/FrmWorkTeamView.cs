using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmWorkTeamView : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkTeamInfo tempInfo = new WorkTeamInfo();
        #endregion //Field

        #region Constructor
        public FrmWorkTeamView()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                this.Text = "编辑班组";
                WorkTeamInfo info = CallerFactory<IWorkTeamService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtName.Text = info.Name;
                    txtNumber.Text = info.Number;
                    txtQuota.Text = info.Quota.ToString();

                    var department = CallerFactory<IDepartmentService>.Instance.FindByID(info.CompanyId);
                    txtCompany.Text = department.Name;

                    txtPrincipal.Text = info.Principal;
                    txtSortCode.Text = info.SortCode;
                    txtRemark.Text = info.Remark;
                    txtEnabled.Text = info.Enabled == 1 ? "已启用" : "未启用";
                }

                //this.btnOK.Enabled = HasFunction("WorkTeam/Edit");             
            }
            else
            {
                this.Text = "新增班组";
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkTeam/Add");  
            }
        }

        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamInfo();
            base.ClearScreen();
        }
        #endregion //Method
    }
}

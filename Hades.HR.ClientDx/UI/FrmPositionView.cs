using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hades.Pager.Entity;
using Hades.Dictionary;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    /// <summary>
    /// 查看岗位窗体
    /// </summary>
    public partial class FrmPositionView : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private PositionInfo tempInfo = new PositionInfo();
        #endregion //Field

        #region Constructor
        public FrmPositionView()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method

        public override void DisplayData()
        {
            if (!string.IsNullOrEmpty(ID))  //编辑
            {
                PositionInfo info = CallerFactory<IPositionService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtName.Text = info.Name;
                    txtNumber.Text = info.Number;

                    txtQuota.Text = info.Quota.ToString();
                    txtSortCode.Text = info.SortCode;
                    txtRemark.Text = info.Remark;
                    txtEnabled.Text = info.Enabled == 1 ? "已启用" : "未启用";

                    var department = CallerFactory<IDepartmentService>.Instance.FindByID(info.DepartmentId);
                    txtDepartment.Text = department.Name;
                }

                this.Text = "查看部门";
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        public override void ClearScreen()
        {
            this.tempInfo = new PositionInfo();
            base.ClearScreen();
        }
        #endregion //Method
    }
}

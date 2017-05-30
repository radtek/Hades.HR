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
    /// 查看部门窗体
    /// </summary>
    public partial class FrmDepartmentView : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private DepartmentInfo tempInfo = new DepartmentInfo();
        #endregion //Field

        #region Constructor
        public FrmDepartmentView()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method

        public override void DisplayData()
        {
            if (!string.IsNullOrEmpty(ID))  //编辑
            {
                DepartmentInfo info = CallerFactory<IDepartmentService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtNumber.Text = info.Number;
                    txtName.Text = info.Name;
                    txtSortCode.Text = info.SortCode;
                    txtType.Text = ((DepartmentType)info.Type).DisplayName();
                    txtAddress.Text = info.Address;
                    txtInnerPhone.Text = info.InnerPhone;
                    txtOuterPhone.Text = info.OuterPhone;
                    dpFoundDate.SetDateTime(info.FoundDate);
                    dpCloseDate.SetDateTime(info.CloseDate);
                    txtRemark.Text = info.Remark;
                    txtEnabled.Text = info.Enabled == 1 ? "已启用" : "未启用";

                    if (!string.IsNullOrEmpty(info.PID))
                    {
                        var parent = CallerFactory<IDepartmentService>.Instance.FindByID(info.PID.ToString());
                        txtParent.Text = parent.Name;
                    }
                }

                this.Text = "查看部门";
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        public override void ClearScreen()
        {
            this.tempInfo = new DepartmentInfo();
            base.ClearScreen();
        }
        #endregion //Method
    }
}

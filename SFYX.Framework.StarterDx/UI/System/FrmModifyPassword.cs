using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.BaseUI;
using Hades.Security.Facade;
using Hades.Framework.ControlUtil.Facade;

namespace SFYX.Framework.Starter
{
    public partial class FrmModifyPassword : BaseDock
    {
        public FrmModifyPassword()
        {
            InitializeComponent();
        }

        private void FrmModifyPassword_Load(object sender, EventArgs e)
        {
            this.txtLogin.Text = this.LoginUserInfo.FullName;
            this.txtOldPassword.Focus();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            #region 输入验证
            if (this.txtRePassword.Text != this.txtPassword.Text)
            {
                MessageDxUtil.ShowTips("两个新密码的输入不一致");
                this.txtRePassword.Focus();
                return;
            }
            #endregion

            try
            {
                bool result = await CallerFactory<IUserService>.Instance.ModifyPasswordAsyn(this.LoginUserInfo.Name, this.txtPassword.Text).TimeOut<bool>(Portal.gc.AsynTimeOut);

                if (result)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageDxUtil.ShowTips("密码修改成功");
                }
                else
                {
                    MessageDxUtil.ShowWarning("用户密码资料不正确，请核对");
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }

        private void txtOldPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtRePassword.Focus();
            }
        }

        private void txtRePassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }
    }
}

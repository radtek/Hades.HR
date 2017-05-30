using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SettingsProviderNet;
using Hades.Framework.Commons;
using Hades.Framework.BaseUI;
using Hades.Framework.BaseUI.Settings;

namespace SFYX.Framework.Starter
{
    public partial class PageLogin : PropertyPage
    {
        private SettingsProvider settings;
        private ISettingsStorage store;

        public PageLogin()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                store = new PortableStorage();//保存在本地计算机
                settings = new SettingsProvider(store);
            }
        }

        public override void OnInit()
        {
            LoginParameter parameter = settings.GetSettings<LoginParameter>();
            if (parameter != null)
            {
                this.txtLoginId.Text = parameter.LoginId;
                this.txtPassword.Text = parameter.Password;
                this.txtPassword.Tag = parameter.Password;
                this.chkRememberPasssword.Checked = parameter.RememberPassword;
                this.txtInternalPort.Value = parameter.InternalWcfPort;
                this.txtInternalHost.Text = parameter.InternalWcfHost;
                this.txtExternalPort.Value = parameter.ExternalWcfPort;
                this.txtExternalHost.Text = parameter.ExternalWcfHost;
                this.txtUseLocalType.Checked = parameter.IsLocalDatabase;
                this.rdgWCFMode.Enabled = !this.txtUseLocalType.Checked;
                if (this.txtUseLocalType.Checked)
                {
                    this.rdgWCFMode.SelectedIndex = -1;
                    
                }
                else
                {
                    this.rdgWCFMode.SelectedIndex = parameter.WcfMode == "内网" ? 0 : 1;
                }
            }
        }

        public override void OnSetActive()
        {
        }

        public override bool OnApply()
        {
            bool result = false;
            try
            {
                LoginParameter parameter = settings.GetSettings<LoginParameter>();
                if (parameter != null)
                {
                    parameter.LoginId = this.txtLoginId.Text;
                    parameter.Password = this.txtPassword.Text;
                    parameter.RememberPassword = this.chkRememberPasssword.Checked;
                    parameter.InternalWcfPort = Convert.ToInt32(this.txtInternalPort.Value);
                    parameter.InternalWcfHost = this.txtInternalHost.Text;
                    parameter.ExternalWcfPort = Convert.ToInt32(this.txtExternalPort.Value);
                    parameter.ExternalWcfHost = this.txtExternalHost.Text;
                    parameter.IsLocalDatabase = this.txtUseLocalType.Checked;
                    parameter.WcfMode = this.txtUseLocalType.Checked?"": this.rdgWCFMode.EditValue.ToString();
                    settings.SaveSettings<LoginParameter>(parameter);
                }
                result = true;
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }

            return result;
        }

        private void txtUseLocalType_CheckedChanged(object sender, EventArgs e)
        {
            this.rdgWCFMode.Enabled = !this.txtUseLocalType.Checked;
            if (this.txtUseLocalType.Checked)
            {
                this.rdgWCFMode.SelectedIndex = -1;
            }
        }
    }
}

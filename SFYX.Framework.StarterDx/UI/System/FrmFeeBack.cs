using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.BaseUI;
using SettingsProviderNet;

namespace SFYX.Framework.Starter
{
    public partial class FrmFeeBack : BaseForm
    {
        private int maxTry = 3;
        private int currentTry = 0;

        private SettingsProvider settings;
        private ISettingsStorage store;
        private EmailParameter parameter;
        private string recipient = string.Empty;//反馈回的邮箱
        public FrmFeeBack()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                //DatabaseStorage：在数据库里面，以指定用户标识保存参数数据
                string creator = Portal.gc.LoginUserInfo.Name;
                store = new DatabaseStorage(creator);
                settings = new SettingsProvider(store);
                parameter = settings.GetSettings<EmailParameter>();
                txtEmail.Text = parameter == null ? "" : parameter.Email;

                AppConfig config = new AppConfig();
                recipient = config.AppConfigGet("feedbackmail");
                
            }
        }

        private void FrmFeeBack_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtAdvise.Dispose();//显式关闭空间，防止错误出现
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 检查地址
            this.DialogResult = DialogResult.None;
            if (this.txtAdvise.BodyHtml.Trim().Length < 10)
            {
                MessageDxUtil.ShowTips("您的建议太短(少于10个字符），请输入详细一些内容，谢谢。");
                this.txtAdvise.Focus();
                return;
            }
            else if (this.txtEmail.Text.Length == 0 || !ValidateUtil.IsEmail(this.txtEmail.Text))
            {
                MessageDxUtil.ShowTips("请输入邮件地址，以便我们能够快速联系到您。");
                this.txtEmail.Focus();
                return;
            }
            #endregion

            
            if (parameter == null)
            {
                MessageDxUtil.ShowTips("请先通过【系统管理】->【参数设置】->【邮箱设置】设备邮箱地址！");
                return;
            }

            if (string.IsNullOrEmpty(recipient))
            {
                MessageDxUtil.ShowWarning("未设置反馈接收者邮箱！");
                return;
            }

            SendEmail();
            this.DialogResult = DialogResult.OK;
            MessageDxUtil.ShowTips("谢谢您的建议！");
        }

        private void SendEmail()
        {
            bool result = false;
            Thread.Sleep(100);
            currentTry++;

            EmailHelper email = new EmailHelper(parameter.SmtpServer, parameter.LoginId, parameter.Password);
            email.Subject = string.Format("来自【{0}】对四方友信ERP管理平台的建议", this.txtEmail.Text);
            email.IsHtml = true;
            email.Body = this.txtAdvise.BodyHtml;//支持嵌入图片的内容发送
            email.From = parameter.Email;  
            email.FromName = parameter.LoginId;
            
            email.AddRecipient(recipient);
            //email.AddAttachment(System.IO.Path.Combine(Application.StartupPath, "cityroad.jpg")); 

            try
            {
                bool success = email.SendEmail();
                if (success)
                {
                    currentTry = 0;
                }
                else if (currentTry < maxTry)
                {
                    LogHelper.Error(email.ErrorMessage);
                    SendEmail();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);

                if (currentTry <= maxTry)
                {
                    SendEmail();
                }
                currentTry = 0; //异常引起的死循环?
            }  
        }
    }
}

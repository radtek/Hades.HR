using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

using Hades.Framework.Commons;
using Hades.Security.Entity;
using Updater.Core;
using Hades.Framework.BaseUI;
using Hades.Framework.ControlUtil;
using Hades.Security.Facade;
using Hades.Framework.ControlUtil.Facade;
using System.Configuration;
using System.ServiceModel.Configuration;
using System.Text.RegularExpressions;
using SettingsProvider = SettingsProviderNet.SettingsProvider;
using SettingsProviderNet;
using DevExpress.XtraBars.Alerter;

namespace SFYX.Framework.Starter
{
	/// <summary>
	/// Logon 的摘要说明。
	/// </summary>
	public class Logon : BaseDock
	{
		#region Private Members

		private GroupBox groupBox1;
		private Label label1;
		private Label label2;
        private DevExpress.XtraEditors.SimpleButton btExit;
        private DevExpress.XtraEditors.SimpleButton btLogin;
		private DevExpress.XtraEditors.ComboBoxEdit cmbzhanhao;
		private TextBox tbPass;
		private Label lblTitle;
		private Label lblCalendar;
		private LinkLabel linkHelp;
        private LinkLabel lnkSecurity;
        private DevExpress.XtraEditors.LabelControl lnkRegister;
        private Label lblNetType;
        private DevExpress.XtraEditors.RadioGroup radNetType;
        private DevExpress.XtraEditors.CheckEdit chkLocalVersion;
        private DevExpress.XtraEditors.LabelControl lblSetting;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private Container components = null;

		#endregion

        public bool bLogin = false; //判断用户是否登录
        private const string Login_Name_Key = "NanyueTongMis_LoginName";
        private BackgroundWorker updateWorker;
        private RegisterHotKeyHelper hotKey1 = new RegisterHotKeyHelper();
        private RegisterHotKeyHelper hotKey2 = new RegisterHotKeyHelper();

        private SettingsProvider settings;
        private ISettingsStorage store;
        private LoginParameter parameter;
        private DevExpress.XtraEditors.CheckEdit chkRemember;
        AlertControl alerter = new AlertControl();

        public Logon()
        {
            InitializeComponent();

            try
            {
                LoadParameter();

                //InitLoginName();
                //InitHistoryLoginName();
                SetHotKey();
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
                LogHelper.Error(ex);
            }

            this.btExit.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 设置F1帮助 F2权限系统 的全局热键
        /// </summary>
        private void SetHotKey()
        {
            hotKey1.Keys = Keys.F1;
            hotKey1.ModKey = 0;
            hotKey1.WindowHandle = this.Handle;
            hotKey1.WParam = 10001;
            hotKey1.HotKey += new RegisterHotKeyHelper.HotKeyPass(hotKey1_HotKey);
            hotKey1.StarHotKey();

            hotKey2.Keys = Keys.F2;
            hotKey2.ModKey = 0;
            hotKey2.WindowHandle = this.Handle;
            hotKey2.WParam = 10002;
            hotKey2.HotKey += new RegisterHotKeyHelper.HotKeyPass(hotKey2_HotKey);
            hotKey2.StarHotKey();
        }

        void hotKey1_HotKey()
        {
            linkHelp_LinkClicked(null, null);
        }

        void hotKey2_HotKey()
        {
            lnkSecurity_LinkClicked(null, null);
        }

        /// <summary>
        /// 从数据库中列出相关用户
        /// </summary>
        private void InitLoginName()
        {
            List<SimpleUserInfo> userList = CallerFactory<IUserService>.Instance.GetSimpleUsers();
            this.cmbzhanhao.Properties.Items.Clear();
            foreach (SimpleUserInfo info in userList)
            {
                this.cmbzhanhao.Properties.Items.Add(info.Name);
            }
        }

        /// <summary>
        /// 初始化账号登录列表
        /// </summary>
        private void InitHistoryLoginName()
        {
            string loginNames = RegistryHelper.GetValue(Login_Name_Key);
            if (!string.IsNullOrEmpty(loginNames))
            {
                if (this.cmbzhanhao.Properties.Items.Count > 0)
                {
                    this.cmbzhanhao.SetComboBoxItem(loginNames);
                }
                else
                {
                    this.cmbzhanhao.Text = loginNames;
                }
            }
        }

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logon));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.cmbzhanhao = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkRemember = new DevExpress.XtraEditors.CheckEdit();
            this.btExit = new DevExpress.XtraEditors.SimpleButton();
            this.btLogin = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.linkHelp = new System.Windows.Forms.LinkLabel();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.lnkSecurity = new System.Windows.Forms.LinkLabel();
            this.lnkRegister = new DevExpress.XtraEditors.LabelControl();
            this.lblNetType = new System.Windows.Forms.Label();
            this.radNetType = new DevExpress.XtraEditors.RadioGroup();
            this.chkLocalVersion = new DevExpress.XtraEditors.CheckEdit();
            this.lblSetting = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbzhanhao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radNetType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocalVersion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tbPass);
            this.groupBox1.Controls.Add(this.cmbzhanhao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkRemember);
            this.groupBox1.Location = new System.Drawing.Point(72, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录信息";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(106, 74);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(184, 22);
            this.tbPass.TabIndex = 1;
            this.tbPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPass_KeyDown);
            // 
            // cmbzhanhao
            // 
            this.cmbzhanhao.Location = new System.Drawing.Point(106, 31);
            this.cmbzhanhao.Name = "cmbzhanhao";
            this.cmbzhanhao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbzhanhao.Size = new System.Drawing.Size(184, 20);
            this.cmbzhanhao.TabIndex = 0;
            this.cmbzhanhao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbzhanhao_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(42, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录账号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(42, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "登录密码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkRemember
            // 
            this.chkRemember.EditValue = null;
            this.chkRemember.Location = new System.Drawing.Point(292, 78);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkRemember.Properties.Appearance.Options.UseForeColor = true;
            this.chkRemember.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chkRemember.Properties.Caption = "记住";
            this.chkRemember.Size = new System.Drawing.Size(50, 19);
            this.chkRemember.TabIndex = 9;
            this.chkRemember.CheckedChanged += new System.EventHandler(this.chkLocalVersion_CheckedChanged);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(349, 268);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 25);
            this.btExit.TabIndex = 1;
            this.btExit.Text = "退出";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(248, 268);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 25);
            this.btLogin.TabIndex = 0;
            this.btLogin.Text = "登录";
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("华文行楷", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(32, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(370, 25);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "仓库管理系统登录界面";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkHelp
            // 
            this.linkHelp.BackColor = System.Drawing.Color.Transparent;
            this.linkHelp.Location = new System.Drawing.Point(440, 34);
            this.linkHelp.Name = "linkHelp";
            this.linkHelp.Size = new System.Drawing.Size(56, 25);
            this.linkHelp.TabIndex = 2;
            this.linkHelp.TabStop = true;
            this.linkHelp.Text = "寻求帮助";
            this.linkHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelp_LinkClicked);
            // 
            // lblCalendar
            // 
            this.lblCalendar.BackColor = System.Drawing.Color.Transparent;
            this.lblCalendar.Location = new System.Drawing.Point(88, 322);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(300, 25);
            this.lblCalendar.TabIndex = 6;
            this.lblCalendar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lnkSecurity
            // 
            this.lnkSecurity.AutoSize = true;
            this.lnkSecurity.BackColor = System.Drawing.Color.Transparent;
            this.lnkSecurity.Location = new System.Drawing.Point(395, 324);
            this.lnkSecurity.Name = "lnkSecurity";
            this.lnkSecurity.Size = new System.Drawing.Size(102, 14);
            this.lnkSecurity.TabIndex = 7;
            this.lnkSecurity.TabStop = true;
            this.lnkSecurity.Text = "权限管理系统(F2)";
            this.lnkSecurity.Visible = false;
            this.lnkSecurity.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSecurity_LinkClicked);
            // 
            // lnkRegister
            // 
            this.lnkRegister.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkRegister.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lnkRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkRegister.Location = new System.Drawing.Point(195, 61);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(84, 19);
            this.lnkRegister.TabIndex = 8;
            this.lnkRegister.Text = "软件注册";
            this.lnkRegister.Visible = false;
            this.lnkRegister.Click += new System.EventHandler(this.lnkRegister_Click);
            // 
            // lblNetType
            // 
            this.lblNetType.BackColor = System.Drawing.Color.Transparent;
            this.lblNetType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblNetType.Location = new System.Drawing.Point(69, 221);
            this.lblNetType.Name = "lblNetType";
            this.lblNetType.Size = new System.Drawing.Size(64, 24);
            this.lblNetType.TabIndex = 0;
            this.lblNetType.Text = "网络方式";
            this.lblNetType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radNetType
            // 
            this.radNetType.EditValue = "内网";
            this.radNetType.Location = new System.Drawing.Point(139, 223);
            this.radNetType.Name = "radNetType";
            this.radNetType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radNetType.Properties.Appearance.Options.UseBackColor = true;
            this.radNetType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("内网", "内网"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("外网", "外网")});
            this.radNetType.Size = new System.Drawing.Size(186, 23);
            this.radNetType.TabIndex = 0;
            this.radNetType.SelectedIndexChanged += new System.EventHandler(this.radNetType_SelectedIndexChanged);
            this.radNetType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbzhanhao_KeyDown);
            // 
            // chkLocalVersion
            // 
            this.chkLocalVersion.EditValue = null;
            this.chkLocalVersion.Location = new System.Drawing.Point(331, 227);
            this.chkLocalVersion.Name = "chkLocalVersion";
            this.chkLocalVersion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLocalVersion.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkLocalVersion.Properties.Appearance.Options.UseFont = true;
            this.chkLocalVersion.Properties.Appearance.Options.UseForeColor = true;
            this.chkLocalVersion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chkLocalVersion.Properties.Caption = "单机版模式";
            this.chkLocalVersion.Size = new System.Drawing.Size(93, 19);
            this.chkLocalVersion.TabIndex = 9;
            this.chkLocalVersion.ToolTip = "使用此模式，将使用本地数据库资源。";
            this.chkLocalVersion.CheckedChanged += new System.EventHandler(this.chkLocalVersion_CheckedChanged);
            // 
            // lblSetting
            // 
            this.lblSetting.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblSetting.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblSetting.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblSetting.Appearance.Image")));
            this.lblSetting.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetting.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.lblSetting.Location = new System.Drawing.Point(12, 321);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(69, 20);
            this.lblSetting.TabIndex = 10;
            this.lblSetting.Text = "参数设置";
            this.lblSetting.Click += new System.EventHandler(this.lblSetting_Click);
            // 
            // Logon
            // 
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.lblSetting);
            this.Controls.Add(this.lnkRegister);
            this.Controls.Add(this.lnkSecurity);
            this.Controls.Add(this.lblNetType);
            this.Controls.Add(this.lblCalendar);
            this.Controls.Add(this.linkHelp);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radNetType);
            this.Controls.Add(this.chkLocalVersion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Logon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库管理系统登录界面";
            this.Load += new System.EventHandler(this.Logon_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Logon_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbzhanhao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemember.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radNetType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocalVersion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private void btExit_Click(object sender, EventArgs e)
		{
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Application.ExitThread();
		}

        /// <summary>
        /// 从本地XML文件中加载参数信息
        /// </summary>
        private void LoadParameter()
        {
            store = new PortableStorage();//保存在本地计算机
            settings = new SettingsProvider(store);
            parameter = settings.GetSettings<LoginParameter>();
            if (parameter != null)
            {
                this.cmbzhanhao.Text = parameter.LoginId;
                this.chkRemember.Checked = parameter.RememberPassword;
                if (parameter.RememberPassword)
                {
                    this.tbPass.Text = parameter.Password;
                }
                else
                {
                    this.tbPass.Text = "";
                }
                this.chkLocalVersion.Checked = parameter.IsLocalDatabase;

                //确保为正确的访问方式，网络版还是单机版
                SetAccessType(this.chkLocalVersion.Checked);
            }
        }

        /// <summary>
        /// 把用户的信息保存到本地XML文件里面
        /// </summary>
        private void SaveParameter()
        {
            store = new PortableStorage();//保存在本地计算机
            settings = new SettingsProvider(store);
            parameter = settings.GetSettings<LoginParameter>();
            if (parameter != null)
            {
                parameter.LoginId = this.cmbzhanhao.Text;
                if (parameter.RememberPassword)
                {
                    parameter.Password = this.tbPass.Text;
                }
                else
                {
                    parameter.Password = "";
                }
                parameter.IsLocalDatabase = this.chkLocalVersion.Checked;

                settings.SaveSettings<LoginParameter>(parameter);
            }
        }

		private void btLogin_Click(object sender, EventArgs e)
		{
            #region 检查验证
            if (Portal.gc.EnableRegister && !Portal.gc.Registed)
            {
                MessageUtil.ShowError("软件未进行授权注册，不能用于商业用途。\r\n如需注册，请单击左边【软件注册】按钮进行注册。");
            }

            if (this.cmbzhanhao.Text.Length == 0)
            {
                MessageDxUtil.ShowTips("请输入帐号");
                this.cmbzhanhao.Focus();
                return;
            }
            #endregion

            try
            {
                //保存用户登录参数
                SaveParameter();

                string ip = NetworkUtil.GetLocalIP();
                string macAddr = HardwareInfoHelper.GetMacAddress();
                string loginName = this.cmbzhanhao.Text.Trim();
                string identity = CallerFactory<IUserService>.Instance.VerifyUser2(loginName, this.tbPass.Text, Portal.gc.SystemType, ip, macAddr);
                if (!string.IsNullOrEmpty(identity))
                {
                    UserInfo info = CallerFactory<IUserService>.Instance.GetUserByName(loginName);
                    if (info != null)
                    {
                        #region 获取用户的功能列表

                        List<FunctionInfo> list = CallerFactory<IFunctionService>.Instance.GetFunctionsByUser(info.ID, Portal.gc.SystemType);
                        if (list != null && list.Count > 0)
                        {
                            foreach (FunctionInfo functionInfo in list)
                            {
                                if (!Portal.gc.FunctionDict.ContainsKey(functionInfo.ControlID))
                                {
                                    Portal.gc.FunctionDict.Add(functionInfo.ControlID, functionInfo.ControlID);
                                }
                            }
                        }

                        #endregion

                        #region 权限判断

                        //判断是否为超级管理员
                        Portal.gc.IsAdmin = CallerFactory<IUserService>.Instance.UserIsAdmin(info.Name);

                        //判断如果用户管理的公司数据多于一个，那么就显示选择单位列表，并绑定公司数据
                        Portal.gc.CompanyList = CallerFactory<IRoleDataService>.Instance.GetBelongCompanysByUser(info.ID);
                        List<int> deptList = CallerFactory<IRoleDataService>.Instance.GetBelongDeptsByUser(info.ID);
                        Portal.gc.DeptList = deptList;

                        //设置选定的公司ID(默认为用户所在公司的ID）
                        Cache.Instance["SelectedCompanyID"] = info.Company_ID;
                        //设置过滤条件给界面基类使用
                        string filterCondition = string.Format(" Company_ID = '{0}' ", info.Company_ID);
                        if (!Portal.gc.IsAdmin)
                        {
                            if (deptList.Count > 0)
                            {
                                filterCondition += string.Format(" AND Dept_ID IN ({0})", string.Join(",", deptList));
                            }
                            else
                            {
                                filterCondition += string.Format(" AND Creator = '{0}' ", info.ID);
                            }
                        }
                        Cache.Instance["DataFilterCondition"] = filterCondition;

                        #endregion

                        bLogin = true;
                        Portal.gc.UserInfo = info;
                        Portal.gc.LoginUserInfo = Portal.gc.ConvertToLoginUser(info);
                        Cache.Instance.Add("LoginUserInfo", Portal.gc.LoginUserInfo);//缓存用户信息，方便后续处理
                        Cache.Instance.Add("FunctionDict", Portal.gc.FunctionDict);//缓存权限信息，方便后续使用

                        this.DialogResult = DialogResult.OK;
                        RegistryHelper.SaveValue(Login_Name_Key, this.cmbzhanhao.Text);
                    }
                }
                else
                {
                    MessageDxUtil.ShowTips("用户帐号密码不正确");
                    this.tbPass.Text = ""; //设置密码为空
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
		}

		/// <summary>
		/// 对字符串加密
		/// </summary>
		/// <returns></returns>
		private string EncodePassword(string passwordText)
		{
            return EncodeHelper.MD5Encrypt(passwordText);
		}

		private void Logon_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btLogin_Click(sender, null);
			}
			if (e.KeyCode == Keys.F1) //按下F1键将跳出帮助
			{
				linkHelp_LinkClicked(sender, null);
			}
		}

		private void cmbzhanhao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) //如果用户回车，跳转到密码的输入框，接受输入
			{
				this.tbPass.Focus();
			}
			if (e.KeyCode == Keys.F1) //按下F1键将跳出帮助
			{
				linkHelp_LinkClicked(sender, null);
			}
		}

		private void tbPass_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) //密码回车，则检查用户是否符合数据库的用户
			{
                btLogin_Click(sender, null);
			}
			if (e.KeyCode == Keys.F1) //按下F1键将跳出帮助
			{
				linkHelp_LinkClicked(sender, null);
			}
		}

		/// <summary>
		/// 开始的时候提示登录账号和密码
		/// </summary>
		private void Logon_Load(object sender, EventArgs e)
		{
			ToolTip tp = new ToolTip();
			tp.SetToolTip(this.cmbzhanhao, "首次登录的默认账号为:admin");
			tp.SetToolTip(this.tbPass, "首次登录的默认密码为空, \r\n 以后请更改默认密码！");
			
			CCalendar cal = new CCalendar();
			this.lblCalendar.Text = cal.GetDateInfo(System.DateTime.Now).Fullinfo;
            AppConfig config = new AppConfig();
            this.Text = config.AppName;
            this.lblTitle.Text = config.AppName;

            //ValidateRegisterStatus();//提示是否已经注册

            if (this.cmbzhanhao.Text != "")
            {
                this.tbPass.Focus();
            }
            else
            {
                this.cmbzhanhao.Focus();
            }

            ValidateRegisterStatus();

            #region 更新提示/判断是否自动更新
            updateWorker = new BackgroundWorker();
            updateWorker.DoWork += new DoWorkEventHandler(updateWorker_DoWork);
            updateWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(updateWorker_RunWorkerCompleted);

            string strUpdate = config.AppConfigGet("AutoUpdate");
            if (!string.IsNullOrEmpty(strUpdate))
            {
                bool autoUpdate = false;
                bool.TryParse(strUpdate, out autoUpdate);
                if (autoUpdate)
                {
                    updateWorker.RunWorkerAsync();
                }
            }
            #endregion
        }

        /// <summary>
        /// 注册信息相关操作
        /// </summary>
        private void ValidateRegisterStatus()
        {
            //if (Portal.gc.EnableRegister)
            //{
            //    //先处理用户的注册信息
            //    Portal.gc.CheckRegister();
            //    //检查用户是否修改时间，是否超过试用期
            //    bool checkTime = Portal.gc.CheckTimeString();
            //    if (!Portal.gc.Registed && !checkTime)
            //    {
            //        RegDlg myRegdlg = RegDlg.Instance();
            //        if (myRegdlg.ShowDialog() != DialogResult.OK)
            //        {
            //            Portal.gc.Quit();
            //        }
            //    }

            //    if (!Portal.gc.Registed)
            //    {
            //        this.lnkRegister.Visible = true;
            //        this.btLogin.ForeColor = Color.Red;
            //        ToolTip tip = new ToolTip();
            //        tip.SetToolTip(this.btLogin, "软件未进行授权注册。\r\n请单击【软件注册】按钮进行注册。");

            //        Text += " [未注册]";

            //        TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - Portal.gc.FirstRunTime.Ticks);
            //        int canUseDays = UIConstants.SoftwareProbationDay - Math.Abs(ts.Days);
            //        Portal.gc.DaysLeft = canUseDays;

            //        string daysLeft = string.Format(" [还剩下{0}天]", canUseDays); //提示剩余多少天
            //        Text += daysLeft;
            //    }
            //    else
            //    {
            //        this.lnkRegister.Visible = false;
            //        //Text += " [已注册]";
            //    }
            //}
            //else
            //{
            //    this.lnkRegister.Visible = false;
            //}
        }

        #region 更新提示线程处理
        private void updateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageDxUtil.ShowTips("版本更新完成");
        }

        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdateClass update = new UpdateClass();
                bool newVersion = update.HasNewVersion;
                if (newVersion)
                {
                    if (MessageDxUtil.ShowYesNoAndTips("有新的版本，是否需要更新") == DialogResult.Yes)
                    {
                        Process.Start(Path.Combine(Application.StartupPath, "Updater.exe"), "121");
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                AlertInfo info = new AlertInfo("主动更新提示", ex.Message);                
                alerter.ShowToolTips = true;

                alerter.Show(this, info);
                //MessageDxUtil.ShowError(ex.Message);
            }
        }

        #endregion

		private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("Help.chm");
			}
			catch (Exception)
			{
				MessageDxUtil.ShowWarning("不能打开帮助！");
			}
		}

        private void lnkSecurity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hades.Security.UI.Portal.StartLogin();
        }

        private void lnkRegister_Click(object sender, EventArgs e)
        {
            //RegDlg myRegdlg = RegDlg.Instance();
            //myRegdlg.ShowDialog();
        }

        /// <summary>
        /// 网络方式（内网、外网）切换处理事件
        /// </summary>
        private void radNetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeConfig();
        }

        /// <summary>
        /// 修改配置文件
        /// </summary>
        private void ChangeConfig()
        {
            if (parameter != null)
            {
                bool isIntranet = radNetType.EditValue.ToString() == "内网";
                if (isIntranet)
                {
                    UpdateConfig(parameter.InternalWcfHost, parameter.InternalWcfPort);
                }
                else
                {
                    UpdateConfig(parameter.ExternalWcfHost, parameter.ExternalWcfPort);
                }
            }
            else
            {
                MessageDxUtil.ShowError("获取参数信息失败");
            }
        }

        /// <summary>
        /// WCF模式下，修改配置文件中的主机地址信息和端口
        /// </summary>
        /// <param name="serverIPAddress">主机地址信息</param>
        /// <param name="serverPort">端口</param>
        private void UpdateConfig(string serverIPAddress, int serverPort)
        {
            string basePath = System.Environment.CurrentDirectory;

            //修改WCF配置文件
            UpdateConfigFile(serverIPAddress, serverPort, Path.Combine(basePath, "BaseWcfConfig.config"));
            UpdateConfigFile(serverIPAddress, serverPort, Path.Combine(basePath, "WcfConfig.config"));

            //修改自动升级配置文件
            UpdateConfigFile(serverIPAddress, serverPort, Path.Combine(basePath, "updateconfiguration.config"));
        }

        /// <summary>
        /// 通过正则标识方式替换其中的主机信息和端口参数
        /// </summary>
        /// <param name="serverIPAddress">主机地址信息</param>
        /// <param name="serverPort">端口</param>
        /// <param name="exeFilePath">配置文件地址</param>
        private void UpdateConfigFile(string serverIPAddress, int serverPort, string exeFilePath)
        {
            if (File.Exists(exeFilePath))
            {
                string address = File.ReadAllText(exeFilePath, System.Text.Encoding.UTF8);

                string pattern = "://.*?/";
                string replacement = string.Format("://{0}:{1}/", serverIPAddress, serverPort);
                address = Regex.Replace(address, pattern, replacement);

                File.WriteAllText(exeFilePath, address, System.Text.Encoding.UTF8);
            }
        }

        /// <summary>
        /// 单机版模式的复选框事件处理
        /// </summary>
        private void chkLocalVersion_CheckedChanged(object sender, EventArgs e)
        {
            SetAccessType(this.chkLocalVersion.Checked);
        }

        /// <summary>
        /// 设置为网络方式还是单机版模式
        /// </summary>
        /// <param name="localType">是否为单机版模式</param>
        private void SetAccessType(bool localType)
        {
            this.lblNetType.Enabled = !localType;
            this.radNetType.Enabled = !localType;

            AppConfig config = new AppConfig();
            config.AppConfigSet("CallerType", localType ? "win" : "wcf");
            ConfigurationManager.RefreshSection("appSettings");

            //需要调整对应的IP地址
            ChangeConfig();
        }

        private void lblSetting_Click(object sender, EventArgs e)
        {
            FrmLoginSettings dlg = new FrmLoginSettings();
            dlg.ShowDialog();

            //重新加载
            LoadParameter();
        }
	}
}
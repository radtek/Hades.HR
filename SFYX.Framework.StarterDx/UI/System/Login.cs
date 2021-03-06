﻿using System;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

using Hades.Framework.Commons;
using Hades.Security.Entity;
using Updater.Core;
using Hades.Framework.BaseUI;
using Hades.Security.Facade;
using Hades.Framework.ControlUtil.Facade;
using System.Configuration;
using System.Text.RegularExpressions;
using SettingsProvider = SettingsProviderNet.SettingsProvider;
using SettingsProviderNet;
using DevExpress.XtraBars.Alerter;


namespace SFYX.Framework.Starter
{
    /// <summary>
    /// 登录处理
    /// </summary>
    public partial class Login : BaseDock //DevExpress.XtraEditors.XtraForm
    {
        public bool bLogin = false;    //判断用户是否登录
        private const string Login_Name_Key = "SFYX_ERP_LoginName";
        private BackgroundWorker updateWorker;
        private RegisterHotKeyHelper hotKey1 = new RegisterHotKeyHelper();
        private RegisterHotKeyHelper hotKey2 = new RegisterHotKeyHelper();

        private SettingsProvider settings;
        private ISettingsStorage store;
        private LoginParameter parameter;
        private AlertControl alerter = new AlertControl();

        public Login()
        {
            InitializeComponent();
            try
            {
                LoadParameter();
                SetHotKey();
            }
            catch (Exception ex)
            {
                ex.ShowException();
            }
            this.txtUserName.Focus();
        }

        /// <summary>
        /// 设置F1帮助 ALT+P 用于登录参数设置 的全局热键
        /// </summary>
        private void SetHotKey()
        {
            hotKey1.Keys = Keys.F1;
            hotKey1.ModKey = 0;
            hotKey1.WindowHandle = this.Handle;
            hotKey1.WParam = 10001;
            hotKey1.HotKey += new RegisterHotKeyHelper.HotKeyPass(hotKey1_HotKey);
            hotKey1.StarHotKey();

            hotKey2.Keys = Keys.P;
            hotKey2.ModKey = RegisterHotKeyHelper.MODKEY.MOD_ALT;
            hotKey2.WindowHandle = this.Handle;
            hotKey2.WParam = 10002;
            hotKey2.HotKey += new RegisterHotKeyHelper.HotKeyPass(hotKey2_HotKey);
            hotKey2.StarHotKey();
        }

        /// <summary>
        /// F1帮助
        /// </summary>
        void hotKey1_HotKey()
        {
            Portal.gc.Help();
        }

        /// <summary>
        /// ALT+P 登录参数设置
        /// </summary>
        void hotKey2_HotKey()
        {
            FrmLoginSettings dlg = new FrmLoginSettings();
            dlg.ShowDialog();

            //重新加载
            LoadParameter();
        }

        #region 登录参数处理
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
                this.txtUserName.Text = parameter.LoginId;
                if (parameter.RememberPassword)
                {
                    this.txtPassword.Text = parameter.Password;
                }
                else
                {
                    this.txtPassword.Text = "";
                }
               
                //确保为正确的访问方式，网络版还是单机版
                SetAccessType(parameter.IsLocalDatabase,parameter.WcfMode);
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
                parameter.LoginId = this.txtUserName.Text;
                if (parameter.RememberPassword)
                {
                    parameter.Password = this.txtPassword.Text;
                }
                else
                {
                    parameter.Password = "";
                }
                
                settings.SaveSettings<LoginParameter>(parameter);
            }
        }

        /// <summary>
        /// 设置为网络方式还是单机版模式
        /// </summary>
        /// <param name="localType">是否为单机版模式</param>
        private void SetAccessType(bool localType,string wcfmode)
        {
            AppConfig config = new AppConfig();
            config.AppConfigSet("CallerType", localType ? "win" : "wcf");
            ConfigurationManager.RefreshSection("appSettings");
        }
      
        #endregion

        /// <summary>
        /// 处理登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region 检查验证
            if (this.txtUserName.Text.Length == 0)
            {
                MessageDxUtil.ShowTips("请输入帐号");
                this.txtUserName.Focus();
                return;
            }
            #endregion

            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.btnLogin.Enabled = false;
                this.btnExit.Enabled = false;
                //保存用户登录参数
                SaveParameter();

                string ip = NetworkUtil.GetLocalIP();
                string macAddr = HardwareInfoHelper.GetMacAddress();
                string loginName = this.txtUserName.Text.Trim();
                string identity = CallerFactory<IUserService>.Instance.VerifyUser2(loginName, this.txtPassword.Text, Portal.gc.SystemType, ip, macAddr); 
                if (!string.IsNullOrEmpty(identity))
                {
                    UserInfo info = CallerFactory<IUserService>.Instance.GetUserByName(loginName);  
                    if (info != null)
                    {
                        #region 获取用户的功能列表
                        Portal.gc.FunctionDict.Clear();

                        List<FunctionInfo> list =CallerFactory<IFunctionService>.Instance.GetFunctionsByUser(info.ID, Portal.gc.SystemType); 
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
                        Portal.gc.IsAdmin =CallerFactory<IUserService>.Instance.UserIsAdmin(info.Name); 

                        //判断如果用户管理的公司数据多于一个，那么就显示选择单位列表，并绑定公司数据
                        Portal.gc.CompanyList =  CallerFactory<IRoleDataService>.Instance.GetBelongCompanysByUser(info.ID); 
                        List<string> deptList =  CallerFactory<IRoleDataService>.Instance.GetBelongDeptsByUser(info.ID); 
                        Portal.gc.DeptList = deptList;

                        //设置选定的公司ID(默认为用户所在公司的ID）
                        Cache.Instance["SelectedCompanyID"] = info.Company_ID;
                        //设置过滤条件给界面基类使用
                        string filterCondition = string.Format(" Company_ID = '{0}' ", info.Company_ID);
                        if (!Portal.gc.IsAdmin)
                        {
                            if (deptList.Count > 0)
                            {                                
                                filterCondition += string.Format(" AND Dept_ID IN ({0})", deptList.CreateSQLInCondition());
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
                        Portal.gc.LoginUserInfo = Portal.gc.ConvertToLoginUser(info);//方便后续处理
                        Portal.gc.LoginUserInfo.Data1 = txtPassword.Text;//当前用户登录密码,方便其他子系统自动登录
                        Cache.Instance.Add("FunctionDict", Portal.gc.FunctionDict);//缓存权限信息，方便后续使用

                        this.DialogResult = DialogResult.OK;
                        RegistryHelper.SaveValue(Login_Name_Key, this.txtUserName.Text);
                    }
                }
                else
                {
                    MessageDxUtil.ShowTips("用户帐号密码不正确");
                    this.txtPassword.Text = ""; //设置密码为空
                }
            }
            catch (Exception ex)
            {
                ex.ShowException();
            }
            finally
            {
                this.btnExit.Enabled = true;
                this.btnLogin.Enabled = true;
                this.Cursor = Cursors.Default ;
            }
        }


        private void labelControl1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Application.ExitThread();
        }

        private void Login_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
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
                btnLogin_Click(null, null);
            }
        }

        private void txtRole_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.Close();
            Application.ExitThread();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this.txtUserName, "首次登录的默认账号为:admin");
            tp.SetToolTip(this.txtPassword, "首次登录的默认密码为空, \r\n 以后请更改默认密码！");
            
            if (this.txtUserName.Text != "")
            {
                this.txtPassword.Focus();
            }
            else
            {
                this.txtUserName.Focus();
            }
           

            #region 更新提示/判断是否自动更新
            updateWorker = new BackgroundWorker();
            updateWorker.DoWork += new DoWorkEventHandler(updateWorker_DoWork);
            updateWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(updateWorker_RunWorkerCompleted);
            AppConfig config = new AppConfig();
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

        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateClass update = new UpdateClass();
            try
            {
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
            }
        }

        private void updateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // throw new NotImplementedException();
        }
    }
}
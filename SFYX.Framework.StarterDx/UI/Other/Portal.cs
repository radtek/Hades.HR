using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.BaseUI;
using DevExpress.LookAndFeel;
using Hades.Security.Entity;
using Hades.Security.Facade;
using Hades.Framework.ControlUtil.Facade;

namespace SFYX.Framework.Starter
{
    public class Portal
    {
        public static GlobalControl gc = new GlobalControl();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            //配置使用Web API模式，需要构建登陆token才能访问
            AppConfig config = new AppConfig();
            //获取异步访问超时设置
            int to = 3;
            if (int.TryParse(config.AppConfigGet("AsynTimeOut"), out to))
            {
                gc.AsynTimeOut = to * 1000;
            }
            string callerType = config.AppConfigGet("CallerType");
            //if (callerType.Equals("api", StringComparison.OrdinalIgnoreCase))
            //{
            //    //存储在TB_AppChannel表中
            //    string appid = "website_9A39C2A8";
            //    string appsecret = "1B4245E3-B1F1-4F76-9D43-2856FB9DBE31";
            //    //使用API方式，需要在缓存里面设置特殊的信息
            //    var url = "http://localhost:9001/api/Auth/GetAccessToken" + SignatureHelper.GetSignatureUrl(appid, appsecret) + "&username=admin&password=";
            //    TokenResult result = JsonHelper<TokenResult>.ConvertJson(url);
            //    if (result == null)
            //    {
            //        MessageDxUtil.ShowError("获取授权信息出错，请检查地址是否正确！");
            //        return;
            //    }
            //    var SignatureInfo = new SignatureInfo()
            //    {
            //        appid = appid,
            //        appsecret = appsecret,
            //        token = result.access_token
            //    };
            //    Cache.Instance.Add("SignatureInfo", SignatureInfo);
            //}

            SetUIConstants();
            GlobalMutex();

            //界面汉化
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hans");
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            if (args.Length >= 1)
            {
                LoginByArgs(args);
            }
            else
            {
                LoginNormal(args);
            }            
        }

        private static void LoginNormal(string[] args)
        {
            //登录界面
            Login dlg = new Login();
            dlg.StartPosition = FormStartPosition.CenterScreen;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (dlg.bLogin)
                {
                    SplashScreen.Splasher.Show(typeof(SplashScreen.frmSplash));
                    gc.MainDialog = new MainForm();
                    gc.MainDialog.StartPosition = FormStartPosition.CenterScreen;
                    Application.Run(gc.MainDialog);
                }

            }
            dlg.Dispose();
        }

        /// <summary>
        /// 使用参数化登录
        /// </summary>
        /// <param name="args"></param>
        private static void LoginByArgs(string[] args)
        {
            CommandArgs commandArgs = CommandLine.Parse(args);
            // 获取用户参数
            string loginName = commandArgs.ArgPairs["U"];
            string password = commandArgs.ArgPairs.ContainsKey("P") ? commandArgs.ArgPairs["P"] : "";
            password = string.IsNullOrEmpty(password) ? "" : password; //edit by xuyi 2016.2.16

            if (!string.IsNullOrEmpty(loginName))
            {
                //string identity = CallerFactory<IUserService>.Instance.VerifyUser(loginName, password, Guid.NewGuid().ToString());
                string identity = CallerFactory<IUserService>.Instance.VerifyUser(loginName, password, Portal.gc.SystemType);
                if (!string.IsNullOrEmpty(identity))
                {
                    UserInfo info = CallerFactory<IUserService>.Instance.GetUserByName(loginName);
                    Portal.gc.FunctionDict.Clear();
                    #region 获取用户的功能列表

                    List<FunctionInfo> list = CallerFactory<IFunctionService>.Instance.GetFunctionsByUser(info.ID,"");
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

                    Portal.gc.UserInfo = info;
                    Portal.gc.LoginUserInfo = Portal.gc.ConvertToLoginUser(info);
                    Portal.gc.LoginUserInfo.Data1 = password;//当前用户登录密码
                    Cache.Instance.Add("LoginUserInfo", Portal.gc.LoginUserInfo);//缓存用户信息，方便后续处理
                    Cache.Instance.Add("FunctionDict", Portal.gc.FunctionDict);//缓存权限信息，方便后续使用

                    SplashScreen.Splasher.Show(typeof(SplashScreen.frmSplash));

                    gc.MainDialog = new MainForm();
                    gc.MainDialog.StartPosition = FormStartPosition.CenterScreen;
                    Application.Run(gc.MainDialog);
                }
                else
                {
                    MessageDxUtil.ShowTips("用户帐号密码不正确");
                    LoginNormal(args);
                }
            }
            else
            {
                MessageDxUtil.ShowTips("命令格式有误");
                LoginNormal(args);
            }
        }

        private static Mutex mutex = null;
        private static void GlobalMutex()
        {
            // 是否第一次创建mutex
            bool newMutexCreated = false;
            string mutexName = "Global\\" +gc.SystemType;
            try
            {
                mutex = new Mutex(false, mutexName, out newMutexCreated);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);
            }

            // 第一次创建mutex
            if (newMutexCreated)
            {
                Console.WriteLine("HadesERP已启动");
                //todo:此处为要执行的任务
            }
            else
            {
                MessageDxUtil.ShowTips("HadesERP已在运行，不能重复启动!");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);//退出程序
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            LogHelper.Error(ex.Exception);

            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            if (DialogResult.Yes == MessageDxUtil.ShowYesNoAndError(message))
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 针对系统控件进行代码设置授权码
        /// </summary>
        private static void SetUIConstants()
        {
            //权限管理授权码
            Hades.Security.MyConstants.License = "c069bGFkZXMuU2VjdXJpdHl85Zua5pb55Y*L5L*hfObXoOmUoeWam*bWueWPi*S-oeiCoeS7_ebciemZkOWFrOWPuHxUcnVl";
            //数据字典授权码
            Hades.Dictionary.MyConstants.License = "c3a8bGFkZXMuRGljdGl_amFyeXzlm5_mlrnlj4_k_6F85peg6ZSh5Zua5pb55Y*L5L*h6IKh5Lu95pyJ6ZmQ5YWs5Y*4fFRydWUv";
            //分页控件授权码
            Hades.Pager.WinControl.MyConstants.License = "f760bGFkZXMuUGFnZXJ85Zua5pb55Y*L5L*hfObXoOmUoeWam*bWueWPi*S-oeiCoeS7_ebciemZkOWFrOWPuHxUcnVl";
            //附件管理
            Hades.Attachment.MyConstants.License = "fdeebGFkZXMuQXR0YWNoaWVudHzlm5_mlrnlj4_k_6F85peg6ZSh5Zua5pb55Y*L5L*h6IKh5Lu95pyJ6ZmQ5YWs5Y*4fFRydWUv";
        }
    }
}

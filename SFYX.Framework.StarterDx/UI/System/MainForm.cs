using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using DevExpress.XtraBars.Ribbon;
using DevExpress.LookAndFeel;
using Hades.Framework.Commons;
using DevExpress.XtraTabbedMdi;
using Hades.Framework.BaseUI;
using System.Threading.Tasks;

namespace SFYX.Framework.Starter
{
    public partial class MainForm : RibbonForm
    {
        #region 属性变量
        private AppConfig config = new AppConfig();
        //月结线程
        private BackgroundWorker worker;
        private BackgroundWorker annualWorker;
        //全局热键
        private RegisterHotKeyHelper hotKey2 = new RegisterHotKeyHelper();
        //用来第一次创建动态菜单
        private RibbonPageHelper ribbonHelper = null;

        /// <summary>
        /// 设置窗体的标题信息
        /// </summary>
        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// 获取或设置命令状态信息
        /// </summary>
        public string CommandStatus
        {
            get { return lblCommandStatus.Caption; }
            set { lblCommandStatus.Caption = value; }
        }

        /// <summary>
        /// 获取或设置用户信息
        /// </summary>
        public string UserStatus
        {
            get { return lblCurrentUser.Caption; }
            set { lblCurrentUser.Caption = value; }
        } 

        #endregion 

        public MainForm()
        {
            InitializeComponent();

            InitSystemInfo();

            SplashScreen.Splasher.Status = "正在加载相关的内容...";

            Application.DoEvents();

            Initialize().Wait();

            Application.DoEvents();

            SplashScreen.Splasher.Close();

            SetHotKey();
        }
        
        /// <summary>
        /// 系统初始化处理
        /// </summary>
        /// <returns></returns>
        private async Task Initialize()
        {           
            SplashScreen.Splasher.Status = "加载系统菜单...";

            System.Threading.Thread.Sleep(100);
            await InitUserMenuItems(); //构建菜单
           
            //TODO :系统初始化处理
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(rgbiSkins, true);
            this.ribbonControl.Toolbar.ItemLinks.Clear();
            this.ribbonControl.Toolbar.ItemLinks.Add(rgbiSkins);
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            SplashScreen.Splasher.Status = "初始化完毕...";
            System.Threading.Thread.Sleep(100);
        }       
          
        /// <summary>
        /// 初始化用户相关的系统信息
        /// </summary>
        private async Task InitUserMenuItems()
        {
            UserStatus = string.Format("当前用户：{0}({1})", Portal.gc.UserInfo.FullName, Portal.gc.UserInfo.Name);

            //动态创建界面菜单对象(防止重复构建）
            if (ribbonHelper == null)
            {
                ribbonHelper = new RibbonPageHelper(this, ref this.ribbonControl);
            }
            await ribbonHelper.InitRibbonMenus();

            if (this.ribbonControl.Pages.Count > 0)
            {
                ribbonControl.SelectedPage = ribbonControl.Pages[0];
            }       
        }

        /// <summary>
        /// 初始化系统信息名称
        /// </summary>
        private void InitSystemInfo()
        {
          
            try
            {
                string CertificatedCompany = config.AppConfigGet("CertificatedCompany");
                string ApplicationName = config.AppConfigGet("ApplicationName");
                string AppWholeName = string.Format("{0}-{1}", CertificatedCompany, ApplicationName);
                Portal.gc.AppUnit = CertificatedCompany;
                Portal.gc.AppName = AppWholeName;
                Portal.gc.AppWholeName = AppWholeName;

                this.Text = AppWholeName;
                this.notifyIcon1.BalloonTipText = AppWholeName;
                this.notifyIcon1.BalloonTipTitle = AppWholeName;
                this.notifyIcon1.Text = AppWholeName;

                CommandStatus = string.Format("欢迎使用 {0}", Portal.gc.AppWholeName);
            }
            catch { }
        }

        /// <summary>
        /// 设置Alt+S的显示/隐藏窗体全局热键
        /// </summary>
        private void SetHotKey()
        {
            try
            {
                hotKey2.Keys = Keys.S;
                hotKey2.ModKey = RegisterHotKeyHelper.MODKEY.MOD_ALT;
                hotKey2.WindowHandle = this.Handle;
                hotKey2.WParam = 10003;
                hotKey2.HotKey += new RegisterHotKeyHelper.HotKeyPass(hotKey2_HotKey);
                hotKey2.StarHotKey();
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
                LogTextHelper.WriteLine(ex.ToString());
            }
        }

        void hotKey2_HotKey()
        {
            notifyMenu_Show_Click(null, null);
        }

        #region 托盘菜单操作

        private void notifyMenu_About_Click(object sender, EventArgs e)
        {
            Portal.gc.About();
        }

        private void notifyMenu_Show_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                this.BringToFront();
                this.Activate();
                this.Focus();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        private void notifyMenu_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = false;
                Portal.gc.Quit();
            }
            catch
            {
                // Nothing to do.
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyMenu_Show_Click(sender, e);
        }

        private void MainForm_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 缩小到托盘中，不退出
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //如果我们操作【×】按钮，那么不关闭程序而是缩小化到托盘，并提示用户.
            if (this.WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;//不关闭程序

                //最小化到托盘的时候显示图标提示信息，提示用户并未关闭程序
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.ShowBalloonTip(3000, "程序最小化提示",
                     "图标已经缩小到托盘，打开窗口请双击图标即可。也可以使用Alt+S键来显示/隐藏窗体。",
                     ToolTipIcon.Info);
            }
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (this == null)
            {
                return;
            }

            //最小化到托盘的时候显示图标提示信息
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(3000, "程序最小化提示",
                    "图标已经缩小到托盘，打开窗口请双击图标即可。也可以使用Alt+S键来显示/隐藏窗体。",
                    ToolTipIcon.Info);
            }
        }

        #endregion

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Exit(object sender, EventArgs args)
        {
            DialogResult dr = MessageDxUtil.ShowYesNoAndTips("点击“Yes”退出系统，点击“No”返回");

            if (dr == DialogResult.Yes)
            {
                notifyIcon1.Visible = false;
                Application.ExitThread();
            }
            else if (dr == DialogResult.No)
            {
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            //显示日期信息
            CCalendar cal = new CCalendar();
            this.lblCalendar.Caption = cal.GetDateInfo(System.DateTime.Now).Fullinfo;

            //TODO: 其他初始化工作
        }

        #region Tab顶部右键菜单

        private void xtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DevExpress.XtraTab.ViewInfo.BaseTabHitInfo hi = xtraTabbedMdiManager1.CalcHitInfo(new Point(e.X, e.Y));
            if (hi.HitTest == DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader)
            {
                popupMenu1.ShowPopup(Cursor.Position);
            }
        }

        private void popMenuCloseCurrent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMdiTabPage page = xtraTabbedMdiManager1.SelectedPage;
            if (page != null && page.MdiChild != null)
            {
                page.MdiChild.Close();
            }
        }

        private void popMenuCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllDocuments();
        }

        private void popMenuCloseOther_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMdiTabPage selectedPage = xtraTabbedMdiManager1.SelectedPage;
            Type currentType = selectedPage.MdiChild.GetType();

            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 0; i--)
            {
                XtraMdiTabPage page = xtraTabbedMdiManager1.Pages[i];
                if (page != null && page.MdiChild != null)
                {
                    Form form = page.MdiChild;
                    if (form.GetType() != currentType)
                    {
                        form.Close();
                        if (form != null && !form.IsDisposed)
                        {
                            form.Dispose();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 关闭所有的MDI子窗口
        /// </summary>
        public void CloseAllDocuments()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
                if (form != null && !form.IsDisposed)
                {
                    form.Dispose();
                }
            }
        }
        #endregion

        #region 工具条操作
        /// <summary>
        /// 重新登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRelogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndWarning("您确定需要重新登录吗？") != DialogResult.Yes)
                return;

            Portal.gc.MainDialog.Hide();
            
            Login dlg = new Login();

            dlg.StartPosition = FormStartPosition.CenterScreen;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (dlg.bLogin)
                {
                    CloseAllDocuments();
                    //动态创建界面菜单对象(防止重复构建）
                    if (ribbonHelper == null)
                    {
                        ribbonHelper = new RibbonPageHelper(this, ref this.ribbonControl);
                    }
                    ribbonHelper.ReInitPage();
                    await InitUserMenuItems();
                }

            }
            dlg.Dispose();
            Portal.gc.MainDialog.Show();
        }

        private void barItemExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Exit(null, null);
        }

        /// <summary>
        /// Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Portal.gc.Help();
        }

        /// <summary>
        /// About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Portal.gc.About();
        }


        /// <summary>
        /// 反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBug_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFeeBack dlg = new FrmFeeBack();

            dlg.InitFunction(Portal.gc.LoginUserInfo,Portal.gc.FunctionDict);//初始化权限控制信息

            dlg.ShowDialog();
        }

        /// <summary>
        /// About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuLogo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Portal.gc.About();
        }


        /// <summary>
        /// 参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tool_Settings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSettings dlg = new FrmSettings();

            dlg.ShowDialog();
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tool_ModifyPass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmModifyPassword dlg = new FrmModifyPassword();

            dlg.InitFunction(Portal.gc.LoginUserInfo, Portal.gc.FunctionDict);//初始化权限控制信息

            dlg.ShowDialog();
        }

        #endregion

        private void btn_DepartmentMan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(Hades.HR.UI.FrmDepartment));
        }

        private void btn_PositionMan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(Hades.HR.UI.FrmPosition));
        }

        private void btn_StaffMan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(Hades.HR.UI.FrmStaff));
        }

        private void btn_StaffOv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(Hades.HR.UI.FrmStaffOverview));
        }

        private void btn_StaffSalary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(Hades.HR.UI.FrmStaffSalary));
        }
    }
}

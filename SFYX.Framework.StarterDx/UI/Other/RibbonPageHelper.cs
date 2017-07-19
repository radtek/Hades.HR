using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.Security.Entity;
using Hades.Security.Facade;
using Hades.Workflow.Entity;
using Hades.Workflow.Facade;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFYX.Framework.Starter
{
    /// <summary>
    /// 动态创建RibbonPage和其下面的按钮项目辅助类
    /// </summary>
    public class RibbonPageHelper
    {
        private RibbonControl control = null;
        private MainForm mainForm = null;

        public RibbonPageHelper(MainForm mainForm, ref RibbonControl control)
        {
            this.mainForm = mainForm;
            this.control = control;
        }

        /// <summary>
        /// 重新初始化菜单系统，只保留系统管理和帮助
        /// </summary>
        public void ReInitPage()
        {
            RibbonPage sysMana = control.Pages.GetPageByText("系统管理");
            RibbonPage help = control.Pages.GetPageByText("帮助");
            control.BeginInit();
            control.Pages.Clear();
            control.Pages.Insert(0, sysMana);
            control.Pages.Insert(1, help);
            control.EndInit();
        }

        #region 初始化Ribbon菜单系统
        /// <summary>
        /// 增加TabPage
        /// </summary>
        /// <remarks> 处理所有的SystemType</remarks>
        public void InitRibbonMenus()
        {
            //约定菜单共有3级，第一级为大的类别，第二级为小模块分组，第三级为具体的菜单
            List<MenuNodeInfo> menuList = new List<MenuNodeInfo>();
            #region 菜单系统信息获取
            try
            {
                menuList = CallerFactory<IMenuService>.Instance.GetTree(Portal.gc.SystemType); 
            }
            catch (Exception ex)
            {
                ex.ShowException();
            }
            if (menuList==null || menuList.Count == 0) return;
            #endregion

            control.BeginInit();
            #region 处理RibbonControl的菜单系统
            int i = 0;
            //添加1级Ribbon
            foreach (MenuNodeInfo firstInfo in menuList)
            {
                //如果没有菜单的权限，则跳过
                if (!Portal.gc.HasFunction(firstInfo.FunctionId)) continue;

                if (firstInfo.Children.Count == 0) continue;

                //添加页面（一级菜单）,edit by xuyi,2016.2.16
                RibbonPage page = null;
                #region 防止系统管理和帮助重复,将一级菜单Page加进RibbonControl
                if (!(firstInfo.Name.Trim().Equals("系统管理") || firstInfo.Name.Trim().Equals("帮助")))
                {
                    page = new DevExpress.XtraBars.Ribbon.RibbonPage();
                    page.Text = firstInfo.Name;
                    page.Name = firstInfo.ID;
                    this.control.Pages.Insert(i++, page);
                }
                else
                {
                    page = control.Pages.GetPageByText(firstInfo.Name.Trim());
                }
                #endregion

                //添加对应的Group
                foreach (MenuNodeInfo secondInfo in firstInfo.Children)
                {
                    //如果没有菜单的权限，则跳过
                    if (!Portal.gc.HasFunction(secondInfo.FunctionId)) continue;

                    if (secondInfo.Children.Count == 0) continue;

                    //添加RibbonPageGroup（二级菜单）edit by xuyi 2016.2.16                    
                    RibbonPageGroup group = page.Groups.GetGroupByText(secondInfo.Name);

                    #region 将Group加进Ribbon
                    if (group == null)
                    {
                        group = new RibbonPageGroup();
                        group.Text = secondInfo.Name;
                        group.Name = secondInfo.ID;
                        if (firstInfo.Name.Trim().Equals("系统管理") || firstInfo.Name.Trim().Equals("帮助"))
                        {
                            page.Groups.Insert(0, group);
                        }
                        else
                        {
                            page.Groups.Add(group);
                        }
                    }
                    else
                    {
                        group.ItemLinks.Clear();
                    }
                    group.Tag = new StringBuilder().
                        Append(secondInfo.WinformType)
                        .Append("|")
                        .Append(secondInfo.SystemType_ID)
                        .Append("|")
                        .Append(secondInfo.Data1).ToString();
                    group.CaptionButtonClick += Group_CaptionButtonClick;
                    #endregion

                    //添加具体的Button
                    foreach (MenuNodeInfo thirdInfo in secondInfo.Children)
                    {
                        //如果没有菜单的权限，则跳过
                        if (!Portal.gc.HasFunction(thirdInfo.FunctionId)) continue;

                        //如果是启动节点的话
                        if (!hasWorkFlow(thirdInfo)) continue;

                        //添加功能按钮（三级菜单）                       
                        group.ItemLinks.Add(initBarButtonItem(thirdInfo));

                    } //endof 三级

                    //如果是空组则删除
                    if (group.ItemLinks.Count == 0)
                    {
                        page.Groups.Remove(group);
                    }
                } //endof 二级
                //如果空page删除
                if (page.Groups.Count == 0)
                {
                    this.control.Pages.Remove(page);
                    i--;
                }
            }
            #endregion
            control.EndInit();
        }

        #region 判断登录人员是否有权限启动流程节点
        private List<WorkTaskViewInfo> myStartWorkflows = null;
        private bool hasWorkFlow(MenuNodeInfo menuInfo)
        {
            //不是和流程启动有关的菜单
            if (!menuInfo.WinformType.Contains("Hades.Workflow.UI.FrmStartWorkFlow")) return true;
            bool result = true;
            try
            {
                if (myStartWorkflows == null)
                {
                    //当前登录用户可以使用的流程启动信息
                    myStartWorkflows =  CallerFactory<IWorkFlowService>.Instance.GetAllowStartWorkFlows(Portal.gc.LoginUserInfo.ID);
                }
                string[] paras = menuInfo.Data1.Split(new char[] { '※' });
                if (paras.Length >= 2)
                {
                    result = myStartWorkflows.FindLast((w) => w.WorkFlowID == paras[0] && w.WorkTaskID == paras[1]) != null;
                }
                else
                {
                    result = false;
                }
            }
            catch(Exception ex)
            {
                ex.ShowException(false);
                result = false;
            }          
            return result;
        }
        #endregion
        /// <summary>
        /// 处理Group的弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Group_CaptionButtonClick(object sender, RibbonPageGroupEventArgs e)
        {
            string[] paras = e.PageGroup.Tag.ToString().Split(new char[] { '|' });

            //未定义弹出窗口
            if (string.IsNullOrEmpty(paras[0])) return;
            string[] typeInfo = paras[0].Split(new char[] { ',' });
            StringBuilder sb = new StringBuilder();
            //paras[0]--winform类型，paras[1]--dll名称;paras[2]--额外参数类别
            sb.Append(typeInfo[0]).Append(",").Append(typeInfo[1]).Append(",1")
                .Append("|").Append(paras[1]);
            //以对话框进行弹出
            LoadPlugInForm(sb.ToString(), paras[2]);

        }

        /// <summary>
        /// 初始化功能按钮
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private BarButtonItem initBarButtonItem(MenuNodeInfo node)
        {
            BarButtonItem button = new BarButtonItem();
            button.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            button.Glyph = LoadIcon(node.Icon);
            button.LargeGlyph = LoadIcon(node.Icon);

            button.Name = node.ID;
            button.Caption = node.Name;
            button.Tag = node.WinformType + "|" + node.SystemType_ID; //绑定winformType和系统类型

            button.ItemClick += (sender, e) =>
            {
                if (button.Tag != null && !string.IsNullOrEmpty(button.Tag.ToString()))
                {
                    LoadPlugInForm(button.Tag.ToString(), node.Data1);
                }
                else
                {
                    MessageDxUtil.ShowTips(button.Caption);
                }
            };
            return button;
        }

        #region 加载按钮图标
        /// <summary>
        /// 加载图标，如果加载不成功，那么使用默认图标
        /// </summary>
        /// <param name="iconPath"></param>
        /// <returns></returns>
        private Image LoadIcon(string iconPath)
        {
            Image result = SFYX.Framework.Starter.Properties.Resources.menuIcon.ToBitmap();//系统默认图标
            try
            {
                if (!string.IsNullOrEmpty(iconPath))
                {
                    string path = Path.Combine(Application.StartupPath, iconPath);
                    if (File.Exists(path))
                    {
                        result = Image.FromFile(path);
                    }
                }
            }
            catch
            {
                LogTextHelper.Error(string.Format("无法识别图标地址：{0}，请确保该文件存在！", iconPath));
            }
            return result;
        }
        #endregion

        #endregion

        #region 加载功能处理窗口
        /// <summary>
        /// 加载插件窗体
        /// </summary>
        private void LoadPlugInForm(string typeName, string extParam = "")
        {
            try
            {
                string[] para = typeName.Split(new char[] { '|' });
                string[] itemArray = para[0].Split(new char[] { ',', ';' });

                string type = itemArray[0].Trim(); //类型名
                string filePath = itemArray[1].Trim();//必须是相对路径

                //判断是否配置了显示模式，默认窗体为Show非模式显示
                string showDialog = (itemArray.Length > 2) ? itemArray[2].ToLower() : "";
                bool isShowDialog = (showDialog == "1") || (showDialog == "dialog");

                string dllFullPath = Path.Combine(Application.StartupPath, filePath);

                //edit by 2016.2.19
                //修正因Assembly是当前正在执行的Assembly或因不能正常加载引起的问题
                Assembly tempAssembly = null;
                if (System.Reflection.Assembly.GetExecutingAssembly().CodeBase.ToLower().Equals(dllFullPath.ToLower().Trim()))
                {
                    tempAssembly = System.Reflection.Assembly.GetExecutingAssembly(); //获取当前正在运行的Assembly
                }
                else
                {
                    try { tempAssembly = System.Reflection.Assembly.LoadFrom(dllFullPath); } catch { }
                }

                if (tempAssembly != null)
                {
                    Type objType = tempAssembly.GetType(type);
                    if (objType != null)
                    {
                        LoadMdiForm(this.mainForm, objType, para[1], isShowDialog, extParam);
                    }
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(string.Format("加载模块【{0}】失败，请检查书写是否正确。", typeName), ex);
            }
        }

        /// <summary>
        /// 唯一加载某个类型的窗体，如果存在则显示，否则创建。
        /// </summary>
        /// <param name="mainDialog">主窗体对象</param>
        /// <param name="systemType">系统类型ID (如HasesERP)</param>
        /// <param name="formType">待显示的窗体类型(xxxFrm,xxx.dll,1)</param>
        /// <param name="extParam">额外参数</param>
        /// <returns></returns>
        public static Form LoadMdiForm(Form mainDialog, Type formType, string systemType, bool isShowDialog, string extParam = "")
        {
            Form tableForm = null;

            bool bFound = false;

            if (!isShowDialog) //如果是模态窗口，跳过
            {
                foreach (Form form in mainDialog.MdiChildren)
                {
                    if (form.GetType() == formType)
                    {
                        bFound = true;
                        tableForm = form;
                        break;
                    }
                }
            }
            bool isSecurity = false;
            //没有在多文档中找到或者是模态窗口，需要初始化属性
            if (!bFound || isShowDialog)
            {
                tableForm = (Form)Activator.CreateInstance(formType);

                //如果窗体集成了IFunction接口(第一次创建需要设置)
                IFunction function = tableForm as IFunction;
                if (function != null)
                {
                    //初始化权限控制信息
                    function.InitFunction(Portal.gc.LoginUserInfo, Portal.gc.FunctionDict);

                    //记录程序的相关信息
                    function.AppInfo = new AppInfo(Portal.gc.AppUnit, Portal.gc.AppName, Portal.gc.AppWholeName,
                        systemType);

                    //传递额外参数
                    if (!string.IsNullOrEmpty(extParam))
                    {
                        function.SetExtendParams(extParam.Split(new char[] { '※' }));
                    }
                }
                else
                {
                    //主要用于权限控制的特殊处理，edit by xuyi 2016.2.16
                    if (tableForm as Hades.Security.UI.MainForm != null)
                    {
                        isSecurity = true;
                        Hades.Security.UI.Portal.StartSecurity(Portal.gc.LoginUserInfo.Name,
                            Portal.gc.LoginUserInfo.Data1,
                            Portal.gc.SystemType);
                    }
                }


            }
            if (!isSecurity)
            {
                if (isShowDialog)
                {
                    tableForm.ShowDialog();
                }
                else
                {
                    tableForm.MdiParent = mainDialog;
                    tableForm.Show();
                }


                tableForm.BringToFront();
                tableForm.Activate();
            }
            else
            {
                tableForm = null;
            }

            return tableForm;
        }
        #endregion
    }
}

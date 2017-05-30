using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

using Hades.Framework.Commons;
using Hades.Security.Entity;
using Hades.Framework.BaseUI;
using Hades.Framework.ControlUtil.Facade;
using Hades.Security.Facade;

namespace SFYX.Framework.Starter
{
    public class GlobalControl
    {
        #region 系统全局变量

        public MainForm MainDialog=null;

        public string AppUnit = string.Empty; //单位名称
        public string AppName = string.Empty; //程序名称
        public string AppWholeName = string.Empty; //单位名称+程序名称
        public string SystemType= "HadesERP";
        public int AsynTimeOut = 3000;  //异步超时事件3秒
        public LoginUserInfo LoginUserInfo = null; //登陆用户基础信息        
        public Dictionary<string, string> FunctionDict = new Dictionary<string, string>(); //登录用户具有的功能字典集合
        public UserInfo UserInfo = null; //登录用户信息

        /// <summary>
        /// 是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 当前用户包含管理数据的公司列表
        /// </summary>
        public List<string> CompanyList { get; set; }

        /// <summary>
        /// 当前用户包含管理数据的部门列表
        /// </summary>
        public List<string> DeptList { get; set; }

       /// <summary>
        /// 程序第一次运行时间
        /// </summary>
        public DateTime FirstRunTime { get; set; }

        /// <summary>
        /// 用户登陆时间列表
        /// </summary>
        public List<DateTime> TimeList { get; set; }


        #endregion

        #region 基本操作函数

        /// <summary>
        /// 转换框架通用的用户基础信息，方便框架使用
        /// </summary>
        /// <param name="info">权限系统定义的用户信息</param>
        /// <returns></returns>
        public LoginUserInfo ConvertToLoginUser(UserInfo info)
        {
            LoginUserInfo loginInfo = new LoginUserInfo();
            loginInfo.ID = info.ID.ToString();
            loginInfo.Name = info.Name;
            loginInfo.FullName = info.FullName;
            loginInfo.IdentityCard = info.IdentityCard;
            loginInfo.MobilePhone = info.MobilePhone;
            loginInfo.QQ = info.QQ;
            loginInfo.Email = info.Email;
            loginInfo.Gender = info.Gender;

            loginInfo.DeptId = info.Dept_ID;
            loginInfo.CompanyId = info.Company_ID;
            return loginInfo;
        }

        /// <summary>
        /// 看用户是否具有某个功能
        /// </summary>
        /// <param name="controlID"></param>
        /// <returns></returns>
        public bool HasFunction(string controlID)
        {
            bool result = false;

            if (string.IsNullOrEmpty(controlID))
            {
                result = true;
            }
            else if (FunctionDict != null && FunctionDict.ContainsKey(controlID))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        public void Quit()
        {
            if (Portal.gc.MainDialog != null)
            {
                Portal.gc.MainDialog.Hide();
                Portal.gc.MainDialog.CloseAllDocuments();
            }

            Application.Exit();
        }

        /// <summary>
        /// 打开帮助文档
        /// </summary>
        public void Help()
        {
            try
            {
                const string helpfile = "Help.chm";
                Process.Start(helpfile);
            }
            catch (Exception)
            {
                MessageDxUtil.ShowWarning("帮助文件打开失败");
            }
        }

        /// <summary>
        /// 关于对话框信息
        /// </summary>
        public void About()
        {
            AboutBox dlg = new AboutBox();
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.ShowDialog();
        }

        #endregion
    }

}

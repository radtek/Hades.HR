
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SettingsProviderNet;

namespace SFYX.Framework.Starter
{
    /// <summary>
    /// 用户登录的连接方式、访问方式
    /// </summary>
    public class LoginParameter
    {
        /// <summary>
        /// 系统最后登录账号
        /// </summary>
        [DefaultValue("admin")]
        public string LoginId { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        [ProtectedString]
        public string Password { get; set; }

        /// <summary>
        /// 记住密码
        /// </summary>
        [DefaultValue(false)]
        public bool RememberPassword { get; set; }

        /// <summary>
        /// 是否为本地数据库连接方式，否则为使用WCF服务模式（内网，外网）
        /// </summary>
        [DefaultValue(false)]
        public bool IsLocalDatabase { get; set; }

        /// <summary>
        /// 内网WCF的主机地址
        /// </summary>
        [DefaultValue("localhost")]
        public string InternalWcfHost { get; set; }

        /// <summary>
        /// 内网WCF的端口
        /// </summary>
        [DefaultValue(8000)]
        public int InternalWcfPort { get; set; }

        /// <summary>
        /// 外网WCF的主机地址
        /// </summary>
        [DefaultValue("183.6.161.193")]
        public string ExternalWcfHost { get; set; }

        /// <summary>
        /// 外网WCF的端口
        /// </summary>
        [DefaultValue(8000)]
        public int ExternalWcfPort { get; set; }

        /// <summary>
        /// WCF模式（内网|外网）
        /// </summary>
        [DefaultValue("内网")]
        public string WcfMode { get; set; }
    }
}

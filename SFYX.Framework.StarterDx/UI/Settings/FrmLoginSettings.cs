using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hades.Framework.BaseUI;

namespace SFYX.Framework.Starter
{
    public partial class FrmLoginSettings : BaseForm
    {
        public FrmLoginSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            this.firefoxDialog1.ImageList = this.imageList1;
            this.firefoxDialog1.AddPage("登录访问参数", new PageLogin());//基于本地XML文件的访问

            this.firefoxDialog1.Init();
        }
    }
}

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

using Hades.Pager.Entity;
using Hades.Dictionary;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmEditLaborSalary : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private LaborSalaryInfo tempInfo = new LaborSalaryInfo();

        private int year;

        private int month;

        private string workTeamId;

        /// <summary>
        /// 缓存职员数据
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditLaborSalary()
        {
            InitializeComponent();
        }

        public FrmEditLaborSalary(int year, int month, string workTeamId)
        {
            this.year = year;
            this.month = month;
            this.workTeamId = workTeamId;
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过
            
            return result;
        }

        public override void ClearScreen()
        {
            this.tempInfo = new LaborSalaryInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            this.Text = "编辑员工月考勤";

            this.txtMonth.Text = $"{this.year}年{this.month}月";

            var team = CallerFactory<IWorkTeamService>.Instance.FindByID(this.workTeamId);
            this.txtWorkTeam.Text = team.Name;

            this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");

            var data = CallerFactory<ILaborSalaryService>.Instance.GetRecords(this.year, this.month, this.workTeamId);
            this.bsSalary.DataSource = data;
        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                var data = this.bsSalary.DataSource as List<LaborSalaryInfo>;

                data.ForEach((r) =>
                {
                    r.Editor = this.LoginUserInfo.Name;
                    r.EditorId = this.LoginUserInfo.ID;
                    r.EditTime = DateTime.Now;
                });

                bool succeed = CallerFactory<ILaborSalaryService>.Instance.SaveRecords(data, this.year, this.month, this.workTeamId);
                if (succeed)
                {
                    //可添加其他关联操作

                    return true;
                }

                if (succeed)
                {
                    //可添加其他关联操作

                    return true;
                }
               
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
            return false;
        }
        #endregion //Method
    }
}

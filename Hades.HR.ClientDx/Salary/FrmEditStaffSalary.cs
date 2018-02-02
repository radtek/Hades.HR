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
    public partial class FrmEditStaffSalary : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private StaffSalaryInfo tempInfo = new StaffSalaryInfo();

        private int year;

        private int month;

        private string departmentId;

        /// <summary>
        /// 缓存职员数据
        /// </summary>
        private List<StaffInfo> staffs;

        /// <summary>
        /// 缓存级别数据
        /// </summary>
        private List<StaffLevelInfo> levels;
        #endregion //Field

        #region Constructor
        public FrmEditStaffSalary()
        {
            InitializeComponent();
        }

        public FrmEditStaffSalary(int year, int month, string departmentId)
        {
            this.year = year;
            this.month = month;
            this.departmentId = departmentId;
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            return result;
        }

        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffSalaryInfo info)
        {

        }
        #endregion //Function

        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new StaffSalaryInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            this.Text = "编辑职员工资";

            this.txtMonth.Text = $"{this.year}年{this.month}月";

            var dep = CallerFactory<IDepartmentService>.Instance.FindByID(this.departmentId);
            this.txtDepartment.Text = dep.Name;

            this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 1");
            this.levels = CallerFactory<IStaffLevelService>.Instance.Find("");

            var data = CallerFactory<IStaffSalaryService>.Instance.GetRecords(this.year, this.month, this.departmentId);
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
                var data = this.bsSalary.DataSource as List<StaffSalaryInfo>;

                data.ForEach((r) =>
                {
                    r.Editor = this.LoginUserInfo.Name;
                    r.EditorId = this.LoginUserInfo.ID;
                    r.EditTime = DateTime.Now;
                });

                bool succeed = CallerFactory<IStaffSalaryService>.Instance.SaveRecords(data, this.year, this.month, this.departmentId);
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

        #region Event
        private void dgvSalary_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "StaffId")
            {
                if (e.Value != null)
                {
                    var s = this.staffs.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Name;
                }
            }
            else if (columnName == "StaffLevelId")
            {
                if (e.Value != null)
                {
                    var s = this.levels.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Name;
                }
            }
        }
        #endregion //Event
    }
}

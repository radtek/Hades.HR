using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

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
    public partial class FrmEditStaffMonthAttendance : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private StaffMonthAttendanceInfo tempInfo = new StaffMonthAttendanceInfo();

        private int year;

        private int month;

        private string departmentId;

        /// <summary>
        /// 缓存职员数据
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditStaffMonthAttendance()
        {
            InitializeComponent();
        }

        public FrmEditStaffMonthAttendance(int year, int month, string departmentId)
        {
            InitializeComponent();

            this.year = year;
            this.month = month;
            this.departmentId = departmentId;
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

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffMonthAttendanceInfo info)
        {
            //info.StaffId = txtStaffId.Text;
            //info.DepartmentId = txtDepartmentId.Text;
            //info.AttendanceDays = Convert.ToInt32(txtAttendanceDays.Value);
            //info.AnnualLeave = Convert.ToInt32(txtAnnualLeave.Value);
            //info.SickLeave = Convert.ToInt32(txtSickLeave.Value);
            //info.CasualLeave = Convert.ToInt32(txtCasualLeave.Value);
            //info.InjuryLeave = Convert.ToInt32(txtInjuryLeave.Value);
            //info.MarriageLeave = Convert.ToInt32(txtMarriageLeave.Value);
            //info.MaternityLeave = Convert.ToInt32(txtMaternityLeave.Value);
            //info.FuneralLeave = Convert.ToInt32(txtFuneralLeave.Value);
            //info.AbsentLeave = Convert.ToInt32(txtAbsentLeave.Value);
            //info.NormalOvertime = txtNormalOvertime.Value;
            //info.WeekendOvertime = txtWeekendOvertime.Value;
            //info.HolidayOvertime = txtHolidayOvertime.Value;
            //info.NoonShift = Convert.ToInt32(txtNoonShift.Value);
            //info.NightShift = Convert.ToInt32(txtNightShift.Value);
            //info.OtherNoon = Convert.ToInt32(txtOtherNoon.Value);
            //info.OtherNight = Convert.ToInt32(txtOtherNight.Value);
            //info.Remark = txtRemark.Text;
        }
        #endregion //Function

        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new StaffMonthAttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            #region MyRegion
            //if (this.txtStaffId.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtStaffId.Focus();
            //    result = false;
            //}
            // else if (this.txtDepartmentId.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtDepartmentId.Focus();
            //    result = false;
            //}
            #endregion

            return result;
        }


        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            this.Text = "编辑职员月考勤";

            this.txtMonth.Text = $"{this.year}年{this.month}月";

            var dep = CallerFactory<IDepartmentService>.Instance.FindByID(this.departmentId);
            this.txtDepartment.Text = dep.Name;

            this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");
                        
            var data = CallerFactory<IStaffMonthAttendanceService>.Instance.GetRecords(year, month, departmentId);
            this.bsAttendance.DataSource = data;
        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                var data = this.bsAttendance.DataSource as List<StaffMonthAttendanceInfo>;

                bool succeed = false; // CallerFactory<IStaffMonthAttendanceService>.Instance.SaveRecords(data, this.year, this.month, this.workTeamId);
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

        /// <summary>
        /// 编辑状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {
            StaffMonthAttendanceInfo info = CallerFactory<IStaffMonthAttendanceService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<IStaffMonthAttendanceService>.Instance.Update(info, info.Id);
                    if (succeed)
                    {
                        //可添加其他关联操作

                        return true;
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
            return false;
        }
        #endregion //Method
    }
}

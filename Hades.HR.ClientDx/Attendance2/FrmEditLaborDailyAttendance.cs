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
    public partial class FrmEditLaborDailyAttendance : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private LaborDailyAttendanceInfo tempInfo = new LaborDailyAttendanceInfo();

        /// <summary>
        /// 考勤日期
        /// </summary>
        private DateTime attendanceDate;

        /// <summary>
        /// 当前关联班组
        /// </summary>
        private string currentWorkTeamId;
        #endregion //Field

        #region Constructor
        public FrmEditLaborDailyAttendance()
        {
            InitializeComponent();
        }

        public FrmEditLaborDailyAttendance(DateTime attendanceDate, string workTeamId)
        {
            this.attendanceDate = attendanceDate;
            this.currentWorkTeamId = workTeamId;

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

        /// <summary>
        /// 载入班组默认员工
        /// </summary>
        private void LoadDefaultStaff()
        {
            var staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("WorkTeamId='{0}' AND Delete=0", this.currentWorkTeamId);


        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborDailyAttendanceInfo info)
        {
            //info.WorkTeamId = txtWorkTeamId.Text;
            //info.AttendanceDate = txtAttendanceDate.Text;
            //info.StaffId = txtStaffId.Text;
            //info.StaffLevelId = txtStaffLevelId.Text;
            //info.AbsentType = Convert.ToInt32(txtAbsentType.Value);
            //info.TotalHours = txtTotalHours.Value;
            //info.IsWeekend = txtIsWeekend.Text.ToBoolean();
            //info.IsHoliday = txtIsHoliday.Text.ToBoolean();
            //info.Remark = txtRemark.Text;
        }
        #endregion //Function

        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new LaborDailyAttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            WorkTeamInfo workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(this.currentWorkTeamId);
            

            if (!string.IsNullOrEmpty(ID))
            {
                #region 显示信息
                LaborDailyAttendanceInfo info = CallerFactory<ILaborDailyAttendanceService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    //txtWorkTeamId.Text = info.WorkTeamId;
                    //txtAttendanceDate.Text = info.AttendanceDate;
                    //txtStaffId.Text = info.StaffId;
                    //txtStaffLevelId.Text = info.StaffLevelId;
                    //txtAbsentType.Value = info.AbsentType;
                    //txtTotalHours.Value = info.TotalHours;
                    //txtIsWeekend.Text = info.IsWeekend.ToString();
                    //txtIsHoliday.Text = info.IsHoliday.ToString();
                    //txtRemark.Text = info.Remark;
                }
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborDailyAttendance/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborDailyAttendance/Add");  
            }
        }

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            //if (this.txtAttendanceDate.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtAttendanceDate.Focus();
            //    result = false;
            //}
            //else if (this.txtStaffId.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtStaffId.Focus();
            //    result = false;
            //}

            return result;
        }
        #endregion //Method

        

         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborDailyAttendanceInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = CallerFactory<ILaborDailyAttendanceService>.Instance.Insert(info);
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
            return false;
        }                 

        /// <summary>
        /// 编辑状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {

            LaborDailyAttendanceInfo info = CallerFactory<ILaborDailyAttendanceService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<ILaborDailyAttendanceService>.Instance.Update(info, info.Id);
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
    }
}

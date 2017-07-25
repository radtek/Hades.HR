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
    /// <summary>
    /// 新增编辑月考勤
    /// </summary>
    public partial class FrmEditAttendance : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private AttendanceInfo tempInfo = new AttendanceInfo();
        #endregion //Field

        #region Constructor
        public FrmEditAttendance()
        {
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
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(AttendanceInfo info)
        {
            info.Year = Convert.ToInt32(txtYear.Value);
            info.Month = Convert.ToInt32(txtMonth.Value);
            info.Days = Convert.ToInt32(txtDays.Value);
            info.Remark = txtRemark.Text;
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

            if (this.txtYear.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtYear.Focus();
                result = false;
            }
            else if (this.txtMonth.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtMonth.Focus();
                result = false;
            }
            else if (this.txtDays.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtDays.Focus();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                AttendanceInfo info = CallerFactory<IAttendanceService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtYear.Value = info.Year;
                    txtMonth.Value = info.Month;
                    txtDays.Value = info.Days;
                    txtRemark.Text = info.Remark;
                }

                this.Text = "编辑月度考勤";
                //this.btnOK.Enabled = HasFunction("Attendance/Edit");             
            }
            else
            {
                this.Text = "新增月度考勤";
                //this.btnOK.Enabled = Portal.gc.HasFunction("Attendance/Add");  
            }
        }

        public override void ClearScreen()
        {
            this.tempInfo = new AttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            AttendanceInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                bool succeed = CallerFactory<IAttendanceService>.Instance.Insert(info);
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

            AttendanceInfo info = CallerFactory<IAttendanceService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    bool succeed = CallerFactory<IAttendanceService>.Instance.Update(info, info.Id);
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
            }
            return false;
        }
        #endregion //Method
    }
}

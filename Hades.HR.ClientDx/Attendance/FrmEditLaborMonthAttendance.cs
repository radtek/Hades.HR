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

using Hades.HR.BLL;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmEditLaborMonthAttendance : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private LaborMonthAttendanceInfo tempInfo = new LaborMonthAttendanceInfo();

        private int year;

        private int month;

        private string workTeamId;
        #endregion //Field

        #region Constructor
        public FrmEditLaborMonthAttendance()
        {
            InitializeComponent();
        }

        public FrmEditLaborMonthAttendance(int year, int month, string workTeamId)
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

            #region MyRegion
            //if (this.txtYear.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtYear.Focus();
            //    result = false;
            //}
            // else if (this.txtMonth.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtMonth.Focus();
            //    result = false;
            //}
            #endregion

            return result;
        }

        public override void ClearScreen()
        {
            //this.tempInfo = new LaborMonthAttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）
    

        }
        #endregion //Method









        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborMonthAttendanceInfo info)
        {

        }
         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborMonthAttendanceInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = BLLFactory<LaborMonthAttendance>.Instance.Insert(info);
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

            LaborMonthAttendanceInfo info = BLLFactory<LaborMonthAttendance>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = BLLFactory<LaborMonthAttendance>.Instance.Update(info, info.Id);
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

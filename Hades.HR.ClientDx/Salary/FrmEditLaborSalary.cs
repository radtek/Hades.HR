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
    public partial class FrmEditLaborSalary : BaseEditForm
    {
    	/// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private LaborSalaryInfo tempInfo = new LaborSalaryInfo();
    	
        public FrmEditLaborSalary()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            #region MyRegion
            if (this.txtStaffId.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtStaffId.Focus();
                result = false;
            }
            #endregion

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
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                #region 显示信息
                LaborSalaryInfo info = BLLFactory<LaborSalary>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
	                    txtStaffId.Text = info.StaffId;
                                   txtYear.Value = info.Year;
                               txtMonth.Value = info.Month;
       	                    txtStaffLevelId.Text = info.StaffLevelId;
                                   txtLevelSalary.Value = info.LevelSalary;
                               txtBaseSalary.Value = info.BaseSalary;
                               txtOverSalary.Value = info.OverSalary;
                               txtWeekendSalary.Value = info.WeekendSalary;
                               txtHolidaySalary.Value = info.HolidaySalary;
                               txtEstimation.Value = info.Estimation;
                               txtAllowance.Value = info.Allowance;
                               txtTotalSalary.Value = info.TotalSalary;
                               txtNoonShift.Value = info.NoonShift;
                               txtNightShift.Value = info.NightShift;
                               txtOtherNoon.Value = info.OtherNoon;
                               txtOtherNight.Value = info.OtherNight;
                               txtShiftAmount.Value = info.ShiftAmount;
       	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborSalary/Edit");             
            }
            else
            {
                  
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborSalary/Add");  
            }
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(LaborSalaryInfo info)
        //{
        //    this.attachmentGUID.AttachmentGUID = info.AttachGUID;
        //    this.attachmentGUID.userId = LoginUserInfo.Name;

        //    string name = txtName.Text;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        string dir = string.Format("{0}", name);
        //        this.attachmentGUID.Init(dir, tempInfo.ID, LoginUserInfo.Name);
        //    }
        //}

        public override void ClearScreen()
        {
            this.tempInfo = new LaborSalaryInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborSalaryInfo info)
        {
	            info.StaffId = txtStaffId.Text;
                       info.Year = Convert.ToInt32(txtYear.Value);
                       info.Month = Convert.ToInt32(txtMonth.Value);
       	            info.StaffLevelId = txtStaffLevelId.Text;
                       info.LevelSalary = txtLevelSalary.Value;
                       info.BaseSalary = txtBaseSalary.Value;
                       info.OverSalary = txtOverSalary.Value;
                       info.WeekendSalary = txtWeekendSalary.Value;
                       info.HolidaySalary = txtHolidaySalary.Value;
                       info.Estimation = txtEstimation.Value;
                       info.Allowance = txtAllowance.Value;
                       info.TotalSalary = txtTotalSalary.Value;
                       info.NoonShift = Convert.ToInt32(txtNoonShift.Value);
                       info.NightShift = Convert.ToInt32(txtNightShift.Value);
                       info.OtherNoon = Convert.ToInt32(txtOtherNoon.Value);
                       info.OtherNight = Convert.ToInt32(txtOtherNight.Value);
                       info.ShiftAmount = txtShiftAmount.Value;
       	            info.Remark = txtRemark.Text;
               }
         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborSalaryInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = BLLFactory<LaborSalary>.Instance.Insert(info);
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

            LaborSalaryInfo info = BLLFactory<LaborSalary>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = BLLFactory<LaborSalary>.Instance.Update(info, info.Id);
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

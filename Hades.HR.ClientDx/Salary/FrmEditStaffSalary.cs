using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

using WHC.Framework.ControlUtil.Facade;
using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmEditStaffSalary : BaseEditForm
    {
    	/// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private StaffSalaryInfo tempInfo = new StaffSalaryInfo();
    	
        public FrmEditStaffSalary()
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
             else if (this.txtDepartmentId.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtDepartmentId.Focus();
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
                StaffSalaryInfo info = CallerFactory<IStaffSalaryService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
                        txtYear.Value = info.Year;
                               txtMonth.Value = info.Month;
       	                    txtStaffId.Text = info.StaffId;
           	                    txtDepartmentId.Text = info.DepartmentId;
           	                    txtStaffLevelId.Text = info.StaffLevelId;
                                   txtLevelSalary.Value = info.LevelSalary;
                               txtBaseBonus.Value = info.BaseBonus;
                               txtDepartmentBonus.Value = info.DepartmentBonus;
                               txtReserveFund.Value = info.ReserveFund;
                               txtInsurance.Value = info.Insurance;
                               txtNormalOvertimeSalary.Value = info.NormalOvertimeSalary;
                               txtWeekendOvertimeSalary.Value = info.WeekendOvertimeSalary;
                               txtHolidayOvertimeSalary.Value = info.HolidayOvertimeSalary;
                               txtOvertimeSalarySum.Value = info.OvertimeSalarySum;
                               txtTotalSalary.Value = info.TotalSalary;
       	                    txtRemark.Text = info.Remark;
           	                    txtEditor.Text = info.Editor;
           	                    txtEditorId.Text = info.EditorId;
                               txtEditTime.SetDateTime(info.EditTime);	
                     } 
                #endregion
                //this.btnOK.Enabled = HasFunction("StaffSalary/Edit");             
            }
            else
            {
                                txtEditor.Text = LoginUserInfo.Name;//默认为当前登录用户
                  txtEditTime.DateTime = DateTime.Now; //默认当前时间
 
                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffSalary/Add");  
            }
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(StaffSalaryInfo info)
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
            this.tempInfo = new StaffSalaryInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffSalaryInfo info)
        {
                info.Year = Convert.ToInt32(txtYear.Value);
                       info.Month = Convert.ToInt32(txtMonth.Value);
       	            info.StaffId = txtStaffId.Text;
       	            info.DepartmentId = txtDepartmentId.Text;
       	            info.StaffLevelId = txtStaffLevelId.Text;
                       info.LevelSalary = txtLevelSalary.Value;
                       info.BaseBonus = txtBaseBonus.Value;
                       info.DepartmentBonus = txtDepartmentBonus.Value;
                       info.ReserveFund = txtReserveFund.Value;
                       info.Insurance = txtInsurance.Value;
                       info.NormalOvertimeSalary = txtNormalOvertimeSalary.Value;
                       info.WeekendOvertimeSalary = txtWeekendOvertimeSalary.Value;
                       info.HolidayOvertimeSalary = txtHolidayOvertimeSalary.Value;
                       info.OvertimeSalarySum = txtOvertimeSalarySum.Value;
                       info.TotalSalary = txtTotalSalary.Value;
       	            info.Remark = txtRemark.Text;
       	            info.Editor = txtEditor.Text;
       	            info.EditorId = txtEditorId.Text;
                   info.EditTime = txtEditTime.DateTime;
           }
         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            StaffSalaryInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = CallerFactory<IStaffSalaryService>.Instance.Insert(info);
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

            StaffSalaryInfo info = CallerFactory<IStaffSalaryService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<IStaffSalaryService>.Instance.Update(info, info.ID);
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

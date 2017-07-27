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
    public partial class FrmEditStaffSalaryDefine : BaseEditForm
    {
    	/// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private StaffSalaryDefineInfo tempInfo = new StaffSalaryDefineInfo();
    	
        public FrmEditStaffSalaryDefine()
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
            if (this.txtFinanceDepartment.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtFinanceDepartment.Focus();
                result = false;
            }
             else if (this.txtCardNumber.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtCardNumber.Focus();
                result = false;
            }
             else if (this.txtSalaryLevel.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtSalaryLevel.Focus();
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
                StaffSalaryDefineInfo info = CallerFactory<IStaffSalaryDefineService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
	                    txtFinanceDepartment.Text = info.FinanceDepartment;
           	                    txtCardNumber.Text = info.CardNumber;
           	                    txtSalaryLevel.Text = info.SalaryLevel;
                                   txtBaseBonus.Value = info.BaseBonus;
                               txtDepartmentBonus.Value = info.DepartmentBonus;
                               txtReserveFund.Value = info.ReserveFund;
                               txtInsurance.Value = info.Insurance;
       	                    txtRemark.Text = info.Remark;
           	                    txtEditor.Text = info.Editor;
           	                    txtEditorId.Text = info.EditorId;
                               txtEditTime.SetDateTime(info.EditTime);	
                     } 
                #endregion
                //this.btnOK.Enabled = HasFunction("StaffSalaryDefine/Edit");             
            }
            else
            {
                        txtEditor.Text = LoginUserInfo.Name;//默认为当前登录用户
                  txtEditTime.DateTime = DateTime.Now; //默认当前时间
 
                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffSalaryDefine/Add");  
            }
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(StaffSalaryDefineInfo info)
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
            this.tempInfo = new StaffSalaryDefineInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffSalaryDefineInfo info)
        {
	            info.FinanceDepartment = txtFinanceDepartment.Text;
       	            info.CardNumber = txtCardNumber.Text;
       	            info.SalaryLevel = txtSalaryLevel.Text;
                       info.BaseBonus = txtBaseBonus.Value;
                       info.DepartmentBonus = txtDepartmentBonus.Value;
                       info.ReserveFund = txtReserveFund.Value;
                       info.Insurance = txtInsurance.Value;
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
            StaffSalaryDefineInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = CallerFactory<IStaffSalaryDefineService>.Instance.Insert(info);
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

            StaffSalaryDefineInfo info = CallerFactory<IStaffSalaryDefineService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<IStaffSalaryDefineService>.Instance.Update(info, info.Id);
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

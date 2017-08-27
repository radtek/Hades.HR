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
    public partial class FrmEditWorkSectionLabor : BaseEditForm
    {
    	/// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private WorkSectionLaborInfo tempInfo = new WorkSectionLaborInfo();
    	
        public FrmEditWorkSectionLabor()
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
                WorkSectionLaborInfo info = CallerFactory<IWorkSectionLaborService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
                        txtYear.Value = info.Year;
                               txtMonth.Value = info.Month;
       	                    txtWorkSectionId.Text = info.WorkSectionId;
           	                    txtStaffId.Text = info.StaffId;
           	                    txtStaffLevel.Text = info.StaffLevel;
           	                    txtRemark.Text = info.Remark;
           	                    txtEditor.Text = info.Editor;
           	                    txtEditorId.Text = info.EditorId;
                               txtEditTime.SetDateTime(info.EditTime);	
                     } 
                #endregion
                //this.btnOK.Enabled = HasFunction("WorkSectionLabor/Edit");             
            }
            else
            {
                      txtEditor.Text = LoginUserInfo.Name;//默认为当前登录用户
                  txtEditTime.DateTime = DateTime.Now; //默认当前时间
 
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkSectionLabor/Add");  
            }
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(WorkSectionLaborInfo info)
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
            this.tempInfo = new WorkSectionLaborInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WorkSectionLaborInfo info)
        {
                info.Year = Convert.ToInt32(txtYear.Value);
                       info.Month = Convert.ToInt32(txtMonth.Value);
       	            info.WorkSectionId = txtWorkSectionId.Text;
       	            info.StaffId = txtStaffId.Text;
       	            info.StaffLevel = txtStaffLevel.Text;
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
            WorkSectionLaborInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = CallerFactory<IWorkSectionLaborService>.Instance.Insert(info);
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

            WorkSectionLaborInfo info = CallerFactory<IWorkSectionLaborService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<IWorkSectionLaborService>.Instance.Update(info, info.Id);
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

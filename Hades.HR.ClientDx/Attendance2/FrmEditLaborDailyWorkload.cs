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
    public partial class FrmEditLaborDailyWorkload : BaseEditForm
    {
    	/// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private LaborDailyWorkloadInfo tempInfo = new LaborDailyWorkloadInfo();
    	
        public FrmEditLaborDailyWorkload()
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
            if (this.txtWorkTeamId.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtWorkTeamId.Focus();
                result = false;
            }
             else if (this.txtStaffId.Text.Trim().Length == 0)
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
                LaborDailyWorkloadInfo info = CallerFactory<ILaborDailyWorkloadService>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
	                    txtWorkTeamWorkloadId.Text = info.WorkTeamWorkloadId;
           	                    txtWorkTeamId.Text = info.WorkTeamId;
           	                    txtActualWorkTeamId.Text = info.ActualWorkTeamId;
                               txtAttendanceDate.SetDateTime(info.AttendanceDate);	
   	                    txtStaffId.Text = info.StaffId;
                                   txtProductionHours.Value = info.ProductionHours;
                               txtChangeHours.Value = info.ChangeHours;
                               txtRepairHours.Value = info.RepairHours;
                               txtElectricHours.Value = info.ElectricHours;
                               txtLeaveHours.Value = info.LeaveHours;
                               txtAllowanceHours.Value = info.AllowanceHours;
       	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborDailyWorkload/Edit");             
            }
            else
            {
            
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborDailyWorkload/Add");  
            }
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(LaborDailyWorkloadInfo info)
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
            this.tempInfo = new LaborDailyWorkloadInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborDailyWorkloadInfo info)
        {
	            info.WorkTeamWorkloadId = txtWorkTeamWorkloadId.Text;
       	            info.WorkTeamId = txtWorkTeamId.Text;
       	            info.ActualWorkTeamId = txtActualWorkTeamId.Text;
                   info.AttendanceDate = txtAttendanceDate.DateTime;
   	            info.StaffId = txtStaffId.Text;
                       info.ProductionHours = txtProductionHours.Value;
                       info.ChangeHours = txtChangeHours.Value;
                       info.RepairHours = txtRepairHours.Value;
                       info.ElectricHours = txtElectricHours.Value;
                       info.LeaveHours = txtLeaveHours.Value;
                       info.AllowanceHours = txtAllowanceHours.Value;
       	            info.Remark = txtRemark.Text;
               }
         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            LaborDailyWorkloadInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = CallerFactory<ILaborDailyWorkloadService>.Instance.Insert(info);
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

            LaborDailyWorkloadInfo info = CallerFactory<ILaborDailyWorkloadService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<ILaborDailyWorkloadService>.Instance.Update(info, info.Id);
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

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
    public partial class FrmEditStaffLevel : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private StaffLevelInfo tempInfo = new StaffLevelInfo();
        #endregion //Field

        #region Constructor
        public FrmEditStaffLevel()
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
        private void SetInfo(StaffLevelInfo info)
        {
            info.Name = txtName.Text;
            info.Salary = txtSalary.Value;
            info.SortCode = txtSortCode.Text;
            info.Remark = txtRemark.Text;
        }
        #endregion //Function

        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new StaffLevelInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入名称");
                this.txtName.Focus();
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
                StaffLevelInfo info = CallerFactory<IStaffLevelService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtName.Text = info.Name;
                    txtSalary.Value = info.Salary;
                    txtSortCode.Text = info.SortCode;
                    txtRemark.Text = info.Remark;
                }

                this.Text = "编辑职员等级";
                //this.btnOK.Enabled = HasFunction("StaffLevel/Edit");             
            }
            else
            {
                this.Text = "新增职员等级";
                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffLevel/Add");  
            }
        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            StaffLevelInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                bool succeed = CallerFactory<IStaffLevelService>.Instance.Insert(info);
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
            StaffLevelInfo info = CallerFactory<IStaffLevelService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<IStaffLevelService>.Instance.Update(info, info.Id);
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

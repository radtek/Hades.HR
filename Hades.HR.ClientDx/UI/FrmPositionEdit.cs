using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Hades.Dictionary;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmPositionEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private PositionInfo tempInfo = new PositionInfo();
        #endregion //Field

        #region Constructor
        public FrmPositionEdit()
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
        private void SetInfo(PositionInfo info)
        {
            info.DepartmentId = luDepartment.GetSelectedId();
            info.Name = txtName.Text;
            info.Number = txtNumber.Text;
            info.Quota = Convert.ToInt32(txtQuota.Value);
            info.SortCode = txtSortCode.Text;
            info.Remark = txtRemark.Text;
            info.Enabled = Convert.ToInt32(cmbEnabled.EditValue);

            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 窗体载入
        /// </summary>
        public override void FormOnLoad()
        {
            this.luDepartment.Init();
            base.FormOnLoad();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                this.Text = "编辑岗位";
                PositionInfo info = CallerFactory<IPositionService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtName.Text = info.Name;
                    txtNumber.Text = info.Number;
                    luDepartment.SetSelected(info.DepartmentId);
                    txtQuota.Value = info.Quota;
                    txtSortCode.Text = info.SortCode;
                    txtRemark.Text = info.Remark;
                    cmbEnabled.EditValue = info.Enabled;
                }

                //this.btnOK.Enabled = HasFunction("Position/Edit");             
            }
            else
            {
                this.Text = "新增岗位";
                //this.btnOK.Enabled = Portal.gc.HasFunction("Position/Add");  
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        public override void ClearScreen()
        {
            this.tempInfo = new PositionInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            if (string.IsNullOrEmpty(this.luDepartment.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("请选择所属部门");
                this.luDepartment.Focus();
                result = false;
            }
            else if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入岗位名称");
                this.txtName.Focus();
                result = false;
            }
            else if (this.txtNumber.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入岗位编码");
                this.txtNumber.Focus();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            PositionInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            info.Creator = this.LoginUserInfo.Name;
            info.CreatorId = this.LoginUserInfo.ID;
            info.CreateTime = DateTime.Now;
            info.Deleted = 0;

            try
            {
                string msg;
                bool succeed = CallerFactory<IPositionService>.Instance.CheckDuplicate(info, out msg);
                if (!succeed)
                {
                    MessageDxUtil.ShowWarning(msg);
                    return false;
                }

                succeed = CallerFactory<IPositionService>.Instance.Insert(info);
                if (succeed)
                {
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
            PositionInfo info = CallerFactory<IPositionService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    string msg;
                    bool succeed = CallerFactory<IPositionService>.Instance.CheckDuplicate(info, out msg);
                    if (!succeed)
                    {
                        MessageDxUtil.ShowWarning(msg);
                        return false;
                    }

                    succeed = CallerFactory<IPositionService>.Instance.Update(info, info.Id);
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

using System;
using System.Text;
using System.Data;
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
    /// <summary>
    /// 添加编辑部门
    /// </summary>
    public partial class FrmDepartmentEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private DepartmentInfo tempInfo = new DepartmentInfo();
        #endregion //Field

        #region Constructor
        public FrmDepartmentEdit()
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
        private void SetInfo(DepartmentInfo info)
        {
            info.PID = this.luParent.GetSelectedId();
            info.Number = txtNumber.Text;
            info.Name = txtName.Text;
            info.SortCode = txtSortCode.Text;
            info.Type = Convert.ToInt32(cmbType.EditValue);
            info.Address = txtAddress.Text;
            info.Principal = txtPrincipal.Text;
            info.Quota = Convert.ToInt32(spQuota.Value);
            info.Fax = txtFax.Text;
            info.InnerPhone = txtInnerPhone.Text;
            info.OuterPhone = txtOuterPhone.Text;
            info.Remark = txtRemark.Text;
            info.FoundDate = dpFoundDate.DateTime;
            info.CloseDate = dpCloseDate.DateTime;
            info.Enabled = Convert.ToInt32(cmbEnabled.EditValue);

            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }
        #endregion //Function

        #region Metohd
        /// <summary>
        /// 窗体载入
        /// </summary>
        public override void FormOnLoad()
        {
            this.luParent.Init();
            this.cmbType.Properties.Items.AddEnum(typeof(DepartmentType));

            base.FormOnLoad();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))  //编辑
            {
                this.Text = "编辑部门";
                DepartmentInfo info = CallerFactory<IDepartmentService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtNumber.Text = info.Number;
                    txtName.Text = info.Name;
                    luParent.SetSelected(info.PID);
                    txtSortCode.Text = info.SortCode;
                    cmbType.EditValue = (DepartmentType)info.Type;
                    txtAddress.Text = info.Address;
                    txtPrincipal.Text = info.Principal;
                    spQuota.Value = info.Quota;
                    txtFax.Text = info.Fax;
                    txtInnerPhone.Text = info.InnerPhone;
                    txtOuterPhone.Text = info.OuterPhone;
                    dpFoundDate.SetDateTime(info.FoundDate);
                    dpCloseDate.SetDateTime(info.CloseDate);
                    txtRemark.Text = info.Remark;
                    cmbEnabled.EditValue = info.Enabled;
                }

                //this.btnOK.Enabled = HasFunction("Department/Edit");             
            }
            else  //新增
            {
                this.Text = "新增部门";
                //this.btnOK.Enabled = Portal.gc.HasFunction("Department/Add");  
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        public override void ClearScreen()
        {
            this.tempInfo = new DepartmentInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            if (this.txtNumber.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入部门代码");
                this.txtNumber.Focus();
                result = false;
            }
            else if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入部门名称");
                this.txtName.Focus();
                result = false;
            }
            else if (this.cmbType.EditValue == null)
            {
                MessageDxUtil.ShowTips("请选择部门类型");
                this.cmbType.Focus();
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
            DepartmentInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            info.Creator = this.LoginUserInfo.Name;
            info.CreatorId = this.LoginUserInfo.ID;
            info.CreateTime = DateTime.Now;
            info.Deleted = 0;

            try
            {
                bool succeed = CallerFactory<IDepartmentService>.Instance.CheckDuplicate(info);
                if (!succeed)
                {
                    MessageDxUtil.ShowWarning("部门代码重复");
                    return false;
                }

                succeed = CallerFactory<IDepartmentService>.Instance.Insert(info);
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
            DepartmentInfo info = CallerFactory<IDepartmentService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    bool succeed = CallerFactory<IDepartmentService>.Instance.CheckDuplicate(info);
                    if (!succeed)
                    {
                        MessageDxUtil.ShowWarning("部门代码重复");
                        return false;
                    }

                    succeed = CallerFactory<IDepartmentService>.Instance.Update(info, info.Id);
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

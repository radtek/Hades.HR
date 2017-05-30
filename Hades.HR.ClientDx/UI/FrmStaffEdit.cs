using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Hades.Pager.Entity;
using Hades.Dictionary;
using Hades.Dictionary.Facade;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmStaffEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private StaffInfo tempInfo = new StaffInfo();
        #endregion //Field

        #region Constructor
        public FrmStaffEdit()
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
            var data = CallerFactory<IDictDataService>.Instance.GetDictListItemByCode("2001");

            ControlUtil.BindDictToCombo(this.cmbNationality, "2001");
            ControlUtil.BindDictItems(this.cmbPolitical, "2002");

            //ControlUtil.BindDictItems(this.cmbNationality, "民族");
            //ControlUtil.BindDictItems(this.cmbPolitical, "政治面貌");
            ControlUtil.BindDictItems(this.cmbEducation, "学历");
            ControlUtil.BindDictItems(this.cmbDegree, "学位");
            ControlUtil.BindDictItems(this.cmbTitles, "职称");
            ControlUtil.BindDictItems(this.cmbDuty, "职务");
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffInfo info)
        {
            info.Number = txtNumber.Text;
            info.Name = txtName.Text;
            info.DepartmentId = luDepartment.GetSelectedId();
            info.PositionId = luPosition.GetSelectedId();
            info.CompanyId = luCompany.GetSelectedId();

            info.Gender = cmbGender.Text;
            info.Birthday = txtBirthday.DateTime;
            info.NativePlace = txtNativePlace.Text;
            info.Nationality = cmbNationality.Text;
            info.IdentityCard = txtIdentityCard.Text;
            info.Phone = txtPhone.Text;
            info.OfficePhone = txtOfficePhone.Text;
            info.Email = txtEmail.Text;
            info.QQ = txtQQ.Text;
            info.HomeAddress = txtHomeAddress.Text;
            info.Political = cmbPolitical.Text;
            info.PartyDate = txtPartyDate.DateTime;
            info.Education = cmbEducation.Text;
            info.Degree = cmbDegree.Text;
            info.WorkingDate = dpWorkingDate.DateTime;
            info.Marriage = cmbMarriage.Text;
            info.ChildStatus = cmbChildStatus.Text;
            info.Titles = cmbTitles.Text;
            info.Duty = cmbDuty.Text;
            info.JobType = txtJobType.Text;
            info.Introduce = txtIntroduce.Text;
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
            this.luCompany.Init();


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
                this.Text = "编辑职员";
                StaffInfo info = CallerFactory<IStaffService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtNumber.Text = info.Number;
                    txtName.Text = info.Name;

                    luDepartment.SetSelected(info.DepartmentId);
                    luCompany.SetSelected(info.CompanyId);
                    luPosition.SetSelected(info.PositionId);

                    cmbGender.Text = info.Gender;
                    txtBirthday.SetDateTime(info.Birthday);
                    txtNativePlace.Text = info.NativePlace;
                    cmbNationality.Text = info.Nationality;
                    txtIdentityCard.Text = info.IdentityCard;
                    txtPhone.Text = info.Phone;
                    txtOfficePhone.Text = info.OfficePhone;
                    txtEmail.Text = info.Email;
                    txtQQ.Text = info.QQ;
                    txtHomeAddress.Text = info.HomeAddress;
                    cmbPolitical.Text = info.Political;
                    txtPartyDate.SetDateTime(info.PartyDate);
                    cmbEducation.Text = info.Education;
                    cmbDegree.Text = info.Degree;
                    dpWorkingDate.SetDateTime(info.WorkingDate);
                    cmbMarriage.Text = info.Marriage;
                    cmbChildStatus.Text = info.ChildStatus;
                    cmbTitles.Text = info.Titles;
                    cmbDuty.Text = info.Duty;
                    txtJobType.Text = info.JobType;
                    txtIntroduce.Text = info.Introduce;
                    txtRemark.Text = info.Remark;
                    cmbEnabled.EditValue = info.Enabled;
                }
                //this.btnOK.Enabled = HasFunction("Staff/Edit");             
            }
            else
            {
                this.Text = "新增职员";
                //this.btnOK.Enabled = Portal.gc.HasFunction("Staff/Add");  
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        public override void ClearScreen()
        {
            this.tempInfo = new StaffInfo();
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
                MessageDxUtil.ShowTips("请输入工号");
                this.txtNumber.Focus();
                result = false;
            }
            else if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入姓名");
                this.txtName.Focus();
                result = false;
            }
            else if (string.IsNullOrEmpty(this.luDepartment.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("请选择所属部门");
                this.luDepartment.Focus();
                result = false;
            }
            else if (string.IsNullOrEmpty(this.luCompany.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("请选择所属公司");
                this.luDepartment.Focus();
                result = false;
            }

            var dep = this.luDepartment.GetSelected();
            if (dep.Type == (int)DepartmentType.Group || dep.Type == (int)DepartmentType.Company)
            {
                MessageDxUtil.ShowTips("所属部门不能为集团或公司");
                this.luDepartment.Focus();
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
            StaffInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            info.Creator = this.LoginUserInfo.Name;
            info.CreatorId = this.LoginUserInfo.ID;
            info.CreateTime = DateTime.Now;

            try
            {
                string msg;
                bool succeed = CallerFactory<IStaffService>.Instance.CheckDuplicate(info, out msg);
                if (!succeed)
                {
                    MessageDxUtil.ShowWarning(msg);
                    return false;
                }

                succeed = CallerFactory<IStaffService>.Instance.Insert(info);
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
            StaffInfo info = CallerFactory<IStaffService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    string msg;
                    bool succeed = CallerFactory<IStaffService>.Instance.CheckDuplicate(info, out msg);
                    if (!succeed)
                    {
                        MessageDxUtil.ShowWarning(msg);
                        return false;
                    }

                    succeed = CallerFactory<IStaffService>.Instance.Update(info, info.Id);
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

        #region Event
        /// <summary>
        /// 部门选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luDepartment_DepartmentSelect(object sender, EventArgs e)
        {
            var depId = this.luDepartment.GetSelectedId();
            if (!string.IsNullOrEmpty(depId))
            {
                this.luPosition.Init(depId);
            }
        }
        #endregion //Event

        //private void SetAttachInfo(StaffInfo info)
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
    }
}

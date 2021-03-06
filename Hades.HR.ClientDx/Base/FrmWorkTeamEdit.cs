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

using Hades.HR.BLL;
using Hades.HR.Facade;
using Hades.HR.Entity;

namespace Hades.HR.UI
{
    public partial class FrmWorkTeamEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkTeamInfo tempInfo = new WorkTeamInfo();
        #endregion //Field

        #region Constructor
        public FrmWorkTeamEdit()
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
        private void SetInfo(WorkTeamInfo info)
        {
            info.Name = txtName.Text;
            info.Number = txtNumber.Text;
            info.CompanyId = luCompany.GetSelectedId();
            info.WorkSectionId = luWorkSection.GetSelectedId();
            info.Quota = Convert.ToInt32(spQuota.Value);
            info.Principal = txtPrincipal.Text;
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
            this.luCompany.Init();
            base.FormOnLoad();
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

            var cid = this.luCompany.GetSelectedId();
            if (string.IsNullOrEmpty(cid) || cid == "-1")
            {
                MessageDxUtil.ShowTips("请选择所属公司");
                this.luCompany.Focus();
                result = false;
            }

            return result;
        }

        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                this.Text = "编辑班组";
                WorkTeamInfo info = CallerFactory<IWorkTeamService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtName.Text = info.Name;
                    txtNumber.Text = info.Number;
                    spQuota.Value = info.Quota;

                    this.luCompany.SetSelected(info.CompanyId);
                    this.luWorkSection.SetSelected(info.WorkSectionId);

                    txtPrincipal.Text = info.Principal;
                    txtSortCode.Text = info.SortCode;
                    txtRemark.Text = info.Remark;
                    cmbEnabled.EditValue = info.Enabled;
                }

                //this.btnOK.Enabled = HasFunction("WorkTeam/Edit");             
            }
            else
            {
                this.Text = "新增班组";
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkTeam/Add");  
            }
        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WorkTeamInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            info.Creator = this.LoginUserInfo.Name;
            info.CreatorId = this.LoginUserInfo.ID;
            info.CreateTime = DateTime.Now;
            info.Deleted = 0;

            try
            {
                #region 新增数据

                bool succeed = CallerFactory<IWorkTeamService>.Instance.Insert(info);
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
            WorkTeamInfo info = CallerFactory<IWorkTeamService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);
                info.Deleted = 0;

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<IWorkTeamService>.Instance.Update(info, info.Id);
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

        #region Event
        /// <summary>
        /// 部门选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luCompany_DepartmentSelect(object sender, EventArgs e)
        {
            string cid = this.luCompany.GetSelectedId();
            if (!string.IsNullOrEmpty(cid))
                this.luWorkSection.Init(cid);
        }
        #endregion //Event
    }
}

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
    public partial class FrmWorkSectionEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkSectionInfo tempInfo = new WorkSectionInfo();
        #endregion //Field

        #region Constructor
        public FrmWorkSectionEdit()
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
        private void SetInfo(WorkSectionInfo info)
        {
            info.Name = txtName.Text;
            info.Number = txtNumber.Text;
            info.WorkTeamId = luWorkTeam.GetSelectedId();
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

        public override void ClearScreen()
        {
            this.tempInfo = new WorkSectionInfo();
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
            else if (string.IsNullOrEmpty(this.luProductionLine.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("请选择所属生产线");
                this.luProductionLine.Focus();
                result = false;
            }
            else if (string.IsNullOrEmpty(this.luWorkTeam.GetSelectedId()))
            {
                MessageDxUtil.ShowTips("请选择所属班组");
                this.luWorkTeam.Focus();
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
                WorkSectionInfo info = CallerFactory<IWorkSectionService>.Instance.FindByID(ID);
                if (info != null)
                {
                    var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(info.WorkTeamId);

                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtName.Text = info.Name;
                    txtNumber.Text = info.Number;

                    this.luCompany.SetSelected(workTeam.CompanyId);
                    this.luProductionLine.SetSelected(workTeam.ProductionLineId);
                    this.luWorkTeam.SetSelected(info.WorkTeamId);

                    txtSortCode.Text = info.SortCode;
                    txtRemark.Text = info.Remark;
                    cmbEnabled.EditValue = info.Enabled;
                }

                this.Text = "编辑工段";
                //this.btnOK.Enabled = HasFunction("WorkSection/Edit");             
            }
            else
            {
                this.Text = "新增工段";
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkSection/Add");  
            }
        }
         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WorkSectionInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);
            info.Deleted = 0;

            try
            {
                #region 新增数据

                bool succeed = CallerFactory<IWorkSectionService>.Instance.Insert(info);
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
            WorkSectionInfo info = CallerFactory<IWorkSectionService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {                    
                    bool succeed = CallerFactory<IWorkSectionService>.Instance.Update(info, info.Id);
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
        private void luCompany_DepartmentSelect(object sender, EventArgs e)
        {
            var depId = this.luCompany.GetSelectedId();
            if (!string.IsNullOrEmpty(depId))
            {
                this.luProductionLine.Init(depId);
            }
        }       

        private void luProductionLine_ProductionLineSelect(object sender, EventArgs e)
        {
            var lineId = this.luProductionLine.GetSelectedId();
            if (!string.IsNullOrEmpty(lineId))
            {
                this.luWorkTeam.Init(lineId);
            }
        }
        #endregion //Event
    }
}

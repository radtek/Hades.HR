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
    /// <summary>
    /// 编辑员工工资信息
    /// </summary>
    public partial class FrmStaffSalaryEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private StaffSalaryInfo tempInfo = new StaffSalaryInfo();
        #endregion //Field

        #region Constructor
        public FrmStaffSalaryEdit()
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
        private void SetInfo(StaffSalaryInfo info)
        {
            info.Id = this.ID;
            info.FinanceDepartment = this.luDepartment.GetSelectedId();
            info.CardNumber = txtCardNumber.Text;
            info.BaseSalary = txtBaseSalary.Value;
            info.BaseBonus = txtBaseBonus.Value;
            info.DepartmentBonus = txtDepartmentBonus.Value;
            info.ReserveFund = txtReserveFund.Value;
            info.Insurance = txtInsurance.Value;
            info.Remark = txtRemark.Text;

            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            StaffSalaryInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                bool result = false;
                var entity = CallerFactory<IStaffSalaryService>.Instance.FindByID(info.Id);
                if (entity == null)
                {
                    result = CallerFactory<IStaffSalaryService>.Instance.Insert(info);
                }
                else
                {
                    result = CallerFactory<IStaffSalaryService>.Instance.Update(info, info.Id);
                }

                //保存自定义奖金
                var bonus = this.bonusGrid.DataSource;
                foreach(var item in bonus)
                {
                    CallerFactory<IStaffBonusService>.Instance.InsertUpdate(item, item.Id);
                }

                return result;
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
            return false;
        }

        #endregion //Function

        #region Method
        /// <summary>
        /// 窗体载入
        /// </summary>
        public override void FormOnLoad()
        {
            this.luDepartment.Init();
            bonusGrid.Init(this.ID);

            base.FormOnLoad();
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
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                this.Text = "编辑员工工资信息";
                StaffSalaryInfo info = CallerFactory<IStaffSalaryService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    luDepartment.SetSelected(info.FinanceDepartment);
                    txtCardNumber.Text = info.CardNumber;
                    txtBaseSalary.Value = info.BaseSalary;
                    txtBaseBonus.Value = info.BaseBonus;
                    txtDepartmentBonus.Value = info.DepartmentBonus;
                    txtReserveFund.Value = info.ReserveFund;
                    txtInsurance.Value = info.Insurance;
                    txtRemark.Text = info.Remark;
                }
              
                //this.btnOK.Enabled = HasFunction("StaffSalary/Edit");             
            }
            else
            {

                //this.btnOK.Enabled = Portal.gc.HasFunction("StaffSalary/Add");  
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        public override void ClearScreen()
        {
            this.tempInfo = new StaffSalaryInfo();
            base.ClearScreen();
        }


        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {

            return false;
        }

        /// <summary>
        /// 编辑状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {
            return Save();
        }
        #endregion //Method
    }
}

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
    public partial class FrmWarehouseEdit : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WarehouseInfo tempInfo = new WarehouseInfo();
        #endregion //Field

        #region Constructor
        public FrmWarehouseEdit()
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
        private void SetInfo(WarehouseInfo info)
        {            
            info.Number = txtNumber.Text;
            info.Name = txtName.Text;
            info.CompanyId = this.luCompany.GetSelectedId();
            info.SortCode = txtSortCode.Text;
            info.Address = txtAddress.Text;
            info.InnerPhone = txtInnerPhone.Text;
            info.OuterPhone = txtOuterPhone.Text;
            info.Remark = txtRemark.Text;
            info.Enabled = Convert.ToInt32(this.cmbEnabled.EditValue);

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
            this.tempInfo = new WarehouseInfo();
            base.ClearScreen();
        }       

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过
            
            var comId = this.luCompany.GetSelectedId();
            if (this.txtNumber.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入编码");
                this.txtNumber.Focus();
                result = false;
            }
             else if (this.txtName.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入名称");
                this.txtName.Focus();
                result = false;
            }
            else if (string.IsNullOrEmpty(comId) || comId == "-1")
            {
                MessageDxUtil.ShowTips("请选择所属公司");
                this.luCompany.Focus();
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
                this.Text = "编辑仓库";
                WarehouseInfo info = CallerFactory<IWarehouseService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                    
                    txtNumber.Text = info.Number;
                    txtName.Text = info.Name;
                    luCompany.SetSelected(info.CompanyId);
                    txtSortCode.Text = info.SortCode;
                    txtAddress.Text = info.Address;
                    txtInnerPhone.Text = info.InnerPhone;
                    txtOuterPhone.Text = info.OuterPhone;
                    txtRemark.Text = info.Remark;

                    cmbEnabled.EditValue = info.Enabled;
                }

                //this.btnOK.Enabled = HasFunction("Warehouse/Edit");             
            }
            else
            {
                this.Text = "新增仓库";
                //this.btnOK.Enabled = Portal.gc.HasFunction("Warehouse/Add");  
            }
        } 
        
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WarehouseInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            info.Deleted = 0;

            try
            {
                #region 新增数据

                bool succeed = CallerFactory<IWarehouseService>.Instance.Insert(info);
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

            WarehouseInfo info = CallerFactory<IWarehouseService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<IWarehouseService>.Instance.Update(info, info.Id);
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

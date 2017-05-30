using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    /// <summary>
    /// 查看职员窗体
    /// </summary>
    public partial class FrmStaffView : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private StaffInfo tempInfo = new StaffInfo();
        #endregion //Field

        #region Constructor
        public FrmStaffView()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 窗体载入
        /// </summary>
        public override void FormOnLoad()
        {
            base.FormOnLoad();
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            if (!string.IsNullOrEmpty(ID))
            {
                this.Text = "查看职员";
                StaffInfo info = CallerFactory<IStaffService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    txtNumber.Text = info.Number;
                    txtName.Text = info.Name;

                    if (!string.IsNullOrEmpty(info.CompanyId))
                    {
                        var company = CallerFactory<IDepartmentService>.Instance.FindByID(info.CompanyId);
                        txtCompany.Text = company.Name;
                    }
                    if (!string.IsNullOrEmpty(info.DepartmentId))
                    {
                        var dep = CallerFactory<IDepartmentService>.Instance.FindByID(info.DepartmentId);
                        txtDepartment.Text = dep.Name;
                    }
                    if (!string.IsNullOrEmpty(info.PositionId))
                    {
                        var pos = CallerFactory<IPositionService>.Instance.FindByID(info.PositionId);
                        txtPosition.Text = pos.Name;
                    }

                    txtGender.Text = info.Gender;
                    txtBirthday.Text = info.Birthday.ToDateString();
                    txtNativePlace.Text = info.NativePlace;
                    txtNationality.Text = info.Nationality;
                    txtIdentityCard.Text = info.IdentityCard;
                    txtPhone.Text = info.Phone;
                    txtOfficePhone.Text = info.OfficePhone;
                    txtEmail.Text = info.Email;
                    txtQQ.Text = info.QQ;
                    txtHomeAddress.Text = info.HomeAddress;
                    txtPolitical.Text = info.Political;
                    txtPartyDate.Text = info.PartyDate.ToDateString();
                    txtEducation.Text = info.Education;
                    txtDegree.Text = info.Degree;
                    txtWorkingDate.Text = info.WorkingDate.ToDateString();
                    txtMarriage.Text = info.Marriage;
                    txtChildStatus.Text = info.ChildStatus;
                    txtTitles.Text = info.Titles;
                    txtDuty.Text = info.Duty;
                    txtJobType.Text = info.JobType;
                    txtIntroduce.Text = info.Introduce;
                    txtRemark.Text = info.Remark;
                    txtEnabled.Text = info.Enabled == 1 ? "已启用" : "未启用";
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
        #endregion //Method
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    /// 编辑班组换机工时
    /// </summary>
    public partial class FrmEditWorkTeamDailyChange : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();
        #endregion //Field

        #region Constructor
        public FrmEditWorkTeamDailyChange()
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
        #endregion //Function

        #region Method

        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamDailyWorkloadInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            //if (string.IsNullOrEmpty(this.luWorkTeam.GetSelectedId()))
            //{
            //    MessageDxUtil.ShowTips("请选择班组");
            //    result = false;
            //}
            //else if (this.txtAttendanceDate.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtAttendanceDate.Focus();
            //    result = false;
            //}

            return result;
        }

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            this.Text = "编辑班组日换机工时";

            //this.luWorkTeam.Init();
            if (!string.IsNullOrEmpty(ID))
            {
                WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    var team = CallerFactory<IWorkTeamService>.Instance.FindByID(info.WorkTeamId);
                    this.txtWorkTeam.Text = team.Name;
                    // txtWorkTeamId.Text = info.WorkTeamId;
                    //this.luWorkTeam.SetSelected(info.WorkTeamId);
                    //txtAttendanceDate.SetDateTime(info.AttendanceDate);
                    //txtProductionHours.Value = info.ProductionHours;
                    //txtPersonCount.Value = info.PersonCount;
                    //txtRemark.Text = info.Remark;

                }

                //this.btnOK.Enabled = HasFunction("WorkTeamDailyWorkload/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkTeamDailyWorkload/Add");  
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }
        #endregion //Method
    }
}

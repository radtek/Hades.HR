using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Linq;
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
    /// 计件工人日考勤记录
    /// </summary>
    public partial class FrmEditLaborAttendanceRecord : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private LaborAttendanceRecordInfo tempInfo = new LaborAttendanceRecordInfo();

        private string workTeamId;

        private DateTime attendanceDate;

        /// <summary>
        /// 相关职员
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditLaborAttendanceRecord()
        {
            InitializeComponent();

            this.workTeamId = "3aafbe8c-98db-41db-bccc-0171ff20e89a";
            this.attendanceDate = DateTime.Now;
        }

        public FrmEditLaborAttendanceRecord(DateTime attendanceDate, string workTeamId)
        {
            InitializeComponent();

            this.attendanceDate = attendanceDate;
            this.workTeamId = workTeamId;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码

            this.repoCmbAbsentType.Items.AddEnum(typeof(AbsentType), true);
        }

        /// <summary>
        /// 初始化考勤记录
        /// </summary>
        /// <returns></returns>
        private List<LaborAttendanceRecordInfo> InitRecords()
        {
            var data = CallerFactory<ILaborAttendanceRecordService>.Instance.Find(string.Format("AttendanceDate='{0}'", attendanceDate));
            this.staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("WorkTeamId='{0}'", workTeamId));

            List<LaborAttendanceRecordInfo> records = new List<LaborAttendanceRecordInfo>();
            foreach (var item in staffs)
            {
                var find = data.SingleOrDefault(r => r.StaffId == item.Id);
                if (find != null)
                {
                    records.Add(find);
                }
                else
                {
                    LaborAttendanceRecordInfo info = new LaborAttendanceRecordInfo();
                    info.Id = Guid.NewGuid().ToString();
                    info.AttendanceDate = this.attendanceDate;
                    info.StaffId = item.Id;

                    records.Add(info);
                }
            }

            return records;
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(LaborAttendanceRecordInfo info)
        {
            //info.StaffId = txtStaffId.Text;
            //      info.AttendanceDate = txtAttendanceDate.DateTime;
            //      info.Workload = txtWorkload.Value;
            //          info.AbsentType = Convert.ToInt32(txtAbsentType.Value);
        }
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            InitDictItem();
            var records = InitRecords();
            this.bsAttendanceRecord.DataSource = records;
        }

        public override void ClearScreen()
        {
            this.tempInfo = new LaborAttendanceRecordInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            #region MyRegion
            //if (this.txtStaffId.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtStaffId.Focus();
            //    result = false;
            //}
            // else if (this.txtAttendanceDate.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtAttendanceDate.Focus();
            //    result = false;
            //}
            // else if (this.txtWorkload.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtWorkload.Focus();
            //    result = false;
            //}
            // else if (this.txtAbsentType.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("请输入");
            //    this.txtAbsentType.Focus();
            //    result = false;
            //}
            #endregion

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
                #region 显示信息
                LaborAttendanceRecordInfo info = CallerFactory<ILaborAttendanceRecordService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    //txtStaffId.Text = info.StaffId;
                    //          txtAttendanceDate.SetDateTime(info.AttendanceDate);	
                    //      txtWorkload.Value = info.Workload;
                    //          txtAbsentType.Value = info.AbsentType;
                }
                #endregion
                //this.btnOK.Enabled = HasFunction("LaborAttendanceRecord/Edit");             
            }
            else
            {

                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborAttendanceRecord/Add");  
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        private void SaveRecords()
        {
            var records = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            foreach (var item in records)
            {
                //item.LeaveDays = item.AnnualLeave + item.SickLeave + item.CasualLeave + item.InjuryLeave + item.MarriageLeave + item.AbsentLeave;
                //item.OvertimeSalarySum = item.NormalOvertimeSalary + item.WeekendOvertimeSalary + item.HolidayOvertimeSalary;
                CallerFactory<ILaborAttendanceRecordService>.Instance.InsertUpdate(item, item.Id);
            }
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveRecords();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowWarning(ex.Message);
            }
        }
        #endregion //Event
    }
}

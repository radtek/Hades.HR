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

        /// <summary>
        /// 关联班组
        /// </summary>
        private string workTeamId;

        /// <summary>
        /// 考勤日期
        /// </summary>
        private DateTime attendanceDate;

        /// <summary>
        /// 相关职员
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
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
            this.staffs = CallerFactory<IStaffService>.Instance.Find(string.Format("StaffType=2 AND WorkTeamId='{0}'", workTeamId));

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
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            InitDictItem();

            var team = CallerFactory<IWorkTeamService>.Instance.FindByID(this.workTeamId);
            this.txtWorkTeamName.Text = team.Name;

            var records = InitRecords();
            this.bsAttendanceRecord.DataSource = records;

            this.txtAttendanceDate.Text = this.attendanceDate.ToDateString();
            if (records.Count > 0)
            {
                var item = records.First();
                this.chkIsWeekend.Checked = item.IsWeekend;
                this.chkIsHoliday.Checked = item.IsHoliday;
            }
        }

        public override void ClearScreen()
        {
            this.tempInfo = new LaborAttendanceRecordInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        private void SaveRecords()
        {
            var records = this.bsAttendanceRecord.DataSource as List<LaborAttendanceRecordInfo>;

            foreach (var item in records)
            {
                item.AttendanceDate = this.attendanceDate;
                item.IsWeekend = this.chkIsWeekend.Checked;
                item.IsHoliday = this.chkIsHoliday.Checked;
                CallerFactory<ILaborAttendanceRecordService>.Instance.InsertUpdate(item, item.Id);
            }
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 格式化显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendance_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "StaffId")
            {
                var s = this.staffs.SingleOrDefault(r => r.Id == e.Value.ToString());
                if (s == null)
                    e.DisplayText = "";
                else
                    e.DisplayText = s.Name;
            }
        }

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
        
        /// <summary>
        /// 绑定数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendance_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

        }
        #endregion //Event
    }
}

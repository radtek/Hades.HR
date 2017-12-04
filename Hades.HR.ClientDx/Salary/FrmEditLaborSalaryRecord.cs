using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

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
    public partial class FrmEditLaborSalaryRecord : BaseEditForm
    {
        #region Field
        private string attendanceId;

        private string workTeamId;

        //private List<WorkSectionLaborViewInfo> sectionLabors;

        private List<StaffLevelInfo> staffLevels;
        #endregion //Field

        #region Constructor
        public FrmEditLaborSalaryRecord(string attendanceId, string workTeamId)
        {
            InitializeComponent();

            this.attendanceId = attendanceId;
            this.workTeamId = workTeamId;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// ��ʼ�������ֵ�
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������
        }

        private List<LaborSalaryRecordInfo> SetEntity()
        {
            List<LaborSalaryRecordInfo> data = this.bsSalaryRecords.DataSource as List<LaborSalaryRecordInfo>;
            return data;
        }
        #endregion //Function

        #region Method
        public override void FormOnLoad()
        {
            InitDictItem();

            this.Text = "���ɹ���";

            var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(this.workTeamId);
            var attendance = CallerFactory<IAttendanceService>.Instance.FindByID(this.attendanceId);

            this.txtWorkTeamName.Text = workTeam.Name;
            this.txtSalaryTime.Text = attendance.Year + "��" + attendance.Month + "��";

            //this.sectionLabors = CallerFactory<IWorkSectionLaborViewService>.Instance.Find(string.Format("WorkTeamId = '{0}'", this.workTeamId));
            this.staffLevels = CallerFactory<IStaffLevelService>.Instance.Find("");

            var records = CallerFactory<ILaborSalaryRecordService>.Instance.CalcLaborSalary(this.attendanceId, this.workTeamId);

            this.bsSalaryRecords.DataSource = records;
        }

        public override void ClearScreen()
        {
            base.ClearScreen();
        }

        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            //if (this.txtAttendanceDays.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("������");
            //    this.txtAttendanceDays.Focus();
            //    result = false;
            //}

            return result;
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                this.dgvSalary.CloseEditor();

                var data = SetEntity();

                bool succeed = CallerFactory<ILaborSalaryRecordService>.Instance.SaveLaborSalary(this.attendanceId, data);

                if (succeed)
                    return true;
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!(ActiveControl is Button))
            {
                if (keyData == Keys.Down || keyData == Keys.Enter)
                {
                    return false;
                }
                else if (keyData == Keys.Up)
                {
                    return false;
                }

                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ��ʽ��������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSalary_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "StaffId")
            {
                //var s = this.sectionLabors.FirstOrDefault(r => r.StaffId == e.Value.ToString());
                //if (s == null)
                //    e.DisplayText = "";
                //else
                //    e.DisplayText = s.Name;
            }
            else if (columnName == "StaffLevelId")
            {
                var s = this.staffLevels.SingleOrDefault(r => r.Id == e.Value.ToString());
                if (s == null)
                    e.DisplayText = "";
                else
                    e.DisplayText = s.Name;
            }
        }

        /// <summary>
        /// �Զ���������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSalary_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsSalaryRecords.Count)
                return;

            var record = this.bsSalaryRecords[rowIndex] as LaborSalaryRecordInfo;

            if (e.Column.FieldName == "StaffNumber" && e.IsGetData)
            {
                //var s = this.sectionLabors.FirstOrDefault(r => r.StaffId == record.StaffId);
                //if (s == null)
                //    e.Value = "";
                //else
                //    e.Value = s.Number;
            }
        }
        #endregion //Event
    }
}

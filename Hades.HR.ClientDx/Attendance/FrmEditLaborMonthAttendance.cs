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
    public partial class FrmEditLaborMonthAttendance : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private LaborMonthAttendanceInfo tempInfo = new LaborMonthAttendanceInfo();

        private int year;

        private int month;

        private string workTeamId;

        /// <summary>
        /// ����ְԱ����
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditLaborMonthAttendance()
        {
            InitializeComponent();
        }

        public FrmEditLaborMonthAttendance(int year, int month, string workTeamId)
        {
            this.year = year;
            this.month = month;
            this.workTeamId = workTeamId;
            InitializeComponent();
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
        #endregion //Function

        #region Method
        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            return result;
        }

        public override void ClearScreen()
        {
            //this.tempInfo = new LaborMonthAttendanceInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�
            this.Text = "�༭Ա���¿���";

            this.txtMonth.Text = $"{this.year}��{this.month}��";

            var team = CallerFactory<IWorkTeamService>.Instance.FindByID(this.workTeamId);
            this.txtWorkTeam.Text = team.Name;

            this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");

            var data = CallerFactory<ILaborMonthAttendanceService>.Instance.GetRecords(this.year, this.month, this.workTeamId);
            this.bsAttendance.DataSource = data;
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                var data = this.bsAttendance.DataSource as List<LaborMonthAttendanceInfo>;

                bool succeed = CallerFactory<ILaborMonthAttendanceService>.Instance.SaveRecords(data, this.year, this.month, this.workTeamId);
                if (succeed)
                {
                    //�����������������

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
        #endregion //Method

        #region Event
        /// <summary>
        /// ��ʽ��������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendance_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "StaffId")
            {
                if (e.Value != null)
                {
                    var s = this.staffs.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Name;
                }
            }
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
        #endregion /Event
    }
}

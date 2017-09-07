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
using Hades.HR.Util;

namespace Hades.HR.UI
{
    /// <summary>
    /// ����ְԱ�༭
    /// </summary>
    public partial class FrmEditWorkSectionLabor : BaseEditForm
    {
        #region Field
        private int year;

        private int month;

        private string workTeamId;

        /// <summary>
        /// ����Ա���б�
        /// </summary>
        private List<StaffInfo> staffs;

        /// <summary>
        /// ����ְԱ�ȼ��б�
        /// </summary>
        private List<StaffLevelInfo> staffLevels;

        /// <summary>
        /// ���湤���б�
        /// </summary>
        private List<WorkSectionInfo> workSections;
        #endregion //Field

        #region Constructor
        public FrmEditWorkSectionLabor(int year, int month, string workTeamId)
        {
            InitializeComponent();

            this.staffs = new List<StaffInfo>();
            this.year = year;
            this.month = month;
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

        /// <summary>
        /// ���빤������
        /// </summary>
        private void LoadWorkSections()
        {
            this.workSections = CallerFactory<IWorkSectionService>.Instance.Find2(string.Format("WorkTeamId = '{0}' AND Enabled=1 AND Deleted=0", this.workTeamId), "ORDER BY SortCode");
            var sectionLabors = CallerFactory<IWorkSectionLaborService>.Instance.Find(string.Format("WorkTeamId = '{0}' AND Year = {1} AND Month = {2}", this.workTeamId, this.year, this.month));

            List<WorkSectionLaborInfo> labors = new List<WorkSectionLaborInfo>();

            foreach (var section in workSections)
            {
                WorkSectionLaborInfo info = new WorkSectionLaborInfo();
                info.Year = this.year;
                info.Month = this.month;
                info.WorkTeamId = workTeamId;
                info.WorkSectionId = section.Id;
                info.SortCode = section.SortCode;

                var labor = sectionLabors.SingleOrDefault(r => r.WorkSectionId == section.Id);
                if (labor != null)
                {
                    info.Id = labor.Id;
                    info.StaffId = labor.StaffId;
                    info.StaffLevelId = labor.StaffLevelId;
                    info.InPosition = labor.InPosition;
                    info.Remark = labor.Remark;
                }

                labors.Add(info);
            }

            this.bsLabors.DataSource = labors;
        }

        /// <summary>
        /// ѡ��Ա��
        /// </summary>
        private void SelectStaff()
        {
            var selected = this.dgvStaff.GetSelectedRows();
            if (selected.Length == 0)
                return;

            var dsIndex = this.dgvStaff.GetDataSourceRowIndex(selected[0]);
            var labor = this.bsLabors[dsIndex] as WorkSectionLaborInfo;

            FrmStaffSearch frm = new FrmStaffSearch(StaffType.Labor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (this.staffs.All(r => r.Id != frm.SelectedStaff.Id))
                {
                    this.staffs.Add(frm.SelectedStaff);
                }

                labor.StaffId = frm.SelectedStaff.Id;

                var salaryBase = CallerFactory<IStaffSalaryBaseService>.Instance.FindByID(frm.SelectedStaff.Id);
                if (salaryBase != null)
                    labor.StaffLevelId = salaryBase.StaffLevelId;

                this.dgvStaff.UpdateCurrentRow();
            }
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo()
        {
            var data = this.bsLabors.DataSource as List<WorkSectionLaborInfo>;

            //data.Where(r => !string.IsNullOrEmpty(r.StaffId)).Distinct()

            foreach (var item in data)
            {
                item.Editor = this.LoginUserInfo.Name;
                item.EditorId = this.LoginUserInfo.ID;
                item.EditTime = DateTime.Now;

                CallerFactory<IWorkSectionLaborService>.Instance.InsertUpdate(item, item.Id);
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            InitDictItem();//�����ֵ���أ����ã�

            this.Text = "�༭���鹤��ְԱ";

            this.txtDate.Text = string.Format("{0}��{1}��", year, month);

            var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(this.workTeamId);
            this.txtWorkTeamName.Text = workTeam.Name;

            this.staffLevels = CallerFactory<IStaffLevelService>.Instance.Find("");

            LoadWorkSections();
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

            return result;
        }

        /// <summary>
        /// �༭״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {
            return true;
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                SetInfo();
                return true;
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
        private void dgvStaff_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "WorkSectionId")
            {
                var s = this.workSections.SingleOrDefault(r => r.Id == e.Value.ToString());
                if (s == null)
                    e.DisplayText = "";
                else
                    e.DisplayText = s.Name;
            }
            else if (columnName == "StaffId")
            {
                if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.DisplayText = "";
                }
                else
                {
                    var s = this.staffs.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s != null)
                        e.DisplayText = s.Name;
                    else
                    {
                        var staff = CallerFactory<IStaffService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = staff.Name;
                        this.staffs.Add(staff);
                    }
                }
            }
            else if (columnName == "StaffLevelId")
            {
                if (e.Value != null)
                {
                    var s = this.staffLevels.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Name;
                }
            }
        }

        /// <summary>
        /// �Զ���������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsLabors.Count)
                return;

            var record = this.bsLabors[rowIndex] as WorkSectionLaborInfo;

            if (e.Column.FieldName == "colIn")
            {
                if (e.IsGetData)
                {
                    e.Value = record.InPosition == 1 ? true : false;
                }
                if (e.IsSetData)
                {
                    record.InPosition = Convert.ToInt32(e.Value);
                }
            }
            if (e.Column.FieldName == "colStaffNumber" && e.IsGetData)
            {
                if (!string.IsNullOrEmpty(record.StaffId))
                {
                    var s = this.staffs.SingleOrDefault(r => r.Id == record.StaffId);
                    if (s != null)
                        e.Value = s.Number;
                    else
                    {
                        var staff = CallerFactory<IStaffService>.Instance.FindByID(record.StaffId);
                        e.Value = staff.Number;
                    }
                }
            }
        }

        /// <summary>
        /// ѡ��Ա��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repoActionButton_Click(object sender, EventArgs e)
        {
            SelectStaff();
        }
        #endregion //Event
    }
}

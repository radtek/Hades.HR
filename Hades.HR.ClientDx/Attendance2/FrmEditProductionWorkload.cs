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
    /// <summary>
    /// �༭������ʱ
    /// </summary>
    public partial class FrmEditProductionWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// �깤������
        /// </summary>
        private List<CompleteForm> completeForms = new List<CompleteForm>();

        /// <summary>
        /// �깤����ϸ��Ϣ
        /// </summary>
        private List<CompleteDetails> completeDetails = new List<CompleteDetails>();

        /// <summary>
        /// �ݴ������ʱ����
        /// </summary>
        private List<LaborProductionWorkloadInfo> laborWorkloads = new List<LaborProductionWorkloadInfo>();

        /// <summary>
        /// ����ְԱ����
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditProductionWorkload()
        {
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

        /// <summary>
        /// �����깤���б�
        /// </summary>
        /// <param name="dt"></param>
        private void GenerateForm(DateTime dt)
        {
            Random random = new Random(dt.Day);

            this.lvComplete.Items.Clear();

            int days = random.Next(2, 6);
            for (int i = 0; i < days; i++)
            {
                string id = Guid.NewGuid().ToString();
                string number = string.Format("{0:D4}{1:D2}{2:D3}-{3:D3}", dt.Year, dt.Month, dt.Day, i);

                CompleteForm form = new CompleteForm();
                form.Id = id;
                form.Number = number;

                completeForms.Add(form);

                GenerateCompleteDetails(form.Id, i);
            }

            this.lvComplete.DataSource = completeForms;
            this.lvComplete.DisplayMember = "Number";
            this.lvComplete.ValueMember = "Id";
        }

        /// <summary>
        /// �����깤����
        /// </summary>
        private void GenerateCompleteDetails(string completeId, int index)
        {
            Random random = new Random(DateTime.Now.Millisecond + index);

            CompleteDetails form1 = new CompleteDetails();
            form1.CompleteId = completeId;
            form1.Name = "Ͱ��ȦԲ";
            form1.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form1.Quota = 196;
            form1.Workload = Math.Round(form1.Production / form1.Quota, 2);

            CompleteDetails form2 = new CompleteDetails();
            form2.CompleteId = completeId;
            form2.Name = "Ͱ��㺸";
            form2.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form2.Quota = 98;
            form2.Workload = Math.Round(form2.Production / form2.Quota, 2);

            CompleteDetails form3 = new CompleteDetails();
            form3.CompleteId = completeId;
            form3.Name = "Ͱ��캸";
            form3.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form3.Quota = 196;
            form3.Workload = Math.Round(form3.Production / form3.Quota, 2);

            completeDetails.Add(form1);
            completeDetails.Add(form2);
            completeDetails.Add(form3);
        }

        /// <summary>
        /// ����ְԱ��ز�����ʱ
        /// </summary>
        private void LoadLaborProduction()
        {
            foreach (var item in this.completeForms)
            {
                var data = CallerFactory<ILaborProductionWorkloadService>.Instance.Find(string.Format("CompleteId = '{0}'", item.Id));

                this.laborWorkloads.AddRange(data);
            }
        }

        /// <summary>
        /// ��ʾ�깤��¼
        /// </summary>
        /// <param name="completeId"></param>
        private void DisplayDetails(string completeId)
        {
            this.wgvComplete.DisplayColumns = "Name,Production,Quota,Workload";

            this.wgvComplete.AddColumnAlias("Name", "��������");
            this.wgvComplete.AddColumnAlias("Production", "ʵ�ʲ���");
            this.wgvComplete.AddColumnAlias("Quota", "�Ƽ�����");
            this.wgvComplete.AddColumnAlias("Workload", "������ʱ");

            var data = this.completeDetails.Where(r => r.CompleteId == completeId);
            this.wgvComplete.DataSource = data;
        }

        /// <summary>
        /// ��ʾְԱ��Ϣ
        /// </summary>
        /// <param name="completeId">�깤��ID</param>
        private void DisplayLaborProduction(string completeId)
        {
            var find = this.laborWorkloads.Where(r => r.CompleteId == completeId);
            if (find.Count() == 0)
            {
                var staffs = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", this.ID));

                List<LaborProductionWorkloadInfo> data = new List<LaborProductionWorkloadInfo>();
                foreach (var item in staffs)
                {
                    LaborProductionWorkloadInfo info = new LaborProductionWorkloadInfo();
                    info.CompleteId = completeId;
                    info.WorkTeamId = this.tempInfo.WorkTeamId;
                    info.StaffId = item.StaffId;

                    data.Add(info);
                }

                this.bsLaborWorkload.DataSource = data;
            }
            else
            {
                this.bsLaborWorkload.DataSource = find;
            }
        }

        /// <summary>
        /// ���㹤ʱ
        /// </summary>
        private void CalculateHours()
        {
            if (this.lvComplete.SelectedIndex == -1 || this.lvComplete.SelectedItem == null)
                return;

            var form = this.lvComplete.SelectedItem as CompleteForm;
            var totalHours = this.completeDetails.Where(r => r.CompleteId == form.Id).Sum(r => r.Workload);

            var selected = this.dgvStaff.GetSelectedRows();
            if (selected.Length == 0)
                return;

            var one = Math.Round(totalHours / selected.Length, 3);

            for (int i = 0; i < this.dgvStaff.RowCount; i++)
            {
                int dsIndex = this.dgvStaff.GetDataSourceRowIndex(i);
                var workload = this.bsLaborWorkload[dsIndex] as LaborProductionWorkloadInfo;
                if (dgvStaff.IsRowSelected(i))
                {
                    workload.ProductionHours = one;
                }
                else
                {
                    workload.ProductionHours = 0;
                }
            }

            this.dgvStaff.RefreshData();
        }

        /// <summary>
        /// �ݴ��깤��
        /// </summary>
        /// <param name="completeId">�깤��ID</param>
        private void StoreCompleteForm(string completeId)
        {
            this.laborWorkloads.RemoveAll(r => r.CompleteId == completeId);

            var data = this.bsLaborWorkload.DataSource as List<LaborProductionWorkloadInfo>;

            foreach (var item in data)
            {
                item.AssignType = 1;
                item.Remark = item.Remark ?? "";
            }
            this.laborWorkloads.AddRange(data);
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WorkTeamDailyWorkloadInfo info)
        {
            //info.WorkTeamId = luWorkTeam.GetSelectedId();
            //info.AttendanceDate = txtAttendanceDate.DateTime;
            info.ProductionHours = txtProductionHours.Value;

            //info.PersonCount = Convert.ToInt32(txtPersonCount.Value);


            info.Editor = this.LoginUserInfo.Name;
            info.EditorId = this.LoginUserInfo.ID;
            info.EditTime = DateTime.Now;
        }
        #endregion //Function

        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new WorkTeamDailyWorkloadInfo();
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
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�

            this.Text = "�༭���������ʱ";

            if (!string.IsNullOrEmpty(ID))
            {
                WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(info.WorkTeamId);
                    this.txtWorkTeamName.Text = workTeam.Name;
                    this.txtAttendanceDate.Text = info.AttendanceDate.ToString("yyyy-MM-dd");

                    this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");

                    GenerateForm(info.AttendanceDate);

                    LoadLaborProduction();

                    txtProductionHours.Value = this.completeDetails.Sum(r => r.Workload);
                }

                //this.btnOK.Enabled = HasFunction("WorkTeamDailyWorkload/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkTeamDailyWorkload/Add");  
            }
        }

        /// <summary>
        /// �༭״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {
            var data = this.laborWorkloads;
            //MessageBox.Show("update");
            return true;

            WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Update(info, info.Id);
                    if (succeed)
                    {
                        //�����������������

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

        #region Event
        /// <summary>
        /// �깤��ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvComplete.SelectedIndex != -1 && this.lvComplete.SelectedItem != null)
            {
                var form = this.lvComplete.SelectedItem as CompleteForm;
                DisplayDetails(form.Id);
                DisplayLaborProduction(form.Id);
            }
        }

        /// <summary>
        /// ��ʽ����ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            else if (columnName == "CompleteId")
            {
                if (e.Value != null)
                {
                    var s = this.completeForms.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Number;
                }
            }
        }

        /// <summary>
        /// ��������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsLaborWorkload.Count)
                return;

            var record = this.bsLaborWorkload[rowIndex] as LaborProductionWorkloadInfo;

            if (e.Column.FieldName == "StaffNumber" && e.IsGetData)
            {
                var s = this.staffs.SingleOrDefault(r => r.Id == record.StaffId);
                if (s == null)
                    e.Value = "";
                else
                    e.Value = s.Number;
            }
        }

        /// <summary>
        /// ְԱѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            CalculateHours();
        }

        /// <summary>
        /// �ݴ��깤��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCurrent_Click(object sender, EventArgs e)
        {
            if (this.lvComplete.SelectedIndex != -1 && this.lvComplete.SelectedItem != null)
            {
                var form = this.lvComplete.SelectedItem as CompleteForm;
                StoreCompleteForm(form.Id);
            }
        }
        #endregion //Event
    }

    /// <summary>
    /// �깤��
    /// </summary>
    public class CompleteForm
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public string Number { get; set; }
    }

    /// <summary>
    /// �깤��Ϣ
    /// </summary>
    public class CompleteDetails
    {
        /// <summary>
        /// �깤��ID
        /// </summary>
        public string CompleteId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public decimal Production { get; set; }

        /// <summary>
        /// �Ƽ�����
        /// </summary>
        public decimal Quota { get; set; }

        /// <summary>
        /// ���������ʱ
        /// </summary>
        public decimal Workload { get; set; }
    }
}

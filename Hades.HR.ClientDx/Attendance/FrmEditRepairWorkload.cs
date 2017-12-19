using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
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
    /// 编辑机修工时窗体
    /// </summary>
    public partial class FrmEditRepairWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// 缓存机修单
        /// </summary>
        public MachineMaintenanceManHoursInfo machineInfo;

        /// <summary>
        /// 暂存机修工时数据
        /// </summary>
        private List<LaborRepairWorkloadInfo> laborRepairs = new List<LaborRepairWorkloadInfo>();

        /// <summary>
        /// 缓存员工日工作量
        /// </summary>
        private List<LaborDailyWorkloadInfo> laborWorkloads = new List<LaborDailyWorkloadInfo>();

        /// <summary>
        /// 缓存职员数据
        /// </summary>
        private List<StaffInfo> staffs;
        #endregion //Field

        #region Constructor
        public FrmEditRepairWorkload()
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
        /// 生成机修数据
        /// </summary>
        private void GenerateRepair()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            machineInfo.ID = Guid.NewGuid().ToString();
            machineInfo.ManHours = Convert.ToInt32(Math.Round(Convert.ToDecimal(random.NextDouble() * 10), 2));
        }

        /// <summary>
        /// 载入机修单
        /// </summary>
        private void LoadMachineInfo()
        {
            string sql = string.Format("WorkTeamId = '{0}' AND WorkingDate = '{1}'", this.tempInfo.WorkTeamId, this.tempInfo.AttendanceDate);
            this.machineInfo = CallerFactory<IMachineMaintenanceManHoursService>.Instance.FindSingle(sql);
        }

        /// <summary>
        /// 载入已存员工相关机修工时
        /// </summary>
        /// <param name="repairId"></param>
        private void LoadLaborRepair(string repairId)
        {
            var data = CallerFactory<ILaborRepairWorkloadService>.Instance.Find(string.Format("RepairId = '{0}'", repairId));
            this.laborRepairs.AddRange(data);
        }

        /// <summary>
        /// 显示员工换机数据
        /// </summary>
        private void DisplayLaborRepair()
        {
            if (this.laborRepairs.Count == 0)
            {
                var staffs = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", this.ID));

                List<LaborRepairWorkloadInfo> data = new List<LaborRepairWorkloadInfo>();
                foreach (var item in staffs)
                {
                    LaborRepairWorkloadInfo info = new LaborRepairWorkloadInfo();
                    info.RepairId = this.machineInfo.ID;
                    info.WorkTeamId = this.tempInfo.WorkTeamId;
                    info.StaffId = item.StaffId;
                    info.AttendanceDate = this.tempInfo.AttendanceDate;

                    data.Add(info);
                }

                this.bsLaborWorkload.DataSource = data;
            }
            else
            {
                this.bsLaborWorkload.DataSource = this.laborRepairs;
            }
        }

        /// <summary>
        /// 计算工时
        /// </summary>
        private void CalculateHours()
        {
            decimal totalHours = this.machineInfo.ManHours;

            var selected = this.dgvStaff.GetSelectedRows();
            if (selected.Length == 0)
                return;

            var one = Math.Round(totalHours / selected.Length, 3);

            for (int i = 0; i < this.dgvStaff.RowCount; i++)
            {
                int dsIndex = this.dgvStaff.GetDataSourceRowIndex(i);
                var workload = this.bsLaborWorkload[dsIndex] as LaborRepairWorkloadInfo;
                if (dgvStaff.IsRowSelected(i))
                {
                    workload.RepairHours = one;
                }
                else
                {
                    workload.RepairHours = 0;
                }
            }

            this.dgvStaff.RefreshData();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WorkTeamDailyWorkloadInfo info)
        {
            //info.WorkTeamId = txtWorkTeamId.Text;
            //info.StaffId = txtStaffId.Text;
            //info.ChangeHours = txtChangeHours.Value;
            //info.AssignType = Convert.ToInt32(txtAssignType.Value);
            //info.Remark = txtRemark.Text;
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
                WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);

                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(info.WorkTeamId);
                    this.txtWorkTeamName.Text = workTeam.Name;
                    this.txtAttendanceDate.Text = info.AttendanceDate.ToString("yyyy-MM-dd");

                    this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 2");

                    // GenerateRepair();

                    LoadMachineInfo();

                    if (this.machineInfo != null)
                    {
                        this.spRepairHours.Value = this.machineInfo.ManHours; ;
                        this.txtRemark.Text = this.machineInfo.Remark;

                        this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                        LoadLaborRepair(this.machineInfo.ID);

                        DisplayLaborRepair();
                    }
                    else
                    {
                        this.spRepairHours.Value = 0;
                        this.txtRemark.Text = "";
                    }
                }

                //this.btnOK.Enabled = HasFunction("LaborChangeWorkload/Edit");             
            }
            else
            {

                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborChangeWorkload/Add");  
            }

            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WorkTeamDailyWorkloadInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                //bool succeed = CallerFactory<ILaborChangeWorkloadService>.Instance.Insert(info);
                //if (succeed)
                //{
                //    //可添加其他关联操作

                //    return true;
                //}
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
            WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);

            if (info != null)
            {
                try
                {
                    this.laborRepairs = this.bsLaborWorkload.DataSource as List<LaborRepairWorkloadInfo>;
                    info.RepairHours = this.machineInfo.ManHours;

                    if (this.laborRepairs.Sum(r => r.RepairHours) == 0)
                    {
                        MessageDxUtil.ShowWarning("机修工时未分配");
                        return false;
                    }

                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.SaveRepair(this.ID, this.machineInfo.ManHours, laborRepairs);
                       
                    return succeed;
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
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
        /// 格式化数据显示
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
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsLaborWorkload.Count)
                return;

            var record = this.bsLaborWorkload[rowIndex] as LaborRepairWorkloadInfo;

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
        /// 员工选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            CalculateHours();
        }
        #endregion //Event
    }
}

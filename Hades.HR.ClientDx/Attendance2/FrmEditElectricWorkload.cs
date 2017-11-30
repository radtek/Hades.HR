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
    /// 编辑电修工时窗体
    /// </summary>
    public partial class FrmEditElectricWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();
        
        /// <summary>
        /// 缓存电修单
        /// </summary>
        public ElectricForm electricForm = new ElectricForm();

        /// <summary>
        /// 暂存电修工时数据
        /// </summary>
        private List<LaborElectricWorkloadInfo> laborElectric = new List<LaborElectricWorkloadInfo>();

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
        public FrmEditElectricWorkload()
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
        /// 生成电修数据
        /// </summary>
        private void GenerateElectric()
        {
            Random random = new Random(DateTime.Now.Millisecond);
          
            electricForm.Id = Guid.NewGuid().ToString();
            electricForm.Workload = Math.Round(Convert.ToDecimal(random.NextDouble() * 10), 2);        
        }

        /// <summary>
        /// 载入已存员工相关电修工时
        /// </summary>
        /// <param name="electricId"></param>
        private void LoadLaborElectric(string electricId)
        {
            var data = CallerFactory<ILaborElectricWorkloadService>.Instance.Find(string.Format("ElectricId = '{0}'", electricId));
            this.laborElectric.AddRange(data);
        }

        /// <summary>
        /// 显示员工电机数据
        /// </summary>
        private void DisplayLaborRepair()
        {
            if (this.laborElectric.Count == 0)
            {
                var staffs = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", this.ID));

                List<LaborElectricWorkloadInfo> data = new List<LaborElectricWorkloadInfo>();
                foreach (var item in staffs)
                {
                    LaborElectricWorkloadInfo info = new LaborElectricWorkloadInfo();
                    info.ElectricId = this.electricForm.Id;
                    info.WorkTeamId = this.tempInfo.WorkTeamId;
                    info.StaffId = item.StaffId;                    

                    data.Add(info);
                }

                this.bsLaborWorkload.DataSource = data;
            }
            else
            {
                this.bsLaborWorkload.DataSource = this.laborElectric;
            }
        }

        /// <summary>
        /// 计算工时
        /// </summary>
        private void CalculateHours()
        {
            var totalHours = this.electricForm.Workload;

            var selected = this.dgvStaff.GetSelectedRows();
            if (selected.Length == 0)
                return;

            var one = Math.Round(totalHours / selected.Length, 3);

            for (int i = 0; i < this.dgvStaff.RowCount; i++)
            {
                int dsIndex = this.dgvStaff.GetDataSourceRowIndex(i);
                var workload = this.bsLaborWorkload[dsIndex] as LaborElectricWorkloadInfo;
                if (dgvStaff.IsRowSelected(i))
                {
                    workload.ElectricHours = one;
                }
                else
                {
                    workload.ElectricHours = 0;
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

                    GenerateElectric();

                    this.spElectricHours.Value = this.electricForm.Workload;
                    this.txtRemark.Text = this.electricForm.Remark;
                    
                    this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                    LoadLaborElectric(this.electricForm.Id);

                    DisplayLaborRepair();
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
                    this.laborElectric = this.bsLaborWorkload.DataSource as List<LaborElectricWorkloadInfo>;
                    info.ElectricHours = this.electricForm.Workload;
                    
                    if (this.laborElectric.Sum(r => r.ElectricHours) == 0)
                    {
                        MessageDxUtil.ShowWarning("电修工时未分配");
                        return false;
                    }

                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Update(info, info.Id);

                    foreach (var item in this.laborElectric)
                    {
                        // 增加电修工时分配
                        CallerFactory<ILaborElectricWorkloadService>.Instance.Insert(item);
                    }

                    foreach (var item in this.laborWorkloads)
                    {
                        var hours = this.laborElectric.Single(r => r.StaffId == item.StaffId).ElectricHours;
                        item.ElectricHours = hours;

                        CallerFactory<ILaborDailyWorkloadService>.Instance.Update(item, item.Id);
                    }

                    return true;
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

            var record = this.bsLaborWorkload[rowIndex] as LaborElectricWorkloadInfo;

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

    /// <summary>
    /// 电修单
    /// </summary>
    public class ElectricForm
    {
        /// <summary>
        /// 电修单ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 工时
        /// </summary>
        public decimal Workload { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}

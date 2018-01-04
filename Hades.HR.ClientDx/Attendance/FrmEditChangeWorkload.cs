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
    /// 编辑换机工时窗体
    /// </summary>
    public partial class FrmEditChangeWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();

        /// <summary>
        /// 相关换机单ID
        /// </summary>
        private string changeId = "";
        
        /// <summary>
        /// 缓存换机数据
        /// </summary>
        public List<ReplaceMachineManHoursInfo> replaceInfo;

        /// <summary>
        /// 暂存换机工时数据
        /// </summary>
        private List<LaborChangeWorkloadInfo> laborChanges = new List<LaborChangeWorkloadInfo>();

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
        public FrmEditChangeWorkload()
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
        /// 载入换机数据
        /// </summary>
        private void LoadChangeDetails()
        {
            string sql = string.Format("WorkTeamId = '{0}' AND WorkingDate = '{1}'", this.tempInfo.WorkTeamId, this.tempInfo.AttendanceDate);
            this.replaceInfo = CallerFactory<IReplaceMachineManHoursService>.Instance.Find(sql);
        }

        /// <summary>
        /// 显示换机记录
        /// </summary>
        private void DisplayChangeDetails()
        {
            this.wgvChange.DisplayColumns = "ItemId,Amount,ManHour";

            this.wgvChange.AddColumnAlias("ItemId", "名称");
            this.wgvChange.AddColumnAlias("Amount", "数量");
            this.wgvChange.AddColumnAlias("ManHour", "换机工时(h)");

            var data = this.replaceInfo;
            this.wgvChange.DataSource = data;
        }

        /// <summary>
        /// 载入员工相关换机工时
        /// </summary>
        private void LoadLaborChanges()
        {
            var data = CallerFactory<ILaborChangeWorkloadService>.Instance.Find(string.Format("ChangeId = '{0}'", changeId));

            this.laborChanges.AddRange(data);
        }

        /// <summary>
        /// 显示员工换机数据
        /// </summary>
        private void DisplayLaborChange()
        {
            if (this.laborChanges.Count == 0)
            {
                var staffs = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", this.ID));

                List<LaborChangeWorkloadInfo> data = new List<LaborChangeWorkloadInfo>();
                foreach (var item in staffs)
                {
                    LaborChangeWorkloadInfo info = new LaborChangeWorkloadInfo();
                    info.ChangeId = changeId;
                    info.WorkTeamId = this.tempInfo.WorkTeamId;
                    info.StaffId = item.StaffId;

                    data.Add(info);
                }

                this.bsLaborWorkload.DataSource = data;
            }
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
                                        
                    LoadChangeDetails();

                    if (this.replaceInfo.Count > 0)
                    {
                        this.spChangeHours.Value = this.replaceInfo.Sum(r => r.ManHours);
                        this.txtRemark.Text = "";

                        this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                        DisplayChangeDetails();
                        // LoadLaborChanges(this.changeId);
                        DisplayLaborChange();
                    }
                    else
                    {
                        this.spChangeHours.Value = 0;
                        this.txtRemark.Text = "";
                    }

                    //DisplayDetails();

                  
                }

                //this.btnOK.Enabled = HasFunction("LaborChangeWorkload/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("LaborChangeWorkload/Add");  
            }

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
                    this.laborChanges = this.bsLaborWorkload.DataSource as List<LaborChangeWorkloadInfo>;

                    info.ChangeHours = this.replaceInfo.Sum(r => r.ManHours);

                    if (laborChanges.Sum(r => r.ChangeHours) > info.ChangeHours)
                    {
                        MessageDxUtil.ShowWarning("分配换机工时操作总数");
                        return false;
                    }

                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Update(info, info.Id);

                    foreach (var item in this.laborChanges)
                    {
                        // 增加换机工时分配
                        CallerFactory<ILaborChangeWorkloadService>.Instance.Insert(item);
                    }

                    foreach (var item in this.laborWorkloads)
                    {
                        var hours = this.laborChanges.Where(r => r.StaffId == item.StaffId).Sum(r => r.ChangeHours);
                        item.ChangeHours = hours;

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

        private void btnSaveAssign_Click(object sender, EventArgs e)
        {

        }

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

            var record = this.bsLaborWorkload[rowIndex] as LaborChangeWorkloadInfo;

            if (e.Column.FieldName == "StaffNumber" && e.IsGetData)
            {
                var s = this.staffs.SingleOrDefault(r => r.Id == record.StaffId);
                if (s == null)
                    e.Value = "";
                else
                    e.Value = s.Number;
            }
        }
        #endregion //Event
    }
}

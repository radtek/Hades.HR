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
        /// 缓存换机数据明细
        /// </summary>
        private List<ChangeDetails> changeDetails = new List<ChangeDetails>();

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
        /// 生成完工数据
        /// </summary>
        private void GenerateChangeDetails()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            this.changeId = Guid.NewGuid().ToString();

            ChangeDetails details1 = new ChangeDetails();
            details1.Name = "换波纹轮";
            details1.Quota = 8m;
            details1.Number = random.Next(1, 8);
            details1.Workload = Math.Round(details1.Quota * details1.Number / 60, 2);
           
            ChangeDetails details2 = new ChangeDetails();
            details2.Name = "开档调整10mm以内";
            details2.Quota = 8m;
            details2.Number = random.Next(1, 7);
            details2.Workload = Math.Round(details2.Quota * details2.Number / 60, 2);

            ChangeDetails details3 = new ChangeDetails();
            details3.Name = "换1只翻边盘";
            details3.Quota = 10m;
            details3.Number = random.Next(1, 5);
            details3.Workload = Math.Round(details3.Quota * details3.Number / 60, 2);

            ChangeDetails details4 = new ChangeDetails();
            details4.Name = "换1只卷边轮";
            details4.Quota = 10m;
            details4.Number = random.Next(1, 9);
            details4.Workload = Math.Round(details4.Quota * details4.Number / 60, 2);

            changeDetails.Add(details1);
            changeDetails.Add(details2);
            changeDetails.Add(details3);
            changeDetails.Add(details4);
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
        private void DisplayDetails()
        {
            this.wgvChange.DisplayColumns = "Name,Quota,Number,Workload";

            this.wgvChange.AddColumnAlias("Name", "名称");
            this.wgvChange.AddColumnAlias("Quota", "标准定额(m)");
            this.wgvChange.AddColumnAlias("Number", "数量");
            this.wgvChange.AddColumnAlias("Workload", "换机工时(h)");

            var data = this.changeDetails;
            this.wgvChange.DataSource = data;
        }

        /// <summary>
        /// 载入员工相关换机工时
        /// </summary>
        private void LoadLaborChanges(string changeId)
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

                    GenerateChangeDetails();
                    DisplayDetails();

                    this.spChangeHours.Value = this.changeDetails.Sum(r => r.Workload);

                    this.laborWorkloads = CallerFactory<ILaborDailyWorkloadService>.Instance.Find(string.Format("WorkTeamWorkloadId='{0}'", ID));

                    LoadLaborChanges(this.changeId);
                    DisplayLaborChange();
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
                #region 新增数据

                //bool succeed = CallerFactory<ILaborChangeWorkloadService>.Instance.Insert(info);
                //if (succeed)
                //{
                //    //可添加其他关联操作

                //    return true;
                //}
                #endregion
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
                    this.laborChanges = this.bsLaborWorkload.DataSource as List<LaborChangeWorkloadInfo>;

                    info.ChangeHours = this.changeDetails.Sum(r => r.Workload);

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

    /// <summary>
    /// 换机信息
    /// </summary>
    public class ChangeDetails
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标准定额
        /// </summary>
        public decimal Quota { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Number { get; set; }

        /// <summary>
        /// 工时
        /// </summary>
        public decimal Workload { get; set; }
    }
}

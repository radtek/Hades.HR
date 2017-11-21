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
    /// 编辑产量工时
    /// </summary>
    public partial class FrmEditProductionWorkload : BaseEditForm
    {
        #region Field
        /// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
        private WorkTeamDailyWorkloadInfo tempInfo = new WorkTeamDailyWorkloadInfo();
        #endregion //Field

        #region Constructor
        public FrmEditProductionWorkload()
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
        /// 生成完工单列表
        /// </summary>
        /// <param name="dt"></param>
        private void GenerateList(DateTime dt)
        {
            Random random = new Random(dt.Day);

            this.lvComplete.Items.Clear();
            int days = random.Next(2, 6);
            for (int i = 0; i < days; i++)
            {
                string number = string.Format("{0:D4}{1:D2}{2:D3}-{3:D3}", dt.Year, dt.Month, dt.Day, i);
                this.lvComplete.Items.Add(number);
            }
        }

        /// <summary>
        /// 生成完工数据
        /// </summary>
        private void GenerateComplete()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            CompleteForm form1 = new CompleteForm();
            form1.Name = "桶身圈圆";
            form1.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form1.Quota = 196;
            form1.Workload = Math.Round(form1.Production / form1.Quota, 2);

            CompleteForm form2 = new CompleteForm();
            form2.Name = "桶身点焊";
            form2.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form2.Quota = 98;
            form2.Workload = Math.Round(form2.Production / form2.Quota, 2);

            CompleteForm form3 = new CompleteForm();
            form3.Name = "桶身缝焊";
            form3.Production = 1700 * (decimal)(random.Next(50, 100) / 100m);
            form3.Quota = 196;
            form3.Workload = Math.Round(form3.Production / form3.Quota, 2);

            List<CompleteForm> data = new List<CompleteForm>();
            data.Add(form1);
            data.Add(form2);
            data.Add(form3);

            this.wgvComplete.DisplayColumns = "Name,Production,Quota,Workload";

            this.wgvComplete.AddColumnAlias("Name", "工序名称");
            this.wgvComplete.AddColumnAlias("Production", "实际产量");
            this.wgvComplete.AddColumnAlias("Quota", "计件定额");
            this.wgvComplete.AddColumnAlias("Workload", "产量工时");
            this.wgvComplete.DataSource = data;

            var totalWorkload = data.Sum(r => r.Workload);
            this.txtProductionHours.Text = totalWorkload.ToString();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WorkTeamDailyWorkloadInfo info)
        {
            //info.WorkTeamId = luWorkTeam.GetSelectedId();
            //info.AttendanceDate = txtAttendanceDate.DateTime;
            info.ProductionHours = txtProductionHours.Value;

            info.PersonCount = Convert.ToInt32(txtPersonCount.Value);
            info.Remark = txtRemark.Text;

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

            this.Text = "编辑班组产量工时";

            if (!string.IsNullOrEmpty(ID))
            {
                WorkTeamDailyWorkloadInfo info = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象

                    var workTeam = CallerFactory<IWorkTeamService>.Instance.FindByID(info.WorkTeamId);

                    this.txtWorkTeamName.Text = workTeam.Name;
                    txtAttendanceDate.Text = info.AttendanceDate.ToString("yyyy-MM-dd");

                    // txtWorkTeamId.Text = info.WorkTeamId;
                  
                    txtProductionHours.Value = info.ProductionHours;
                    txtPersonCount.Value = info.PersonCount;
                    txtRemark.Text = info.Remark;

                }

                //this.btnOK.Enabled = HasFunction("WorkTeamDailyWorkload/Edit");             
            }
            else
            {
                //this.btnOK.Enabled = Portal.gc.HasFunction("WorkTeamDailyWorkload/Add");  
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

                bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Insert(info);
                if (succeed)
                {
                    //可添加其他关联操作

                    return true;
                }
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
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = CallerFactory<IWorkTeamDailyWorkloadService>.Instance.Update(info, info.Id);
                    if (succeed)
                    {
                        //可添加其他关联操作

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
        private void txtAttendanceDate_EditValueChanged(object sender, EventArgs e)
        {
            //GenerateList(this.txtAttendanceDate.DateTime);
        }

        /// <summary>
        /// 完工单选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvComplete.SelectedIndex != -1)
            {
                GenerateComplete();
            }
        }
        #endregion //Event
    }

    public class CompleteForm
    {
        /// <summary>
        /// 工序名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 工序产量
        /// </summary>
        public decimal Production { get; set; }

        /// <summary>
        /// 计件定额
        /// </summary>
        public decimal Quota { get; set; }

        /// <summary>
        /// 工序产量工时
        /// </summary>
        public decimal Workload { get; set; }
    }
}

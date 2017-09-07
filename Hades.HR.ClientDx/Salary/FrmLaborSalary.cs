using System;
using System.Text;
using System.Data;
using System.Drawing;
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
    /// LaborSalary
    /// </summary>	
    public partial class FrmLaborSalary : BaseDock
    {
        #region Constructor
        public FrmLaborSalary()
        {
            InitializeComponent();

            InitDictItem();

   //         this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
   //         this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
   //         this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
   //         this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
   //         this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
   //         this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
   //         this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;
   //         this.winGridViewPager1.ShowLineNumber = true;
   //         this.winGridViewPager1.BestFitColumnWith = false;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
			//this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
   //         this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
   //         this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

         
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// ��ʼ���ֵ��б�����
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������
        }

        private AttendanceInfo LoadAttendance(DateTime date)
        {
            var attendance = CallerFactory<IAttendanceService>.Instance.FindSingle(string.Format("Year = {0} AND Month = {1}", date.Year, date.Month));
         
            return attendance;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            this.treeLine.Init();
            //BindData();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// �¶�ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpMonth_EditValueChanged(object sender, EventArgs e)
        {
            var attendance = LoadAttendance(this.dpMonth.DateTime);
            if (attendance != null)
            {
                this.txtMonthDays.Text = attendance.Days.ToString();
            }
        }

        /// <summary>
        /// ���㹤��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            var teamId = this.treeLine.GetSelectedTeamId();
            if (string.IsNullOrEmpty(teamId))
            {
                MessageDxUtil.ShowWarning("��ѡ�����");
                return;
            }
            if (this.dpMonth.EditValue == null)
            {
                MessageDxUtil.ShowWarning("��ѡ��������");
                return;
            }

            var attendace = LoadAttendance(this.dpMonth.DateTime);

            FrmEditLaborSalaryRecord dlg = new FrmEditLaborSalaryRecord(attendace.Id, teamId);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            if (DialogResult.OK == dlg.ShowDialog())
            {
                //LoadRecordData();
            }
        }
        #endregion //Event

        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName == "OrderStatus")
            //{
            //    string status = this.winGridViewPager1.gridView1.GetRowCellValue(e.RowHandle, "OrderStatus").ToString();
            //    Color color = Color.White;
            //    if (status == "�����")
            //    {
            //        e.Appearance.BackColor = Color.Red;
            //        e.Appearance.BackColor2 = Color.LightCyan;
            //    }
            //}
        }
        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
        	string columnName = e.Column.FieldName;
            if (e.Column.ColumnType == typeof(DateTime))
            {   
                if (e.Value != null)
                {
                    if (e.Value == DBNull.Value || Convert.ToDateTime(e.Value) <= Convert.ToDateTime("1900-1-1"))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm");//yyyy-MM-dd
                    }
                }
            }
            //else if (columnName == "Age")
            //{
            //    e.DisplayText = string.Format("{0}��", e.Value);
            //}
            //else if (columnName == "ReceivedMoney")
            //{
            //    if (e.Value != null)
            //    {
            //        e.DisplayText = e.Value.ToString().ToDecimal().ToString("C");
            //    }
            //}
        }
        
   
    
        
        /// <summary>
        /// ��ҳ�ؼ�ˢ�²���
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }
        
      
        
      
        
        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
        }
        
      
     

        /// <summary>
        /// ��ҳ�ؼ���ҳ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;
        
        /// <summary>
        /// ���ݲ�ѯ���������ѯ���
        /// </summary> 
        private string GetConditionSql()
        {
            //������ڸ߼���ѯ������Ϣ����ʹ�ø߼���ѯ����������ʹ������������ѯ
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {
                condition = new SearchCondition();
              
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        
        /// <summary>
        /// ���б�����
        /// </summary>
        private void BindData()
        {
        	//entity
            //this.winGridViewPager1.DisplayColumns = "AttendanceId,StaffId,AttendanceDays,AnnualLeave,SickLeave,CasualLeave,InjuryLeave,MarriageLeave,AbsentLeave,StaffLevelId,LevelSalary,MonthWorkload,BaseWorkload,WeekendWorkload,HolidayWorkload,Estimation,Allowance,WorkshopDeduction,WorkshopBonus,BonusDeduction,NoonShift,NightShift,OtherNoon,OtherNight,ShiftAmount,QualityBonus,Deduction,Nutrition,EquipmentBonus,SafetyBonus,FiveSBonus,HotBonus,LunchAllowance,Remark";
            //this.winGridViewPager1.ColumnNameAlias = CallerFactory<ILaborSalaryRecordService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

           

            //string where = GetConditionSql();
            //PagerInfo pagerInfo = this.winGridViewPager1.PagerInfo;
            //   List<LaborSalaryRecordInfo> list = CallerFactory<ILaborSalaryRecordService>.Instance.FindWithPager(where, ref pagerInfo);
            //this.winGridViewPager1.PagerInfo.RecordCount = pagerInfo.RecordCount;
            //this.winGridViewPager1.DataSource = new Hades.Pager.WinControl.SortableBindingList<LaborSalaryRecordInfo>(list);
            //   this.winGridViewPager1.PrintTitle = "LaborSalaryRecord����";
         }
        
   
    

    }
}

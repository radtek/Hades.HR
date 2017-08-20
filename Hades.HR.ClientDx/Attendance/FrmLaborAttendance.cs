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

namespace Hades.HR.UI
{
    /// <summary>
    /// LaborAttendanceRecord
    /// </summary>	
    public partial class FrmLaborAttendance : BaseDock
    {
        #region Field
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;
        #endregion //Field

        #region Constructor
        public FrmLaborAttendance()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvRecord.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.wgvRecord.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvRecord.ShowLineNumber = true;
            this.wgvRecord.BestFitColumnWith = true;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
            this.wgvRecord.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.wgvRecord.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);
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

        /// <summary>
        /// ��ʼ���������б�
        /// </summary>
        private void InitWorkTeam()
        {
            var companys = CallerFactory<IDepartmentService>.Instance.Find("Type=2");
            var lines = CallerFactory<IProductionLineService>.Instance.Find("");
            var teams = CallerFactory<IWorkTeamService>.Instance.Find("");

            foreach (var com in companys)
            {
                TreeNode comNode = new TreeNode { Name = com.Id, Text = com.Name, Tag = 1 };
                var node = this.tvLine.Nodes.Add(comNode);

                var lines2 = lines.Where(r => r.CompanyId == com.Id);
                foreach (var line in lines2)
                {
                    TreeNode lineNode = new TreeNode { Name = line.Id, Text = line.Name, Tag = 2 };
                    var node2 = comNode.Nodes.Add(lineNode);

                    var teams2 = teams.Where(r => r.ProductionLineId == line.Id);
                    foreach (var team in teams2)
                    {
                        TreeNode teamNode = new TreeNode { Name = team.Id, Text = team.Name, Tag = 3 };
                        lineNode.Nodes.Add(teamNode);
                    }
                }
            }
        }

        /// <summary>
        /// ���б�����
        /// </summary>
        private void LoadRecordData()
        {
            //entity
            this.wgvRecord.DisplayColumns = "WorkTeamName,Number,Name,AttendanceDate,Workload,AbsentType,IsWeekend,IsHoliday,Remark";
            this.wgvRecord.ColumnNameAlias = CallerFactory<ILaborAttendanceRecordViewService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            string where = GetConditionSql();
            PagerInfo pagerInfo = this.wgvRecord.PagerInfo;
            List<LaborAttendanceRecordViewInfo> list = CallerFactory<ILaborAttendanceRecordViewService>.Instance.FindWithPager(where, ref pagerInfo);
            this.wgvRecord.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvRecord.DataSource = new Hades.Pager.WinControl.SortableBindingList<LaborAttendanceRecordViewInfo>(list);
            this.wgvRecord.PrintTitle = "���ڼ�¼����";
        }

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
                condition.AddCondition("AttendanceDate", this.dpAttendance.DateTime.Date, SqlOperator.Equal);

                var node = this.tvLine.SelectedNode;
                if (node == null && Convert.ToInt32(node.Tag) == 3)
                {
                    condition.AddCondition("WorkTeamId", node.Name, SqlOperator.Equal);
                }
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            InitWorkTeam();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ��������ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpAttendance_EditValueChanged(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// �༭���ڼ�¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            var node = this.tvLine.SelectedNode;
            if (node == null || Convert.ToInt32(node.Tag) != 3)
            {
                MessageDxUtil.ShowWarning("��ѡ�����");
                return;
            }
            if (this.dpAttendance.EditValue == null)
            {
                MessageDxUtil.ShowWarning("��ѡ��������");
                return;
            }

            var teamId = node.Name;
            var date = this.dpAttendance.DateTime.Date;

            FrmEditLaborAttendanceRecord dlg = new FrmEditLaborAttendanceRecord(date, teamId);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadRecordData();
            }
        }

        /// <summary>
        /// ��ҳ�ؼ�ˢ�²���
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        /// <summary>
        /// ��ҳ�ؼ���ҳ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            LoadRecordData();
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
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");//yyyy-MM-dd
                    }
                }
            }
            else if (columnName == "AbsentType")
            {
                e.DisplayText = ((AbsentType)e.Value).DisplayName();
            }
        }


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
        #endregion //Event
    }
}

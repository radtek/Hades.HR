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
    /// WorkSectionLabor
    /// </summary>	
    public partial class FrmWorkSectionLabor : BaseDock
    {
        #region Constructor
        public FrmWorkSectionLabor()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvLabor.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvLabor.AppendedMenu = this.contextMenuStrip1;
            this.wgvLabor.ShowLineNumber = true;
            this.wgvLabor.BestFitColumnWith = true;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������

            this.wgvLabor.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.wgvLabor.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

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
        /// ���ݲ�ѯ���������ѯ���
        /// </summary> 
        private string GetConditionSql()
        {
            //������ڸ߼���ѯ������Ϣ����ʹ�ø߼���ѯ����������ʹ������������ѯ
            SearchCondition condition = new SearchCondition(); ;

            var teamId = this.treeLine.GetSelectedTeamId();
            condition.AddCondition("WorkTeamId", teamId, SqlOperator.Equal);

            var date = this.dpDate.DateTime;
            condition.AddCondition("Year", date.Year, SqlOperator.Equal);
            condition.AddCondition("Month", date.Month, SqlOperator.Equal);

            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// ���б�����
        /// </summary>
        private void BindData()
        {
            //entity
            this.wgvLabor.DisplayColumns = "WorkTeamName,WorkSectionName,Number,Name,StaffLevelName,InPosition,Remark";
            this.wgvLabor.ColumnNameAlias = CallerFactory<IWorkSectionLaborViewService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            string where = GetConditionSql();

            var list = CallerFactory<IWorkSectionLaborViewService>.Instance.Find2(where, "ORDER BY SortCode");

            this.wgvLabor.DataSource = list;
            this.wgvLabor.PrintTitle = "WorkSectionLabor����";
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            this.dpDate.DateTime = DateTime.Now;
            this.treeLine.Init();
        }
        #endregion //Method


        #region Event
        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeLine_TeamSeleted(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// �·�ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpDate_EditValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// �༭����ְԱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var teamId = this.treeLine.GetSelectedTeamId();

            if (string.IsNullOrEmpty(teamId))
            {
                return;
            }
            else
            {
                var date = this.dpDate.DateTime;
                FrmEditWorkSectionLabor frm = new FrmEditWorkSectionLabor(date.Year, date.Month, teamId);
                frm.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
                frm.ShowDialog();

                BindData();
            }
        }

        /// <summary>
        /// ��ҳ�ؼ�ˢ�²���
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
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
            else if (columnName == "InPosition")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "�ڸ�" : "���ڸ�";
            }
        }
        #endregion //Event
    }
}

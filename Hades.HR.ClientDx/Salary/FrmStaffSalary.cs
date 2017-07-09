using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Hades.Dictionary;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using Hades.Framework.ControlUtil;
using Hades.Framework.ControlUtil.Facade;
using Hades.HR.Entity;
using Hades.HR.Facade;
using Hades.Pager.Entity;

namespace Hades.HR.UI
{
    /// <summary>
    /// Ա��������Ϣ
    /// </summary>	
    public partial class FrmStaffSalary : BaseDock
    {
        #region Field
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;
        #endregion //Field

        #region Constructor
        public FrmStaffSalary()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvStaffSalary.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.wgvStaffSalary.OnEditSelected += new EventHandler(menuEditSalary_Click);
            this.wgvStaffSalary.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            //this.wgvStaffSalary.AppendedMenu = this.contextMenuStrip1;
            this.wgvStaffSalary.ShowLineNumber = true;
            this.wgvStaffSalary.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
          
            //�����س������в�ѯ
            foreach (Control control in this.layoutControl1.Controls)
            {
                control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
            }
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
        /// ���б�����
        /// </summary>
        private void BindData()
        {
            //entity
            this.wgvStaffSalary.DisplayColumns = "Number,Name,FinanceDepartment,CardNumber,BaseSalary,BaseBonus,DepartmentBonus,ReserveFund,Insurance";
            this.wgvStaffSalary.ColumnNameAlias = CallerFactory<IStaffSalaryViewService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            string where = GetConditionSql();
            PagerInfo pagerInfo = this.wgvStaffSalary.PagerInfo;
            List<StaffSalaryViewInfo> list = CallerFactory<IStaffSalaryViewService>.Instance.FindWithPager(where, ref pagerInfo);

            this.wgvStaffSalary.PagerInfo.RecordCount = pagerInfo.RecordCount;
            this.wgvStaffSalary.DataSource = new Hades.Pager.WinControl.SortableBindingList<StaffSalaryViewInfo>(list);
            this.wgvStaffSalary.PrintTitle = "Ա�����ʻ�����Ϣ";
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
                condition.AddCondition("Name", this.txtName.Text.Trim(), SqlOperator.Like);

                var dep = this.depTree.GetSelectedObject();
                if (dep != null && !string.IsNullOrEmpty(dep.PID))
                {
                    var departments = CallerFactory<IDepartmentService>.Instance.FindWithChildren(dep.Id);

                    var idList = departments.Select(r => r.Id).ToList();
                    string ids = string.Join(",", idList);
                    ids = ids.TransSQLInStrFormat();

                    condition.AddCondition("FinanceDepartment", ids, SqlOperator.In);
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
            this.depTree.DataSource = CallerFactory<IDepartmentService>.Instance.Find2("deleted=0", "ORDER BY SortCode");
            this.depTree.Expand();

            BindData();
        }

        #endregion //Method

        #region Event
        #region Grid Event
        /// <summary>
        /// ��ҳ�ؼ�ˢ�²���
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
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
        /// �Զ�����ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (columnName == "FinanceDepartment" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var dep = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = dep.Name;
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

        #endregion //Grid Event

        /// <summary>
        /// �ṩ���ؼ��س�ִ�в�ѯ�Ĳ���
        /// </summary>
        private void SearchControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// ��ѯ���ݲ���
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            advanceCondition = null;//�������ò�ѯ������������ܻ�ʹ�ø߼���ѯ������
            BindData();
        }

        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentSelect(object sender, EventArgs e)
        {
            BindData();
        }

        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// �༭������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditSalary_Click(object sender, EventArgs e)
        {
            string ID = this.wgvStaffSalary.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvStaffSalary.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvStaffSalary.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmStaffSalaryEdit dlg = new FrmStaffSalaryEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    BindData();
                }
            }
        }
        #endregion //Event
        

        /// <summary>
        /// �����ݺ󣬷�����еĿ��
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.wgvStaffSalary.gridView1.Columns.Count > 0 && this.wgvStaffSalary.gridView1.RowCount > 0)
            {
                //ͳһ����100���
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.wgvStaffSalary.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //�����������ر�Ŀ��
                //SetGridColumWidth("Note", 200);
            }
        }

        private void SetGridColumWidth(string columnName, int width)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = this.wgvStaffSalary.gridView1.Columns.ColumnByFieldName(columnName);
            if (column != null)
            {
                column.Width = width;
            }
        }



        /// <summary>
        /// ��ҳ�ؼ�ȫ����������ǰ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.wgvStaffSalary.AllToExport = CallerFactory<IStaffSalaryService>.Instance.FindToDataTable(where);
        }





        private string moduleName = "StaffSalary";
        /// <summary>
        /// ����Excel�Ĳ���
        /// </summary>          
        private void btnImport_Click(object sender, EventArgs e)
        {
            string templateFile = string.Format("{0}-ģ��.xls", moduleName);
            FrmImportExcelData dlg = new FrmImportExcelData();
            dlg.SetTemplate(templateFile, System.IO.Path.Combine(Application.StartupPath, templateFile));
            dlg.OnDataSave += new FrmImportExcelData.SaveDataHandler(ExcelData_OnDataSave);
            dlg.OnRefreshData += new EventHandler(ExcelData_OnRefreshData);
            dlg.ShowDialog();
        }

        void ExcelData_OnRefreshData(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// ����ֶδ��ڣ����ȡ��Ӧ��ֵ�����򷵻�Ĭ�Ͽ�
        /// </summary>
        /// <param name="row">DataRow����</param>
        /// <param name="columnName">�ֶ�����</param>
        /// <returns></returns>
        private string GetRowData(DataRow row, string columnName)
        {
            string result = "";
            if (row.Table.Columns.Contains(columnName))
            {
                result = row[columnName].ToString();
            }
            return result;
        }

        bool ExcelData_OnDataSave(DataRow dr)
        {
            bool success = false;
            bool converted = false;
            DateTime dtDefault = Convert.ToDateTime("1900-01-01");
            DateTime dt;
            StaffSalaryInfo info = new StaffSalaryInfo();
            //info.Id = GetRowData(dr, "Id");
            //  info.FinanceDepartment = GetRowData(dr, "FinanceDepartment");
            info.CardNumber = GetRowData(dr, "CardNumber");
            info.BaseSalary = GetRowData(dr, "BaseSalary").ToDecimal();
            info.BaseBonus = GetRowData(dr, "BaseBonus").ToDecimal();
            info.DepartmentBonus = GetRowData(dr, "DepartmentBonus").ToDecimal();
            info.ReserveFund = GetRowData(dr, "ReserveFund").ToDecimal();
            info.Insurance = GetRowData(dr, "Insurance").ToDecimal();

            success = CallerFactory<IStaffSalaryService>.Instance.Insert(info);
            return success;
        }

        /// <summary>
        /// ����Excel�Ĳ���
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            if (!string.IsNullOrEmpty(file))
            {
                string where = GetConditionSql();
                List<StaffSalaryInfo> list = CallerFactory<IStaffSalaryService>.Instance.Find(where);
                DataTable dtNew = DataTableHelper.CreateTable("���|int,Id,FinanceDepartment,CardNumber,BaseSalary,BaseBonus,DepartmentBonus,ReserveFund,Insurance");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["���"] = j++;
                    dr["Id"] = list[i].Id;
                    dr["FinanceDepartment"] = list[i].FinanceDepartment;
                    dr["CardNumber"] = list[i].CardNumber;
                    dr["BaseSalary"] = list[i].BaseSalary;
                    dr["BaseBonus"] = list[i].BaseBonus;
                    dr["DepartmentBonus"] = list[i].DepartmentBonus;
                    dr["ReserveFund"] = list[i].ReserveFund;
                    dr["Insurance"] = list[i].Insurance;
                    dtNew.Rows.Add(dr);
                }

                try
                {
                    string error = "";
                    AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageDxUtil.ShowError(string.Format("����Excel���ִ���{0}", error));
                    }
                    else
                    {
                        if (MessageDxUtil.ShowYesNoAndTips("�����ɹ����Ƿ���ļ���") == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
        }
    }
}

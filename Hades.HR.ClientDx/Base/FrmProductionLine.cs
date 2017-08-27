using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
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
    /// ���߹�����
    /// </summary>	
    public partial class FrmProductionLine : BaseDock
    {
        #region Field
        private List<DepartmentInfo> departments;
        #endregion //Field

        #region Constructor
        public FrmProductionLine()
        {
            InitializeComponent();

            InitDictItem();
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
        /// ���벿������
        /// </summary>
        private void LoadDepartments()
        {
            this.depTree.Init(2);
        }

        /// <summary>
        /// ���빫˾��������
        /// </summary>
        /// <param name="department"></param>
        private void LoadProductionLines(DepartmentInfo department)
        {
            var lines = CallerFactory<IProductionLineService>.Instance.Find2(string.Format("CompanyId='{0}' AND Deleted=0", department.Id), "ORDER BY SortCode");

            this.wgvProductionLine.DisplayColumns = "Name,Number,CompanyId,SortCode,Remark,Enabled";
            this.wgvProductionLine.ColumnNameAlias = CallerFactory<IProductionLineService>.Instance.GetColumnNameAlias();

            this.wgvProductionLine.DataSource = lines;
            this.wgvProductionLine.PrintTitle = "���߱���";
        }

        /// <summary>
        /// ������߰�������
        /// </summary>
        /// <param name="productionLineId"></param>
        private void LoadWorkTeams(string productionLineId)
        {
            var teams = CallerFactory<IWorkTeamService>.Instance.Find2(string.Format("ProductionLineId='{0}' AND Deleted=0", productionLineId), "ORDER BY SortCode");

            this.wgvWorkTeam.DisplayColumns = "Name,Number,CompanyId,ProductionLineId,Quota,SortCode,Remark,Enabled";
            this.wgvWorkTeam.ColumnNameAlias = CallerFactory<IWorkTeamService>.Instance.GetColumnNameAlias();

            this.wgvWorkTeam.DataSource = teams;
            this.wgvWorkTeam.PrintTitle = "���鱨��";
        }

        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="workTeamId"></param>
        private void LoadWorkSections(string workTeamId)
        {
            var sections = CallerFactory<IWorkSectionService>.Instance.Find2(string.Format("WorkTeamId='{0}' AND Deleted=0", workTeamId), "ORDER BY SortCode");

            this.wgvWorkSection.DisplayColumns = "Name,Number,WorkTeamId,SortCode,Remark,Enabled";
            this.wgvWorkSection.ColumnNameAlias = CallerFactory<IWorkSectionService>.Instance.GetColumnNameAlias();

            this.wgvWorkSection.DataSource = sections;
            this.wgvWorkSection.PrintTitle = "���α���";
        }
        #endregion //Function


        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            this.departments = CallerFactory<IDepartmentService>.Instance.Find2("Enabled=1 AND Deleted=0", "");

            LoadDepartments();

            this.depTree.Expand();

            this.wgvProductionLine.AppendedMenu = this.contextMenuStrip1;
            this.wgvProductionLine.ShowLineNumber = true;
            this.wgvProductionLine.BestFitColumnWith = true;
            this.wgvProductionLine.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvProductionLine_CustomColumnDisplayText);

            this.wgvWorkTeam.AppendedMenu = this.contextMenuStrip2;
            this.wgvWorkTeam.ShowLineNumber = true;
            this.wgvWorkTeam.BestFitColumnWith = true;
            this.wgvWorkTeam.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvWorkTeam_CustomColumnDisplayText);

            this.wgvWorkSection.AppendedMenu = this.contextMenuStrip3;
            this.wgvWorkSection.ShowLineNumber = true;
            this.wgvWorkSection.BestFitColumnWith = true;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentSelect(object sender, EventArgs e)
        {
            var department = this.depTree.GetSelectedObject();
            if (department != null)
            {
                this.txtDepartmentName.Text = department.Name;
                this.txtDepartmentNumber.Text = department.Number;
             
                LoadProductionLines(department);
                //LoadWorkTeams(department);
                //LoadWarehouse(department);
            }
        }        

        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        #region Menu Event
        /// <summary>
        /// �˵� - ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddLine_Click(object sender, EventArgs e)
        {
            FrmProductionLineEdit dlg = new FrmProductionLineEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadDepartments();
            }
        }

        /// <summary>
        /// �˵� - �༭����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditLine_Click(object sender, EventArgs e)
        {
            string ID = this.wgvProductionLine.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvProductionLine.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvProductionLine.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmProductionLineEdit dlg = new FrmProductionLineEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadDepartments();
                }
            }
        }

        /// <summary>
        /// �˵� - ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeleteLine_Click(object sender, EventArgs e)
        {
            string id = this.wgvProductionLine.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���Ĳ���ô��") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IProductionLineService>.Instance.MarkDelete(id);
            LoadDepartments();
        }

        /// <summary>
        /// �˵� - ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddTeam_Click(object sender, EventArgs e)
        {
            FrmWorkTeamEdit dlg = new FrmWorkTeamEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadDepartments();
            }
        }

        /// <summary>
        /// �˵� - �༭����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditTeam_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkTeam.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvWorkTeam.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvWorkTeam.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmWorkTeamEdit dlg = new FrmWorkTeamEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadDepartments();
                }
            }
        }

        /// <summary>
        /// �˵� - ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeleteTeam_Click(object sender, EventArgs e)
        {
            string id = this.wgvWorkTeam.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���Ĳ���ô��") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IWorkTeamService>.Instance.MarkDelete(id);
            LoadDepartments();
        }

        /// <summary>
        /// �˵� - ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddSection_Click(object sender, EventArgs e)
        {
            FrmWorkSectionEdit dlg = new FrmWorkSectionEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadDepartments();
            }
        }

        /// <summary>
        /// �˵� - �༭����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditSection_Click(object sender, EventArgs e)
        {
            string ID = this.wgvWorkSection.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvWorkSection.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvWorkSection.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmWorkSectionEdit dlg = new FrmWorkSectionEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadDepartments();
                }
            }
        }

        private void menuDeleteSection_Click(object sender, EventArgs e)
        {

        }
        #endregion //Menu Event

        /// <summary>
        /// ��ʽ�������б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvProductionLine_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "CompanyId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var dep = this.departments.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (dep != null)
                    {
                        e.DisplayText = dep.Name;
                    }
                    else
                    {
                        var dep2 = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = dep.Name;
                    }                    
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "������" : "δ����";
            }
        }

        /// <summary>
        /// ��ʽ�������б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvWorkTeam_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "CompanyId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var dep = this.departments.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (dep != null)
                    {
                        e.DisplayText = dep.Name;
                    }
                    else
                    {
                        var dep2 = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = dep.Name;
                    }
                }
            }
            else if (columnName == "ProductionLineId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var line = CallerFactory<IProductionLineService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = line.Name;
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "������" : "δ����";
            }
        }

        /// <summary>
        /// ��ʽ�������б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvWorkSection_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "CompanyId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var dep = this.departments.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (dep != null)
                    {
                        e.DisplayText = dep.Name;
                    }
                    else
                    {
                        var dep2 = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                        e.DisplayText = dep.Name;
                    }
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "������" : "δ����";
            }
        }

        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wgvProductionLine_OnGridViewMouseClick(object sender, EventArgs e)
        {
            string id = this.wgvProductionLine.gridView1.GetFocusedRowCellDisplayText("Id");

            LoadWorkTeams(id);
        }
        
        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wgvWorkTeam_OnGridViewMouseClick(object sender, EventArgs e)
        {
            string id = this.wgvWorkTeam.gridView1.GetFocusedRowCellDisplayText("Id");

            LoadWorkSections(id);
        }
        #endregion //Event
    }
}

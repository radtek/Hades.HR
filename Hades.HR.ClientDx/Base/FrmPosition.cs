using System;
using System.Text;
using System.Data;
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
    /// ��λ���߰��������
    /// </summary>	
    public partial class FrmPosition : BaseDock
    {
        #region Constructor
        public FrmPosition()
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
            var departments = CallerFactory<IDepartmentService>.Instance.Find2("deleted=0", "ORDER BY SortCode");
            this.depTree.DataSource = departments;
        }

        /// <summary>
        /// ���벿�Ű�����λ
        /// </summary>
        /// <param name="department"></param>
        private void LoadPositions(DepartmentInfo department)
        {
            var positions = CallerFactory<IPositionService>.Instance.Find2(string.Format("departmentId='{0}' AND Deleted=0", department.Id), "ORDER BY SortCode");

            this.wgvPosition.DisplayColumns = "Name,Number,DepartmentId,Quota,SortCode,Remark,Enabled";
            this.wgvPosition.ColumnNameAlias = CallerFactory<IPositionService>.Instance.GetColumnNameAlias();

            this.wgvPosition.DataSource = positions;
            this.wgvPosition.PrintTitle = "��λ����";
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
        /// ���벿�Ű�������
        /// </summary>
        /// <param name="department"></param>
        private void LoadWorkTeams(DepartmentInfo department)
        {
            var teams = CallerFactory<IWorkTeamService>.Instance.Find2(string.Format("CompanyId='{0}' AND Deleted=0", department.Id), "ORDER BY SortCode");

            this.wgvWorkTeam.DisplayColumns = "Name,Number,CompanyId,ProductionLineId,SortCode,Remark,Enabled";
            this.wgvWorkTeam.ColumnNameAlias = CallerFactory<IWorkTeamService>.Instance.GetColumnNameAlias();

            this.wgvWorkTeam.DataSource = teams;
            this.wgvWorkTeam.PrintTitle = "���鱨��";
        }

        /// <summary>
        /// �鿴��λ
        /// </summary>
        private void ViewPosition()
        {
            string ID = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvPosition.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvPosition.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmPositionView dlg = new FrmPositionView();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);
                dlg.ShowDialog();
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            LoadDepartments();

            this.depTree.Expand();

            this.wgvPosition.AppendedMenu = this.contextMenuStrip1;
            this.wgvPosition.ShowLineNumber = true;
            this.wgvPosition.BestFitColumnWith = true;
            this.wgvPosition.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvPosition_CustomColumnDisplayText);

            this.wgvProductionLine.AppendedMenu = this.contextMenuStrip2;
            this.wgvProductionLine.ShowLineNumber = true;
            this.wgvProductionLine.BestFitColumnWith = true;
            this.wgvProductionLine.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvProductionLine_CustomColumnDisplayText);

            this.wgvWorkTeam.AppendedMenu = this.contextMenuStrip3;
            this.wgvWorkTeam.ShowLineNumber = true;
            this.wgvWorkTeam.BestFitColumnWith = true;
            this.wgvWorkTeam.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvWorkTeam_CustomColumnDisplayText);
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// ѡ����
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

                LoadPositions(department);
                LoadProductionLines(department);
                LoadWorkTeams(department);
            }
        }

        /// <summary>
        /// �˵� - �鿴��λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuViewPosition_Click(object sender, EventArgs e)
        {
            ViewPosition();
        }

        /// <summary>
        /// �˵� - ������λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddPosition_Click(object sender, EventArgs e)
        {
            FrmPositionEdit dlg = new FrmPositionEdit();
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadDepartments();
            }
        }

        /// <summary>
        /// �˵� - �༭��λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditPosition_Click(object sender, EventArgs e)
        {
            string ID = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvPosition.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvPosition.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmPositionEdit dlg = new FrmPositionEdit();
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
        /// �˵� - ɾ����λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeletePosition_Click(object sender, EventArgs e)
        {
            string id = this.wgvPosition.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���ļ�¼ô��") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IPositionService>.Instance.MarkDelete(id);
            LoadDepartments();
        }

        /// <summary>
        /// �˵� - ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddLine_Click(object sender, EventArgs e)
        {
            FrmProductionLineEdit dlg = new FrmProductionLineEdit();
            //dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
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
            // dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
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

        #region Grid Event
        /// <summary>
        /// ˫����λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wgvPosition_OnGridViewMouseDoubleClick(object sender, EventArgs e)
        {
            ViewPosition();
        }

        /// <summary>
        /// ��ʽ����λ�б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wgvPosition_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            else if (columnName == "DepartmentId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var dep = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = dep.Name;
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
        void wgvProductionLine_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string columnName = e.Column.FieldName;
            if (columnName == "CompanyId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var dep = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = dep.Name;
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
                    var dep = CallerFactory<IDepartmentService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = dep.Name;
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
        #endregion //Grid Event

        #endregion //Event
    }
}

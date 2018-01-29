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
using Hades.Framework.ControlUtil.Facade;

using Hades.HR.Facade;
using Hades.HR.Entity;
using Hades.Framework.ControlUtil;

namespace Hades.HR.UI
{
    /// <summary>
    /// ְԱ������
    /// </summary>	
    public partial class FrmStaff : BaseDock
    {
        #region Field
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;

        /// <summary>
        /// ���沿����Ϣ
        /// </summary>
        private List<DepartmentInfo> departmentList;
        #endregion //Field

        #region Constructor
        public FrmStaff()
        {
            InitializeComponent();

            InitDictItem();

            this.wgvStaff.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            //this.wgvStaff.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            //this.wgvStaff.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            this.wgvStaff.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.wgvStaff.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.wgvStaff.AppendedMenu = this.contextMenuStrip1;
            this.wgvStaff.ShowLineNumber = true;
            this.wgvStaff.BestFitColumnWith = false;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
            this.wgvStaff.gridView1.DataSourceChanged += new EventHandler(gridView1_DataSourceChanged);
            this.wgvStaff.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(wgvStaff_CustomColumnDisplayText);
            this.wgvStaff.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

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
            this.wgvStaff.DisplayColumns = "Number,Name,StaffType,CompanyId,DepartmentId,PositionId,Gender,Birthday,NativePlace,Nationality,IdentityCard,Phone,OfficePhone,Email,HomeAddress,Political,PartyDate,Education,Degree,WorkingDate,Marriage,ChildStatus,Titles,Duty,JobType,Enabled";
            this.wgvStaff.ColumnNameAlias = CallerFactory<IStaffService>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            string where = GetConditionSql();
            var page = this.wgvStaff.PagerInfo;
            List<StaffInfo> list = CallerFactory<IStaffService>.Instance.FindWithPager(where, ref page);
            this.wgvStaff.DataSource = list;//new Hades.Pager.WinControl.SortableBindingList<StaffInfo>(list);
            this.wgvStaff.PrintTitle = "ְԱ����";
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
                condition.AddCondition("Number", this.txtNumber.Text.Trim(), SqlOperator.Like);
                condition.AddCondition("Name", this.txtName.Text.Trim(), SqlOperator.Like);
                condition.AddCondition("IdentityCard", this.txtIdentityCard.Text.Trim(), SqlOperator.Like);
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }

        /// <summary>
        /// �鿴ְԱ
        /// </summary>
        private void ViewStaff()
        {
            string ID = this.wgvStaff.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvStaff.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvStaff.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmStaffView dlg = new FrmStaffView();
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
            this.departmentList = CallerFactory<IDepartmentService>.Instance.Find("");
            BindData();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// �˵� - �鿴ְԱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuViewStaff_Click(object sender, EventArgs e)
        {
            ViewStaff();
        }

        /// <summary>
        /// �˵� - ����ְԱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddStaff_Click(object sender, EventArgs e)
        {
            FrmStaffEdit dlg = new FrmStaffEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }

        /// <summary>
        /// �˵� - �༭ְԱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditStaff_Click(object sender, EventArgs e)
        {
            string ID = this.wgvStaff.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvStaff.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvStaff.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmStaffEdit dlg = new FrmStaffEdit();
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

        /// <summary>
        /// �༭����������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditBaseSalary_Click(object sender, EventArgs e)
        {
            string ID = this.wgvStaff.gridView1.GetFocusedRowCellDisplayText("Id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.wgvStaff.gridView1.RowCount; i++)
            {
                string strTemp = this.wgvStaff.GridView1.GetRowCellDisplayText(i, "Id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditSalaryBase dlg = new FrmEditSalaryBase();
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

        private void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
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
        /// �ṩ���ؼ��س�ִ�в�ѯ�Ĳ���
        /// </summary>
        private void SearchControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        #region Grid Event
        void wgvStaff_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            else if (columnName == "CompanyId" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (e.Value != null)
                {
                    var company = this.departmentList.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (company != null)
                    {
                        e.DisplayText = company.Name;
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
            else if (columnName == "PositionId")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    var pos = CallerFactory<IPositionService>.Instance.FindByID(e.Value.ToString());
                    e.DisplayText = pos.Name;
                }
            }
            else if (columnName == "Enabled")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "������" : "δ����";
            }
            else if (columnName == "StaffType")
            {
                e.DisplayText = Convert.ToInt32(e.Value) == 1 ? "����Ա��" : "�Ƽ�Ա��";
            }
        }

        /// <summary>
        /// �����ݺ󣬷�����еĿ��
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.wgvStaff.gridView1.Columns.Count > 0 && this.wgvStaff.gridView1.RowCount > 0)
            {
                //ͳһ����100���
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.wgvStaff.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //�����������ر�Ŀ��
                //SetGridColumWidth("Note", 200);
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

        /// <summary>
        /// ��ҳ�ؼ���������
        /// </summary>
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            menuAddStaff_Click(null, null);
        }

        /// <summary>
        /// ��ҳ�ؼ�ɾ������
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            string id = this.wgvStaff.gridView1.GetFocusedRowCellDisplayText("Id");
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���ļ�¼ô��") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IStaffService>.Instance.MarkDelete(id);

            BindData();
        }

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
        /// ˫���ؼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wgvStaff_OnGridViewMouseDoubleClick(object sender, EventArgs e)
        {
            ViewStaff();
        }
        #endregion //Grid Event
        #endregion //Event

        #region System
        /// <summary>
        /// ��ҳ�ؼ�ȫ����������ǰ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.wgvStaff.AllToExport = CallerFactory<IStaffService>.Instance.FindToDataTable(where);
        }


        private string moduleName = "Staff";
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
            StaffInfo info = new StaffInfo();
            info.Id = GetRowData(dr, "Id");
            info.Number = GetRowData(dr, "Number");
            info.Name = GetRowData(dr, "Name");
            info.Gender = GetRowData(dr, "Gender");

            string Birthday = GetRowData(dr, "Birthday");
            if (!string.IsNullOrEmpty(Birthday))
            {
                converted = DateTime.TryParse(Birthday, out dt);
                if (converted && dt > dtDefault)
                {
                    info.Birthday = dt;
                }
            }
            else
            {
                info.Birthday = DateTime.Now;
            }

            info.NativePlace = GetRowData(dr, "NativePlace");
            info.Nationality = GetRowData(dr, "Nationality");
            info.IdentityCard = GetRowData(dr, "IdentityCard");
            info.Phone = GetRowData(dr, "Phone");
            info.OfficePhone = GetRowData(dr, "OfficePhone");
            info.Email = GetRowData(dr, "Email");
            info.HomeAddress = GetRowData(dr, "HomeAddress");
            info.Political = GetRowData(dr, "Political");

            string PartyDate = GetRowData(dr, "PartyDate");
            if (!string.IsNullOrEmpty(PartyDate))
            {
                converted = DateTime.TryParse(PartyDate, out dt);
                if (converted && dt > dtDefault)
                {
                    info.PartyDate = dt;
                }
            }
            else
            {
                info.PartyDate = DateTime.Now;
            }

            info.Education = GetRowData(dr, "Education");
            info.Degree = GetRowData(dr, "Degree");
            //info.WorkingDate = GetRowData(dr, "WorkingDate");
            info.Marriage = GetRowData(dr, "Marriage");
            info.ChildStatus = GetRowData(dr, "ChildStatus");
            info.Titles = GetRowData(dr, "Titles");
            info.Duty = GetRowData(dr, "Duty");
            info.JobType = GetRowData(dr, "JobType");
            info.Introduce = GetRowData(dr, "Introduce");
            info.Remark = GetRowData(dr, "Remark");
            info.AttachId = GetRowData(dr, "AttachId");
            info.CompanyId = GetRowData(dr, "CompanyId");
            info.DepartmentId = GetRowData(dr, "DepartmentId");
            info.PositionId = GetRowData(dr, "PositionId");
            info.Creator = GetRowData(dr, "Creator");
            info.CreatorId = GetRowData(dr, "CreatorId");

            string CreateTime = GetRowData(dr, "CreateTime");
            if (!string.IsNullOrEmpty(CreateTime))
            {
                converted = DateTime.TryParse(CreateTime, out dt);
                if (converted && dt > dtDefault)
                {
                    info.CreateTime = dt;
                }
            }
            else
            {
                info.CreateTime = DateTime.Now;
            }

            info.EditorId = GetRowData(dr, "EditorId");
            info.Deleted = GetRowData(dr, "Deleted").ToInt32();
            info.Enabled = GetRowData(dr, "Enabled").ToInt32();

            success = CallerFactory<IStaffService>.Instance.Insert(info);
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
                List<StaffInfo> list = CallerFactory<IStaffService>.Instance.Find(where);
                DataTable dtNew = DataTableHelper.CreateTable("���|int,Id,Number,Name,Gender,Birthday,NativePlace,Nationality,IdentityCard,Phone,OfficePhone,Email,HomeAddress,Political,PartyDate,Education,Degree,WorkingDate,Marriage,ChildStatus,Titles,Duty,JobType,Introduce,Remark,AttachId,CompanyId,DepartmentId,PositionId,Creator,CreatorId,CreateTime,EditorId,Deleted,Enabled");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["���"] = j++;
                    dr["Id"] = list[i].Id;
                    dr["Number"] = list[i].Number;
                    dr["Name"] = list[i].Name;
                    dr["Gender"] = list[i].Gender;
                    dr["Birthday"] = list[i].Birthday;
                    dr["NativePlace"] = list[i].NativePlace;
                    dr["Nationality"] = list[i].Nationality;
                    dr["IdentityCard"] = list[i].IdentityCard;
                    dr["Phone"] = list[i].Phone;
                    dr["OfficePhone"] = list[i].OfficePhone;
                    dr["Email"] = list[i].Email;
                    dr["HomeAddress"] = list[i].HomeAddress;
                    dr["Political"] = list[i].Political;
                    dr["PartyDate"] = list[i].PartyDate;
                    dr["Education"] = list[i].Education;
                    dr["Degree"] = list[i].Degree;
                    dr["WorkingDate"] = list[i].WorkingDate;
                    dr["Marriage"] = list[i].Marriage;
                    dr["ChildStatus"] = list[i].ChildStatus;
                    dr["Titles"] = list[i].Titles;
                    dr["Duty"] = list[i].Duty;
                    dr["JobType"] = list[i].JobType;
                    dr["Introduce"] = list[i].Introduce;
                    dr["Remark"] = list[i].Remark;
                    dr["AttachId"] = list[i].AttachId;
                    dr["CompanyId"] = list[i].CompanyId;
                    dr["DepartmentId"] = list[i].DepartmentId;
                    dr["PositionId"] = list[i].PositionId;
                    dr["Creator"] = list[i].Creator;
                    dr["CreatorId"] = list[i].CreatorId;
                    dr["CreateTime"] = list[i].CreateTime;
                    dr["EditorId"] = list[i].EditorId;
                    dr["Deleted"] = list[i].Deleted;
                    dr["Enabled"] = list[i].Enabled;
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

        private FrmAdvanceSearch dlg;
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            if (dlg == null)
            {
                dlg = new FrmAdvanceSearch();
                dlg.FieldTypeTable = CallerFactory<IStaffService>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = CallerFactory<IStaffService>.Instance.GetColumnNameAlias();
                dlg.DisplayColumns = "Id,Number,Name,Gender,Birthday,NativePlace,Nationality,IdentityCard,Phone,OfficePhone,Email,HomeAddress,Political,PartyDate,Education,Degree,WorkingDate,Marriage,ChildStatus,Titles,Duty,JobType,Introduce,Remark,AttachId,CompanyId,DepartmentId,PositionId,Creator,CreatorId,CreateTime,EditorId,Deleted,Enabled";

                #region �����б�����

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("��Ա����"));//�ֵ��б�
                //dlg.AddColumnListItem("Sex", "��,Ů");//�̶��б�
                //dlg.AddColumnListItem("Credit", BLLFactory<Staff>.Instance.GetFieldList("Credit"));//��̬�б�

                #endregion

                dlg.ConditionChanged += new FrmAdvanceSearch.ConditionChangedEventHandler(dlg_ConditionChanged);
            }
            dlg.ShowDialog();
        }

        void dlg_ConditionChanged(SearchCondition condition)
        {
            advanceCondition = condition;
            BindData();
        }
        #endregion //System
    }
}

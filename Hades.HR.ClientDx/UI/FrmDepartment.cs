using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// ���Ź�����
    /// </summary>	
    public partial class FrmDepartment : BaseDock
    {
        #region Constructor
        public FrmDepartment()
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
        /// ��ʼ������
        /// </summary>
        private async void LoadData()
        {
            var departments = await CallerFactory<IDepartmentService>.Instance.Find2Asyn("deleted=0", "ORDER BY SortCode");
            this.depTree.DataSource = departments;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void FormOnLoad()
        {
            LoadData();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// �Ի������ݱ���ʱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dlg_OnDataSaved(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// �������ݲ���
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmDepartmentEdit dlg = new FrmDepartmentEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadData();
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentCreate(object sender, EventArgs e)
        {
            FrmDepartmentEdit dlg = new FrmDepartmentEdit();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LoadData();
            }
        }

        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentEdit(object sender, EventArgs e)
        {
            string ID = this.depTree.GetCurrentSelectId();
            List<string> IDList = this.depTree.GetIDList();

            if (!string.IsNullOrEmpty(ID))
            {
                FrmDepartmentEdit dlg = new FrmDepartmentEdit();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// �鿴����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentView(object sender, EventArgs e)
        {
            string ID = this.depTree.GetCurrentSelectId();
            List<string> IDList = this.depTree.GetIDList();

            if (!string.IsNullOrEmpty(ID))
            {
                FrmDepartmentView dlg = new FrmDepartmentView();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.InitFunction(LoginUserInfo, FunctionDict);
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depTree_DepartmentDelete(object sender, EventArgs e)
        {
            string id = this.depTree.GetCurrentSelectId();
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���ļ�¼ô��") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IDepartmentService>.Instance.MarkDelete(id);
            LoadData();
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, EventArgs e)
        {
            string id = this.depTree.GetCurrentSelectId();
            if (string.IsNullOrEmpty(id))
                return;

            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���ļ�¼ô��") == DialogResult.No)
            {
                return;
            }

            CallerFactory<IDepartmentService>.Instance.MarkDelete(id);
            LoadData();
        }
        #endregion //Event
        

        /// <summary>
        /// ���б�����
        /// </summary>
        private void BindData()
        {
     
        }


        private string moduleName = "Department";
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
            DepartmentInfo info = new DepartmentInfo();
            info.Id = GetRowData(dr, "Id");
            info.PID = GetRowData(dr, "PID");
            info.Number = GetRowData(dr, "Number");
            info.Name = GetRowData(dr, "Name");
            info.SortCode = GetRowData(dr, "SortCode");
            info.Type = GetRowData(dr, "Type").ToInt32();
            info.Address = GetRowData(dr, "Address");
            info.InnerPhone = GetRowData(dr, "InnerPhone");
            info.OuterPhone = GetRowData(dr, "OuterPhone");
            info.Remark = GetRowData(dr, "Remark");

            string FoundDate = GetRowData(dr, "FoundDate");
            if (!string.IsNullOrEmpty(FoundDate))
            {
                converted = DateTime.TryParse(FoundDate, out dt);
                if (converted && dt > dtDefault)
                {
                    info.FoundDate = dt;
                }
            }
            else
            {
                info.FoundDate = DateTime.Now;
            }


            string CloseDate = GetRowData(dr, "CloseDate");
            if (!string.IsNullOrEmpty(CloseDate))
            {
                converted = DateTime.TryParse(CloseDate, out dt);
                if (converted && dt > dtDefault)
                {
                    info.CloseDate = dt;
                }
            }
            else
            {
                info.CloseDate = DateTime.Now;
            }

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

            //success = BLLFactory<Department>.Instance.Insert(info);
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
                List<DepartmentInfo> list = CallerFactory<IDepartmentService>.Instance.Find2("deleted=0", "ORDER BY SortCode");
                DataTable dtNew = DataTableHelper.CreateTable("���|int,Id,PID,Number,Name,SortCode,Type,Address,InnerPhone,OuterPhone,Remark,CompanyId,CompanyName,FoundDate,CloseDate,Creator,CreatorId,CreateTime,EditorId,Deleted,Enabled");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["���"] = j++;
                    dr["Id"] = list[i].Id;
                    dr["PID"] = list[i].PID;
                    dr["Number"] = list[i].Number;
                    dr["Name"] = list[i].Name;
                    dr["SortCode"] = list[i].SortCode;
                    dr["Type"] = list[i].Type;
                    dr["Address"] = list[i].Address;
                    dr["InnerPhone"] = list[i].InnerPhone;
                    dr["OuterPhone"] = list[i].OuterPhone;
                    dr["Remark"] = list[i].Remark;
                    dr["FoundDate"] = list[i].FoundDate;
                    dr["CloseDate"] = list[i].CloseDate;
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

    }
}

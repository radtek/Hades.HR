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
    public partial class FrmEditStaffSalary : BaseEditForm
    {
        #region Field
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private StaffSalaryInfo tempInfo = new StaffSalaryInfo();

        private int year;

        private int month;

        private string departmentId;

        /// <summary>
        /// ����ְԱ����
        /// </summary>
        private List<StaffInfo> staffs;

        /// <summary>
        /// ���漶������
        /// </summary>
        private List<StaffLevelInfo> levels;
        #endregion //Field

        #region Constructor
        public FrmEditStaffSalary()
        {
            InitializeComponent();
        }

        public FrmEditStaffSalary(int year, int month, string departmentId)
        {
            this.year = year;
            this.month = month;
            this.departmentId = departmentId;
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            return result;
        }

        /// <summary>
        /// ��ʼ�������ֵ�
        /// </summary>
        private void InitDictItem()
        {
            //��ʼ������
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(StaffSalaryInfo info)
        {

        }
        #endregion //Function

        #region Method
        public override void ClearScreen()
        {
            this.tempInfo = new StaffSalaryInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�

            this.Text = "�༭ְԱ����";

            this.txtMonth.Text = $"{this.year}��{this.month}��";

            var dep = CallerFactory<IDepartmentService>.Instance.FindByID(this.departmentId);
            this.txtDepartment.Text = dep.Name;

            this.staffs = CallerFactory<IStaffService>.Instance.Find("StaffType = 1");
            this.levels = CallerFactory<IStaffLevelService>.Instance.Find("");

            var data = CallerFactory<IStaffSalaryService>.Instance.GetRecords(this.year, this.month, this.departmentId);
            this.bsSalary.DataSource = data;
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            try
            {
                var data = this.bsSalary.DataSource as List<StaffSalaryInfo>;

                data.ForEach((r) =>
                {
                    r.Editor = this.LoginUserInfo.Name;
                    r.EditorId = this.LoginUserInfo.ID;
                    r.EditTime = DateTime.Now;
                });

                bool succeed = CallerFactory<IStaffSalaryService>.Instance.SaveRecords(data, this.year, this.month, this.departmentId);
                if (succeed)
                {
                    //�����������������

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }

            return false;
        }
        #endregion //Method

        #region Event
        private void dgvSalary_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            else if (columnName == "StaffLevelId")
            {
                if (e.Value != null)
                {
                    var s = this.levels.SingleOrDefault(r => r.Id == e.Value.ToString());
                    if (s == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = s.Name;
                }
            }
        }
        #endregion //Event
    }
}

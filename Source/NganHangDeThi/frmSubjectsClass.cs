using Controller.Services;
using Model.POCO;
using NganHangDeThi.Form_Popup;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class frmSubjectsClass : SimpleBaseForm<SubjectsClass, SubjectsClassService> {
        private UserService m_userService;
        private DepartmentService m_departmentService;
        private SubjectsService m_subjectsService;

        public frmSubjectsClass() {
            InitializeComponent();
            grvSubjectsClass.ShowGroupPanel = false;
            grvSubjectsClass.EnableHotTracking = true;
            grvSubjectsClass.ShowFilteringRow = false;
            grvSubjectsClass.EnableFiltering = true;
            grvSubjectsClass.EnableCustomFiltering = true;
            grvSubjectsClass.CustomFiltering += grvSubjectsClass_CustomFiltering;
            ddlFK_Department.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            m_subjectsService = new SubjectsService(Service.Context);
            m_departmentService = new DepartmentService(Service.Context);
            m_userService = new UserService(Service.Context);
            ddl_Subject.DataSource = m_subjectsService.GetAllSubject().ToList();
            ddl_Subject.DisplayMember = "Name";
            ddl_Subject.ValueMember = "SubjectId";
            // Department
            ddlFK_Department.DataSource = m_departmentService.GetAllDepartment().ToList();
            ddlFK_Department.DisplayMember = "DepartmentName";
            ddlFK_Department.ValueMember = "DepartmentId";
            // Main teacher
            ddlMainTeacher.DataSource = m_userService.GetAll().ToList();
            ddlMainTeacher.DisplayMember = "FullName";
            ddlMainTeacher.ValueMember = "TeacherId";
            // Subject teacher
            ddlSubjectTeacher.DataSource = m_userService.GetAll().ToList();
            ddlSubjectTeacher.DisplayMember = "FullName";
            ddlSubjectTeacher.ValueMember = "TeacherId";
        }

        private void grvSubjectsClass_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e) {
            if (string.IsNullOrEmpty(txtFilter.Text)) {
                e.Visible = true;
                for (int i = 0; i < grvSubjectsClass.ColumnCount; i++) {
                    e.Row.Cells[i].Style.Reset();
                    e.Row.InvalidateRow();
                }
                return;
            }
            e.Visible = false;
            for (int i = 0; i < grvSubjectsClass.ColumnCount; i++) {
                if (e.Row.Cells[i].Value != null) {
                    string text = e.Row.Cells[i].Value.ToString();
                    if (text.IndexOf(txtFilter.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0) {
                        e.Visible = true;
                        e.Row.Cells[i].Style.CustomizeFill = true;
                        e.Row.Cells[i].Style.DrawFill = true;
                        e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                    } else {
                        e.Row.Cells[i].Style.Reset(); e.Row.InvalidateRow();
                    }
                }
            }
        }

        protected override void SetBindingSource() {
            grvSubjectsClass.DataSource = BindingSource;
            // Subject
            
            
        }

        protected override void SetDetailBindingSource() {
            try {
                txtSubjectsClassNo.DataBindings.Add("Text", BindingSource, "SubjectsClassNo", false, DataSourceUpdateMode.OnPropertyChanged);
                chkOpenOut.DataBindings.Add("Checked", BindingSource, "OpenOut", false, DataSourceUpdateMode.OnPropertyChanged);
                txtSubjectsClassName.DataBindings.Add("Text", BindingSource, "SubjectsClassName", false, DataSourceUpdateMode.OnPropertyChanged);
                dtpFromDate.DataBindings.Add("Value", BindingSource, "FromDate", false, DataSourceUpdateMode.OnPropertyChanged);
                dtpToDate.DataBindings.Add("Value", BindingSource, "ToDate", false, DataSourceUpdateMode.OnPropertyChanged);
                txtPartner.DataBindings.Add("Text", BindingSource, "Partner", false, DataSourceUpdateMode.OnPropertyChanged);
                speContractValue.DataBindings.Add("Value", BindingSource, "ContractValue", false, DataSourceUpdateMode.OnPropertyChanged);
                grvStudents.DataBindings.Add("DataSource", BindingSource, "Students", false, DataSourceUpdateMode.OnPropertyChanged);
                ddlMainTeacher.DataBindings.Add("SelectedValue", BindingSource, "FK_TeacherIdMain", false, DataSourceUpdateMode.OnPropertyChanged);
                ddlSubjectTeacher.DataBindings.Add("SelectedValue", BindingSource, "FK_TeacherIdSubject", false, DataSourceUpdateMode.OnPropertyChanged);
                ddlFK_Department.DataBindings.Add("SelectedValue", BindingSource, "FK_DepartmentId", false, DataSourceUpdateMode.OnPropertyChanged);
                ddl_Subject.DataBindings.Add("SelectedValue", BindingSource, "FK_SubjectId", false, DataSourceUpdateMode.OnPropertyChanged);
            } catch {
            
            }
        }

        private void OnAddStudents(object sender, EventArgs e) {
            frmSelectStudents selectStudents = new frmSelectStudents(grvStudents.DataSource as List<Student>, Service);
            if (selectStudents.ShowDialog() == DialogResult.OK) {
                SubjectsClass currentSubjectsClass = grvSubjectsClass.CurrentRow.DataBoundItem as SubjectsClass;
                currentSubjectsClass.Students = selectStudents.SelectedStudents;
                for (int idx = 0; idx < currentSubjectsClass.Students.Count; idx++) {
                    currentSubjectsClass.Students.ElementAt(idx).SubjectsClasses.Add(currentSubjectsClass);
                }
                grvStudents.DataSource = currentSubjectsClass.Students; // Check refresh datasource function instead of assign datasource
            }
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            grvSubjectsClass.MasterTemplate.Refresh();
        }

        protected override SubjectsClass InternalCreateNew() {
            SubjectsClass item = base.InternalCreateNew();
            item.FromDate = DateTime.Now;
            item.ToDate = DateTime.Now.AddMonths(3);
            item.FK_DepartmentId = Convert.ToInt32(ddlFK_Department.SelectedValue);
            item.Department = Service.GetDepartmentById(item.FK_DepartmentId);
            item.FK_SubjectId = Convert.ToInt32(ddl_Subject.SelectedValue);//(ddl_Subject.SelectedItem.DataBoundItem as Subject).SubjectId;
            item.Subject = Service.GetSubjectById(item.FK_SubjectId);
            item.FK_TeacherIdMain = Convert.ToInt32(ddlMainTeacher.SelectedValue);
            item.Teacher = Service.GetTeacherById(item.FK_TeacherIdMain);
            item.FK_TeacherIdSubject = Convert.ToInt32(ddlSubjectTeacher.SelectedValue);
            item.Teacher1 = Service.GetTeacherById(item.FK_TeacherIdSubject);
            return item;
        }
    }
}

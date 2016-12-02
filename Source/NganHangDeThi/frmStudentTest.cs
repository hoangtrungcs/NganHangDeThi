using Controller.Services;
using Model.POCO;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls.UI.Data;

namespace NganHangDeThi {
    public partial class frmStudentTest : SimpleBaseForm<StudentTest, StudentTestService> {
        private SubjectsClassService m_subjectsClassService;
        private SubjectsService m_subjectService;
        private TestsService m_testService;
        public frmStudentTest() {
            InitializeComponent();
            m_subjectsClassService = new SubjectsClassService(Service.Context);
            m_subjectService = new SubjectsService(Service.Context);
            m_testService = new TestsService(Service.Context);

            m_cbxClasses.DataSource = m_subjectsClassService.GetAll();
            m_cbxClasses.SelectedIndexChanged += CbxClassesOnSelectedIndexChanged;
            m_cbxClasses.ValueMember = "SubjectsClassId";
            m_cbxClasses.DisplayMember = "SubjectsClassName";

            m_cbxSubjects.DataSource = m_subjectService.GetAllSubject();
            m_cbxSubjects.ValueMember = "SubjectId";
            m_cbxSubjects.DisplayMember = "Name";
            m_cbxSubjects.SelectedIndexChanged += OnSubjectChanged;
            OnSubjectChanged(null, null);
            m_cbxTest.SelectedIndexChanged += m_cbxTest_SelectedIndexChanged;
        }

        void m_cbxTest_SelectedIndexChanged(object sender, PositionChangedEventArgs e) {
            LoadSecurityStatus();
        }



        void OnSubjectChanged(object sender, PositionChangedEventArgs e) {
            m_cbxTest.Items.Clear();
            if (m_cbxSubjects.SelectedItem != null) {
                var selectedSubject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
                if (selectedSubject != null) {
                    //m_cbxTest.DataSource = null;
                    m_cbxTest.DataSource = m_testService.GetAllTestsBySubject(selectedSubject.SubjectId);
                    m_cbxTest.DisplayMember = "Name";
                    m_cbxTest.ValueMember = "TestId";
                }
            }
            LoadSecurityStatus();
        }
        public override void Add() {
            if (m_cbxClasses.SelectedItem != null && m_cbxTest.SelectedItem != null) {
                var classes = m_cbxClasses.SelectedItem.DataBoundItem as SubjectsClass;
                var selectedTest = m_cbxTest.SelectedItem.DataBoundItem as Test;
                if (classes != null && selectedTest !=null) {
                    var students = m_subjectsClassService.GetAllStudentsByClass(classes.SubjectsClassId);
                    
                    foreach (Student student in students) {
                        StudentTest studentTest = new StudentTest();
                        studentTest.FK_TestId = selectedTest.TestId;
                        studentTest.FK_StudenId = student.StudentId;
                        studentTest.Student = student;
                        studentTest.Test = selectedTest;
                        IsDirty = true;
                        studentTest.IsAddNew = true;
                        studentTest.AcceptChanged();
                        BindingSource.Add(studentTest);
                        BindingSource.ResetBindings(true);
                        BindingSource.MoveLast();
                    }
                }
            }
        }

        private void CbxClassesOnSelectedIndexChanged(object sender, PositionChangedEventArgs positionChangedEventArgs) {
            InternalLoadData();
            BindingSource.DataSource = EntitiesCollection;
            LoadSecurityStatus();
        }

        protected override void InternalLoadData() {
            if (m_cbxClasses.SelectedItem != null) {
                var classes = m_cbxClasses.SelectedItem.DataBoundItem as SubjectsClass;
                if (classes != null) {
                    EntitiesCollection = Service.GetAllStudentTestByClass(classes.SubjectsClassId);
                } else {
                    EntitiesCollection = new List<StudentTest>();
                }    
            }
        }
        protected override void SetBindingSource() {
            m_gridStudentTests.DataSource = BindingSource;
        }
        public override void LoadSecurityStatus() {
            base.LoadSecurityStatus();
            this.CanCreate = m_cbxClasses.SelectedItem != null && m_cbxTest.SelectedItem != null;
            this.CanEdit = false;
            this.CanDelete = false;
            NotifyStateChanged();
        }
    }
    //public partial class frmStudentTest : BaseForm {
    //    SubjectsService _subjectsService = new SubjectsService();
    //    StudentTestService _studentTestService = new StudentTestService();
    //    TestsService _testService = new TestsService();
    //    StudentsService _studentService = new StudentsService();
    //    private bool isNew = false;
    //    public frmStudentTest() {
    //        InitializeComponent();
    //        this.m_gridStudentTests.ShowGroupPanel = false;
    //        this.m_gridStudentTests.EnableHotTracking = true;
    //        this.m_gridStudentTests.ShowFilteringRow = true;
    //        this.m_gridStudentTests.EnableFiltering = true;
    //        this.m_gridStudentTests.EnableCustomFiltering = true;
    //        m_cbxSubjects.ValueMember = "SubjectId";
    //        m_cbxSubjects.DisplayMember = "Name";

    //        m_cbxClasses.ValueMember = "StudentId";
    //        m_cbxClasses.DisplayMember = "FirstName";

    //        m_cbxTest.ValueMember = "TestId";
    //        m_cbxTest.DisplayMember = "Name";

    //    }

    //    public override void Save() {
    //        Subject objSubject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
    //        Student objStudent = m_cbxClasses.SelectedItem.DataBoundItem as Student;
    //        Test objTest = m_cbxTest.SelectedItem.DataBoundItem as Test;

    //        if (objStudent != null && objSubject != null && objTest != null) {

    //            StudentTest objStudentTest = new StudentTest();
    //            objStudentTest.FK_StudenId = objStudent.StudentId;
    //            objStudentTest.FK_TestId = objTest.TestId;
    //            _studentTestService.Save(objStudentTest);
    //        } else {
    //            MessageBox.Show("Ban vui long dien day du thong tin truoc khi luu");
    //        }
    //        m_gridStudentTests.DataSource = null;
    //        m_gridStudentTests.DataSource = _studentTestService.GetAll();
    //        isNew = false;
    //    }

    //    public override void Add() {
    //        isNew = true;
    //        BindingControl(new StudentTest());
    //    }

    //    public override void Edit() {

    //    }

    //    public override void Cancel() {
    //        isNew = false;
    //    }

    //    public override void Delete() {
    //        isNew = false;
    //    }

    //    private void radGridView1_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e) {
    //        if (m_gridStudentTests.CurrentRow != null) {
    //            StudentTest objStudentTest = m_gridStudentTests.CurrentRow.DataBoundItem as StudentTest;
    //            if (objStudentTest != null) {
    //                BindingControl(objStudentTest);
    //            }
    //        }
    //    }

    //    public void BindingControl(StudentTest objStudentTest) {
    //        if (!isNew) {
    //            var objTest = _testService.GetTestById(objStudentTest.FK_TestId);
    //            if (objTest != null) {
    //                int subjectId = _subjectsService.GetById(objTest.FK_SubjectId).SubjectId;
    //                m_cbxSubjects.SelectedValue = _subjectsService.GetAllSubject().Select(x => x.SubjectId == subjectId);
    //                m_cbxTest.SelectedValue = objStudentTest.FK_TestId;
    //                m_cbxClasses.SelectedValue = objStudentTest.FK_StudenId;
    //            }

    //        } else {
    //            m_cbxSubjects.SelectedValue = -1;
    //            m_cbxClasses.SelectedValue = -1;
    //            m_cbxTest.SelectedValue = -1;
    //        }
    //    }

    //    private void radGridView1_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e) {
    //        if (string.IsNullOrEmpty(this.filterTextBox.Text)) {
    //            e.Visible = true; for (int i = 0; i < this.m_gridStudentTests.ColumnCount; i++) {
    //                e.Row.Cells[i].Style.Reset(); e.Row.InvalidateRow();
    //            }
    //            return;
    //        }
    //        e.Visible = false;
    //        for (int i = 0; i < this.m_gridStudentTests.ColumnCount; i++) {
    //            if (e.Row.Cells[i].Value != null) {
    //                string text = e.Row.Cells[i].Value.ToString();
    //                if (text.IndexOf(this.filterTextBox.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0) {
    //                    e.Visible = true;
    //                    e.Row.Cells[i].Style.CustomizeFill = true;
    //                    e.Row.Cells[i].Style.DrawFill = true;
    //                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
    //                } else {
    //                    e.Row.Cells[i].Style.Reset();
    //                    e.Row.InvalidateRow();
    //                }
    //            }
    //        }
    //    }

    //    private void filterTextBox_TextChanged(object sender, EventArgs e) {
    //        this.m_gridStudentTests.MasterTemplate.Refresh();
    //    }

    //    private void frmStudentTest_Load(object sender, EventArgs e) {
    //        m_cbxSubjects.DataSource = _subjectsService.GetAllSubject();
    //        m_cbxClasses.DataSource = _studentService.GetAllStudent();
    //        m_gridStudentTests.DataSource = _studentTestService.GetAll();
    //    }

    //    private void dropdownSubject_SelectedValueChanged(object sender, EventArgs e) {
    //        if (m_cbxSubjects.SelectedItem != null) {
    //            Subject objSubject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
    //            m_cbxTest.DataSource = null;
    //            m_cbxTest.DataSource = _testService.GetAllTestsBySubject(objSubject.SubjectId);
    //            m_cbxTest.ValueMember = "TestId";
    //            m_cbxTest.DisplayMember = "Name";
    //        }

    //    }
    //}
}

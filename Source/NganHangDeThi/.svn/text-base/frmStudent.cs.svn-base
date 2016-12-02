using Common;
using Controller.Services;
using Model.POCO;
using NganHangDeThi.Properties;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class frmStudent : SimpleBaseForm<Student, StudentsService>
    {
        public frmStudent() {
            InitializeComponent();
            this.m_gridStudents.ShowGroupPanel = false;
            this.m_gridStudents.EnableHotTracking = true;
            this.m_gridStudents.ShowFilteringRow = true;
            this.m_gridStudents.EnableFiltering = true;
            this.m_gridStudents.EnableCustomFiltering = true;
            m_cbxSchoolYear.DataSource = Enumerable.Range(DateTime.Now.Year - 20, 30);
            pictureBox1.MouseClick += OnBrowPictureBox1MouseClick;
            m_gridStudents.SelectionChanged += OnSelectionChanged;
        }

        void OnSelectionChanged(object sender, EventArgs e) {
            if (CurrentEntity != null && !string.IsNullOrEmpty(CurrentEntity.Images) && File.Exists(CurrentEntity.Images)) {
                pictureBox1.Image = Image.FromFile(CurrentEntity.Images);
            } else {
                pictureBox1.Image = Resources.no_image;
            }
        }
        protected override void SetBindingSource() {
            base.SetBindingSource();
            m_gridStudents.DataSource = BindingSource;
        }
        protected override void SetDetailBindingSource() {
            base.SetDetailBindingSource();
            txtAddress.DataBindings.Add("Text", BindingSource, "Address", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCMND.DataBindings.Add("Text", BindingSource, "CMND",false,DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", BindingSource, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
            txtFirstName.DataBindings.Add("Text", BindingSource, "FirstName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtHomePhone.DataBindings.Add("Text", BindingSource, "HomePhone", false, DataSourceUpdateMode.OnPropertyChanged);
            txtLastName.DataBindings.Add("Text", BindingSource, "LastName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtUserName.DataBindings.Add("Text", BindingSource, "UserName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtPassword.DataBindings.Add("Text", BindingSource, "PassWord", false, DataSourceUpdateMode.OnPropertyChanged);
            txtStudentNo.DataBindings.Add("Text", BindingSource, "StudentNo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtPhone.DataBindings.Add("Text", BindingSource, "Phone", false, DataSourceUpdateMode.OnPropertyChanged);
            dteBirthday.DataBindings.Add("Text", BindingSource, "BirthDay", false, DataSourceUpdateMode.OnPropertyChanged);
            dteBirthday.DataBindings.Add("Value", BindingSource, "BirthDay");
            //m_cbxSchoolYear.DataBindings.Add("SelectedItem", BindingSource, "SchoolYear");
            m_cbxSchoolYear.DataBindings.Add("SelectedValue", BindingSource, "SchoolYear",false,DataSourceUpdateMode.OnPropertyChanged);
        }
        protected override Student InternalCreateNew() {
            var student = base.InternalCreateNew();
            student.SchoolYear = DateTime.Now.Year;
            student.BirthDay = DateTime.Now.AddYears(-10);
            student.IsActive = true;
            return student;
        }
        private void OnFilterTextBoxTextChanged(object sender, EventArgs e) {
            this.m_gridStudents.MasterTemplate.Refresh();
        }
        private void OnStudentCustomFiltering(object sender, GridViewCustomFilteringEventArgs e) {
            if (string.IsNullOrEmpty(this.filterTextBox.Text)) {
                e.Visible = true;
                for (int i = 0; i < this.m_gridStudents.ColumnCount; i++) {
                    e.Row.Cells[i].Style.Reset();
                    e.Row.InvalidateRow();
                }
                return;
            }
            e.Visible = false;
            for (int i = 0; i < this.m_gridStudents.ColumnCount; i++) {
                if (e.Row.Cells[i].Value != null) {
                    string text = e.Row.Cells[i].Value.ToString();
                    if (text.IndexOf(this.filterTextBox.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0) {
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
        private void OnBrowPictureBox1MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                ContextMenu menu = new ContextMenu();
                menu.MenuItems.Add("Chọn ảnh", new EventHandler(BrowseImage_Clicked));
                menu.Show(pictureBox1, new Point(e.X, e.Y));
            }
        }
        private void BrowseImage_Clicked(object sender, EventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.gif)|*.gif";
            openFileDialog.InitialDirectory = Application.ExecutablePath;
            openFileDialog.Title = "Chọn hình ảnh";
            if (openFileDialog.ShowDialog() == DialogResult.OK && CurrentEntity != null) {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                string imagesServerFolderPath = ConfigurationManager.AppSettings["ImagesServerFolderPath"];
                var imageName = Guid.NewGuid().ToString() + ".jpg";
                string currentImageFilePath = Path.Combine(imagesServerFolderPath, imageName);
                CurrentEntity.Images = currentImageFilePath;
                Image teacherImage = pictureBox1.Image;
                teacherImage.Save(currentImageFilePath);
            }
        }
        public override void LoadSecurityStatus() {
            base.LoadSecurityStatus();
            CanCreate = UserService.CurrentUser.HasRole(UserRole.Administrator);
            CanDelete = UserService.CurrentUser.HasRole(UserRole.Administrator);
            CanEdit = UserService.CurrentUser.HasRole(UserRole.Administrator);
            NotifyStateChanged();
        }
    }
    //public partial class frmStudent : BaseForm {

    //    #region Properties
    //    private StudentsService _service = new StudentsService();
    //    /// <summary>
    //    /// The current student list
    //    /// </summary>
    //    private IList<Student> _CurrentStudentList = new List<Student>();
    //    #endregion

    //    #region Constructor
    //    public frmStudent() {
    //        InitializeComponent();
    //        this.m_gridStudents.ShowGroupPanel = false;
    //        this.m_gridStudents.EnableHotTracking = true;
    //        this.m_gridStudents.ShowFilteringRow = true;
    //        this.m_gridStudents.EnableFiltering = true;
    //        this.m_gridStudents.EnableCustomFiltering = true;
    //    }
    //    #endregion

    //    #region Methods

    //    public override void Save() {
    //        try {
    //            studentBindingSource.EndEdit();
    //            Student objStudent = (Student)studentBindingSource.Current;

    //            if (string.IsNullOrEmpty(objStudent.Images)) {
    //                string imagesServerFolderPath = ConfigurationManager.AppSettings["ImagesServerFolderPath"];
    //                string currentImageFilePath = string.Format("{0}\\Student_{1}.jpg", imagesServerFolderPath, objStudent.StudentId);
    //                objStudent.Images = currentImageFilePath;
    //                Image studentImage = pictureBox1.Image;
    //                studentImage.Save(currentImageFilePath);
    //            }

    //            if (objStudent.StudentId > 0) {
    //                _service.UpdateStudent(objStudent);
    //            } else {
    //                _service.InsertStudent(objStudent);
    //                _CurrentStudentList.Add((Student)studentBindingSource.Current);
    //            }
    //            m_gridStudents.DataSource = null;
    //            m_gridStudents.DataSource = _CurrentStudentList;
    //            MessageBox.Show("Luu thanh cong!");
    //        } catch (Exception) {
    //            MessageBox.Show("Ban khong the luu. Vui long kiem tra lai!");
    //        }
    //    }

    //    public override void Add() {
    //        studentBindingSource.AllowNew = true;
    //        studentBindingSource.AddNew();
    //    }

    //    public override void Edit() {
    //        studentBindingSource.EndEdit();
    //        this.CurrentAction = FormAction.Edit;
    //        (this.ParentForm as MainForm).ProcessButton(this.CurrentAction);
    //    }

    //    public override void Cancel() {
    //        studentBindingSource.ResetCurrentItem();
    //        m_gridStudents.DataSource = null;
    //        m_gridStudents.DataSource = _CurrentStudentList;
    //    }

    //    public override void Delete() {

    //        DialogResult dialog = MessageBox.Show("Ban muon xoa sinh vien nay?",
    //                     "Thong bao", MessageBoxButtons.YesNo);
    //        if (dialog == DialogResult.Yes) {
    //            _CurrentStudentList.Remove((Student)studentBindingSource.Current);
    //            _service.DeleteStudent(((Student)studentBindingSource.Current).StudentId);
    //            studentBindingSource.RemoveCurrent();
    //        }
    //        m_gridStudents.DataSource = null;
    //        m_gridStudents.DataSource = _CurrentStudentList;
    //    }
    //    #endregion

    //    #region Events
    //    private void frmStudent_Load(object sender, EventArgs e) {
    //        _CurrentStudentList = _service.GetAllStudent();
    //        m_gridStudents.DataSource = _CurrentStudentList;
    //        dtpSchoolYear.CustomFormat = "MM/yyyy";
    //        dtpSchoolYear.ShowUpDown = true;
    //    }

    //    private void radGridView1_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e) {
    //        if (string.IsNullOrEmpty(this.filterTextBox.Text)) {
    //            e.Visible = true;
    //            for (int i = 0; i < this.m_gridStudents.ColumnCount; i++) {
    //                e.Row.Cells[i].Style.Reset();
    //                e.Row.InvalidateRow();
    //            }
    //            return;
    //        }
    //        e.Visible = false;
    //        for (int i = 0; i < this.m_gridStudents.ColumnCount; i++) {
    //            if (e.Row.Cells[i].Value != null) {
    //                string text = e.Row.Cells[i].Value.ToString();
    //                if (text.IndexOf(this.filterTextBox.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0) {
    //                    e.Visible = true;
    //                    e.Row.Cells[i].Style.CustomizeFill = true;
    //                    e.Row.Cells[i].Style.DrawFill = true;
    //                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
    //                } else {
    //                    e.Row.Cells[i].Style.Reset(); e.Row.InvalidateRow();
    //                }
    //            }
    //        }
    //    }

    //    private void radGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e) {
    //        if (m_gridStudents.CurrentRow != null) {
    //            Student objStudent = m_gridStudents.CurrentRow.DataBoundItem as Student;
    //            if (objStudent != null) {
    //                studentBindingSource.DataSource = _CurrentStudentList.Where(s => s.StudentId == objStudent.StudentId);
    //                // Load image
    //                string imagesServerFolderPath = ConfigurationManager.AppSettings["ImagesServerFolderPath"];
    //                string currentImageFilePath = string.Format("{0}\\Student_{1}.jpg", imagesServerFolderPath, objStudent.StudentId);
    //                if (File.Exists(currentImageFilePath)) {
    //                    pictureBox1.Image = Image.FromFile(currentImageFilePath);
    //                } else {
    //                    pictureBox1.Image = Properties.Resources.no_image;
    //                }
    //                objStudent.PropertyChanged += (objSender, objE) => {
    //                    this.Edit();
    //                };
    //            }
    //        }
    //    }

    //    private void filterTextBox_TextChanged(object sender, EventArgs e) {
    //        this.m_gridStudents.MasterTemplate.Refresh();
    //    }
    //    #endregion
    //}
}

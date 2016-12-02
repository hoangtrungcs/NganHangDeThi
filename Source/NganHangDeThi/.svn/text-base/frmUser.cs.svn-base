using Controller.Services;
using Model.POCO;
using NganHangDeThi.Properties;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NganHangDeThi {
    public partial class frmUser : SimpleBaseForm<Teacher, UserService> {
        private DepartmentService _departmentService;
        public frmUser() {
            InitializeComponent();
            this.m_gridTeacher.ShowGroupPanel = false;
            this.m_gridTeacher.EnableHotTracking = true;
            this.m_gridTeacher.ShowFilteringRow = true;
            this.m_gridTeacher.EnableFiltering = true;
            this.m_gridTeacher.EnableCustomFiltering = true;
            _departmentService = new DepartmentService(Service.Context);
            m_cbxDepartment.DataSource = _departmentService.GetAllDepartment();
            m_gridTeacher.SelectionChanged += m_gridTeacher_SelectionChanged;
        }

        void m_gridTeacher_SelectionChanged(object sender, EventArgs e) {
            if (CurrentEntity != null && !string.IsNullOrEmpty(CurrentEntity.Images) && File.Exists(CurrentEntity.Images)) {
                pictureBox1.Image = Image.FromFile(CurrentEntity.Images);
            } else {
                pictureBox1.Image = Resources.no_image;
            }
        }

        protected override void SetBindingSource() {
            base.SetBindingSource();
            m_gridTeacher.DataSource = BindingSource;
        }
        protected override void SetDetailBindingSource() {
            base.SetDetailBindingSource();
            txtFirstName.DataBindings.Add("Text", BindingSource, "FirstName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtLastName.DataBindings.Add("Text", BindingSource, "LastName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", BindingSource, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
            txtPhone.DataBindings.Add("Text", BindingSource, "Phone", false, DataSourceUpdateMode.OnPropertyChanged);
            txtHomePhone.DataBindings.Add("Text", BindingSource, "HomePhone", false, DataSourceUpdateMode.OnPropertyChanged);
            txtPassword.DataBindings.Add("Text", BindingSource, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            dteBirthday.DataBindings.Add("Text", BindingSource, "Birthday", false, DataSourceUpdateMode.OnPropertyChanged);
            dteBirthday.DataBindings.Add("Value", BindingSource, "Birthday");
            txtUserName.DataBindings.Add("Text", BindingSource, "Username", false, DataSourceUpdateMode.OnPropertyChanged);
            this.m_cbxDepartment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.BindingSource, "FK_DepartmentId", true));
            this.m_cbxDepartment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BindingSource, "FK_DepartmentId", true));
            //pictureBox1.DataBindings.Add("Image", BindingSource.DataSource, "ThumbImage", false, DataSourceUpdateMode.Never);
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                ContextMenu menu = new ContextMenu();
                menu.MenuItems.Add("Chọn ảnh", new EventHandler(BrowseImage_Clicked));
                menu.Show(pictureBox1, new Point(e.X, e.Y));
            }
        }
        private void BrowseImage_Clicked(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.gif)|*.gif";
            openFileDialog.InitialDirectory = Application.ExecutablePath;
            openFileDialog.Title = "Chọn hình ảnh";
            if (openFileDialog.ShowDialog() == DialogResult.OK && CurrentEntity != null) {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                string imagesServerFolderPath = ConfigurationManager.AppSettings["ImagesServerFolderPath"];
                var imageName = Guid.NewGuid() + ".jpg";
                string currentImageFilePath = Path.Combine(imagesServerFolderPath, imageName);
                CurrentEntity.Images = currentImageFilePath;
                Image teacherImage = pictureBox1.Image;
                teacherImage.Save(currentImageFilePath);
            }
        }
        private void radGridView1_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e) {
            if (string.IsNullOrEmpty(this.filterTextBox.Text)) {
                e.Visible = true;
                for (int i = 0; i < this.m_gridTeacher.ColumnCount; i++) {
                    e.Row.Cells[i].Style.Reset();
                    e.Row.InvalidateRow();
                }
                return;
            }
            e.Visible = false;
            for (int i = 0; i < this.m_gridTeacher.ColumnCount; i++) {
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
        private void filterTextBox_TextChanged(object sender, EventArgs e) {
            this.m_gridTeacher.MasterTemplate.Refresh();
        }
        protected override Teacher InternalCreateNew() {
            var teacher = base.InternalCreateNew();
            teacher.IsActive = true;
            teacher.Birthday = DateTime.Now.AddYears(-15);
            if (m_cbxDepartment.SelectedItem != null) {
                Department department = m_cbxDepartment.SelectedItem.DataBoundItem as Department;
                if (department != null) {
                    teacher.FK_DepartmentId = department.DepartmentId;
                }
            }
            return teacher;
        }
        public override void LoadSecurityStatus() {
            base.LoadSecurityStatus();
            NotifyStateChanged();
        }
    }

    //public partial class frmUser : BaseForm
    //{
    //    #region Properties
    //    private UserService _service = new UserService();
    //    private DepartmentService _departmentService=new DepartmentService();
    //    /// <summary>
    //    /// The current teacher list
    //    /// </summary>
    //    private IList<Teacher> _CurrentTeacherList = new List<Teacher>();
    //    #endregion

    //    public frmUser()
    //    {
    //        InitializeComponent();
    //        this.m_gridTeacher.ShowGroupPanel = false;
    //        this.m_gridTeacher.EnableHotTracking = true;
    //        this.m_gridTeacher.ShowFilteringRow = true;
    //        this.m_gridTeacher.EnableFiltering = true;
    //        this.m_gridTeacher.EnableCustomFiltering = true;
    //    }

    //    public override void Save() {
    //        try {
    //            teacherBindingSource.EndEdit();
    //            Teacher objTeacher = (Teacher)teacherBindingSource.Current;
    //            if (objTeacher.Birthday == null)
    //            {
    //                objTeacher.Birthday = DateTime.Now;
    //            }
    //            if (objTeacher.FK_DepartmentId==0)
    //            {
    //                MessageBox.Show("Ban vui long chon phong ban cho giao vien!");
    //                return;
    //            }
    //            if (string.IsNullOrEmpty(objTeacher.Username))
    //            {
    //                MessageBox.Show("Ban vui long nhap Tai khoan cho giao vien!");
    //                return;
    //            }
    //            if (string.IsNullOrEmpty(objTeacher.Images))
    //            {
    //                string imagesServerFolderPath = ConfigurationManager.AppSettings["ImagesServerFolderPath"];
    //                string currentImageFilePath = string.Format("{0}\\Teacher_{1}.jpg", imagesServerFolderPath, objTeacher.TeacherId);
    //                objTeacher.Images = currentImageFilePath;
    //                Image teacherImage = pictureBox1.Image;
    //                teacherImage.Save(currentImageFilePath);
    //            }
    //            if (objTeacher.TeacherId > 0) {
    //                _service.Update(objTeacher);
    //            } else {
    //                _service.Insert(objTeacher);
    //                _CurrentTeacherList.Add(objTeacher);
    //            }
    //            m_gridTeacher.DataSource = null;
    //            m_gridTeacher.DataSource = _CurrentTeacherList;
    //            MessageBox.Show("Luu thanh cong!");
    //        } catch (Exception) {
    //            MessageBox.Show("Ban khong the luu. Vui long kiem tra lai!");
    //        }
    //    }

    //    public override void Add() {
    //        teacherBindingSource.AllowNew = true;
    //        teacherBindingSource.AddNew();
    //        radDropDownList1.SelectedIndex = -1;
    //    }

    //    public override void Edit() {
    //        teacherBindingSource.EndEdit();
    //        this.CurrentAction = FormAction.Edit;
    //        (this.ParentForm as MainForm).ProcessButton(this.CurrentAction);
    //    }

    //    public override void Cancel() {
    //        teacherBindingSource.ResetCurrentItem();
    //        m_gridTeacher.DataSource = null;
    //        m_gridTeacher.DataSource = _CurrentTeacherList;
    //    }

    //    public override void Delete() {
    //        DialogResult dialog = MessageBox.Show("Ban muon xoa giao vien nay?",
    //                    "Thong bao", MessageBoxButtons.YesNo);
    //        if (dialog == DialogResult.Yes) {
    //            _CurrentTeacherList.Remove((Teacher)teacherBindingSource.Current);
    //            _service.Delete(((Teacher)teacherBindingSource.Current).TeacherId);
    //            teacherBindingSource.RemoveCurrent();
    //        }
    //        m_gridTeacher.DataSource = null;
    //        m_gridTeacher.DataSource = _CurrentTeacherList;
    //    }

    //    private void radGridView1_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e) {
    //        if (string.IsNullOrEmpty(this.filterTextBox.Text)) {
    //            e.Visible = true;
    //            for (int i = 0; i < this.m_gridTeacher.ColumnCount; i++) {
    //                e.Row.Cells[i].Style.Reset();
    //                e.Row.InvalidateRow();
    //            }
    //            return;
    //        }
    //        e.Visible = false;
    //        for (int i = 0; i < this.m_gridTeacher.ColumnCount; i++) {
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

    //    private void radGridView1_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e) {
    //        Teacher objTeacher = m_gridTeacher.CurrentRow.DataBoundItem as Teacher;
    //        if (objTeacher != null) {
    //            teacherBindingSource.DataSource = _CurrentTeacherList.Where(s => s.TeacherId == objTeacher.TeacherId);
    //            departmentBindingSource.DataSource = _departmentService.GetDepartmentById(objTeacher.TeacherId);
    //            radDropDownList1.SelectedValue = objTeacher.FK_DepartmentId;
    //            // load image
    //            string imagesServerFolderPath = ConfigurationManager.AppSettings["ImagesServerFolderPath"];
    //            string currentImageFilePath = string.Format("{0}\\Teacher_{1}.jpg", imagesServerFolderPath, objTeacher.TeacherId);
    //            if (File.Exists(currentImageFilePath))
    //            {
    //                pictureBox1.Image = Image.FromFile(currentImageFilePath);
    //            }
    //            else
    //            {
    //                pictureBox1.Image = Properties.Resources.no_image;
    //            }
    //            objTeacher.PropertyChanged += (objSender, objE) =>
    //            {
    //                this.Edit();
    //            };
    //        }

    //    }

    //    private void filterTextBox_TextChanged(object sender, EventArgs e) {
    //        this.m_gridTeacher.MasterTemplate.Refresh();
    //    }

    //    private void frmUser_Load(object sender, EventArgs e) {
    //        _CurrentTeacherList = _service.GetAllTeachers();
    //        radDropDownList1.DataSource = _departmentService.GetAllDepartment();
    //        m_gridTeacher.DataSource = _CurrentTeacherList;
    //    }

    //    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Right)
    //        {
    //            ContextMenu menu = new ContextMenu();
    //            menu.MenuItems.Add("Chọn ảnh", new EventHandler(BrowseImage_Clicked));
    //            menu.Show(pictureBox1, new Point(e.X, e.Y));
    //        }
    //    }

    //    private void BrowseImage_Clicked(object sender, EventArgs e)
    //    {
    //        OpenFileDialog openFileDialog = new OpenFileDialog();
    //        openFileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.gif)|*.gif";
    //        openFileDialog.InitialDirectory = Application.ExecutablePath;
    //        openFileDialog.Title = "Chọn hình ảnh";
    //        if (openFileDialog.ShowDialog() == DialogResult.OK)
    //        {
    //            pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
    //        }
    //    }
    //}
}

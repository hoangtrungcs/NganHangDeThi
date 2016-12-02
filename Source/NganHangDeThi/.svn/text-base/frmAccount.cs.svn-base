using Controller.Services;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NganHangDeThi {
    public partial class frmAccount : SimpleBaseForm<Teacher, UserService> {
        public frmAccount() {
            InitializeComponent();
            IsDirty = false;
            LoadSecurityStatus();
        }

        public override void Save() {

            UserService.CurrentUser.CurrentUser.AcceptChanged();
            Service.Update(CurrentEntity);
            IsDirty = false;
            LoadSecurityStatus();
        }

        public void Create() {
            throw new NotImplementedException();
        }

        public override void Add() {
            throw new NotImplementedException();
        }

        public override void Edit() {
            throw new NotImplementedException();
        }

        public override void Cancel() {
            IsDirty = false;
            LoadSecurityStatus();
        }

        public override void Delete() {
            throw new NotImplementedException();
        }

        public override void LoadSecurityStatus() {
            CanCreate = false;
            CanDelete = false;
            CanEdit = true;
            NotifyStateChanged();
        }
        protected override void InternalLoadData() {
            EntitiesCollection = new List<Teacher> { Service.GetById(UserService.CurrentUser.CurrentUser.TeacherId) };
        }
        protected override void SetBindingSource() {
            base.SetBindingSource();
        }
        protected override void SetDetailBindingSource() {
            try {
                txtFirstName.DataBindings.Add("Text", BindingSource, "FirstName", false, DataSourceUpdateMode.OnPropertyChanged);
                txtLastName.DataBindings.Add("Text", BindingSource, "LastName", false, DataSourceUpdateMode.OnPropertyChanged);
                dtpBirthDay.DataBindings.Add("Value", BindingSource, "Birthday", true, DataSourceUpdateMode.OnPropertyChanged);
                txtPhone.DataBindings.Add("Text", BindingSource, "Phone", false, DataSourceUpdateMode.OnPropertyChanged);
                txtHomePhone.DataBindings.Add("Text", BindingSource, "HomePhone", false, DataSourceUpdateMode.OnPropertyChanged);
                txtEmail.DataBindings.Add("Text", BindingSource, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
                txtUserName.DataBindings.Add("Text", BindingSource, "Username", false, DataSourceUpdateMode.OnPropertyChanged);
                txtPassword.DataBindings.Add("Text", BindingSource, "PassWord", false, DataSourceUpdateMode.OnPropertyChanged);
                txtDepartment.DataBindings.Add("Text", BindingSource, "Department.DepartmentName", false, DataSourceUpdateMode.OnPropertyChanged);
                picImage.Image = File.Exists(CurrentEntity.Images) ?
                                 Image.FromFile(CurrentEntity.Images) : Properties.Resources.no_image;
            } catch (Exception) {
            }
        }
        /// <summary>
        /// Binding data to control
        /// </summary>
        private void BindingControl() {

        }

        private void btnSelectImage_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.gif)|*.gif";
            openFileDialog.InitialDirectory = Application.ExecutablePath;
            openFileDialog.Title = "Chọn hình ảnh";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                picImage.Image = Image.FromFile(openFileDialog.FileName);
                string imagesServerFolderPath = ConfigurationManager.AppSettings["ImagesServerFolderPath"];
                var imageGuiId = Guid.NewGuid().ToString() + ".jpg";
                string currentImageFilePath = Path.Combine(imagesServerFolderPath, imageGuiId);
                CurrentEntity.Images = currentImageFilePath;
                Image teacherImage = picImage.Image;
                teacherImage.Save(currentImageFilePath);
            }
        }
    }
}

using System.Data.Entity;
using Common;
using Controller.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.POCO;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class LoginForm : RadForm {
        private UserService m_service;
        public LoginForm() {
            InitializeComponent();

            ////Test Compare license key
            //try
            //{
            //    string myKey = LicenseKey.LicenseKeyHelper.Value();
            //    string decript = LicenseKey.LicenseKeyHelper.Decrypt("c153a55c4de705914ec1e5969080ea45e5960d60f589f4e8a8714a0fb2b23a5c", myKey);
            //    string decript = LicenseKey.LicenseKeyHelper.Decrypt("12a57219856f666e3dd2ee2998ddc7900316b9286266f58c768819a2e0ccb2b6e9fefc90369dcf0d", myKey);
            //    if (decript == myKey)
            //    {
            //        MessageBox.Show("OK");
            //    }
            //    else
            //    {
            //        MessageBox.Show("False");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("False" + ex.ToString());
            //}
         
            //return;
            comboBox1.DataSource = new List<string> {"Local", "Server"};
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            m_service = new UserService();
            CreateNewDatabase(m_service);
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedItem.ToString() == "Local") {
                DbHelper.ConnectionString = DbHelper.LocalConnectionString;
            } else {
                DbHelper.ConnectionString = DbHelper.ServerConnectionString;
            }
            m_service = new UserService();

            CreateNewDatabase(m_service);
        }

        private void CreateNewDatabase(UserService teacher)
        {
            using (var context = new NganHangEntities())
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<NganHangEntities>());
                context.Database.Initialize(true);
                if (teacher.GetAllTeachers().Count == 0)
                {
                    Department department = new Department();
                    department.DepartmentName = "Computer";
                    department.DepartmentNo = "1002";
                    context.Departments.Add(department);
                    context.SaveChanges();
                    Teacher obj = new Teacher();
                    obj.FirstName = "ADMIN";
                    obj.LastName = "Administrator";
                    obj.Username = "abc";
                    obj.PassWord = "1";
                    obj.Birthday = DateTime.Now;
                    obj.IsActive = true;
                    obj.Roles = 1;
                    obj.FK_DepartmentId = 1;
                    context.Teachers.Add(obj);
                    context.SaveChanges();
                }
            }
        }

        private void CreateNewLocalDatabase()
        {
            using (var context = new NganHangEntities())
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<NganHangEntities>());
                context.Database.Initialize(true);
                UserService teacher = new UserService();
                if (teacher.GetAllTeachers().Count == 0)
                {
                    Department department = new Department();
                    department.DepartmentName = "Computer";
                    department.DepartmentNo = "1002";
                    context.Departments.Add(department);
                    context.SaveChanges();
                    Teacher obj = new Teacher();
                    obj.FirstName = "ADMIN";
                    obj.LastName = "Administrator";
                    obj.Username = "abc";
                    obj.PassWord = "1";
                    obj.Birthday = DateTime.Now;
                    obj.IsActive = true;
                    obj.Roles = 1;
                    obj.FK_DepartmentId = 1;
                    context.Teachers.Add(obj);
                    context.SaveChanges();
                }


            }

        }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(m_txtUsername.Text)) {
                MessageBox.Show("Vui lòng nhập Tài khoản người dùng!","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(m_txtPassword.Text)) {
                MessageBox.Show("Bạn chưa nhập mật khẩu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!m_service.Login(m_txtUsername.Text, m_txtPassword.Text)) {
                MessageBox.Show("Tài khoản người dùng hoặc mật khẩu không đúng. Bạn vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

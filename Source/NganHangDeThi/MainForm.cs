using System.Data.Entity;
using System.Threading;
using Common;
using Controller.Services;
using Model.POCO;
using NganHangDeThi.Form_Popup;
using NganHangDeThi.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NganHangDeThi
{
    public partial class MainForm : RadRibbonForm
    {

        #region Fields

        private UserService m_userService;
        private static Dictionary<Tuple<string, string>, List<Tuple<string, string>>> m_toolBarDictionary;
        private List<IForm> m_allOpenForms;
        public static Dictionary<Tuple<string, string>, List<Tuple<string, string>>> Operations { get { return m_toolBarDictionary; } }

        //Set button to Property
        public bool AddButton
        {
            get { return btnAdd.Enabled; }
            set { btnAdd.Enabled = value; }
        }

        public bool DeleteButton
        {
            get { return btnDelete.Enabled; }
            set { btnDelete.Enabled = value; }
        }

        public bool CancelButton
        {
            get { return btnCancel.Enabled; }
            set { btnCancel.Enabled = value; }
        }

        public bool SaveButton
        {
            get { return btnSave.Enabled; }
            set { btnSave.Enabled = value; }
        }

        #endregion Fields

        #region Constructor
        public MainForm()
        {
            this.Hide();
            Thread splashthread = new Thread(new ThreadStart(Splash.SplashScreenManage.ShowSplashScreen));
            splashthread.IsBackground = true;
            splashthread.Start();

            
            InitializeComponent();
          
            radRibbonBar1.Enabled = false;
            btnAdd.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.N));
        }

        

        private void InitToolbarDictionary()
        {
            var document = new XmlDocument();
            document.Load(Path.Combine(Application.StartupPath, @"Structure\Tabs.xml"));
            var root = document.SelectSingleNode("Tabs");
            foreach (XmlNode tab in root.ChildNodes)
            {
                var groupsButtons = new List<Tuple<string, string>>(tab.ChildNodes.Count);
                groupsButtons.AddRange(from XmlNode @group in tab.ChildNodes select new Tuple<string, string>(@group.Attributes["OperationName"].Value, @group.Attributes["Text"].Value));
                m_toolBarDictionary.Add(new Tuple<string, string>(tab.Attributes["Name"].Value, tab.Attributes["Text"].Value), groupsButtons);
            }
        }
        private void InitToolbar()
        {
            var key = m_toolBarDictionary.Keys.FirstOrDefault(x => x.Item1 == Constants.DANH_MUC_TAB_NAME);
            var lstDanhMucGroupButtons = m_toolBarDictionary[key].Select(x => x.Item1);
            var userOperations = m_userService.GetCurrentUserOperations();
            if (!userOperations.Any(x => lstDanhMucGroupButtons.Contains(x)))
            {
                ribbonTab1.Visibility = ElementVisibility.Collapsed;
            }
            else
            {
                if (!userOperations.Contains(Constants.TEACHER_OPERATIONS))
                {
                    btnFormUser.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.STUDENT_OPERATIONS))
                {
                    btnFormStudent.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.SUBJECT_OPERATIONS))
                {
                    btnFormSubject.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.SUBJECT_CLASS_OPERATIONS))
                {
                    btnSubjectClass.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.DEPARTMENT_OPERATION))
                {
                    btnDepartmentGroup.Visibility = ElementVisibility.Collapsed;
                }
            }

            key = m_toolBarDictionary.Keys.FirstOrDefault(x => x.Item1 == Constants.CHUC_NANG_TAB_NAME);
            var lstChucNangButtonGroups = m_toolBarDictionary[key].Select(x => x.Item1);

            if (!userOperations.Any(x => lstChucNangButtonGroups.Contains(x)))
            {
                ribbonTab3.Visibility = ElementVisibility.Collapsed;
            }
            else
            {
                if (!userOperations.Contains(Constants.TEST_COMPOSER_OPERATIONS))
                {
                    btnFormTest.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.QUESTION_OPERATIONS))
                {
                    btnFormQuestion.Visibility = ElementVisibility.Collapsed;
                }
                if (!UserService.CurrentUser.HasRole(UserRole.Administrator) &&
                    UserService.CurrentUser.CurrentUser.UserSubjectRights.Count(r => r.Right > 0) == 0)
                {
                    btnFormTest.Visibility = ElementVisibility.Collapsed;
                    btnFormQuestion.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.ASSIGN_TEST_OPERATIONS))
                {
                    btnfrmStudentTest.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.CUSTOM_QUESTION_OPERATIONS))
                {
                    btnCustomQuestion.Visibility = ElementVisibility.Collapsed;

                }
                if (!userOperations.Contains(Constants.MUTILPLE_TEST_OPERATIONS))
                {
                    btnMultipleTest.Visibility = ElementVisibility.Collapsed;
                }
            }

            key = m_toolBarDictionary.Keys.FirstOrDefault(x => x.Item1 == Constants.XEM_KQ_TAB_NAME);
            var lstResult = m_toolBarDictionary[key].Select(x => x.Item1);
            if (!userOperations.Any(x => lstResult.Contains(x)))
            {
                ribbonTab4.Visibility = ElementVisibility.Collapsed;
            }
            else
            {
                if (!userOperations.Contains(Constants.STUDENT_RESULT))
                {
                    btnFormResultTest.Visibility = ElementVisibility.Collapsed;
                }
            }

            key = m_toolBarDictionary.Keys.FirstOrDefault(x => x.Item1 == Constants.CAU_HINH_TAB_NAME);
            var lstCauHinh = m_toolBarDictionary[key].Select(x => x.Item1);
            if (!userOperations.Any(x => lstCauHinh.Contains(x)))
            {
                ribbonTab5.Visibility = ElementVisibility.Collapsed;
            }
            else
            {
                if (!userOperations.Contains(Constants.PROFILES_OPERATION))
                {
                    btnFrmAccount.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.USER_PERMISTION_OPERATIONS))
                {
                    btnFormUserRole.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.BACKUP_DATA_OPERATIONS))
                {
                    btnFormBackupData.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.THEMES_OPERATION))
                {
                    btnFormTheme.Visibility = ElementVisibility.Collapsed;
                }
                if (!userOperations.Contains(Constants.EDIT_SCHOOL_OPERATION))
                {
                    btnEditSchool.Visibility = ElementVisibility.Collapsed;
                }
            }
        }

        #endregion

        #region Methods
        private void AddNewChildForm<T>() where T : RadForm, IForm, new()
        {
            var item = m_allOpenForms.FirstOrDefault(x => x.GetType() == typeof(T));
            m_allOpenForms.ForEach(x => x.IsActive = false);
            if (item == null)
            {
                item = new T();
                item.ActionStateChanged += CurrentFormStateChanged;
                m_allOpenForms.Add(item);
                item.IsActive = true;
                ((RadForm)item).WindowState = FormWindowState.Maximized;
                ((RadForm)item).MaximizeBox = true;
                ((RadForm)item).MdiParent = this;
                ((RadForm)item).Show();
                ((RadForm)item).Closed += ChildFormClosed;
            }
            else
            {
                item.IsActive = true;
                ((RadForm)item).Activate();
                ReloadCurrentFormStatus(item);
            }
        }

        void CurrentFormStateChanged(object sender, EventArgs e)
        {
            var form = sender as IForm;
            ReloadCurrentFormStatus(form);
        }

        private void ReloadCurrentFormStatus(IForm form)
        {
            if (form != null)
            {
                btnAdd.Enabled = form.CanCreate;
                btnDelete.Enabled = form.CanDelete;
                btnCancel.Enabled = form.IsDirty;
                btnSave.Enabled = (form.CanCreate || form.CanEdit) && form.IsDirty;
            }
        }

        /// <summary>
        /// Childs the form closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void ChildFormClosed(object sender, EventArgs e)
        {
            var item = sender as IForm;
            if (item != null)
            {
                m_allOpenForms.Remove(item);
            }
            ((RadForm)sender).Closed -= ChildFormClosed;
            ProcessButton(item.CurrentAction);
        }

        #endregion

        #region Events
        private void OnOpenUserForm(object sender, EventArgs e)
        {
            AddNewChildForm<frmUser>();
        }

        private void OnOpenStudentForm(object sender, EventArgs e)
        {
            AddNewChildForm<frmStudent>();

        }

        private void btnFormSubject_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmSubject>();

        }

        private void btnFormTest_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmTest>();
        }

        private void btnFormQuestion_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmQuestion>();
            ProcessButton(FormAction.None);
        }

        private void btnFormResultTest_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmResultTest>();
        }

        private void btnFrmAccount_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmAccount>();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnFormUserRole_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmUserRole>();

        }

        private void btnFormBackupData_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmBackupData>();
        }

        private void btnFormTheme_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmTheme>();
        }
        private void btnfrmStudentTest_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmStudentTest>();
            //AddNewChildForm<AssignedTest>();
        }

        private void btnFormCustomQuestion_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmCustomQuestion>();
        }
        #endregion

        public void ProcessButton(FormAction action)
        {
            if (m_allOpenForms.Count > 0)
            {
                switch (action)
                {
                    case FormAction.Add:
                        btnAdd.Enabled = false;
                        btnDelete.Enabled = false;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    case FormAction.Edit:
                        btnAdd.Enabled = false;
                        btnDelete.Enabled = false;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    case FormAction.Save:
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    case FormAction.Delete:
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    case FormAction.Cancel:
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    default: btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                }
            }
            else
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void OnSaveActiveForm(object sender, EventArgs e)
        {
            var activeForm = m_allOpenForms.FirstOrDefault(x => x.IsActive);
            if (activeForm != null)
            {
                activeForm.Save();
            }
        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {
            var activeForm = m_allOpenForms.FirstOrDefault(x => x.IsActive);
            if (activeForm != null)
            {
                //activeForm.CurrentAction = FormAction.Add;
                //ProcessButton(FormAction.Add);
                activeForm.Add();
            }
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            var activeForm = m_allOpenForms.FirstOrDefault(x => x.IsActive);
            if (activeForm != null)
            {
                //activeForm.CurrentAction = FormAction.Cancel;
                //ProcessButton(FormAction.Cancel);
                activeForm.Cancel();
            }
        }

        private void OnDeletedItem(object sender, EventArgs e)
        {
            var activeForm = m_allOpenForms.FirstOrDefault(x => x.IsActive);
            if (activeForm != null)
            {
                //activeForm.CurrentAction = FormAction.Delete;
                //ProcessButton(FormAction.Delete);
                activeForm.Delete();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Show();
            Splash.SplashScreenManage.CloseSplashScreen();
            Activate();
            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                m_userService = new UserService();
                m_allOpenForms = new List<IForm>();
                m_toolBarDictionary = new Dictionary<Tuple<string, string>, List<Tuple<string, string>>>();
                InitToolbarDictionary();
                InitToolbar();
                ProcessButton(FormAction.None);
                radLabelElement1.Text = UserService.CurrentUser.CurrentUser.FullName;
                radRibbonBar1.Enabled = true;
            }
            else
            {
                Close();
            }
        }

        private void OnOpenSubjectsClass(object sender, EventArgs e)
        {
            AddNewChildForm<frmSubjectsClass>();
        }

        private void btnMultitest_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmMultipleTest>();
        }

        private void btnEditSchoolInfo_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmSchoolInfo>();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmDepartment>();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            AddNewChildForm<frmClass>();
        }

        private void OnRestoreData(object sender, EventArgs e)
        {
            //if (RadMessageBox.Show("Để thực hiện chức năng phục hồi dữ liệu, cần phải thoát chương trình, bạn có muốn tiếp tục không?",
            //                   "Thông báo", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.Yes)
            //{
            //    this.Close();
            //    Process.Start(@"..\..\..\BackupRestore\bin\Debug\BackupRestore.exe");
            //}
            AddNewChildForm<frmRestoreData>();
        }

        private void OnCreateMixedTest(object sender, EventArgs e)
        {
            AddNewChildForm<frmMixedTest>();
        }

        private void OnOpenLimitedTest(object sender, EventArgs e)
        {
            AddNewChildForm<frmLimitedTest>();
        }

        private void OnSharingQuestions(object sender, EventArgs e)
        {
            AddNewChildForm<frmSharingQuestion>();
        }

        private void OnUpdateQuestions(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IList<Subject> importedSubjects = ExportHelpers.ImportQuestion(dialog.FileName);
                frmEditQuestion editQuestion = new frmEditQuestion(importedSubjects);
                editQuestion.ShowDialog();
            }
        }

        private void radRibbonBar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                OnAddButtonClick(sender,e);
            }
            else if (e.KeyData == (Keys.Control | Keys.S))
            {
                OnSaveActiveForm(sender,e);
            }
        }


    }
}

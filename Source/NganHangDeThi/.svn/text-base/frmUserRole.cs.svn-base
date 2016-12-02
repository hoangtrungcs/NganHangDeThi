using Common;
using Controller.Services;
using Model;
using Model.POCO;
using NganHangDeThi.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class frmUserRole : BaseForm {
        private UserService m_userService;
        private SubjectsService m_subjectsService;
        private DbContext m_context;
        private bool IsTreeBinding = false;
        public frmUserRole() {
            InitializeComponent();
            m_context = new NganHangEntities();
            m_userService = new UserService(m_context);
            m_subjectsService = new SubjectsService(m_context);
            InitMonHocGridView();
            InitFunctionRight();
            m_treeUserRole.NodeCheckedChanged += m_treeUserRole_NodeCheckedChanged;
            CanEdit = true;
            CanCreate = false;
        }

        void m_treeUserRole_NodeCheckedChanged(object sender, RadTreeViewEventArgs e) {
            if (!IsTreeBinding) {
                IsDirty = true;
                NotifyStateChanged();
            }
        }


        public override void Save() {
            if (m_lstUsers.SelectedItem != null) {
                int userId = Convert.ToInt32(m_lstUsers.SelectedItem.Tag);
                List<UserSubjectRight> rights = new List<UserSubjectRight>(m_subjectGrid.Rows.Count);
                foreach (var row in m_subjectGrid.Rows) {
                    var item = row.DataBoundItem as UserSubjectRightModel;
                    if (item != null) {
                        RightType r = RightType.None;
                        if (item.List) {
                            r |= RightType.List;
                        }
                        if (item.Create) {
                            r |= RightType.Create;
                        }
                        if (item.Edit) {
                            r |= RightType.Edit;
                        }
                        if (item.Delete) {
                            r |= RightType.Delete;
                        }
                        if (item.ListTest) {
                            r |= RightType.ListTest;
                        }
                        if (item.CreateTest) {
                            r |= RightType.CreateTest;
                        }
                        if (item.EditTest) {
                            r |= RightType.EditTest;
                        }
                        if (item.DeleteTest) {
                            r |= RightType.DeleteTest;
                        }
                        rights.Add(new UserSubjectRight() {
                            FK_SubjectId = item.SubjectId,
                            FK_TeacherId = userId,
                            Right = (int)r
                        });
                    }
                }
                m_userService.SaveUserSubjectRight(rights);
                // save teacher operation
                List<TeacherOperation> updateTeacherOperations = new List<TeacherOperation>();
                foreach (RadTreeNode tabs in m_treeUserRole.Nodes) {
                    foreach (RadTreeNode operation in tabs.Nodes) {
                        TeacherOperation update = new TeacherOperation() {
                            TeacherId = userId,
                            OperationName = operation.Tag.ToString(),
                            Enable = operation.Checked
                        };
                        updateTeacherOperations.Add(update);
                    }
                }
                m_userService.SaveUserOperation(updateTeacherOperations);
            }
            //TODO : Do save for User by function
            IsDirty = false;
            NotifyStateChanged();
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
            CanCreate = false;
            UpdateGridData();
            UpdateUserRole();
            NotifyStateChanged();
        }
        public override void Delete() {
            throw new NotImplementedException();
        }

        private void frmUserRole_Load(object sender, EventArgs e) {
            var teachers = m_userService.GetAllTeachers();
            int width = Resources.no_image.Width;
            int height = Resources.no_image.Height;
            var radItems = teachers.Select(x => new RadListDataItem {
                Text = x.Username,
                Image = File.Exists(x.Images) ? ResizeImage(Image.FromFile(x.Images), width, height) : Resources.no_image,
                Tag = x.TeacherId

            }).ToList();
            m_lstUsers.DataSource = null;
            m_lstUsers.Items.Clear();
            m_lstUsers.Items.AddRange(radItems);
            radItems.ForEach(x => x.Height = 75);
            NotifyStateChanged();
        }
        public Image ByteArrayToImage(byte[] byteArrayIn) {
            using (var ms = new MemoryStream(byteArrayIn)) {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        private static Image ResizeImage(Image srcImage, int newWidth, int newHeight) {
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage)) {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                return newImage;
            }
        }
        private void InitMonHocGridView() {
            m_subjectGrid.AllowAddNewRow = false;
            this.m_subjectGrid.MasterTemplate.AutoGenerateColumns = false;
            GridViewDataColumn idColumn = new GridViewTextBoxColumn();
            idColumn.HeaderText = "SubjectId";
            idColumn.Name = "SubjectId";
            idColumn.FieldName = "SubjectId";
            idColumn.DataType = typeof(int);
            idColumn.ReadOnly = true;
            idColumn.IsVisible = false;
            idColumn.Width = 100;
            this.m_subjectGrid.Columns.Add(idColumn);

            var subjectName = new GridViewTextBoxColumn();
            subjectName.FieldName = "SubjectName";
            subjectName.Name = "SubjectName";
            subjectName.HeaderText = "Subject Name";
            subjectName.Width = 100;
            subjectName.IsVisible = true;
            this.m_subjectGrid.Columns.Add(subjectName);

            var viewColumn = new GridViewCheckBoxColumn();
            viewColumn.FieldName = "List";
            viewColumn.Name = "List";
            viewColumn.HeaderText = "List";
            viewColumn.Width = 100;
            viewColumn.IsVisible = true;
            this.m_subjectGrid.Columns.Add(viewColumn);

            viewColumn = new GridViewCheckBoxColumn();
            viewColumn.FieldName = "Create";
            viewColumn.Name = "Create";
            viewColumn.HeaderText = "Create";
            viewColumn.Width = 100;
            viewColumn.IsVisible = true;
            this.m_subjectGrid.Columns.Add(viewColumn);

            viewColumn = new GridViewCheckBoxColumn();
            viewColumn.FieldName = "Edit";
            viewColumn.Name = "Edit";
            viewColumn.HeaderText = "Edit";
            viewColumn.Width = 100;
            viewColumn.IsVisible = true;
            this.m_subjectGrid.Columns.Add(viewColumn);

            viewColumn = new GridViewCheckBoxColumn();
            viewColumn.FieldName = "Delete";
            viewColumn.Name = "Delete";
            viewColumn.HeaderText = "Delete";
            viewColumn.Width = 100;
            viewColumn.IsVisible = true;
            this.m_subjectGrid.Columns.Add(viewColumn);

            viewColumn = new GridViewCheckBoxColumn();
            viewColumn.FieldName = "ListTest";
            viewColumn.Name = "ListTest";
            viewColumn.HeaderText = "ListTest";
            viewColumn.Width = 100;
            viewColumn.IsVisible = true;
            this.m_subjectGrid.Columns.Add(viewColumn);

            viewColumn = new GridViewCheckBoxColumn();
            viewColumn.FieldName = "CreateTest";
            viewColumn.Name = "CreateTest";
            viewColumn.HeaderText = "CreateTest";
            viewColumn.Width = 100;
            viewColumn.IsVisible = true;
            this.m_subjectGrid.Columns.Add(viewColumn);

            viewColumn = new GridViewCheckBoxColumn();
            viewColumn.FieldName = "EditTest";
            viewColumn.Name = "EditTest";
            viewColumn.HeaderText = "EditTest";
            viewColumn.Width = 100;
            viewColumn.IsVisible = true;
            this.m_subjectGrid.Columns.Add(viewColumn);

            viewColumn = new GridViewCheckBoxColumn();
            viewColumn.FieldName = "DeleteTest";
            viewColumn.Name = "DeleteTest";
            viewColumn.HeaderText = "DeleteTest";
            viewColumn.Width = 100;
            viewColumn.IsVisible = true;
            this.m_subjectGrid.Columns.Add(viewColumn);
        }
        private void UpdateGridData() {

            if (m_lstUsers.SelectedItem != null) {
                m_subjectGrid.DataSource = null;
                var selectedUser = m_lstUsers.SelectedItem.Text;

                var allSubjects = m_subjectsService.GetAllSubject();
                var allUserSubjectRight = m_userService.GetAllUserSubjectRights(selectedUser);
                var allUserRights = allSubjects.Select(x => new UserSubjectRightModel {
                    SubjectId = x.SubjectId,
                    SubjectName = x.Name,
                    List = allUserSubjectRight.Any(y => y.FK_SubjectId == x.SubjectId && ((int)RightType.List & y.Right) == (int)RightType.List),
                    Create = allUserSubjectRight.Any(y => y.FK_SubjectId == x.SubjectId && ((int)RightType.Create & y.Right) == (int)RightType.Create),
                    Edit = allUserSubjectRight.Any(y => y.FK_SubjectId == x.SubjectId && ((int)RightType.Edit & y.Right) == (int)RightType.Edit),
                    Delete = allUserSubjectRight.Any(y => y.FK_SubjectId == x.SubjectId && ((int)RightType.Delete & y.Right) == (int)RightType.Delete),
                    ListTest = allUserSubjectRight.Any(y => y.FK_SubjectId == x.SubjectId && ((int)RightType.ListTest & y.Right) == (int)RightType.ListTest),
                    CreateTest = allUserSubjectRight.Any(y => y.FK_SubjectId == x.SubjectId && ((int)RightType.CreateTest & y.Right) == (int)RightType.CreateTest),
                    EditTest = allUserSubjectRight.Any(y => y.FK_SubjectId == x.SubjectId && ((int)RightType.EditTest & y.Right) == (int)RightType.EditTest),
                    DeleteTest = allUserSubjectRight.Any(y => y.FK_SubjectId == x.SubjectId && ((int)RightType.DeleteTest & y.Right) == (int)RightType.DeleteTest)
                }).ToList();
                m_subjectGrid.DataSource = allUserRights;
            }
        }
        private void ConfirmSaveCurrentData() {
            if (IsDirty && MessageBox.Show("Do you want to save the current change?", "Confirm", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes) {
                Save();
                IsDirty = false;
                NotifyStateChanged();
            }
        }
        private void SelectedUserChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e) {
            UpdateGridData();
            UpdateUserRole();
        }
        private void SelectedUserChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e) {
            ConfirmSaveCurrentData();
            IsDirty = false;
        }
        private void UpdateUserRole() {
            if (m_lstUsers.SelectedItem != null) {
                List<string> currentUserRoles = m_userService.GetUserOperationsByUserId(Convert.ToInt32(m_lstUsers.SelectedItem.Tag));
                IsTreeBinding = true;
                foreach (RadTreeNode tabs in m_treeUserRole.Nodes) {
                    foreach (RadTreeNode operation in tabs.Nodes) {
                        if (currentUserRoles.Contains(operation.Tag.ToString())) {
                            operation.Checked = true;
                        } else {
                            operation.Checked = false;
                        }
                    }
                }
                IsTreeBinding = false;
            }
        }
        private void InitFunctionRight() {
            foreach (var operation in MainForm.Operations) {
                var groupNode = new RadTreeNode();
                groupNode.Text = operation.Key.Item2;
                groupNode.Tag = operation.Key.Item1;
                groupNode.CheckType = CheckType.CheckBox;
                foreach (var childOperation in operation.Value) {
                    var child = new RadTreeNode();
                    child.Text = childOperation.Item2;
                    child.CheckType = CheckType.CheckBox;
                    child.Tag = childOperation.Item1;
                    groupNode.Nodes.Add(child);
                }
                m_treeUserRole.Nodes.Add(groupNode);
            }
            m_treeUserRole.Refresh();
            m_treeUserRole.ExpandAll();
        }
        private void OnRoleChanged(object sender, EventArgs e) {
            m_subjectGrid.EndEdit();
            m_subjectGrid.BeginEdit();
            IsDirty = true;
            NotifyStateChanged();
        }
    }
}

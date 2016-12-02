using Controller.Services;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NganHangDeThi {
    public partial class frmSubject : SimpleBaseForm<Subject, SubjectsService> {
        #region Constructor
        public frmSubject() {
            InitializeComponent();
            this.m_gridSubjects.ShowGroupPanel = false;
            this.m_gridSubjects.EnableHotTracking = true;
            this.m_gridSubjects.ShowFilteringRow = true;
            this.m_gridSubjects.EnableFiltering = true;
            this.m_gridSubjects.EnableCustomFiltering = true;
        }
        #endregion

        #region Methods

        #endregion

        #region Events
        protected override Subject InternalCreateNew() {
            var subject = base.InternalCreateNew();
            subject.IsDel = false;
            subject.SubjectGuid = Guid.NewGuid();
            return subject;
        }

        protected override void SetBindingSource() {
            base.SetBindingSource();
            m_gridSubjects.DataSource = BindingSource;
        }
        protected override void SetDetailBindingSource() {
            base.SetDetailBindingSource();
            txtSubjectName.DataBindings.Add("Text", BindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSubjectNo.DataBindings.Add("Text", BindingSource, "SubjectNo", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        public override void LoadSecurityStatus() {
            base.LoadSecurityStatus();
            CanCreate = true;
            CanDelete = true;
            CanEdit = true;
            NotifyStateChanged();
        }
        private void GridSubjectCustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e) {
            if (string.IsNullOrEmpty(this.filterTextBox.Text)) {
                e.Visible = true; for (int i = 0; i < this.m_gridSubjects.ColumnCount; i++) {
                    e.Row.Cells[i].Style.Reset(); e.Row.InvalidateRow();
                }
                return;
            }
            e.Visible = false;
            for (int i = 0; i < this.m_gridSubjects.ColumnCount; i++) {
                if (e.Row.Cells[i].Value != null) {
                    string text = e.Row.Cells[i].Value.ToString();
                    if (text.IndexOf(this.filterTextBox.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0) {
                        e.Visible = true;
                        e.Row.Cells[i].Style.CustomizeFill = true;
                        e.Row.Cells[i].Style.DrawFill = true;
                        e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                    } else {
                        e.Row.Cells[i].Style.Reset();
                        e.Row.InvalidateRow();
                    }
                }
            }
        }
        private void filterTextBox_TextChanged(object sender, EventArgs e) {
            this.m_gridSubjects.MasterTemplate.Refresh();
        }
        #endregion
    }
}

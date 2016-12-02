using Controller.Services;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NganHangDeThi.Form_Popup {
    public partial class frmSelectStudents : RadForm {
        public IList<Student> SelectedStudents { get; set; }

        private SubjectsClassService m_subjectsClassService;

        public frmSelectStudents(List<Student> selectedStudents, SubjectsClassService subjectClassService) {
            InitializeComponent();            
            // Add header checkbox column
            CustomCheckBoxColumn column = new CustomCheckBoxColumn();
            column.FieldName = "Checked";
            column.Name = "colChecked";
            column.HeaderText = "All";
            grvStudents.Columns.Insert(0, column);
            m_subjectsClassService = subjectClassService;
            // Refresh selected student on gridview
            SelectedStudents = selectedStudents;
        }

        private void OnAccept(object sender, EventArgs e) {
            SelectedStudents = (grvStudents.DataSource as List<Student>).Where(s => s.Checked).ToList();
            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnLoad(object sender, EventArgs e) {
            List<Student> allStudents = m_subjectsClassService.GetAllStudent();
            if (SelectedStudents != null) {
                foreach (Student student in SelectedStudents) {
                    allStudents.First(s => s.StudentId == student.StudentId).Checked = true;
                }
            }
            grvStudents.DataSource = allStudents;
        }
    }

    public class CustomCheckBoxColumn : GridViewCheckBoxColumn {
        public override Type GetCellType(GridViewRowInfo row) {
            if (row is GridViewTableHeaderRowInfo) {
                return typeof(CheckBoxHeaderCell);
            }
            return base.GetCellType(row);
        }
    }
}

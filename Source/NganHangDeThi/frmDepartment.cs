using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model.POCO;
using Telerik.WinControls;
using Controller.Services;

namespace NganHangDeThi {
    public partial class frmDepartment : SimpleBaseForm<Department, DepartmentService> {
        public frmDepartment() {
            InitializeComponent();
            this.m_gridDepartments.ShowGroupPanel = false;
            this.m_gridDepartments.EnableHotTracking = true;
            //this.m_gridDepartments.ShowFilteringRow = true;
            this.m_gridDepartments.EnableFiltering = true;
            this.m_gridDepartments.EnableCustomFiltering = true;
            this.m_gridDepartments.CustomFiltering += GridSubjectCustomFiltering;
            m_txtFilter.TextChanged += m_txtFilter_TextChanged;

        }

        void m_txtFilter_TextChanged(object sender, EventArgs e) {
            this.m_gridDepartments.MasterTemplate.Refresh();
        }
        protected override void SetBindingSource() {
            base.SetBindingSource();
            m_gridDepartments.DataSource = BindingSource;
        }
        protected override void SetDetailBindingSource() {
            base.SetDetailBindingSource();
            m_txtDepartmentName.DataBindings.Add("Text", BindingSource, "DepartmentName", false, DataSourceUpdateMode.OnPropertyChanged);
            m_txtDeparmentNo.DataBindings.Add("Text", BindingSource, "DepartmentNo", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void LoadSecurityStatus() {
            base.LoadSecurityStatus();
            NotifyStateChanged();
        }
        private void GridSubjectCustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e) {
            if (string.IsNullOrEmpty(this.m_txtFilter.Text)) {
                e.Visible = true; for (int i = 0; i < this.m_gridDepartments.ColumnCount; i++) {
                    e.Row.Cells[i].Style.Reset(); e.Row.InvalidateRow();
                }
                return;
            }
            e.Visible = false;
            for (int i = 0; i < this.m_gridDepartments.ColumnCount; i++) {
                if (e.Row.Cells[i].Value != null) {
                    string text = e.Row.Cells[i].Value.ToString();
                    if (text.IndexOf(this.m_txtFilter.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0) {
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
    }
}

using Controller.Services;
using Model.POCO;
using System;

namespace NganHangDeThi {
    public partial class frmSchoolInfo : BaseForm {

        private SchoolInfoService m_service;
        private SchoolInfo m_schoolInfo;

        public frmSchoolInfo() {
            InitializeComponent();
            this.Load += OnLoad;
            m_service = new SchoolInfoService();
            txtSchoolName.TextChanged += OnTextChange;
            txtEmail.TextChanged += OnTextChange;
            txtFax.TextChanged += OnTextChange;
            txtHomePhone.TextChanged += OnTextChange;
        }

        private void OnTextChange(object sender, EventArgs e) {
            IsDirty = true;
            LoadSecurityStatus();
        }

        private void OnLoad(object sender, EventArgs e) {
            m_schoolInfo = m_service.GetSchoolInfo();
            if (m_schoolInfo != null)
            {
                txtSchoolName.Text = m_schoolInfo.SchoolName;
                txtHomePhone.Text = m_schoolInfo.HomePhone;
                txtEmail.Text = m_schoolInfo.Email;
                //Because in database not have Fax so i will get Phone as Fax.:)
                txtFax.Text = m_schoolInfo.Phone;
            }
            LoadSecurityStatus();
        }

        public override void Save() {
            if (!string.IsNullOrEmpty(txtSchoolName.Text)) {
                if(m_schoolInfo==null)
                    m_schoolInfo=new SchoolInfo();
                m_schoolInfo.SchoolName = txtSchoolName.Text;
                m_schoolInfo.HomePhone=txtHomePhone.Text;
                m_schoolInfo.Email = txtEmail.Text;
                m_schoolInfo.Phone = txtFax.Text;
                m_service.Save(m_schoolInfo);
                IsDirty = false;
                LoadSecurityStatus();
            }
        }

        public override void LoadSecurityStatus() {
            CanCreate = false;
            CanEdit = true;
            CanDelete = false;
            //IsDirty = true;
            NotifyStateChanged();
            (this.ParentForm as MainForm).CancelButton = false;
        }
    }
}

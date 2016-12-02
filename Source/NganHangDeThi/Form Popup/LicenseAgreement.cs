using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace NganHangDeThi.Form_Popup {
    public partial class ResizeImageInRichTextBox : Telerik.WinControls.UI.RadForm {
        public bool IsRegisterOk { get; set; }
        public ResizeImageInRichTextBox() {
            InitializeComponent();
            IsRegisterOk = false;
            textBox1.Text = LicenseKey.LicenseKeyHelper.Value();
        }

        private void radButton1_Click(object sender, EventArgs e) {
            System.Windows.Forms.Clipboard.SetText(textBox1.Text);
        }

        private void radButton2_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBox2.Text)) {
                RadMessageBox.Show("Xin vui lòng nhập mã kích hoạt! Nếu bạn chưa có mã kích hoạt vui lòng liên hệ: \n Admin để lấy mã kích hoạt!", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            if (!LicenseKey.LicenseKeyHelper.IsGenuine(textBox2.Text)) {
                RadMessageBox.Show("Mã kích hoạt không đúng! Vui lòng liên hệ Admin để nhận mã kích hoạt!", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            RadMessageBox.Show("Đăng kí thành công!", "Thông báo", MessageBoxButtons.OK, RadMessageIcon.Info);
            string registerFile = Path.Combine(Application.StartupPath, "key.ini");
            File.WriteAllText(registerFile,textBox2.Text);
            DialogResult = DialogResult.OK;
            IsRegisterOk = true;
        }
    }
}

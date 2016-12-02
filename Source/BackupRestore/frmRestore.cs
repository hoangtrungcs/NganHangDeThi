using NganHangDeThi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace BackupRestore
{
    public partial class frmRestore : RadForm
    {
        public frmRestore()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Tập tin dữ liệu|*.bak";
            if (openFile.ShowDialog() == DialogResult.OK) {
                txtFilePath.Text = openFile.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtFilePath.Text.Trim())) {
                RadMessageBox.Show("Bạn phải chọn tập tin dữ liệu để phục hồi", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            RestoreHelper restore = new RestoreHelper();
            string dbName = ConfigurationManager.AppSettings["Database"];
            string usr = ConfigurationManager.AppSettings["User"];
            string pwd = ConfigurationManager.AppSettings["Password"];
            string server = ConfigurationManager.AppSettings["Server"];
            string dataFile = ConfigurationManager.AppSettings["DataFilePath"];
            string logFile = ConfigurationManager.AppSettings["DataFilePath"];
            try {
                restore.RestoreDatabase(dbName, txtFilePath.Text, server, usr, pwd, dataFile, logFile);
                RadMessageBox.Show("Phục hồi dữ liệu thành công", "Thành công", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.Close();
                Process.Start(@"..\..\..\NganHangDeThi\bin\Debug\NganHangDeThi.exe");
            } catch {
                RadMessageBox.Show("Không thể phục hồi, bạn hãy chắc chắn rằng tất cả kết nối đến cơ sở dữ liệu đều đã được đóng và thử lại.",
                                    "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}

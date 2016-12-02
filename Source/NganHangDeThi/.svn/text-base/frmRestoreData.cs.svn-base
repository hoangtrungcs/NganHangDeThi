using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class frmRestoreData : BaseForm {
        public frmRestoreData() {
            InitializeComponent();
            // Register event
            btnRestore.Click += OnRestore;
        }

        private void OnRestore(object sender, EventArgs e) {
            //if (!string.IsNullOrEmpty(brwFileName.Value)) {
            //    StringBuilder queryBuilder = new StringBuilder();
            //    queryBuilder.AppendLine("DROP DATABASE [NganHang]");
            //    queryBuilder.AppendLine("GO");
            //    queryBuilder.AppendLine("CREATE DATABASE [NganHang]");
            //    queryBuilder.AppendLine("GO");
            //    queryBuilder.AppendLine("USE [NganHang]");
            //    queryBuilder.AppendLine("GO");
            //    string[] lines = File.ReadAllLines(brwFileName.Value);
            //    foreach (string line in lines) {
            //        queryBuilder.AppendLine(line);
            //    }
            //    string query = queryBuilder.ToString();
            //    SqlConnection connection = new SqlConnection("data source=(local);initial catalog=NganHang;MultipleActiveResultSets=True;User Id=sa;Password=p@ssw0rd");
            //    SqlCommand cmd = new SqlCommand(query, connection);
            //    connection.Open();
            //    cmd.ExecuteNonQuery();
            //    connection.Close();
            //}

            try {
                // Copy database file
                string serverDB = ConfigurationManager.AppSettings["ServerDb"];
                string localDB = ConfigurationManager.AppSettings["LocalDb"];
                if (!string.IsNullOrEmpty(brwFileServer.Value)) {
                    File.Copy(brwFileServer.Value, serverDB, true);
                }
                if (!string.IsNullOrEmpty(brwFileLocal.Value)) {
                    File.Copy(brwFileLocal.Value, localDB, true);
                }
                RadMessageBox.Show("Phục hồi thành công", "Thông báo", MessageBoxButtons.OK);
            } catch {
                RadMessageBox.Show("Phục hồi thất bại! Có thể do chương trình nào đó đang đọc tập tin database", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void brwFileName_Click(object sender, EventArgs e) {
            RadBrowseEditor editor = sender as RadBrowseEditor;
            OpenFileDialog openFile = new OpenFileDialog();
            // Default file extension
            openFile.DefaultExt = "bak";
            // Available file extensions
            openFile.Filter = "(*.bak)|*.bak";
            // Adds a extension if the user does not
            openFile.AddExtension = true;
            // Restores the selected directory, next time
            openFile.RestoreDirectory = true;
            // Dialog title
            openFile.Title = "Chọn csdl cần phục hồi";
            // Startup directory
            openFile.InitialDirectory = Application.ExecutablePath;
            // Show the dialog and process the result
            if (openFile.ShowDialog() == DialogResult.OK) {
                editor.Value = openFile.FileName;
            }
            openFile.Dispose();
            openFile = null;
        }
    }
}

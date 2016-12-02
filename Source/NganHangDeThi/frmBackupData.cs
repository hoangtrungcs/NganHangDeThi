using Common;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using NganHangDeThi.Helpers;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class frmBackupData : BaseForm {
        
        public frmBackupData() {
            InitializeComponent();
        }
        
        private void btnBackup_Click(object sender, EventArgs e) {
            //BackupHelper backup = new BackupHelper();
            //if (DbHelper.ConnectionString == DbHelper.ServerConnectionString) {
            //    // Backup server                
            //    string dbName = ConfigurationManager.AppSettings["Database"];
            //    string usr = ConfigurationManager.AppSettings["User"];
            //    string pwd = ConfigurationManager.AppSettings["Password"];
            //    string server = ConfigurationManager.AppSettings["Server"];
            //    if (string.IsNullOrEmpty(brwSaveFilePath.Value)) {
            //        RadMessageBox.Show("Vui lòng chọn nơi để lưu trữ tập tin!", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            //        return;
            //    }
            //    if (File.Exists(brwSaveFilePath.Value)) {
            //        File.Delete(brwSaveFilePath.Value);
            //    }
            //    try {
            //        backup.BackupServerDatabase(dbName, usr, pwd, server, brwSaveFilePath.Value);
            //        RadMessageBox.Show("Backup successful!", "Success", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    } catch (Exception ex) {
            //        RadMessageBox.Show("Backup failed!\n" + ex.ToString(), "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            //    }
            //} else {
            //    // Back up local
            //    if (string.IsNullOrEmpty(brwSaveFilePath.Value)) {
            //        RadMessageBox.Show("Vui lòng chọn nơi để lưu trữ tập tin!", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            //        return;
            //    }
            //    backup.BackupLocalDatabase(string.Empty, brwSaveFilePath.Value);
            //}

            try {
                // Copy database file
                string folderPath = brwSaveFilePath.Value;
                string serverDB = ConfigurationManager.AppSettings["ServerDb"];
                string localDB = ConfigurationManager.AppSettings["LocalDb"];
                if (string.IsNullOrEmpty(folderPath)) {
                    RadMessageBox.Show("Xin hãy chọn thư mục chứa database!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (!Directory.Exists(folderPath)) {
                    RadMessageBox.Show("Thư mục không tồn tại, mời bạn xem lại.", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (chkDbServer.Checked) {
                    File.Copy(serverDB, string.Format("{0}\\{1}", folderPath, "ServerDatabase.bak"), true);
                }
                if (chkDbLocal.Checked) {
                    File.Copy(localDB, string.Format("{0}\\{1}", folderPath, "LocalDatabase.bak"), true);
                }
                RadMessageBox.Show("Sao lưu thành công", "Thông báo", MessageBoxButtons.OK);
            } catch {
                RadMessageBox.Show("Sao lưu thất bại! Có thể do chương trình nào đó đang đọc tập tin database", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void brwSaveFilePath_Click(object sender, EventArgs e) {
            //SaveFileDialog saveFile = new SaveFileDialog();
            //// Default file extension
            //saveFile.DefaultExt = "bak";
            //// Available file extensions
            //saveFile.Filter = "(*.bak)|*.bak";
            //// Adds a extension if the user does not
            //saveFile.AddExtension = true;
            //// Restores the selected directory, next time
            //saveFile.RestoreDirectory = true;
            //// Dialog title
            //saveFile.Title = "Save file";
            //// Startup directory
            //saveFile.InitialDirectory = Application.ExecutablePath;
            //// Show the dialog and process the result
            //if (saveFile.ShowDialog() == DialogResult.OK) {
            //    brwSaveFilePath.Value = saveFile.FileName;
            //}
            //saveFile.Dispose();
            //saveFile = null;

            using (FolderBrowserDialog dialog = new FolderBrowserDialog()) {
                dialog.Description = "Chọn thư mục lưu trữ database";
                dialog.ShowNewFolderButton = true;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (dialog.ShowDialog() == DialogResult.OK) {
                    brwSaveFilePath.Value = dialog.SelectedPath;
                }
            }
        }

        private void ScriptDatabase(string saveFilePath) {
            //if (!string.IsNullOrEmpty(saveFilePath)) {
            //    // This method is need 4 dll of ssms, they are stored C:\Program Files\Microsoft SQL Server\110\SDK\Assemblies
            //    // The folder can be changed by each computer other.
            //    // To do: Make folder dll for them. (I dont know it's comfortable with any ssms version or not. Discuss later :D)
            //    // Dll: Microsoft.SqlServer.ConnectionInfo.dll
            //    // Microsoft.SqlServer.Smo.dll
            //    // Microsoft.SqlServer.Management.Sdk.Sfc.dll
            //    // Microsoft.SqlServer.SqlEnum.dll
            //    try {
            //        string serverName = ConfigurationManager.AppSettings["Server"];
            //        string userName = ConfigurationManager.AppSettings["User"];
            //        string password = ConfigurationManager.AppSettings["Password"];
            //        string dbName = ConfigurationManager.AppSettings["Database"];
            //        Server srv = new Server(new ServerConnection(serverName, userName, password));
            //        Database dbs = srv.Databases[dbName];
            //        ScriptingOptions options = new ScriptingOptions();
            //        //options.AnsiPadding = true;
            //        //options.AppendToFile = false;
            //        //options.ContinueScriptingOnError = false;
            //        //options.ConvertUserDefinedDataTypesToBaseType = false;
            //        //options.WithDependencies = false;



            //        options.ScriptData = true;
            //        options.ScriptDrops = false;
            //        options.FileName = saveFilePath;
            //        options.EnforceScriptingOptions = true;
            //        options.ScriptSchema = true;
            //        options.IncludeHeaders = false;
            //        options.AppendToFile = true;
            //        options.DriAllKeys = true;
            //        Cursor.Current = Cursors.WaitCursor;
            //        foreach (Table tbl in dbs.Tables) {
            //            tbl.EnumScript(options).ToList();
            //        }
            //        RadMessageBox.Show("Successful");
            //    } catch (Exception ex) {
            //        RadMessageBox.Show(ex.Message);
            //    } finally {
            //        Cursor.Current = Cursors.Default;
            //    }
            //}
        }
    }
}

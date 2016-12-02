using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHangDeThi.Helpers {
    public class FileHelper {
        /// <summary>
        /// Get save file path
        /// </summary>
        /// <returns>File path to save</returns>
        public static string GetSaveFilePath() {
            string filePathResult = string.Empty;
            SaveFileDialog saveFile = new SaveFileDialog();
            // Default file extension
            saveFile.DefaultExt = "qbk";
            // Available file extensions
            saveFile.Filter = "Câu hỏi (*.qbk)|*.qbk|Tất cả (*.*)|*.*";
            // Adds a extension if the user does not
            saveFile.AddExtension = true;
            // Restores the selected directory, next time
            saveFile.RestoreDirectory = true;
            // Dialog title
            saveFile.Title = "Chọn nơi lưu trữ câu hỏi";
            // Startup directory
            saveFile.InitialDirectory = Application.ExecutablePath;
            // Show the dialog and process the result
            if (saveFile.ShowDialog() == DialogResult.OK) {
                filePathResult = saveFile.FileName;
            }
            saveFile.Dispose();
            saveFile = null;
            return filePathResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Controller.Services;
using Microsoft.Office.Interop.Word;
using Model.POCO;
using Telerik.WinControls;
using Common;
using Telerik.WinControls.RichTextBox.FileFormats.OpenXml.Docx;
using Telerik.WinControls.RichTextBox.FileFormats.Rtf;
using Telerik.WinControls.RichTextBox.FormatProviders;
using Telerik.WinControls.RichTextBox.Model;
using Microsoft.Office.Interop.Word;

namespace NganHangDeThi.ReportWithImage
{
    public partial class frmTestReportWithImage : Telerik.WinControls.UI.RadForm
    {
        private SchoolInfoService m_schoolInfoService;
        private TestsService m_testsService;
        private SubjectsService m_subjectService;
        private QuestionModelService _questionModelService;
        const string Path = @"D:\contentRtf.rtf";

        public frmTestReportWithImage()
        {
            InitializeComponent();
            NganHangEntities context = new NganHangEntities();
            m_schoolInfoService = new SchoolInfoService();
            m_testsService = new TestsService(context);
            m_subjectService = new SubjectsService(context);

            _questionModelService = new QuestionModelService(context);
        }

        public frmTestReportWithImage(int testCopyId, int no)
            : this()
        {

            const string testNameField = "«TESTNAME»";
            const string subjectField = "«SUBJECT»";
            const string classNameField = "«CLASSNAME»";
            const string testDateField = "«testDate»";
            const string testTimeField = "«testTime»";

            //richTextBox1.LoadFile(Path, RichTextBoxStreamType.RichText);
            //return;

            TestCopy testCopy = m_testsService.GetTestCopy(testCopyId);
            Test test = m_testsService.GetTestById(testCopy.FK_TestId);
            //var schoolName = school == null ? string.Empty : school.SchoolName;
            //rp.SubjectName = m_subjectService.GetById(test.FK_SubjectId) != null ?
            //                    m_subjectService.GetById(test.FK_SubjectId).Name.ToUpper() : string.Empty;
            //rp.SubjectHeader += rp.SubjectName;

            //rp.TestName = string.Format("ĐỀ SỐ 0{0}", no);
            //rp.TestDate = test.TestDate.ToString("dd/MM/yyyy");
            //rp.TestTime = string.Format("{0} phút", test.Time);
            //if (test.Class != null)
            //    rp.ClassName = string.Format("{0}{1}", "LỚP: ", test.Class.ClassName);

            //var schoolName = school == null ? string.Empty : school.SchoolName;
            var subjectName = m_subjectService.GetById(test.FK_SubjectId) != null ?
                                 m_subjectService.GetById(test.FK_SubjectId).Name.ToUpper() : string.Empty;

            var subjectTestName = test.Name;
            var testName = string.Format("ĐỀ SỐ 0{0}", no);
            var testDate = test.TestDate.ToString("dd/MM/yyyy");
            var testTime = string.Format("{0} phút", test.Time);

            var className = string.Empty;
            if (test.LopHoc != null)
                className = string.Format("{0}", test.LopHoc.ClassName);

            var testDetails = _questionModelService.GetTestDetails(testCopyId);
            int i = 1;

            foreach (var questionModel in testDetails)
            {
                if (questionModel.Content.Contains(i.ToString() + "."))
                {
                    richTextBox1.AppendText(i.ToString() + ".");
                    // radRichTextBox1.Insert(i.ToString() + ".");
                    var content = questionModel.Content.Replace(i.ToString() + ".", "").Trim();
                    Merge(content, richTextBox1.Rtf, i);
                    //RtfFormatProvider provider1 = new RtfFormatProvider();
                    //Merge(content, provider1.Export(radRichTextBox1.Document), i);
                    i++;
                }

            }
            richTextBox1.Rtf = rtbMerged.Rtf;
            //richTextBox1.SaveFile(m_subjectService != null && string.Format(@"D:\{0}", m_subjectService.GetById(test.FK_SubjectId)) != null ?
            //                    m_subjectService.GetById(test.FK_SubjectId).Name.ToUpper() : string.Empty);

            richTextBox1.SelectAll();
            Clipboard.Clear();
            // richTextBox1.Copy();
            Clipboard.SetText(richTextBox1.SelectedRtf, TextDataFormat.Rtf);

            #region Docx
            //   // Modify to suit your machine:
            //   string fileName = @"D:\rpMultiTestQuestion.docx";

            //   string newFileName = subjectName.Replace(" ", "_") + "_" + testName.Replace(" ", "_") + ".docx";
            //   // Create a document in memory:
            //   //var doc = DocX.Create(fileName);

            //   var docLoad = DocX.Load(fileName);
            //   // Insert a paragrpah:
            //   //docLoad.InsertParagraph("This is my first paragraph");


            //   docLoad.ReplaceText("<<Subject>>", subjectName);

            //   docLoad.ReplaceText("<<Content>>", Clipboard.GetData(DataFormats.Rtf).ToString());
            ////   DocxFormatProvider provider=new DocxFormatProvider();

            //   // Save to the output directory:
            //   docLoad.SaveAs(@"D:\" + newFileName);

            #endregion

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            object filename = @"D:\rpMultiTestQuestion.doc";
            object newFileName = @"D:\" + subjectName.Replace(" ", "_") + "_" + subjectTestName + "_" + testName.Replace(" ", "_") + ".doc";

            object missing = Type.Missing;
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            Microsoft.Office.Interop.Word.Selection sel = wordApp.Selection;
            object end = doc.Content.End;
            object start = (int)end - 11;
            doc.Range(ref start, ref end).Select();
            sel.Paste();

            var range = doc.Range();

            range.Find.Execute(FindText: classNameField, Replace: WdReplace.wdReplaceAll, ReplaceWith: className);
            range.Find.Execute(FindText: subjectField, Replace: WdReplace.wdReplaceAll, ReplaceWith: subjectName);
            range.Find.Execute(FindText: testNameField, Replace: WdReplace.wdReplaceAll, ReplaceWith: testName);
            range.Find.Execute(FindText: testDateField, Replace: WdReplace.wdReplaceAll, ReplaceWith: testDate);
            range.Find.Execute(FindText: testTimeField, Replace: WdReplace.wdReplaceAll, ReplaceWith: testTime);

            doc.SaveAs(ref newFileName,
                       ref missing, ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing, ref missing);
            //doc.Close();

            //Marshal.ReleaseComObject(wordApp);
            //richTextBox1.Paste();
            //doc.Close(ref missing, ref missing, ref missing);
            //Marshal.ReleaseComObject(wordApp);
            Process.Start("WINWORD.EXE", newFileName.ToString());
        }

        RichTextBox rtbMerged = new RichTextBox();

        public string Merge(string s1, string s2, int count)
        {
            rtbMerged.AppendText(count.ToString() + ". ");
            RichTextBox rtbTemp = new RichTextBox();

            rtbTemp.Rtf = s1;
            rtbTemp.SelectAll();
            rtbTemp.Cut();
            rtbMerged.Paste();

            rtbMerged.AppendText(Environment.NewLine);
            rtbMerged.AppendText(Environment.NewLine);

            //rtbTemp.Rtf = s2;
            //rtbTemp.SelectAll();
            //rtbTemp.Cut();
            //rtbMerged.Paste();

            return rtbMerged.Rtf;
        }

        private void btnExportToWord_Click(object sender, EventArgs e)
        {

            //DocxFormatProvider provider = new DocxFormatProvider();
            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.DefaultExt = ".docx";
            //saveDialog.Filter = "Documents|*.docx";
            //DialogResult dialogResult = saveDialog.ShowDialog();
            //if (dialogResult == System.Windows.Forms.DialogResult.OK)
            //{
            //    using (Stream output = saveDialog.OpenFile())
            //    {
            //        provider.Export(radRichTextBox1.Document, output);
            //        MessageBox.Show("Saved Successfuly!");
            //    }
            //}
        }
    }
}

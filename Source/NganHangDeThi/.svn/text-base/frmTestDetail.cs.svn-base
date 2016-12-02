using System.IO;
using Telerik.WinControls.RichTextBox.FileFormats.OpenXml.Docx;
using Telerik.WinControls.RichTextBox.FormatProviders;
using Telerik.WinControls.RichTextBox.Model;

namespace NganHangDeThi {
    public partial class frmTestDetail : Telerik.WinControls.UI.RadForm {
        public frmTestDetail() {
            InitializeComponent();
        }
        public void LoadContent(string fileName) {

            IDocumentFormatProvider provider = new DocxFormatProvider();

            using (Stream stream = File.Open(fileName, FileMode.Open)) {
                RadDocument document = provider.Import(stream);
                //this.DetachDocument(this.radRichTextBox1.Document);
                this.radRichTextBox1.Document = document;
                //this.AttachDocument(document);
                document.LayoutMode = DocumentLayoutMode.Paged;
            }


        }
    }
}

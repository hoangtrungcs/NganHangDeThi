using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NganHangDeThi.Form_Popup;

namespace NganHangDeThi.User_Controls
{
    public partial class CustomRichTextBox : RichTextBox
    {
        private readonly ContextMenu _contextMenu = new ContextMenu();
        private EventHandler _menuHandler;

        public CustomRichTextBox()
        {
            InitializeComponent();
            this.ContextMenu = _contextMenu;
            _menuHandler = new EventHandler(ContentMenu_Click);
            this.Width = 256;
            this.Height = 53;
            this.ScrollBars=RichTextBoxScrollBars.Vertical;
        }

        private void ContentMenu_Click(object sender, EventArgs e)
        {
            if (_contextMenu.MenuItems[0].Text == "Thêm hình ảnh")
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "JPG files (*.jpg)|*.jpg";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(openFileDialog1.FileName);
                    Clipboard.SetImage(image);
                    this.Paste();
                    Clipboard.Clear();
                }
            }
            else if (_contextMenu.MenuItems[0].Text == "Chỉnh sửa")
            {
                // var width= richTextBox1.Text.Substring(m_txtContent.SelectedRtf.IndexOf(@"\pict\wmetafile"),)
                ResizeImage frmResizeImage = new ResizeImage(100, 100);
                frmResizeImage.Show();
                var a = frmResizeImage.ImageSizeResult;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //Point point = new Point(e.X, e.Y);
                    if (this.SelectionType == RichTextBoxSelectionTypes.Object &&
                        this.SelectedRtf.IndexOf(@"\pict\wmetafile", System.StringComparison.Ordinal) != -1)
                    {
                        _contextMenu.MenuItems.Clear();
                        _contextMenu.MenuItems.Add("Chỉnh sửa", _menuHandler);
                        return;
                    }
                    _contextMenu.MenuItems.Clear(); // error here
                    _contextMenu.MenuItems.Add("Thêm hình ảnh", _menuHandler); //error here
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                DataFormats.Format df = DataFormats.GetFormat(DataFormats.Bitmap);
                StringCollection strcollect = Clipboard.GetFileDropList();
                if (strcollect.Count > 0)
                {
                    Image image = Image.FromFile(strcollect[0]);
                    Clipboard.Clear();
                    Clipboard.SetImage(image);
                    if (Clipboard.ContainsImage())
                    {
                        this.Paste(df);
                        e.Handled = true;
                        Clipboard.Clear();
                    }
                }
            }

        }
    }
}

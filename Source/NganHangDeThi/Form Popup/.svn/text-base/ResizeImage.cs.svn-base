using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Telerik.WinControls;

namespace NganHangDeThi.Form_Popup
{
    public partial class ResizeImage : Telerik.WinControls.UI.RadForm
    {
        public System.Windows.Size ImageSizeResult { get; set; }

        public ResizeImage(double width, double height)
        {
            InitializeComponent();

            ImageSizeResult = new System.Windows.Size(width, height);

            //Set width and height of image before edit 
            lblHiddenWidth.Text = width.ToString();
            lblHiddenHeight.Text = height.ToString();

            numbericWidth.Text = width.ToString();
            numbericHeight.Text = height.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ImageSizeResult = CalculateDimensions(
                  new System.Windows.Size(Convert.ToDouble(lblHiddenWidth.Text), Convert.ToDouble(lblHiddenHeight.Text)),
                  Convert.ToDouble(numbericWidth.Value), Convert.ToDouble(numbericHeight.Value));
        }

        public static System.Windows.Size CalculateDimensions(System.Windows.Size currentSize, double maxWidth, double maxHeight)
        {
            if (currentSize.Width <= maxWidth && currentSize.Height <= maxHeight)
                return currentSize;

            var sourceWidth = (double)currentSize.Width;
            var sourceHeight = (double)currentSize.Height;

            var widthPercent = maxWidth / sourceWidth;
            var heightPercent = maxHeight / sourceHeight;

            var percent = heightPercent < widthPercent
                           ? heightPercent
                           : widthPercent;

            var destWidth = (int)(sourceWidth * percent);
            var destHeight = (int)(sourceHeight * percent);

            return new System.Windows.Size(destWidth, destHeight);
        }
    }
}

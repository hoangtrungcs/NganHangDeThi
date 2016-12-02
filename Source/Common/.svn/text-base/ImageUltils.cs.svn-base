using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ImageUltils
    {
        //private void rtfImage_Paint(object sender, PaintEventArgs e)
        //{
        //    string rtfStr = System.IO.File.ReadAllText("MySampleFile.rtf");
        //    string imageDataHex = ExtractImgHex(rtfStr);
        //    byte[] imageBuffer = ToBinary(imageDataHex);
        //    Image image;
        //    using (MemoryStream stream = new MemoryStream(imageBuffer))
        //    {
        //        image = Image.FromStream(stream);
        //    }
        //    Rectangle rect = new Rectangle(0, 0, 100, 100);
        //    e.Graphics.DrawImage(image, rect);
        //}

        public static string ExtractImgHex(string s)
        {
            // I'm sure you could use regex here, but this works.
            // This assumes one picture per file; loops required otherwise
            int pictTagIdx = s.IndexOf("{\\pict\\");
            int startIndex = s.IndexOf(" ", pictTagIdx) + 1;
            int endIndex = s.IndexOf("}", startIndex);
            return s.Substring(startIndex, endIndex - startIndex);
        }

        public static byte[] ToBinary(string imageDataHex)
        {
            //this function taken entirely from:
            // http://www.codeproject.com/Articles/27431/Writing-Your-Own-RTF-Converter
            if (imageDataHex == null)
            {
                throw new ArgumentNullException("imageDataHex");
            }

            int hexDigits = imageDataHex.Length;
            int dataSize = hexDigits / 2;
            byte[] imageDataBinary = new byte[dataSize];

            StringBuilder hex = new StringBuilder(2);

            int dataPos = 0;
            for (int i = 0; i < hexDigits; i++)
            {
                char c = imageDataHex[i];
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }
                hex.Append(imageDataHex[i]);
                if (hex.Length == 2)
                {
                    imageDataBinary[dataPos] = byte.Parse(hex.ToString(), System.Globalization.NumberStyles.HexNumber);
                    dataPos++;
                    hex.Remove(0, 2);
                }
            }
            return imageDataBinary;
        }
    }
}

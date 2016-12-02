using System.Windows.Forms;

namespace Common
{
    public static class RtfHelpers
    {
        /// <summary>
        /// Converts the text to RTF.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string ConvertTextToRtf(string text)
        {
            if (!text.StartsWith(@"{\rtf"))
            {
                using (var rtb = new RichTextBox())
                {
                    rtb.Text = text;
                    return rtb.Rtf;
                }
            }
            return text;
        }

        /// <summary>
        /// Converts the RTF to text.
        /// </summary>
        /// <param name="rtf">The RTF.</param>
        /// <returns></returns>
        public static string ConvertRtfToText(string rtf)
        {
            if (rtf.StartsWith(@"{\rtf"))
            {
                using (var rtb = new RichTextBox())
                {
                    rtb.Rtf = rtf;
                    return rtb.Text;
                }
            }
            return rtf;
        }


    }
}

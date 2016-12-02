using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHangDeThi
{
    public partial class SplashScreen : Form
    {
        delegate void StringParameterDelegate(string Text);
        delegate void StringParameterWithStatusDelegate(string Text, Splash.TypeOfMessage tom);
        delegate void SplashShowCloseDelegate();
        /// <summary>
        /// To ensure splash screen is closed using the API and not by keyboard or any other things
        /// </summary>
        bool CloseSplashScreenFlag = false;

        public SplashScreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public void ShowSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }
            CloseSplashScreenFlag = true;
            this.Close();
        }
        /// <summary>
        /// Prevents the closing of form other than by calling the CloseSplashScreen function
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseSplashScreenFlag == false)
                e.Cancel = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangDeThi
{
    public class Splash
    {
        /// <summary>
        /// Defined types of messages: Success/Warning/Error.
        /// </summary>
        public enum TypeOfMessage
        {
            Success,
            Warning,
            Error,
        }
        /// <summary>
        /// Initiate instance of SplashScreen
        /// </summary>
        public static class SplashScreenManage
        {
            static SplashScreen sf = null;

            /// <summary>
            /// Displays the splashscreen
            /// </summary>
            public static void ShowSplashScreen()
            {
                if (sf == null)
                {
                    sf = new SplashScreen();
                    sf.ShowSplashScreen();
                }
            }

            /// <summary>
            /// Closes the SplashScreen
            /// </summary>
            public static void CloseSplashScreen()
            {
                if (sf != null)
                {
                    sf.CloseSplashScreen();
                    sf = null;
                }
            }

       
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Model.POCO;
using NganHangDeThi.Form_Popup;

namespace NganHangDeThi {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

           // string key = GetCDKey("1882757847");
           // MessageBox.Show(key.ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string registerFile = Path.Combine(Application.StartupPath, "key.ini");
            bool isRegister = false;
            if (!File.Exists(registerFile)) {
                ResizeImageInRichTextBox license = new ResizeImageInRichTextBox();
                isRegister = license.ShowDialog() == DialogResult.OK && license.IsRegisterOk;
            } else {
                string info = File.ReadAllText(registerFile);
                isRegister = LicenseKey.LicenseKeyHelper.IsGenuine(info);
                if (!isRegister) {
                    ResizeImageInRichTextBox license = new ResizeImageInRichTextBox();
                    isRegister = license.ShowDialog() == DialogResult.OK && license.IsRegisterOk;
                }
            }
            if (isRegister) {
                Thread splashthread = new Thread(new ThreadStart(Splash.SplashScreenManage.ShowSplashScreen));
                splashthread.IsBackground = true;
                splashthread.Start();

                Assembly versionNumber = Assembly.GetExecutingAssembly();

                string version = versionNumber.GetName().Version.ToString();
                List<string> versionInfos = UpdateMe.update.getUpdateInfo("https://dl.dropboxusercontent.com/u/113932393/", "Version.txt",
                                              Application.StartupPath + @"\", 1);
                Splash.SplashScreenManage.CloseSplashScreen();
                if (versionInfos!=null)
                {
                    if (!versionInfos[1].Contains(version))
                    {
                        string path = UpdateMe.UpdateMe.postProcess;
                        System.Diagnostics.Process process = System.Diagnostics.Process.Start(path);
                        while (!process.HasExited)
                        {
                            process.WaitForExit(300);
                            //TODO: UPdate
                        }
                        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(UpdateMe.UpdateMe.mainApp);
                        string newVersion = myFileVersionInfo.FileVersion;
                        if (newVersion.Contains(versionInfos[1]))
                        {
                            Application.Restart();
                            return;
                        }
                    }
                }
               
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
               
                //var config = new DbMigrationsConfiguration<NganHangEntities> { AutomaticMigrationsEnabled = true };
                //var migrator = new DbMigrator(config);
                //migrator.Update();

                Application.Run(new MainForm());
            }
            //Application.Run(new MainForm());
        }

     //   public static string CryptographyMD5(string source)
     //   {
     //       string str = "";
     //       try
     //       {
     //           MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
     //           byte[] bytes = Encoding.UTF8.GetBytes(source);
     //           byte[] buffer2 = provider.ComputeHash(bytes);
     //           foreach (byte num in buffer2)
     //           {
     //               str = str + int.Parse(num.ToString(), NumberStyles.HexNumber).ToString();
     //           }
     //       }
     //       catch
     //       {
     //       }
     //       return str;
     //   }

     //   public static string GetCDKey(string Source)
     //   {
     //       string str = "";
     //       string[] strArray = new string[] { 
     //   "H", "I", "N", "H", "Q", "U", "R", "N", "G", "P", "L", "K", "J", "H", "G", "F", 
     //   "D", "S", "A", "Z", "X", "C", "V", "B", "N", "M"
     //};
     //       string[] strArray2 = new string[] { 
     //   "A", "W", "N", "Y", "Q", "U", "A", "N", "G", "P", "O", "H", "L", "K", "N", "A", 
     //   "S", "D", "F", "C", "V", "Z", "X", "M", "J", "B"
     //};
     //       if (Source != "")
     //       {
     //           str = CryptographyMD5(Source);
     //           char[] chArray = str.ToCharArray(0, str.Trim().Length);
     //           for (int i = 0; i < chArray.Length; i++)
     //           {
     //               if ((i % 2) == 1)
     //               {
     //                   str = str + chArray[i];
     //               }
     //           }
     //           char[] chArray2 = str.Trim().ToCharArray(0, str.Trim().Length);
     //           str = "";
     //           for (int j = 0; j < 20; j++)
     //           {
     //               if ((j % 2) == 1)
     //               {
     //                   str = str + strArray[int.Parse(chArray[j].ToString())];
     //               }
     //               else
     //               {
     //                   str = str + strArray2[int.Parse(chArray[j].ToString())];
     //               }
     //           }
     //       }
     //       return str;
     //   }

    }
}

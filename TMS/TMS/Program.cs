using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TMS.Properties;
using System.Threading;
namespace TMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>                
        
        static Mutex mutex = new Mutex(true, "{9F5FF4AC-B9A1-45fd-A8CF-72ELVI6BDE8F}");
        [STAThread]
        static void Main()
        {   
            DevExpress.UserSkins.BonusSkins.Register(); 
            if (true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TMS.login.frmLogin()); 
                if (Settings.Default.UserID != "") Application.Run(new frmMain());                
            }
            else NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace USDKDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Single Instance
           // SingleInstance.SingleApplication.Run(new SDKDemo());

           // Multi Instance
            Application.Run(new SDKDemo());
        }
    }
}

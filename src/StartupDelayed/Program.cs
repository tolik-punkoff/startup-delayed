using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StartupDelayed
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

            string cline = Environment.CommandLine.ToLowerInvariant();
            if (cline.IndexOf("/help") != -1)
            {
                Application.Run(new frmCLIHelp());
                return;
            }

            //анализируем остальные параметры.
            int i = 0;
            string[] cliargs = Environment.GetCommandLineArgs();
            foreach (string arg in cliargs)
            {                
                string a = arg.ToLowerInvariant();
                i++;
                switch (a)
                {
                    case "/run": CommonClass.Running = true;break;
                    case "/d":
                        {
                            CommonClass.ConfigPath = Environment.GetFolderPath
                                (Environment.SpecialFolder.LocalApplicationData)
                                + "\\StartupDelayed\\";
                            CommonClass.NoPortable = true;
                        }; break;                    
                }                
            }

            if (!CommonClass.NoPortable) //портабельный режим
            {
                //конфиги в директории с программой
                CommonClass.ConfigPath =
                    CommonClass.AddSlash(Application.StartupPath);
            }
            
            Application.Run(new frmMain());
        }
    }
}

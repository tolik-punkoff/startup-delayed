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

            if ((cline.IndexOf("/d") != -1) && (cline.IndexOf("/confdir") != -1))
            {
                MessageBox.Show("Укажите параметр /confdir <путь> или /d",
                        "Ошибка параметров командной строки", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                Application.Run(new frmCLIHelp());
                return;
            }

            //анализируем остальные параметры.
            int i = 0;
            int confdirN = 0;            
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
                    case "/confdir":
                        {
                            confdirN = i;
                            CommonClass.ConfDir = true;
                        } break;
                }                
            }
            //проверяем путь в confdir
            if (confdirN > 0)
            {
                if (confdirN < cliargs.Length)
                {
                    CommonClass.ConfigPath = CommonClass.AddSlash(cliargs[confdirN]);
                }
                else //параметр /confdir есть, а путь не указан
                {
                    MessageBox.Show("Не указан путь после параметра /confdir",
                        "Ошибка параметров командной строки", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Application.Run(new frmCLIHelp());
                    return;
                }
            }
            else //Параметра /confdir нет
            {
                if (!CommonClass.NoPortable) //параметра /d тоже
                {
                    //конфиги в директории с программой
                    CommonClass.ConfigPath =
                        CommonClass.AddSlash(Application.StartupPath);                     
                }
            }
            Application.Run(new frmMain());
        }
    }
}

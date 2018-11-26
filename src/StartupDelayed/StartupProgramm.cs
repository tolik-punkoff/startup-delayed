using System;
using System.Collections.Generic;
using System.Text;
using vbAccelerator.Components.Shell;
using System.Windows.Forms;

namespace StartupDelayed
{
    public static class StartupProgramm
    {
        public static void AddToStartup()
        {
            string StartupDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Startup);
            string LNKName = "\\DelayedStartup.lnk";
            string Target = Application.ExecutablePath;
            string WorkDir = Application.StartupPath;

            ShellLink shortcut = new ShellLink();
            shortcut.ShortCutFile = StartupDirectory + LNKName;
            shortcut.Target = Target;
            shortcut.WorkingDirectory = WorkDir;
            shortcut.IconPath = Target;
            shortcut.IconIndex = 0;
            shortcut.Description = "Менеджер отложенной автозагрузки";
            shortcut.Arguments = "/run ";
            if (CommonClass.NoPortable) // параметр /d
            {
                shortcut.Arguments = shortcut.Arguments + "/d";
            }
            if (CommonClass.ConfDir) //параметр ConfDir
            {
                shortcut.Arguments = shortcut.Arguments + "/confdir "+CommonClass.ConfigPath;
            }
            shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
            shortcut.Save();
        }
    }
}

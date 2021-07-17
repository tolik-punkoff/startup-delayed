using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Diagnostics;
using System.ComponentModel;

namespace StartupDelayed
{
    public class StartupTask
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string TaskPath { get; set; }
        public string Parameters { get; set; }
        public string WorkingDirectory { get; set; }
        public ProcessWindowStyle WindowStyle { get; set; }
        public bool AsAdmin { get; set; }
        public bool ActiveTask { get; set; }

        public string ErrorMessage { get; private set; }
        public bool Complete { get; set; }

        public StartupTask(string path)
        {
            ID = -999;
            TaskName = string.Empty;
            Parameters = string.Empty;
            TaskPath = path;
            WorkingDirectory = string.Empty;
            WindowStyle = ProcessWindowStyle.Normal;
            AsAdmin = false;
            ActiveTask = true;

            Complete = false;
        }

        public bool Exist()
        {
            if (string.IsNullOrEmpty(TaskPath)) return false;

            DriveInfo[] drives = DriveInfo.GetDrives();
            List<string> drNames = new List<string>();

            string drName = GetDriveName(TaskPath);
            if (drName == string.Empty)
            {
                return File.Exists(TaskPath);
            }
            else
            {
                foreach (DriveInfo drive in drives)
                {
                    drNames.Add(GetDriveName(drive.Name));
                }

                if (drNames.Contains(drName))
                {
                    return File.Exists(TaskPath);
                }
                else
                    return false;
            }
        }

        private bool IsExecute()
        {
            FileInfo fi = new FileInfo(TaskPath);
            if (fi.Extension == "exe" || fi.Extension == "com"
                || fi.Extension == "bat" || fi.Extension == "cmd") return true;

            return false;
        }

        private bool IsAdmin()
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(
                WindowsIdentity.GetCurrent());

            return pricipal.IsInRole(
                WindowsBuiltInRole.Administrator);
        }

        private string GetDriveName(string sPath)
        {
            int colPos = sPath.IndexOf(':');
            if (colPos < 0) return string.Empty;
            return sPath.Substring(0, colPos);
        }

        public bool Run()
        {
            if (!ActiveTask)
            {
                ErrorMessage = "Not active";
                return false;
            }

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = TaskPath;
            psi.Arguments = Parameters;
            psi.UseShellExecute = !IsExecute();
            psi.WindowStyle = WindowStyle;
            if (!string.IsNullOrEmpty(WorkingDirectory.Trim()))
            {
                psi.WorkingDirectory = WorkingDirectory;
            }
            bool adm = IsAdmin();

            if (AsAdmin)
            {
                if (!adm)
                {
                    psi.Verb = "runas";
                }
            }

            try
            {
                Process.Start(psi);
            }
            catch (Win32Exception wex)
            {
                if (wex.NativeErrorCode == 1223) //нажали "Отмену" в окне UAC
                {
                    return true;
                }
                else //какой-то другой Win32 Error
                {
                    ErrorMessage = wex.NativeErrorCode.ToString() + " " + wex.Message;
                    return false;
                }
            }
            catch (Exception ex) //какой-то другой Exception
            {
                ErrorMessage = ex.Message;
                return false;
            }
            return true;
        }        
    }
}

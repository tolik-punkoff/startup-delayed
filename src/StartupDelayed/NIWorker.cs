using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace StartupDelayed
{
    public static class NIWorker
    {
        public static NotifyIcon niMain = null;
        private static Icon icoOK = Properties.Resources.ok;
        private static Icon icoError = Properties.Resources.error;
        private static Icon[] aniIcons = new Icon[]
            {
                Properties.Resources.ani01,
                Properties.Resources.ani02,
                Properties.Resources.ani03,
                Properties.Resources.ani04,
                Properties.Resources.ani05
            };
        private static Timer aniTimer = new Timer();
        private static Timer delayTimer = new Timer();
        private static int aniCtr = 0;

        public static void Start()
        {
            niMain.Visible = true;
            aniTimer.Interval = 250;
            aniTimer.Tick += new EventHandler(aniTimer_Tick);
            aniTimer.Start();
        }

        private static void aniTimer_Tick(object sender, EventArgs e)
        {
            niMain.Icon = aniIcons[aniCtr];
            aniCtr++;
            if (aniCtr == aniIcons.Length) aniCtr = 0;
        }

        public static void Stop()
        {
            aniTimer.Stop();
            niMain.Icon = aniIcons[aniIcons.Length-1];
        }

        public static void Pause(string Text)
        {
            aniTimer.Stop();
            if (!string.IsNullOrEmpty(Text))
            {
                niMain.ShowBalloonTip(5000, "Pause", Text, ToolTipIcon.Info);
            }
        }

        public static void Continue(string Text)
        {
            Start();
            if (!string.IsNullOrEmpty(Text))
            {
                niMain.ShowBalloonTip(5000, "Continue", Text, ToolTipIcon.Info);
            }
        }

        public static void ShowOK(int Delay)
        {
            niMain.Visible = true;
            Stop();
            niMain.Icon = icoOK;
            if (Delay != 0)
            {
                delayTimer.Interval = Delay;
                delayTimer.Tick += new EventHandler(delayTimer_Tick);
                delayTimer.Start();
            }
        }

        public static void ShowError(int Delay, string ErrorMessage)
        {
            niMain.Visible = true;
            Stop();
            niMain.Icon = icoError;
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                niMain.ShowBalloonTip(5000, "Error", ErrorMessage, ToolTipIcon.Error);
            }
            if (Delay != 0)
            {
                delayTimer.Interval = Delay;
                delayTimer.Tick += new EventHandler(delayTimer_Tick);
                delayTimer.Start();
            }
        }

        static void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            niMain.Visible = false;
        }

    }
}

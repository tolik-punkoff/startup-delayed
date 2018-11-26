using System;
using System.Collections.Generic;
using System.Text;

namespace StartupDelayed
{
    public static class CommonClass
    {
        public static bool NoPortable = false;
        public static bool Running = false;
        public static bool ConfDir = false;
        public static string ConfigPath = string.Empty;
        public static string AddSlash(string St)
        {
            if (!St.EndsWith("\\")) return St + "\\";
            return St;
        }
    }
}

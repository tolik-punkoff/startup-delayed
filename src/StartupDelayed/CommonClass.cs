using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StartupDelayed
{
    public static class CommonClass
    {
        public static bool NoPortable = false;
        public static bool Running = false;
        public static string ConfigPath = string.Empty;
        
        public static string AddSlash(string St)
        {
            if (!St.EndsWith("\\")) return St + "\\";
            return St;
        }

        public static string WrongPath(string sPath)
        {
            try
            {
                FileInfo f = new FileInfo(sPath);
            }
            catch (ArgumentNullException anex) //имя файла == null
            {
                return anex.Message;
            }
            catch (ArgumentException aex) //в пути недопустимые символы
            {
                return aex.Message;
            }            
            catch (PathTooLongException ptlex) //слишком длинный путь
            {
                return ptlex.Message;
            }
            catch (NotSupportedException nsex)
            {
                return nsex.Message + " Двоеточие в середине пути!";
            }

            return string.Empty;
        }
    }
}

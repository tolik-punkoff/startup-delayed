using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;


namespace StartupDelayed
{
    public enum TimeType
    {
        Secs=0, Min = 1
    }

    public class AppSettings
    {
        public TimeType CheckTimeType { get; set; }
        public int CheckTime { get; set; }
        public bool CloseAfterSuccess { get; set; }
        

        public AppSettings()
        {
        }
    }
    
    public class AppSettingsManager
    {        
        public AppSettings Settings = new AppSettings();
        public string ConfigError { get; private set; }

        public string configDir { get; set; }
        public string configFile { get; set; }
        public string TasksFile { get; set; }
        
        public AppSettingsManager()
        {
            //устанавливаем путь к директории конфига
            configDir = CommonClass.ConfigPath;
            //имена файлов
            configFile = configDir + "config.xml";
            TasksFile = configDir + "tasks.xml";
            //другие значения по умолчанию
            Settings.CheckTimeType = TimeType.Secs;
            Settings.CheckTime = 30;
            Settings.CloseAfterSuccess = true;
        }
        public bool SaveConfig()
        {
            FileStream fs = null;

            try
            {
                Directory.CreateDirectory(configDir);
            }
            catch (Exception ex)
            {
                ConfigError = ex.Message;
                return false;
            }

            XmlSerializer formatter = new XmlSerializer(typeof(AppSettings));
            try
            {
                fs = new FileStream(configFile, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, Settings);
            }
            catch (Exception ex)
            {
                ConfigError = ex.Message;
                return false;
            }

            fs.Close();
            return true;
        }

        public bool LoadConfig()
        {
            FileStream fs = null;
            XmlSerializer formatter = new XmlSerializer(typeof(AppSettings));

            if (!File.Exists(configFile)) return true;

            try
            {
                fs = new FileStream(configFile, FileMode.Open, FileAccess.Read);
                Settings = (AppSettings)formatter.Deserialize(fs);
            }
            catch (Exception ex)
            {
                if (fs != null) fs.Close();
                ConfigError = ex.Message;
                return false;
            }

            fs.Close();
            return true;
        }

    }
}

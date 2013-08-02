using System;

namespace MYLog
{
    public abstract class Log
    {
        protected const string CONFIG_NAME = "MYLog.config";
        protected static string logPath = string.Empty;
        protected static string fileName = string.Empty;
        protected string logFormat = string.Empty;

        public virtual void LoadConfig()
        {
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + CONFIG_NAME);
            while (reader.Read())
            {
                if (reader.GetAttribute("name") != this.GetType().Name)
                    continue;

                if (!string.IsNullOrEmpty(reader.GetAttribute("path")))
                    logPath = reader.GetAttribute("path");
                else
                    logPath = AppDomain.CurrentDomain.BaseDirectory + "Logs";

                if (!string.IsNullOrEmpty(reader.GetAttribute("fileName")))
                    fileName = reader.GetAttribute("fileName");
                else
                    fileName = this.GetType().Name;

                if (!string.IsNullOrEmpty(reader.GetAttribute("format")))
                    logFormat = reader.GetAttribute("format");

                break;

            }
        }

        protected virtual string GetFormatString(string format)
        {
            return format.Replace("[%%DATE%%]", DateTime.Now.Date.ToString("yyyyMMdd")).Replace("[%%DATEFORMAT%%]", DateTime.Now.Date.ToString("yyyy-MM-dd")).Replace("[%%DATETIME%%]", DateTime.Now.Date.ToString("yyyyMMddhhmmss")).Replace("[%%DATETIMEFORMAT%%]", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")).Replace("\\r\\n", "\r\n");
        }
    }
}

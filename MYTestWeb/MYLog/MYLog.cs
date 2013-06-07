using System.IO;

namespace MYLog
{
    public class MYLog : Log, IMYLog
    {
        public MYLog()
        {
            base.LoadConfig();
        }

        public virtual bool Write(string message)
        {
            try
            {
                if (!Directory.Exists(logPath))
                    Directory.CreateDirectory(logPath);

                string formatText = GetFormatString(logFormat);
                if (!string.IsNullOrEmpty(formatText))
                    if (formatText.Contains("[%%LOGTEXT%%]"))
                        message = formatText.Replace("[%%LOGTEXT%%]", message);

                File.AppendAllText(string.Format("{0}\\{1}", logPath, GetFormatString(fileName)),message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

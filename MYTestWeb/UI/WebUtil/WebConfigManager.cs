﻿using System.Configuration;

namespace UI.WebUtil
{
    public class WebConfigManager
    {
        public static string MYORMConnectionString
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["MYORMConnectionString"]; }
            set { System.Configuration.ConfigurationManager.AppSettings["MYORMConnectionString"] = value; }
        }

        public static string DatabaseName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DatabaseName"]; }
            set { System.Configuration.ConfigurationManager.AppSettings["DatabaseName"] = value; }
        }

        public static string DatabaseDir
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DatabaseDir"]; }
            set { System.Configuration.ConfigurationManager.AppSettings["DatabaseDir"] = value; }
        }

        public static string DefaultLanguage
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"]; }
            set { System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"] = value; }
        }

    }
}
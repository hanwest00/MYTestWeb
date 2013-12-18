using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Util
{
    public class WebPathManager
    {
        public static string BaseUrl
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public static string TemplateUrl
        {
            get { return string.Format("{0}Template\\", BaseUrl); }
        }

        public static string ControllersUrl
        {
            get { return string.Format("{0}Controllers\\", BaseUrl); }
        }

        public static string DataUrl
        {
            get { return string.Format("{0}Data\\", BaseUrl); }
        }

        public static string ViewsUrl
        {
            get { return string.Format("{0}Views\\", BaseUrl); }
        }

        public static string ConfigsUrl
        {
            get { return string.Format("{0}Configs\\", BaseUrl); }
        }
    }
}
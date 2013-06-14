using System.Collections.Generic;
using System.Configuration;

namespace MYIoc.Config
{
    public class registerReader
    {
        private const string CFG_FILE = "MYIoc.config";

        private static ConfigXmlDocument cfgDom;

        private register current;

        private bool readOk;

        public registerReader()
        {
            if (cfgDom == null) cfgDom = new ConfigXmlDocument();
            cfgDom.Load(string.Format("{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, CFG_FILE));
        }

        public bool Read()
        {
            //todo:向下读取
            return false;
        }

        public register GetCurrent()
        {
            if (!readOk) return null;

            //todo:读取成功 返回当前
            return null;
        }
    }
}

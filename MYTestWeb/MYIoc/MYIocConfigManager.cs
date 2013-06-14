using System.Configuration;

namespace MYIoc
{
    public class MYIocConfigManager
    {
        private const string CFG_FILE = "MYIoc.config";

        private static ConfigXmlDocument cfgDom;

        private static MYIocConfigManager instance;

        #region Singleton
        public static MYIocConfigManager GetInstance()
        {
            object lockObj = new object();
            lock (lockObj) if (instance == null) instance = new MYIocConfigManager();
            return instance;
        }
        #endregion

        private MYIocConfigManager()
        {
            if (cfgDom == null) cfgDom = new ConfigXmlDocument();
            cfgDom.Load(string.Format("{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, CFG_FILE));
        }

        /// <summary>
        /// 获取整个配置实体
        /// </summary>
        /// <returns>整个配置实体</returns>
        public MYIoc.Config.MYIoc GetMYIoc()
        {
            //todo:
            return null;
        }

        /// <summary>
        /// 依name获取单个register配置的实体
        /// </summary>
        /// <param name="name">register 的 name</param>
        /// <returns>register实体</returns>
        public MYIoc.Config.register GetRegisterByName(string name)
        {
            //todo:
            return null;
        }
    }
}

using System.Configuration;
using System.Xml.Linq;
using System.Linq;
using MYIoc.Config;

namespace MYIoc
{
    /// <summary>
    /// 解析配置文件返回对象化的内容
    /// </summary>
    public class MYIocConfigManager
    {
        #region Constant
        private const string CFG_REGNODE = "register";
        private const string CFG_CSTRNODE = "constructor";
        private const string CFG_PROPNODE = "property";
        private const string CFG_MTHDNODE = "method";
        private const string CFG_PARAMNODE = "param";

        private static XName ATTRI_TYPE = XName.Get("type");
        private static XName ATTRI_NAME = XName.Get("name");
        private static XName ATTRI_MAPTO = XName.Get("mapTo");
        private static XName ATTRI_VALUE = XName.Get("value");
        private static XName ATTRI_DEPEND = XName.Get("dependon");
        #endregion

        public static string cfgPath
        {
            get;
            private set;
        }

        #region Private variable
        private static System.Collections.Generic.IEnumerable<XElement> cfgNodeList;
        private static MYIocConfigManager instance;
        #endregion

        #region Singleton
        public static MYIocConfigManager GetInstance(string path)
        {
            object lockObj = new object();
            lock (lockObj) if (instance == null || cfgPath != path) instance = new MYIocConfigManager(path);
            return instance;
        }
        #endregion

        #region Constructor
        private MYIocConfigManager(string path)
        {
            cfgNodeList = XDocument.Load(path).Elements().First().Elements();
            cfgPath = path;
        }
        #endregion

        #region Public method

        /// <summary>
        /// 获取整个配置实体
        /// </summary>
        /// <returns>整个配置实体</returns>
        public MYIoc.Config.MYIoc GetMYIoc()
        {
            //todo:
            MYIoc.Config.MYIoc ret = new MYIoc.Config.MYIoc();
            cfgNodeList.Where(w => w.Name == CFG_REGNODE).ToList().ForEach(s =>
            {
                ret.Add(this.XElementToRegister(s));
            });

            return ret;
        }

        /// <summary>
        /// 依name获取单个register配置的实体
        /// </summary>
        /// <param name="name">register 的 name</param>
        /// <returns>register实体</returns>
        public register GetRegisterByName(string name)
        {
            return XElementToRegister(cfgNodeList.Where(w => w.Attribute(ATTRI_NAME).Value == name).First());
        }
        #endregion

        #region Private method
        /// <summary>
        /// 解析XElement为register对象
        /// </summary>
        /// <param name="xElem">配置文件中的结点XElement</param>
        /// <returns>解析得到的register对象</returns>
        private register XElementToRegister(XElement xElem)
        {
            if (xElem == null) return null;
            var Name = xElem.Attribute(ATTRI_NAME).Value;
            var Type = this.GetAssType(xElem.Attribute(ATTRI_TYPE).Value);
            var MapTo = this.GetAssType(xElem.Attribute(ATTRI_MAPTO).Value);
            register ret = new register { Name = xElem.Attribute(ATTRI_NAME).Value, Type = this.GetAssType(xElem.Attribute(ATTRI_TYPE).Value), MapTo = this.GetAssType(xElem.Attribute(ATTRI_MAPTO).Value) };
            XElement c = xElem.Element(XName.Get(CFG_CSTRNODE));

            if (c != null) ret.constructor = this.AddParamsToItem(c, new constructor()) as constructor;

            xElem.Elements(XName.Get(CFG_MTHDNODE)).ToList().ForEach(s =>
            {
                ret.AddMethod(this.AddParamsToItem(s, new method { Name = s.Attribute(ATTRI_NAME).Value }) as method);
            });

            xElem.Elements(XName.Get(CFG_PROPNODE)).ToList().ForEach(p =>
            {
                ret.AddProperty(new property { dependon = p.Attribute(ATTRI_DEPEND).Value, Name = p.Attribute(ATTRI_NAME).Value });
            });

            return ret;
        }

        private INode AddParamsToItem(XElement elem, INode node)
        {
            elem.Elements().ToList().ForEach(i =>
            {
                if (i.Name.LocalName == CFG_PARAMNODE)
                    node.Add(new param
                    {
                        dependon = i.Attribute(ATTRI_DEPEND) != null ? i.Attribute(ATTRI_DEPEND).Value : string.Empty,
                        Name = i.Attribute(ATTRI_NAME) != null ? i.Attribute(ATTRI_NAME).Value : string.Empty,
                        Type = i.Attribute(ATTRI_TYPE) != null ? this.GetAssType(i.Attribute(ATTRI_TYPE).Value) : null,
                        value = i.Attribute(ATTRI_VALUE) != null ? i.Attribute(ATTRI_VALUE).Value : string.Empty
                    });
            });

            return node;
        }

        private System.Type GetAssType(string assString)
        {
            return System.Type.GetType(assString);
        }
        #endregion
    }
}

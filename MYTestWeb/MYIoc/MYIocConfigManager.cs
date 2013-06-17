using System.Configuration;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using MYIoc.Config;

namespace MYIoc
{
    public class MYIocConfigManager
    {
        #region constant
        private const string CFG_FILE = "MYIoc.config";
        private const string CFG_REGNODE = "register";
        private const string CFG_CSTRNODE = "constructor";
        private const string CFG_PROPNODE = "property";
        private const string CFG_MTHDNODE = "method";
        private const string CFG_PARAMNODE = "param";

        private const XName ATTRI_TYPE = XName.Get("type");
        private const XName ATTRI_NAME = XName.Get("name");
        private const XName ATTRI_MAPTO = XName.Get("mapTo");
        private const XName ATTRI_VALUE = XName.Get("value");
        private const XName ATTRI_DEPEND = XName.Get("dependon");
        #endregion

        private static ConfigXmlDocument cfgDom;

        private static IEnumerable<XElement> cfgNodeList;

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
            cfgNodeList = XDocument.Load(string.Format("{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, CFG_FILE)).Elements();
        }

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

        /// <summary>
        /// 解析XElement为register对象
        /// </summary>
        /// <param name="xElem">配置文件中的结点XElement</param>
        /// <returns>解析得到的register对象</returns>
        private register XElementToRegister(XElement xElem)
        {
            if (xElem == null) return null;

            register ret = new register { Name = xElem.Attribute(ATTRI_TYPE).Value, Type = this.GetAssType(xElem.Attribute(ATTRI_NAME).Value).GetType(), MapTo = this.GetAssType(xElem.Attribute(ATTRI_MAPTO).Value).GetType() };
            XElement c = xElem.Element(XName.Get(CFG_CSTRNODE));
            if (c != null)
            {
                constructor cstr = new constructor();
                this.AddParamsToItem(c, cstr);
                ret.constructor = cstr;
            }

            xElem.Elements(XName.Get(CFG_MTHDNODE)).ToList().ForEach(s =>
            {
                method mtd = new method { Name = s.Attribute(ATTRI_NAME).Value };
                this.AddParamsToItem(s, mtd);
                ret.AddMethod(mtd);
            });

            xElem.Elements(XName.Get(CFG_PROPNODE)).ToList().ForEach(s =>
            {
                ret.AddProperty(new property { dependon = s.Attribute(ATTRI_DEPEND).Value, Name = s.Attribute(ATTRI_NAME).Value });
            });

            return ret;
        }

        private void AddParamsToItem(XElement elem, INode node)
        {
            elem.Elements().ToList().ForEach(i =>
            {
                if (i.Value == CFG_PARAMNODE)
                    node.Add(new param
                    {
                        dependon = i.Attribute(ATTRI_DEPEND).Value,
                        Name = i.Attribute(ATTRI_NAME).Value,
                        Type = this.GetAssType(i.Attribute(ATTRI_TYPE).Value).GetType(),
                        value = i.Attribute(ATTRI_VALUE).Value
                    });
            });
        }

        private System.Type GetAssType(string assString)
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.Load(assString);
            if (ass != null) return ass.GetType();
            return null;
        }
    }
}

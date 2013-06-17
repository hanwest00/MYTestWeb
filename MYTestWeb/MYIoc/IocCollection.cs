using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYIoc.Config;

namespace MYIoc
{
    public class IocContains
    {
        private IDictionary<Type, IList<register>> typeCollection;

        public IocContains()
        {
            typeCollection = new Dictionary<Type, IList<register>>();
        }

        public void RegisterType<T, TTO>()
        {
            Type map = typeof(T);
            Type to = typeof(TTO);

            if (!map.IsInterface || (to.GetInterface(map.Name) == null)) return;

            IList<register> toList = this.typeCollection[map];
            if (toList != null)
            {
                toList = new List<register>();
                this.typeCollection.Add(map, toList);
            }

            toList.Add(new register { Type = to, MapTo = map });
        }

        public void RegisterTypeFromConfig(string configPath)
        {

        }

        public T Resolve<T>()
        {
            Type objType = this.typeCollection[typeof(T)][0].Type;
            return (T)objType.Assembly.CreateInstance(objType.FullName);
        }

        public IList<T> Resolves<T>()
        {
            System.Configuration.ConfigXmlDocument cfgDom = new System.Configuration.ConfigXmlDocument();
            cfgDom.Load(System.AppDomain.CurrentDomain.BaseDirectory + "MYIoc.config");


            IList<T> ret = new List<T>();
            this.typeCollection[typeof(T)].ToList().ForEach(s =>
            {
                ret.Add((T)s.Type.Assembly.CreateInstance(s.Type.FullName));
            });
            return ret;
        }

    }
}

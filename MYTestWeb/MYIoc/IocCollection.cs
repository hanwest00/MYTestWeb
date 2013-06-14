using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYIoc
{
    public class IocContains
    {
        private Dictionary<Type, List<Type>> typeCollection;

        public IocContains()
        {
            typeCollection = new Dictionary<Type, List<Type>>();
        }

        public void RegisterType<T, TTO>()
        {
            Type map = typeof(T);
            Type to = typeof(TTO);

            if (!map.IsInterface || (to.GetInterface(map.Name) == null)) return;

            List<Type> toList = this.typeCollection[map];
            if (toList != null)
                toList.Add(to);
            else
                this.typeCollection.Add(map, new List<Type>() { to });
        }

        public void RegisterTypeFromConfig(string configPath)
        {

        }

        public T Resolve<T>()
        {
            Type objType = this.typeCollection[typeof(T)][0];
            return (T)objType.Assembly.CreateInstance(objType.FullName);
        }

        public IList<T> Resolves<T>()
        {
            System.Configuration.ConfigXmlDocument cfgDom = new System.Configuration.ConfigXmlDocument();
            cfgDom.Load(System.AppDomain.CurrentDomain.BaseDirectory + "MYIoc.config");
            

            IList<T> ret = new List<T>();
            this.typeCollection[typeof(T)].ToList().ForEach(s => {
                ret.Add((T)s.Assembly.CreateInstance(s.FullName));
            });
            return ret;
        }

    }
}

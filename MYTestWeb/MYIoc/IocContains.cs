using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYIoc
{
    public class IocContains
    {
        private Dictionary<Type, Type> typeCollection;

        public IocContains()
        {
            typeCollection = new Dictionary<Type, Type>();
        }

        public void RegisterType<T, TTO>()
        {
            Type map = typeof(T);
            Type to = typeof(TTO);
            if (!map.IsInterface)
                return;
            if (to.GetInterface(map.Name) == null)
                return;
            typeCollection.Add(map, to);
        }

        public void RegisterTypeFromConfig(string configPath)
        {
            
        }

        public T Resolve<T>()
        {
            Type objType = typeCollection[typeof(T)];
            return (T)objType.Assembly.CreateInstance(objType.FullName);
        }

        public IList<T> Resolves<T>()
        {
            IList<T> all = new List<T>();
            typeCollection.Where(s => {
                return s.Key == typeof(T); 
            }).ToList().ForEach(s=>{
                all.Add((T)s.Value.Assembly.CreateInstance(s.Value.FullName));
            });
            return all;
        }
    }
}

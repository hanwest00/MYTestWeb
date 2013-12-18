using System.Linq;
using System.Collections.Generic;

namespace MYIoc.Config
{
    /// <summary>
    /// 把配置文件中的register对象化
    /// </summary>
    public class register
    {
        public IDictionary<int, method> methods
        {
            get;
            private set;
        }

        public IDictionary<int, property> propertys
        {
            get;
            private set;
        }

        public constructor constructor
        {
            get;
            set;
        }

        public System.Type Type
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public System.Type MapTo
        {
            get;
            set;
        }

        public register()
        { 
           methods = new Dictionary<int, method>();
           propertys = new Dictionary<int, property>();
        }

        public void AddMethod(method item)
        {
            methods.Add(methods.Count, item);
        }

        public void RemoveMethod(int index)
        {
            methods.Remove(index);
        }

        public void RemoveMethod(method item)
        {
            this.RemoveMethod(methods.Where(w => w.Value == item).First().Key);
        }

        public void AddProperty(property item)
        {
            propertys.Add(propertys.Count, item);
        }

        public void RemoveProperty(int index)
        {
            propertys.Remove(index);
        }

        public void RemoveProperty(property item)
        {
            this.RemoveMethod(propertys.Where(w => w.Value == item).First().Key);
        }
    }
}

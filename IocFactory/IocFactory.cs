using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYIoc;

namespace BusinessIocFactory
{
    public class IocFactory
    {
        private static IocContains contians = new IocContains();
        private static IocFactory instance = null;

        public static IocFactory Instance
        {
            get
            {
                if (instance == null) instance = new IocFactory();
                return instance;
            }  
        }

        public IocFactory()
        {
            contians.RegisterTypeFromConfig(string.Format("{0}BIZIoc.config", Util.WebPathManager.ConfigsUrl));
        }

        public T GetBIZ<T>()
        {
            return contians.Resolve<T>();
        }
    }
}

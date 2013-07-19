using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYIoc;

namespace IocFactory
{
    public class IocFactory
    {
        private static IocContains contians = new IocContains();

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

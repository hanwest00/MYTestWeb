using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM;
using MYORM.Interfaces;
using MYIoc;

namespace DataIocFactory
{
    public class DataIoc<T>
    {
        private static IocContains contians = new IocContains();

        public static ITable<T> GetData()
        {
            contians.RegisterTypeFromConfig(string.Format("{0}DataIoc.config", Util.WebPathManager.ConfigsUrl));
            return contians.ResolveGeneric<ITable<T>>(Util.WebConfigManager.DatebaseType, typeof(T));
        }
    }
}

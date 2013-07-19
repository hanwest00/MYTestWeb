using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Interfaces;
using MYIoc;

namespace Data
{
    /// <summary>
    /// 使用IOC来实例化DB对象(为多数据库设计提供支持)
    /// 数据库IOC的配置为:程序根目录/Configs/DataIoc.config
    /// 在web.config或app.config中设置DatebaseType的值
    /// 即可配置系统使用不同的数据库
    /// </summary>
    /// <typeparam name="T">继承自MYORM.MYItemBase的类型</typeparam>
    public class DataIoc<T> where T : DataModels.IModels
    {
        private static IocContains contians = new IocContains();

        public static ITable<T> GetData()
        {
            contians.RegisterTypeFromConfig(string.Format("{0}DataIoc.config", Util.WebPathManager.ConfigsUrl));
            return contians.ResolveGeneric<ITable<T>>(Util.WebConfigManager.DatebaseType, typeof(T));
        }
    }
}

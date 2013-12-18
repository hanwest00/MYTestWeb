using System;
using System.Collections.Generic;

using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace MYORM
{
    public static class ExFunc
    {
        /* for .net 3.5 or above
        private delegate TT Func<T, TT>(T obj);
        private delegate void Action<T, TT>(T obj,TT obj1);
        public static TT PropGetter<T, TT>(this PropertyInfo propInfo, T obj)
        {

            MethodInfo getMethod = propInfo.GetGetMethod(true);
            return (Delegate.CreateDelegate(typeof(Func<T, TT>), getMethod) as Func<T, TT>)(obj);
        }

        public static void PropSetter<T, TT>(this PropertyInfo propInfo, T obj, TT value)
        {
            MethodInfo setMethod = propInfo.GetSetMethod(true);
            (Delegate.CreateDelegate(typeof(Action<T, TT>), setMethod) as Action<T, TT>)(obj, value);
        }
         * */
    }
}

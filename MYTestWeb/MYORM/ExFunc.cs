﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace MYORM
{
    public static class ExFunc
    {
        public static TT PropGetter<T, TT>(this PropertyInfo propInfo, T obj)
        {
            MethodInfo getMethod = propInfo.GetGetMethod(true);
            return (Delegate.CreateDelegate(typeof(Func<T, TT>), getMethod) as Func<T, TT>)(obj);
        }

        public static void PropSetter<T, TT>(this PropertyInfo propInfo, T obj, TT value)
        {
            MethodInfo getMethod = propInfo.GetSetMethod(true);
            (Delegate.CreateDelegate(typeof(Action<T, TT>), getMethod) as Action<T, TT>)(obj, value);
        }

        public static TT DynamicPropGetter<T, TT>(this PropertyInfo propInfo, T obj)
        {
            dynamic getMethod = propInfo.GetGetMethod(true);
            return (TT)getMethod.Invoke(obj);
        }

        public static void DynamicPropSetter<T, TT>(this PropertyInfo propInfo, T obj, TT value)
        {
            dynamic getMethod = propInfo.GetSetMethod(true);
            getMethod.Involk(obj, value);
        }
    }
}

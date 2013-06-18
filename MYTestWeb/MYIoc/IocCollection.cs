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

        /// <summary>
        /// register中的name对应typeCollection的索引
        /// </summary>
        private IDictionary<string, int[]> nameIndex;

        public IocContains()
        {
            typeCollection = new Dictionary<Type, IList<register>>();
            nameIndex = new Dictionary<string, int[]>();
        }

        public void RegisterType<T, TTO>()
        {
            this.RegisterType(new register { Type = typeof(T), MapTo = typeof(TTO) });
        }

        public void RegisterType(register reg)
        {
            Type map = reg.Type;
            Type to = reg.MapTo;

            if (!map.IsInterface || (to.GetInterface(map.Name) == null)) return;

            IList<register> toList = null;

            if (!this.typeCollection.Keys.Contains(map))
            {
                toList = new List<register>();
                this.typeCollection.Add(map, toList);
            }
            else
                toList = this.typeCollection[map];

            toList.Add(reg);

            if (!string.IsNullOrEmpty(reg.Name)) this.nameIndex.Add(reg.Name, new int[] { this.typeCollection.Count, toList.Count });
        }

        public void RegisterTypeFromConfig()
        {
            MYIocConfigManager.GetInstance().GetMYIoc().GetRegisters().ToList().ForEach(s =>
            {
                this.RegisterType(s);
            });
        }

        public T Resolve<T>()
        {
            register reg = this.typeCollection[typeof(T)][0];
            return this._resolve<T>(reg);
        }

        public IList<T> Resolves<T>()
        {
            IList<T> retList = new List<T>();
            this.typeCollection[typeof(T)].ToList().ForEach(reg =>
            {
                retList.Add(this._resolve<T>(reg));
            });
            return retList;
        }

        private T _resolve<T>(register reg)
        {
            Type[] constrTypes = null;
            T ret = default(T);

            object[] objs = null;
            if (reg.constructor != null)
            {
                if (reg.constructor.ParamCount > 0)
                {
                    constrTypes = new Type[reg.constructor.ParamCount];
                    objs = new object[reg.constructor.ParamCount];
                    int i = 0;
                    reg.constructor.GetParams().ToList().ForEach(s =>
                    {
                        Type t = null;
                        if (!string.IsNullOrEmpty(s.dependon)) t = typeCollection.ToList()[nameIndex[s.dependon][0]].Value[nameIndex[s.dependon][1]].MapTo;

                        if (!string.IsNullOrEmpty(s.value)) t = s.Type;
                        objs[i] = Activator.CreateInstance(t);
                        constrTypes[i] = t;
                        i++;
                    });

                    ret = (T)reg.MapTo.GetConstructor(constrTypes).Invoke(objs);
                }
            }
            else ret = (T)Activator.CreateInstance(reg.MapTo);

            if (reg.propertys.Count > 0)
                reg.propertys.ToList().ForEach(s =>
                {
                    reg.Type.GetProperty(s.Value.Name).SetValue(ret, Activator.CreateInstance(typeCollection.ToList()[nameIndex[s.Value.dependon][0]].Value[nameIndex[s.Value.dependon][1]].Type), null);
                });


            if (reg.methods.Count > 0)
            {
                reg.methods.ToList().ForEach(s =>
                {
                    var methd = reg.MapTo.GetMethod(s.Value.Name);
                    object[] prms = new object[s.Value.ParamCount];
                    int i = 0;
                    s.Value.GetParams().ToList().ForEach(p =>
                    {
                        prms[i] = Activator.CreateInstance(typeCollection.ToList()[nameIndex[p.dependon][0]].Value[nameIndex[p.dependon][1]].Type);
                    });

                    ret = (T)methd.Invoke(ret, prms);
                });
            }

            return ret;
        }
    }
}

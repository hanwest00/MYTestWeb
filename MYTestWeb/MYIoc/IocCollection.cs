using System;
using System.Collections.Generic;
using System.Linq;
using MYIoc.Config;

namespace MYIoc
{
    public class IocContains
    {
        #region Private variable
        private IDictionary<Type, IList<register>> typeCollection;
        /// <summary>
        /// register中的name对应typeCollection的索引
        /// </summary>
        private IDictionary<string, int[]> nameIndex;
        #endregion

        #region Constructor
        public IocContains()
        {
            typeCollection = new Dictionary<Type, IList<register>>();
            nameIndex = new Dictionary<string, int[]>();
        }
        #endregion

        #region Public method
        /// <summary>
        /// 把TTO类型注入到T接口中(T到TTO的映射)
        /// </summary>
        /// <typeparam name="T">接口类型</typeparam>
        /// <typeparam name="TTO">注入类型(继承至T接口)</typeparam>
        public void RegisterType<T, TTO>()
        {
            this.RegisterType(new register { Type = typeof(T), MapTo = typeof(TTO) });
        }

        /// <summary>
        /// 读取对象化的注册项来添加依赖
        /// </summary>
        /// <param name="reg"></param>
        public void RegisterType(register reg)
        {
            try
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

                //添加name对应typeCollection的索引
                if (!string.IsNullOrEmpty(reg.Name)) this.nameIndex.Add(reg.Name, new int[] { this.typeCollection.Count - 1, toList.Count - 1 });
            }
            catch (Exception e)
            {
                //如果出错移除name对应typeCollection的索引
                if (!string.IsNullOrEmpty(reg.Name)) if (this.nameIndex.Keys.Contains(reg.Name)) this.nameIndex.Remove(reg.Name);
                throw e;
            }
        }

        /// <summary>
        /// 读取配置文件来生成依赖注入
        /// </summary>
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

        /// <summary>
        /// 使用配置中register的name的值来解析为对象
        /// </summary>
        /// <typeparam name="T">解析出的对象的类型(通常为接口)</typeparam>
        /// <param name="name">配置中register的name的值</param>
        /// <returns>解析出的对象</returns>
        public T Resolve<T>(string name)
        {
            register reg = this.typeCollection.ToList()[nameIndex[name][0]].Value[nameIndex[name][1]];
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
        #endregion

        #region Private method
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
                        if (!string.IsNullOrEmpty(s.dependon))
                        {
                            t = typeCollection.ToList()[nameIndex[s.dependon][0]].Value[nameIndex[s.dependon][1]].MapTo;
                            objs[i] = Activator.CreateInstance(t);
                        }

                        if (!string.IsNullOrEmpty(s.value))
                        {
                            t = s.Type;
                            objs[i] = s.value;
                        }

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
                    reg.MapTo.GetProperty(s.Value.Name).SetValue(ret, Activator.CreateInstance(typeCollection.ToList()[nameIndex[s.Value.dependon][0]].Value[nameIndex[s.Value.dependon][1]].MapTo), null);
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
                        prms[i] = Activator.CreateInstance(typeCollection.ToList()[nameIndex[p.dependon][0]].Value[nameIndex[p.dependon][1]].MapTo);
                    });

                    methd.Invoke(ret, prms);
                });
            }

            return ret;
        }
        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using TxHumor.Cache.Service;
using TxHumor.Common;
using TxHumor.Controller.model;
using TxHumor.UpdateSolr.Service;

namespace TxHumor.Controller
{
    public class ctrl_ServiceClient
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isCache"></param>
        /// <param name="invokeKey"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public static List<T> GetService<T>(bool isCache, string invokeKey, params object[] prams) where T : new()
        {
            if (invokeKey == null || invokeKey.Length == 0)
            {
                return null;
            }
            m_InvokeConfig config = ctrl_InvokeConfig.GetConfig(invokeKey);
            if (config == null)
            {
                return null;
            }
            Type type = Type.GetType(Assembly.CreateQualifiedName(config.AssemblyPath, config.ClassName));
            MethodInfo mi = type.GetMethod(config.MethodName);
            //判断该方法是静态方法还是普通方法
            object instance = mi.IsStatic ? null : Activator.CreateInstance(type);
            object seed = mi.Invoke(instance, prams);
            if (seed == null)
            {
                return null;
            }
            //该seed是有id组成的字符串通过,分离开
            object obj = srv_CacheManager.CacheData(isCache, mi, seed);
            if (obj == null)
            {
                return null;
            }
            Type t = obj.GetType();
            List<T> list = new List<T>();
            //判断是否是集合
            if (t.IsCollection())
            {
                var arry = (IEnumerable)obj;
                foreach (var item in arry)
                {
                    T o;
                    if (item is string)
                    {
                        o = JsonConvert.DeserializeObject<T>(item.ToString());
                    }
                    else
                    {
                        o = (T)Convert.ChangeType(item, typeof(T));
                    }

                    list.Add(o);
                }
                return list;
            }
            else
            {
                T o;
                if (obj is string)
                {
                    o = JsonConvert.DeserializeObject<T>(obj.ToString());
                }
                else
                {
                    o = (T)Convert.ChangeType(obj, typeof(T));
                }

                list.Add(o);
            }
            return (list.Count == 0) ? null : list;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="invokeKey"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public static T UpdateService<T>(string invokeKey, object[] prams)
        {
            if (invokeKey == null || invokeKey.Length == 0) return default(T);
            m_InvokeConfig config = ctrl_InvokeConfig.UpdateConfig(invokeKey);
            Type type = Type.GetType(Assembly.CreateQualifiedName(config.AssemblyPath, config.ClassName));
            MethodInfo mi = type.GetMethod(config.MethodName);
            //添加solr数据
            srv_UpdateSolr.AddSolr(mi,prams);

            object instance = mi.IsStatic ? null : Activator.CreateInstance(type);
            object seed = mi.Invoke(instance, prams);
            //根据标签操作
            return seed == null ? default(T) : (T)seed;
        }
    }
}

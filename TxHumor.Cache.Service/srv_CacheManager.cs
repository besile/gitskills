using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TxHumor.Cache.Service.model;
using TxHumor.Common;
using TxHumor.Common.Attr;

namespace TxHumor.Cache.Service
{
    public class srv_CacheManager
    {
        private srv_CacheManager() { }
        /// <summary>
        /// 反射获取数据 
        /// </summary>
        /// <param name="isCache"></param>
        /// <param name="cacheConfig"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        private static object InvokeData(bool isCache, m_CacheConfig cacheConfig, params string[] prams)
        {
            if (cacheConfig == null)
            {
                return null;
            }
            if (prams == null || prams.Length == 0) return null;
            if (!isCache)
            {
                object obj = InvokeData(cacheConfig, prams);
                if (obj.GetType().IsCollection())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>(prams.Length);
                    ArrayList al = new ArrayList(prams.Length);
                    var arrayObj = (IEnumerable)obj;
                    foreach (var item in arrayObj)
                    {
                        var t = item.GetType();
                        PropertyInfo[] pis = t.GetProperties();
                        foreach (PropertyInfo pi in pis)
                        {
                            object[] attrs = pi.GetCustomAttributes(typeof(Attr_CachePrimaryKeyAttribute), false);
                            foreach (Attr_CachePrimaryKeyAttribute attr in attrs)
                            {
                                if (attr == null)
                                {
                                    continue;
                                }
                                string key = pi.GetValue(item, null).ToString();
                                dic.Add(key, item);
                            }
                        }
                    }
                    foreach (var item in prams)
                    {
                        if (dic.ContainsKey(item) && dic[item] != null)
                        {
                            al.Add(dic[item]);
                        }
                    }
                    return al.ToArray();
                }
                return obj;
            }
            else
            {
                //缓存key前缀
                string pre = cacheConfig.Pre;
                Dictionary<string, string> keyDic = new Dictionary<string, string>(prams.Length);
                foreach (string pram in prams)
                {
                    string key = string.Concat(pre, pram);
                    keyDic.Add(key, pram);
                }
                string[] cacheKeys = keyDic.Keys.ToArray();
                IDictionary<string, object> cacheObjects = srv_RedisManager.Get(cacheKeys);
                List<string> addObjKeys = new List<string>();
                //判断该缓存是否全部包含该缓存的key
                foreach (var item in cacheObjects)
                {
                    var obj = item.Value;
                    //缓存不包含该数据添加到 addObjKeys
                    if (obj == null)
                    {
                        addObjKeys.Add(keyDic[item.Key]);
                    }
                }
                //全部添加到缓存中
                if (addObjKeys.Count == 0)
                {
                    //因Memcache批量获取数据不排序，需要按照Key重新排序
                    ArrayList all = new ArrayList(prams.Length);
                    foreach (var key in cacheKeys)
                    {
                        if (cacheObjects.ContainsKey(key) && cacheObjects[key] != null)
                        {
                            all.Add(cacheObjects[key]);
                        }
                    }
                    return all.ToArray();
                }
                else
                {
                    //有部分没有添加到缓存中，或者一部分添加到缓存
                    //获取数据
                    object obj = InvokeData(cacheConfig, addObjKeys.ToArray());
                    if (obj != null)
                    {
                        Type type = obj.GetType();
                        if (type.IsCollection())
                        {
                            var arrayObj = (IEnumerable)obj;
                            foreach (var item in arrayObj)
                            {
                                string cacheKey = string.Concat(pre, item.ToPrimaryKey());
                                srv_RedisManager.Add(cacheKey, item, cacheConfig.ExpTime);
                                cacheObjects[cacheKey] = item;
                            }
                        }
                        else
                        {
                            string cacheKey = string.Concat(pre, obj.ToPrimaryKey());
                            srv_RedisManager.Add(cacheKey, obj, cacheConfig.ExpTime);
                            //添加到缓存字典中
                            cacheObjects[cacheKey] = obj;
                        }
                    }
                    //因Memcache批量获取数据不排序，需要按照Key重新排序
                    ArrayList all = new ArrayList(prams.Length);
                    foreach (var key in cacheKeys)
                    {
                        if (cacheObjects.ContainsKey(key) && cacheObjects[key] != null)
                        {
                            all.Add(cacheObjects[key]);
                        }
                    }
                    return all.ToArray();
                }
            }
        }
        /// <summary>
        /// 获取数据通过ids或者其他参数值
        /// </summary>
        /// <param name="cacheConfig"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        private static object InvokeData(m_CacheConfig cacheConfig, params string[] prams)
        {
            if (cacheConfig == null)
            {
                return null;
            }
            if (prams == null || prams.Length == 0) return null;
            string invokePrams = string.Join(",", prams);
            Type type = Type.GetType(Assembly.CreateQualifiedName(cacheConfig.AssemblyPath, cacheConfig.ClassName));
            MethodInfo mi = type.GetMethod(cacheConfig.MethodName);
            object instance = mi.IsStatic ? null : Activator.CreateInstance(type);
            //获取该方法的第一个参数信息
            ParameterInfo pi = mi.GetParameters()[0];
            object invokeP = Convert.ChangeType(invokePrams, pi.ParameterType);
            object seed = mi.Invoke(instance, new object[] { invokeP });
            return seed;
        }
        /// <summary>
        /// 创建缓存数据
        /// </summary>
        /// <param name="isCache"></param>
        /// <param name="method"></param>
        /// <param name="cacheKeys"></param>
        /// <returns></returns>
        private static object BuildCache(bool isCache, MethodInfo method, string[] cacheKeys)
        {
            if (cacheKeys == null || cacheKeys.Length == 0)
            {
                return null;
            }
            //判断是否有缓存标签
            object[] cacheAttrs = method.GetCustomAttributes(typeof(Attr_CacheDataAttribute), false);
            object data = null;
            foreach (Attr_CacheDataAttribute cacheAttr in cacheAttrs)
            {
                if (cacheAttr == null)
                {
                    continue;
                }
                string key = cacheAttr.WhatCase;
                m_CacheConfig cacheConfig = srv_CacheConfig.GetConfig(key);
                data=InvokeData(isCache, cacheConfig, cacheKeys);
            }
            return data;
        }
        /// <summary>
        /// 转换参数
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        private static string[] FormateCacheKey(object cacheKey)
        {
            Type type = cacheKey.GetType();
            if (type.IsCollection())
            {
                var keys = (IEnumerable)cacheKey;
                List<string> list = new List<string>();
                foreach (var key in keys)
                {
                    list.Add(key.ToString());
                }
                return list.ToArray();
            }
            return new string[] { cacheKey.ToString() };
        }
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="isCache"></param>
        /// <param name="method"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static object CacheData(bool isCache, MethodInfo method, object seed)
        {
            if (method == null || seed == null)
            {
                return null;
            }
            //分解参数(seed ids集合，或者guid集合)
            string[] cacheKeys = FormateCacheKey(seed);
            object obj = BuildCache(isCache, method, cacheKeys);
            return obj;
        }
    }
}

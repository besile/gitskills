using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;

namespace TxHumor.Common
{
    public static class UICommonConfig
    {
        private static int? _SessionExpireSeconds;
        public static int SessionExpireSeconds
        {
            get
            {
                if (UICommonConfig._SessionExpireSeconds == null)
                {
                    UICommonConfig._SessionExpireSeconds = UICommonConfig.GetValueFromAppSettings<int>("SessionExpireSeconds", 7200, false);
                }
                return UICommonConfig._SessionExpireSeconds.Value;
            }

        }

        private static IDictionary<string, object> _MemcachedValueFromAppSettings = new Dictionary<string, object>(16);
        private static Semaphore MemecachedLocker = new Semaphore(1, 1);
        /// <summary>
        /// 获取内存中缓存的节点值。线程安全。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="emptyValue"></param>
        /// <param name="throwIfNotFound"></param>
        /// <returns></returns>
        public static T GetMemcachedValueFromAppSettings<T>(string key, T emptyValue, bool throwIfNotFound = false)
        {
            object objValue;
            if (UICommonConfig._MemcachedValueFromAppSettings.TryGetValue(key, out objValue) == false)
            {
                objValue = UICommonConfig.GetValueFromAppSettings<T>(key, emptyValue, throwIfNotFound);
                try
                {
                    UICommonConfig.MemecachedLocker.WaitOne();
                    if (UICommonConfig._MemcachedValueFromAppSettings.ContainsKey(key) == false)
                    {
                        UICommonConfig._MemcachedValueFromAppSettings.Add(key, objValue);
                    }
                }
                finally
                {
                    UICommonConfig.MemecachedLocker.Release();
                }
            }
            return (T)objValue;
        }

        /// <summary>
        /// 获取内存中缓存的节点值。线程安全。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="emptyValue"></param>
        /// <param name="dataGenerator">自定义生成逻辑</param>
        /// <param name="throwIfNotFound"></param>
        /// <returns></returns>
        public static T GetMemcachedValueFromAppSettings<T>(string key, T emptyValue, Func<string, T> dataGenerator, bool throwIfNotFound = false)
        {
            object objValue;
            if (UICommonConfig._MemcachedValueFromAppSettings.TryGetValue(key, out objValue) == false)
            {
                string strConfigValue = UICommonConfig.GetValueFromAppSettings<string>(key, null, throwIfNotFound);
                if (strConfigValue == null)
                {
                    return emptyValue;
                }
                try
                {
                    T tValue = dataGenerator(strConfigValue);
                    objValue = tValue;
                    UICommonConfig.MemecachedLocker.WaitOne();
                    if (UICommonConfig._MemcachedValueFromAppSettings.ContainsKey(key) == false)
                    {
                        UICommonConfig._MemcachedValueFromAppSettings.Add(key, tValue);
                    }
                }
                finally
                {
                    UICommonConfig.MemecachedLocker.Release();
                }
            }
            return (T)objValue;
        }

        public static T GetValueFromAppSettings<T>(string key, T emptyValue, bool throwWhenNotFound = false)
        {
            string strValue = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(strValue))
            {
                if (throwWhenNotFound)
                {
                    throw new ConfigurationException("AppSetting中找不到" + key);
                }
                else
                {
                    return emptyValue;
                }
            }
            return strValue.ToSimpleT<T>(emptyValue);
        }

        #region 铁血资源管理

        
        /// <summary>
        /// 返回string.Concat(resourceHost, resourcePath, "?ResourceVersion=", resourceVersion);
        /// </summary>
        /// <param name="resourceHost"></param>
        /// <param name="resourcePath"></param>
        /// <param name="resourceVersion"></param>
        /// <returns></returns>
        public static string GetVersionableResourceUrl(string resourceHost, string resourcePath, int resourceVersion)
        {
            if (resourcePath.IsNullOrEmpty())
            {
                return string.Empty;
            }
            return string.Concat(resourceHost, resourcePath, "?ResourceVersion=", resourceVersion).ToLower();
        }

        #endregion
    }
}

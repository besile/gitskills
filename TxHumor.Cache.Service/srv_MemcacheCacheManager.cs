using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Cache.Service
{
    public class srv_MemcacheCacheManager
    {
        /// <summary>
        /// 获取多个
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Get(params string[] keys)
        {
            return new Dictionary<string, object>(0);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireMin"></param>
        public static void Add(string key, object value, int expireMin)
        {
            return;
        }
    }
}

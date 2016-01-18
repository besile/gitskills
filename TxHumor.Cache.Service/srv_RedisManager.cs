using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TxHumor.Redis;

namespace TxHumor.Cache.Service
{
    public class srv_RedisManager
    {
        /// <summary>
        /// 获取多个
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Get(params string[] keys)
        {
            return RedisBase.Excute(redis => redis.GetAll<object>(keys));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireMin"></param>
        public static void Add(string key, object value, int expireMin)
        {
            RedisBase.Excute(redis => redis.Set(key, JsonConvert.SerializeObject(value), DateTime.Now.AddMinutes(expireMin)));
        }

        
    }
}

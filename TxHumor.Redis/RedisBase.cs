using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;

namespace TxHumor.Redis
{
    public class RedisBase
    {
        public static void Excute(Action<IRedisClient> action)
        {
            if (action == null)
            {
                throw new Exception("action is null");
            }
            using (IRedisClient redis = RedisClientPool.GetInstance().GetRedisClient())
            {
                action(redis);
            }
        }

        public static T Excute<T>(Func<IRedisClient, T> func)
        {
            if (func == null)
            {
                throw new Exception("func is null");
            }
            using (IRedisClient redis = RedisClientPool.GetInstance().GetRedisClient())
            {
                return func(redis);
            }
        }
    }
}

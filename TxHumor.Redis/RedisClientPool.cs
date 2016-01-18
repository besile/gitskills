using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;

namespace TxHumor.Redis
{
    public class RedisClientPool
    {
        private PooledRedisClientManager pooledRedisClientManager = null;
        private static readonly RedisClientPool rpool = new RedisClientPool(5, 5);
        public static RedisClientPool GetInstance()
        {
            return rpool;
        }
        public RedisClientPool(int writeCount, int readCount)
        {
            //原来的写法
            //string[] readWriteHosts = new string[] { string.Format("{0}:{1}", Config.Redis.Host, Config.Redis.Port) };
            //string[] readOnlyHosts = new string[] { string.Format("{0}:{1}", Config.Redis.Host, Config.Redis.Port) };

            //改为走配置文件
            string redisIp = "127.0.0.1:6379";//CommTool.GetValueFromAppSetting("redisFullIp", "192.168.0.6:6379");
            string[] readWriteHosts = new string[] { redisIp };
            string[] readOnlyHosts = new string[] { redisIp };
            //支持读写分离，均衡负载
            this.pooledRedisClientManager = new PooledRedisClientManager(readWriteHosts, readOnlyHosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = writeCount,//“写”链接池链接数
                MaxReadPoolSize = readCount,//“写”链接池链接数
                AutoStart = true,
            });
        }


        /// <summary>
        /// Protocol error from client: addr=192.168.9.133:2879 fd=5 idle=0 flags=N db=0 sub=0 psub=0 qbuf=56 obl=44 oll=0 events=rw cmd=info
        /// </summary>
        /// <returns></returns>
        public IRedisClient GetRedisClient()
        {
            //return new RedisClient(Config.Redis.Host, Config.Redis.Port);
            return this.pooledRedisClientManager.GetClient();
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Net;

namespace NetCoreRedis.Services
{
    public class RedisService
    {
        private readonly string _redisHost;
        private readonly int _redisPort;
        private ConnectionMultiplexer _redis;

        public RedisService(IConfiguration config)
        {
            _redisHost = config["Redis:Host"];
            _redisPort = Convert.ToInt32(config["Redis:Port"]);
        }
        public void Connect()
        {
            try
            {
                var configString = $"{_redisHost}:{_redisPort},connectRetry=5";
                // _redis = ConnectionMultiplexer.Connect(configString);

                var options = ConfigurationOptions.Parse(configString);
                // options.ClientName = GetAppName(); // only known at runtime
                options.AllowAdmin = true;
                _redis = ConnectionMultiplexer.Connect(options);                
            }
            catch (RedisConnectionException err)
            {
                throw err;
            }
        }


        public async Task<bool> Set(string key, string value)
        {
            var db = _redis.GetDatabase();
            return await db.StringSetAsync(key, value);
        }

        public async Task<string> Get(string key)
        {
            var db = _redis.GetDatabase();
            return await db.StringGetAsync(key);
        }


        public EndPoint[] GetEndPoints()
        {
           return _redis.GetEndPoints();
        }
        public DateTime GetLastSave()
        {
            IServer server = _redis.GetServer("localhost", 6379);
            return server.LastSave();
        }

        public ClientInfo[] ClientList()
        {
            IServer server = _redis.GetServer("localhost", 6379);
            return server.ClientList();
        }

        public RedisResult MemoryStats()
        {
            IServer server = _redis.GetServer("localhost", 6379);
            return server.MemoryStats();
        }

    }
}

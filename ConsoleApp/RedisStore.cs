using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    public class RedisStore {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisStore() {
            var configurationOptions = new ConfigurationOptions {
                EndPoints = { ConfigurationManager.AppSettings["redis.connection"] }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}

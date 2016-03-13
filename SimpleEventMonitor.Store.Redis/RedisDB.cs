using StackExchange.Redis;

namespace SimpleEventMonitor.Store.Redis
{
    internal static class RedisDB
    {
        private static int _database; 
        internal static void Initialize(string redisHost, int redisPort, int database, string redisPassword)
        {
            _database = database;
            if(_connection != null)
                return;

            lock (typeof (RedisDB))
            {
                if (_connection == null)
                {
                    //Singleton as described here: https://github.com/StackExchange/StackExchange.Redis/blob/master/Docs/Basics.md
                    _connection =
                        ConnectionMultiplexer.Connect(
                            $"{redisHost}:{redisPort},password={redisPassword},syncTimeout=1000,KeepAlive=10,ConnectTimeout=100,ConnectRetry=5,abortConnect=false");
                }
            }
        }

        private static ConnectionMultiplexer _connection;
        internal static IDatabase Database => _connection.GetDatabase(_database);
    }
}

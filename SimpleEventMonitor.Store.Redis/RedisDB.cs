using StackExchange.Redis;

namespace SimpleEventMonitor.Store.Redis
{
    internal static class RedisDB
    {
        private static int _database; 
        internal static void Initialize(string redisHost, int redisPort, int database, string redisPassword)
        {
            _database = database;
            if(Connection != null)
                return;

            lock (typeof (RedisDB))
            {
                if (Connection == null)
                {
                    //This is a Singleton as specified here: https://github.com/StackExchange/StackExchange.Redis/blob/master/Docs/Basics.md
                    Connection =
                        ConnectionMultiplexer.Connect(
                            $"{redisHost}:{redisPort},password={redisPassword},syncTimeout=1000,KeepAlive=10,ConnectTimeout=100,ConnectRetry=5,abortConnect=false");
                }
            }
        }

        internal static ConnectionMultiplexer Connection { get; private set; }
        internal static IDatabase Database => Connection.GetDatabase(_database);
    }
}

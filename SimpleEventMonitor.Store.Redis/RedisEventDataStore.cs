using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Store.Redis
{
    public class RedisEventDataStore : EventDataStoreBase
    {
        public RedisEventDataStore(string hubBaseUrl, string redisHost, int redisPort, int database = 0, string redisPassword = "") : base(hubBaseUrl)
        {
            RedisDB.Initialize(redisHost, redisPort, database, redisPassword);
        }

        public override IEnumerable<SimpleEvent> GetEvents(long startIdx = 0, long endIdx = long.MaxValue)
        {
            var redisValues = RedisDB.Database.ListRange(Key, startIdx, endIdx);
            return redisValues.Select(redisValue => JsonConvert.DeserializeObject<SimpleEvent>(redisValue));
        }

        public override long TotalCount => 0;

        private const string Key = "SimpleEventMonitor.EventList";

        protected override void Persist(SimpleEvent evt)
        {
            RedisDB.Database.ListLeftPush(Key, JsonConvert.SerializeObject(evt));
        }
    }
}

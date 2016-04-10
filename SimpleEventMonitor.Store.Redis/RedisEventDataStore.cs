using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Store.Redis
{
    public class RedisEventDataStore : EventDataStoreBase
    {
        private readonly string _keySuffix;
        private string Key => $"SimpleEventMonitor.EventList.{_keySuffix}";

        /// <summary>
        /// Initializes the RedisEventDataStore
        /// </summary>
        /// <param name="keySuffix">This is used to suffix the key under which the eventlist is stored. Use the same key for systems that use the same store. Different keys if you need to distinguish</param>
        /// <param name="redisHost"></param>
        /// <param name="redisPort"></param>
        /// <param name="database"></param>
        /// <param name="redisPassword"></param>
        public RedisEventDataStore(string keySuffix, string redisHost, int redisPort, int database = 0, string redisPassword = "") : base(SemConfiguration.HubBaseUrl)
        {
            _keySuffix = keySuffix;
            RedisDB.Initialize(redisHost, redisPort, database, redisPassword);
        }

        public override IEnumerable<SimpleEvent> GetEvents(int startIdx = 0, int endIdx = int.MaxValue)
        {
            var redisValues = RedisDB.Database.ListRange(Key, startIdx, endIdx);
            return redisValues.Select(redisValue => JsonConvert.DeserializeObject<SimpleEvent>(redisValue));
        }

        public override long TotalCount => RedisDB.Database.ListLength(Key);

        protected override void Persist(SimpleEvent evt)
        {
            RedisDB.Database.ListLeftPush(Key, JsonConvert.SerializeObject(evt));
        }
    }
}

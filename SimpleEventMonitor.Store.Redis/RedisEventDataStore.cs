using System;
using System.Collections.Generic;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Store.Redis
{
    public class RedisEventDataStore : EventDataStoreBase
    {
        public RedisEventDataStore(string hubBaseUrl, string redisHost, int redisPort, int database = 0, string redisPassword = "") : base(hubBaseUrl)
        {
            RedisDB.Initialize(redisHost, redisPort, database, redisPassword);
        }

        public override IEnumerable<SimpleEvent> GetEvents(int startIdx = 0, int endIdx = int.MaxValue)
        {
            yield return new SimpleEvent(new SomeEvent());
            yield return new SimpleEvent(new SomeEvent());
            yield return new SimpleEvent(new SomeEvent());
        }

        public override int TotalCount => 0;

        protected override void Persist(SimpleEvent evt)
        {
        }
    }

    public class SomeEvent
    {
        public SomeEvent()
        {
            Id = Guid.NewGuid();
            HappenedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public DateTime HappenedAt { get; set; }
    }
}

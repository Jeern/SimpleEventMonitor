using System;
using System.Collections.Generic;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Store.Redis
{
    public class RedisEventDataStore : EventDataStoreBase
    {
        private readonly string _redisHost;
        private readonly int _redisPort;
        private readonly string _redisPassword;

        public RedisEventDataStore(string hubBaseUrl, string redisHost, int redisPort, string redisPassword = "") : base(hubBaseUrl)
        {
            _redisHost = redisHost;
            _redisPort = redisPort;
            _redisPassword = redisPassword;
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

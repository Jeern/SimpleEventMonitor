﻿using System;
using System.Collections.Generic;
using SimpleEventMonitor.Common;

namespace SimpleEventMonitor.Store.Redis
{
    public class RedisEventDataStore : EventDataStoreBase
    {
        protected override void Persist(SimpleEvent evt)
        {
        }

        public override IEnumerable<SimpleEvent> GetEvents()
        {
            yield return new SimpleEvent(new SomeEvent());
            yield return new SimpleEvent(new SomeEvent());
            yield return new SimpleEvent(new SomeEvent());
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
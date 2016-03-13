using System;
using System.Collections.Generic;

namespace SimpleEventMonitor.Core
{
    public class PublishOnlyEventDataStore : EventDataStoreBase
    {
        public PublishOnlyEventDataStore(string hubBaseUrl) : base(hubBaseUrl)
        {
            
        }
        public override long TotalCount => 0;

        public override IEnumerable<SimpleEvent> GetEvents(long startIdx = 0, long endIdx = long.MaxValue)
        {
            yield break;
        }

        protected override void Persist(SimpleEvent evt)
        {
            throw new InvalidOperationException("Persist is not possible in the PublishOnlyEventDataStore");
        }
    }
}

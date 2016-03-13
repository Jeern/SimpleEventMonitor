using System;
using System.Collections.Generic;

namespace SimpleEventMonitor.Core
{
    public class PublishOnlyEventDataStore : EventDataStoreBase
    {
        public PublishOnlyEventDataStore(string hubBaseUrl) : base(hubBaseUrl)
        {
            
        }
        public override int TotalCount => 0;

        public override IEnumerable<SimpleEvent> GetEvents(int startIdx = 0, int endIdx = int.MaxValue)
        {
            yield break;
        }

        protected override void Persist(SimpleEvent evt)
        {
            throw new InvalidOperationException("Persist is not possible in the PublishOnlyEventDatStore");
        }
    }
}

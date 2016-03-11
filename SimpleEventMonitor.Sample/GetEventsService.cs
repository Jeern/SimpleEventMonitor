using System.Collections.Generic;
using ServiceStack.ServiceInterface;
using SimpleEventMonitor.Common;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.Sample
{
    public class GetEventsService : Service
    {
        public IEnumerable<SimpleEvent> Get(GetEventsRequest request)
        {
            var eventDataStore = new RedisEventDataStore();
            return eventDataStore.GetEvents();
        }
    }
}

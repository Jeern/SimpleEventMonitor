using System.Collections.Generic;
using System.Linq;
using ServiceStack.ServiceInterface;
using SimpleEventMonitor.Common;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.Sample
{
    public class GetEventsService : Service
    {
        public IEnumerable<SimpleEvent> Get(GetEventsRequest request)
        {
            return RedisEventDataStore.Current.GetEvents().OrderByDescending(evt => evt.UtcTime);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using ServiceStack.ServiceInterface;
using SimpleEventMonitor.Core;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.Sample
{
    public class GetEventsService : Service
    {
        public IEnumerable<SimpleEvent> Get(GetEventsRequest request)
        {
            //ListItems are shown in descending order, but this is assured by using prepend instead of append in Jquery
            //That is why this ordered ascending
            return RedisEventDataStore.Current.GetEvents().OrderBy(evt => evt.UtcTime);
        }
    }
}

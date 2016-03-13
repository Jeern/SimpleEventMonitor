using System.Collections.Generic;
using System.Linq;
using ServiceStack.ServiceInterface;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Web
{
    public class GetEventsService : Service
    {
        private readonly IEventDataStore _dataStore;

        public GetEventsService(IEventDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable<SimpleEvent> Get(GetEventsRequest request)
        {
            //ListItems are shown in descending order, but this is assured by using prepend instead of append in Jquery
            //That is why this ordered ascending
            return _dataStore.GetEvents().OrderBy(evt => evt.UtcTime);
        }
    }
}

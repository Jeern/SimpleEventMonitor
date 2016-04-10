using ServiceStack.ServiceInterface;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Web
{
    public class GetTotalCountService : Service
    {
        private readonly IEventDataStore _dataStore;

        public GetTotalCountService(IEventDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public long Get(GetTotalCountRequest request)
        {
            return _dataStore.TotalCount;
        }
    }
}

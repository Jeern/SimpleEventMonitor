using System.Collections.Generic;
using ServiceStack.ServiceHost;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Web
{
    [Route("/Events", "GET")]
    public class GetEventsRequest : IReturn<IEnumerable<SimpleEvent>>
    {
        public long StartIdx { get; set; }
        public long EndIdx { get; set; }
    }
}

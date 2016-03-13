﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Sample
{
    [Route("/Events", "GET")]
    public class GetEventsRequest : IReturn<IEnumerable<SimpleEvent>>
    {
    }
}

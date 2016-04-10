using ServiceStack.ServiceHost;

namespace SimpleEventMonitor.Web
{
    [Route("/TotalCount", "GET")]
    public class GetTotalCountRequest : IReturn<long>
    {
    }
}

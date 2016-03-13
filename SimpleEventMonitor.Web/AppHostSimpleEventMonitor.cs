using System.Reflection;
using Funq;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Web
{
    public class AppHostSimpleEventMonitor : AppHostBase
    {
        public AppHostSimpleEventMonitor(IEventDataStore dataStore)
            : base("SimpleEventMonitorServices", Assembly.GetExecutingAssembly())
        {
            Container.Register(dataStore);
        }

        public override void Configure(Container container)
        {
            JsConfig.IncludeNullValues = true;
            SetConfig(
                    new EndpointHostConfig
                    {
                        DebugMode = true,
                        DefaultContentType = ContentType.Json,
                        EnableFeatures = Feature.All
                    });
        }
    }
}
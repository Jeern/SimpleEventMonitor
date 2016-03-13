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
#if DEBUG
            bool debug = true;
            var enableFeatures = Feature.All;
#else
            bool debug = false;
            var enableFeatures = Feature.All.Remove(Feature.Metadata);
#endif

            JsConfig.IncludeNullValues = true;
            SetConfig(
                    new EndpointHostConfig
                    {
                        DebugMode = debug,
                        DefaultContentType = ContentType.Json,
                        EnableFeatures = enableFeatures
                    });
        }
    }
}
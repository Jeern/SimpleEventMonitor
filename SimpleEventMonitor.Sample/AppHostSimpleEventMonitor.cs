using System.Reflection;
using Funq;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace SimpleEventMonitor.Sample
{
    public class AppHostSimpleEventMonitor : AppHostBase
    {
        public AppHostSimpleEventMonitor()
            : base("SimpleEventMonitorServices", Assembly.GetExecutingAssembly())
        {
        }

        public override void Configure(Container container)
        {
            //JsConfig.AlwaysUseUtc = true;
            //JsConfig.DateHandler = JsonDateHandler.ISO8601;
            JsConfig.EmitCamelCaseNames = true;
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
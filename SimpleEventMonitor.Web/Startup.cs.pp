using Owin;
using SimpleEventMonitor.Core;
using SimpleEventMonitor.Web;
using SimpleEventMonitor.Store.Redis;

namespace $rootnamespace$
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.ConfigureMonitor(new PublishOnlyEventDataStore("http://localhost:2419", "localhost", 6379));
        }
    }
}

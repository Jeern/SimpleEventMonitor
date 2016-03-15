using Owin;
using SimpleEventMonitor.Web;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.ConfigureMonitor(new RedisEventDataStore("localhost", 6379));
        }
    }
}

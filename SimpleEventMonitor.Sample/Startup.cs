using System.Threading.Tasks;
using Owin;
using SimpleEventMonitor.Web;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.Sample
{
    public class Startup
    {
        private AppHostSimpleEventMonitor _appHost;
        public void Configuration(IAppBuilder app)
        {
            _appHost = new AppHostSimpleEventMonitor();
            _appHost.Init();
            app.ConfigureMonitor(() => RedisEventDataStore.Current);
        }
    }
}

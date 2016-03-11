using System.Threading.Tasks;
using Owin;
using SimpleEventMonitor.Client;
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
            TestSignalR();
        }

        private async Task TestSignalR()
        {
            await Task.Delay(1500);
            RedisEventDataStore.Current.Persist(new SomeEvent());
            await Task.Delay(1500);
            RedisEventDataStore.Current.Persist(new SomeEvent());
            await Task.Delay(1500);
            RedisEventDataStore.Current.Persist(new SomeEvent());
        }
    }
}

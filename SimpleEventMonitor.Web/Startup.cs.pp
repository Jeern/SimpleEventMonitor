using Owin;
using SimpleEventMonitor.Core;
using SimpleEventMonitor.Web;

namespace $rootnamespace$
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.ConfigureMonitor(new PublishOnlyEventDataStore());
        }
    }
}

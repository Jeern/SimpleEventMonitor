﻿using Owin;
using SimpleEventMonitor.Web;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.ConfigureMonitor(new RedisEventDataStore("Sample", "localhost", 6379));
        }
    }
}

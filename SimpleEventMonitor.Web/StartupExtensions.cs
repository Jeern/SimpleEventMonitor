﻿using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using SimpleEventMonitor.Core;

namespace SimpleEventMonitor.Web
{
    public static class StartupExtensions
    {
        private static AppHostSimpleEventMonitor _appHost;

        public static IAppBuilder ConfigureMonitor(this IAppBuilder app, IEventDataStore dataStore)
        {
            _appHost = new AppHostSimpleEventMonitor(dataStore);
            _appHost.Init();


            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration();
                map.RunSignalR(hubConfiguration);
            });
            return app;
        }

        public static IAppBuilder UseRedisBackplane(this IAppBuilder app, string redisHost, int redisPort, string redisPassword = "")
        {
            GlobalHost.DependencyResolver.UseRedis(redisHost, redisPort, redisPassword, "SimpleEventMonitor.SignalR.Backplane");
            return app;
        }
    }

}

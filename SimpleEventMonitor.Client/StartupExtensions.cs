﻿using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace SimpleEventMonitor.Client
{
    public static class StartupExtensions
    {
        public static IAppBuilder ConfigureMonitor(this IAppBuilder app)
        {
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

# SimpleEventMonitor

A simple event monitor for .NET that monitors events from any .NET system using SignalR

## Usage

1. Create your new monitor app. 
    1. Open Visual Studio and Create a New Empty ASP.NET Web Site
    1. Install-Package SimpleEventMonitor.Web in the project
    1. Open the Web.config and change the value of the appSetting SEM:HubBaseUrl to your new projects baseUrl e.g. http://localhost:52317 (remember to change it if deploying to a server)
1. To Publish events from your .NET systems
	1. Open the project from which you want to publish events
	1. Install-Package SimpleEventMonitor.Core in the project
	1. Open the Web.config or app.config which applies to the project and change the value of the appSetting SEM:HubBaseUrl to your Monitor projects baseUrl e.g. http://localhost:52317 (again remember to change it if deploying to a server)
	1. Create a PublishOnlyEventDataStore (can be a singleton) and call Publish on it where ever you need to publish events use arbitrary event objects as input
1. Start the monitor and the app(s) that need to be monitored. And watch the events flow in.	

``` csharp 
            var publisher = new PublishOnlyEventDataStore();
            publisher.Publish(new SomeEvent());
```

## Redis as EventStore

If you need the events to be persisted you should Install-Package SimpleEventMonitor.Store.Redis to both the Monitor and the app(s) that needs to be monitored.

Then use the RedisEventDataStore in place of the PublishOnlyEventDataStore like so:

Startup.cs

``` csharp 
        public void Configuration(IAppBuilder app)
        {
            app.ConfigureMonitor(new RedisEventDataStore("YourAppName", "localhost", 6379));
        }
```

And instead of Publish you do this:

``` csharp 
            var publisher = new RedisEventDataStore("YourAppName", "localhost", 6379);
            publisher.PersistAndPublish(new SomeEvent());
```

Again publisher can be a singleton.

You might have noticed the "YourAppName". It is a suffix for the Key used in redis. If you want different events loaded for different apps you need this to be different. You can also store all events for all apps in the same RedisStore by using the same name. 

You can also choose to differentiate the apps by using different Redis databases. The constructor has an overload that takes the redis database as input.






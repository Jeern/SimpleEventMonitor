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
1. Start the monitor and the app(s) that need to be monitored. And watch the events flow in. You can watch them using the standard index.html page or in table format using table.html	

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

## Redis as Backplane

As mentioned the SimpleEventMonitor uses SignalR to send events from the publishers to the monitor. If you have several servers you need a Backplane. For this there is an Extension method which you call in the Startup.cs code:

``` csharp 
        public void Configuration(IAppBuilder app)
        {
            app.ConfigureMonitor(new RedisEventDataStore("Web11", "localhost", 6379))
                .UseRedisBackplane("localhost", 6379);
        }
```

## Custom EventStore

If you need your events persisted, but do not want to use Redis for this. You can easily implement your own Storage.

Just Install-Package SimpleEventMonitor.Core and inherit the abstract class EventDataStoreBase. Look in the code for RedisEventDataStore for inspiration.


## Missing features / known issues

This is only a beta for now - there is  currently some stuff that needs to be looked into:

1. Needs to Check if SignalR Connection needs to be stopped
1. Add functionality to Clear events from the store
1. Check if the insertion into Redis is optimal in relation to the Linq ordering of events
1. Paging is needed - e.g. 20 events pr. page









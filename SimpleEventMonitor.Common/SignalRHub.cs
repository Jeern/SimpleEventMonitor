using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SimpleEventMonitor.Core
{
    [HubName("EventHub")]
    public class SignalRHub : Hub
    {

        public void Subscribe(string groupId)
        {
            //Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(1500);
            //    Clients.All.publish(new SimpleEvent(new SomeEvent()));
            //    Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
            //    Thread.Sleep(2500);
            //    Clients.All.publish(new SimpleEvent(new SomeEvent()));
            //    Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
            //    Thread.Sleep(3500);
            //    Clients.All.publish(new SimpleEvent(new SomeEvent()));
            //    Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
            //    Thread.Sleep(4500);
            //    Clients.All.publish(new SimpleEvent(new SomeEvent()));
            //    Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
            //    Thread.Sleep(5500);
            //    Clients.All.publish(new SimpleEvent(new SomeEvent()));
            //    Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
            //});

            Groups.Add(Context.ConnectionId, groupId);
        }


        public void Publish(SimpleEvent evt)
        {
            Clients.Group("simpleEventMonitorEvents").publish(evt);
        }
    }
}
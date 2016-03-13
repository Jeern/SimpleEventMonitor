using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SimpleEventMonitor.Core
{
    [HubName("EventHub")]
    public class SignalRHub : Hub
    {

        public void Subscribe(string groupId)
        {
            Groups.Add(Context.ConnectionId, groupId);
        }

        public void Publish(SimpleEvent evt)
        {
            Clients.Group("simpleEventMonitorEvents").publish(evt);
        }
    }
}
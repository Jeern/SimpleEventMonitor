using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SimpleEventMonitor.Common;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.Client
{
    [HubName("EventHub")]
    public class SignalRHub : Hub
    {
        private readonly IEventDataStore _dataStore;
        private string _groupId;

        public SignalRHub()
        {
            _dataStore = new RedisEventDataStore();
//            _dataStore.SimpleEventHappened += (sender, args) => Clients.All.publish(args.Evt);
            _dataStore.SimpleEventHappened += (sender, args) => Clients.Group(_groupId).publish(args.Evt);
        }

        public void Subscribe(string groupId)
        {
            _groupId = groupId;
            Groups.Add(Context.ConnectionId, groupId);
        }
    }
}
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.AspNet.SignalR;
//using Microsoft.AspNet.SignalR.Hubs;
//using SimpleEventMonitor.Common;
//using SimpleEventMonitor.Store.Redis;

//namespace SimpleEventMonitor.Client
//{
//    [HubName("EventHub")]
//    public class SignalRHub : Hub
//    {
//        private string _groupId;

//        //public SignalRHub()
//        //{
//        //    //            _dataStore.SimpleEventHappened += (sender, args) => Clients.All.publish(args.Evt);
//        //    RedisEventDataStore.Current.SimpleEventHappened += (sender, args) => Clients.Group(_groupId).publish(args.Evt);
//        //}

//        public void Subscribe(string groupId)
//        {
//            Task.Factory.StartNew(() =>
//            {
//                Thread.Sleep(1500);
//                Clients.All.publish(new SimpleEvent(new SomeEvent()));
//                Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
//                Thread.Sleep(2500);
//                Clients.All.publish(new SimpleEvent(new SomeEvent()));
//                Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
//                Thread.Sleep(3500);
//                Clients.All.publish(new SimpleEvent(new SomeEvent()));
//                Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
//                Thread.Sleep(4500);
//                Clients.All.publish(new SimpleEvent(new SomeEvent()));
//                Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
//                Thread.Sleep(5500);
//                Clients.All.publish(new SimpleEvent(new SomeEvent()));
//                Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
//            });

//            RedisEventDataStore.Current.SimpleEventHappened += (sender, args) =>
//            {
//                //            Clients.Group(groupId).publish(args.Evt);

//                Task.Delay(1500);
//                Clients.All.publish(new SimpleEvent(new SomeEvent()));
//                Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
//                Task.Delay(1500);
//                Clients.All.publish(new SimpleEvent(new SomeEvent()));
//                Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
//                Task.Delay(1500);
//                Clients.All.publish(new SimpleEvent(new SomeEvent()));
//                Clients.Group(groupId).publish(new SimpleEvent(new SomeEvent()));
//            };
//            _groupId = groupId;
//            Groups.Add(Context.ConnectionId, groupId);

//        }
//    }
//}
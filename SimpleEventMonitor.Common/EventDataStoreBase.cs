using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;

namespace SimpleEventMonitor.Common
{
    public abstract class EventDataStoreBase : IEventDataStore
    {
        public void Persist(object evt)
        {
            var simpleEvent = new SimpleEvent(evt);
            Persist(simpleEvent);
            PublishViaSignalR(simpleEvent);
        }

        protected abstract void Persist(SimpleEvent evt);

        public abstract IEnumerable<SimpleEvent> GetEvents();

        private void OnSimpleEventHappened(SimpleEvent evt)
        {
            _simpleEventHappened(this, new SimpleEventEventArgs(evt));
        }

        private void PublishViaSignalR(SimpleEvent evt)
        {
            var connection = new HubConnection("http://localhost:2419");
            var eventHub = connection.CreateHubProxy("EventHub");
            connection.Start().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            eventHub.Invoke<SimpleEvent>("Publish", evt).ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling publish: {0}",
                                      task.Exception.GetBaseException());
                }
            });
            connection.Stop();
        }

        private event EventHandler<SimpleEventEventArgs> _simpleEventHappened = delegate { };
        public event EventHandler<SimpleEventEventArgs> SimpleEventHappened
        {
            add { _simpleEventHappened += value;  }
            remove { _simpleEventHappened -= value; }
        }
    }
}
